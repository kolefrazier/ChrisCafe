using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Data
{
    public class MenuCache
    {
        public MenuCache()
        {
            IsFullMenuCacheSet = false;

            Categories = new List<Category>();
            Subcategories = new List<Subcategory>();
            MenuItems = new List<MenuItem>();
        }

        public bool IsFullMenuCacheSet { get; private set; }

        private FullMenu _CachedFullMenu { get; set; }
        public FullMenu CachedFullMenu {
            get
            {
                if (!IsFullMenuCacheSet) //Should be redundant at this point, but check anyways.
                    CreateFullMenuCacheContent();
                return _CachedFullMenu;
            }

            private set
            {
                _CachedFullMenu = value;
            } 
        }

        public List<Category> Categories { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public void Setup()
        {
            PopulateFromRawJson();
            CreateFullMenuCacheContent();
        }

        private void PopulateFromRawJson()
        {
            string MenuItemsFile = Path.Combine("RawData", "Menu_MenuItems.json"),
                MenuCategoriesFile = Path.Combine("RawData", "Menu_Categories.json"),
                MenuSubcategoriesFile = Path.Combine("RawData", "Menu_Subcategories.json");


            string MenuItemsRaw = File.ReadAllText(MenuItemsFile),
                MenuCategoriesRaw = File.ReadAllText(MenuCategoriesFile),
                MenuSubcategoriesRaw = File.ReadAllText(MenuSubcategoriesFile);

            Categories = JsonConvert.DeserializeObject<List<Category>>(MenuCategoriesRaw);
            Subcategories = JsonConvert.DeserializeObject<List<Subcategory>>(MenuSubcategoriesRaw);
            MenuItems = JsonConvert.DeserializeObject<List<MenuItem>>(MenuItemsRaw);
        }

        public void CacheFullMenu(FullMenu fullMenu)
        {
            CachedFullMenu = fullMenu;
            IsFullMenuCacheSet = true;
        }

        #region Content Creation Methods
        private void CreateFullMenuCacheContent()
        {
            FullMenu FullMenu = new FullMenu()
            {
                BreakfastMenu = new List<SubcategoryItem>(),
                LunchMenu = new List<SubcategoryItem>()
            };

            //Get all breakfast and lunch items.
            //  Query the collection ONCE then adjust the now-in-memory collection into an ordered list.
            IQueryable<MenuItem> AllBreakfastItemsRaw = MenuItems.AsQueryable().Where(m => m.CategoryId == 1);
            List<MenuItem> AllBreakfastItems = AllBreakfastItemsRaw.OrderBy(x => x.DisplayOrder).ToList();

            IQueryable<MenuItem> AllLunchItemsRaw = MenuItems.AsQueryable().Where(m => m.CategoryId == 2);
            List<MenuItem> AllLunchItems = AllLunchItemsRaw.OrderBy(x => x.DisplayOrder).ToList();

            //Combine into the lists
            //  Breakfast
            foreach (MenuItem item in AllBreakfastItems)
            {
                if (FullMenu.BreakfastMenu.FirstOrDefault(x => x.SubcategoryId == item.SubcategoryId) == null)
                {
                    var MatchedSubCategory = Subcategories.First(x => x.SubcategoryId == item.SubcategoryId);
                    FullMenu.BreakfastMenu.Add(new SubcategoryItem()
                    {
                        SubcategoryId = item.SubcategoryId,
                        Name = MatchedSubCategory.Name,
                        Description = MatchedSubCategory.Description,
                        Items = new List<MenuItem>()
                    });
                }

                FullMenu.BreakfastMenu.First(x => x.SubcategoryId == item.SubcategoryId).Items.Add(item);
            }

            //  Lunch
            foreach (MenuItem item in AllLunchItems)
            {
                var MatchedSubCategory = Subcategories.First(x => x.SubcategoryId == item.SubcategoryId);
                if (FullMenu.LunchMenu.FirstOrDefault(x => x.SubcategoryId == item.SubcategoryId) == null)
                {
                    FullMenu.LunchMenu.Add(new SubcategoryItem()
                    {
                        SubcategoryId = item.SubcategoryId,
                        Name = Subcategories.First(x => x.SubcategoryId == item.SubcategoryId).Name,
                        Description = MatchedSubCategory.Description,
                        Items = new List<MenuItem>()
                    });
                }

                FullMenu.LunchMenu.First(x => x.SubcategoryId == item.SubcategoryId).Items.Add(item);
            }

            //Sort based on Subcategory.SortPosition (ASC)
            //FullMenu.BreakfastMenu = FullMenu.BreakfastMenu.OrderBy(m => _context.Subcategories.First(s => s.SubcategoryId == m.SubcategoryId).SortPosition).ToList();
            //FullMenu.LunchMenu = FullMenu.LunchMenu.OrderBy(m => _context.Subcategories.First(s => s.SubcategoryId == m.SubcategoryId).SortPosition).ToList();
            FullMenu.BreakfastMenu = FullMenu.BreakfastMenu.OrderBy(m => Subcategories.First(s => s.SubcategoryId == m.SubcategoryId).SortPosition).ToList();
            FullMenu.LunchMenu = FullMenu.LunchMenu.OrderBy(m => Subcategories.First(s => s.SubcategoryId == m.SubcategoryId).SortPosition).ToList();

            CacheFullMenu(FullMenu);
        }
        #endregion Content Creation Methods
    }
}
