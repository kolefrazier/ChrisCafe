using ChrisCafe.Models;
using ChrisCafe.Models.ViewModels;
using Newtonsoft.Json;

namespace ChrisCafe.Data.Factories
{
    public class MenuFactory
    {
        private List<Category> Categories { get; set; } = new List<Category>();
        private List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
        private List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        public FullMenu Setup()
        {
            ImportMenuData();
            return CreateFullMenu();
        }

        private void ImportMenuData()
        {
            // Categories, Subcategories, Beverages
            string MenuCategoriesRaw = File.ReadAllText(Path.Combine("RawData", "Menu", "Categories.json")),
                MenuSubcategoriesRaw = File.ReadAllText(Path.Combine("RawData", "Menu", "Subcategories.json")),
                BeveragesRaw = File.ReadAllText(Path.Combine("RawData", "Menu", "Beverages.json"));

            Categories = JsonConvert.DeserializeObject<List<Category>>(MenuCategoriesRaw);
            Subcategories = JsonConvert.DeserializeObject<List<Subcategory>>(MenuSubcategoriesRaw);

            // Menu Items
            MenuItems.AddRange(JsonConvert.DeserializeObject<List<MenuItem>>(BeveragesRaw));

            // File directory paths
            string[] MenuItemFiles = new string[]
            {
                Path.Combine("RawData", "Menu", "Breakfast"),
                Path.Combine("RawData", "Menu", "Lunch"),
            };

            // Read in all files from the directories
            foreach (string FilePath in MenuItemFiles)
            {
                var Files = Directory.GetFiles(FilePath);
                foreach (string ItemsFile in Files)
                {
                    string contents = File.ReadAllText(ItemsFile);
                    MenuItems.AddRange(JsonConvert.DeserializeObject<List<MenuItem>>(contents));
                }
            }
        }

        private FullMenu CreateFullMenu()
        {
            FullMenu FullMenu = new();

            // Double-grouping (new(){i.a, i.b}) would be great, but the function call became ugly and not really codable...
            // "IGrouping<'a, MenuItem>" -- That "single-quote-a" type is correct.
            var GroupedItems = MenuItems.OrderBy(i => i.DisplayOrder).GroupBy(i => i.CategoryId);

            FullMenu.BreakfastMenu = CategorizeItems(FullMenu.BreakfastMenu, GroupCategoryItems(GroupedItems, "Breakfast"));
            FullMenu.LunchMenu = CategorizeItems(FullMenu.LunchMenu, GroupCategoryItems(GroupedItems, "Lunch"));
            FullMenu.BeveragesMenu = CategorizeItems(FullMenu.BeveragesMenu, GroupCategoryItems(GroupedItems, "Beverages"));

            //WriteAllItemsToFilesDbg(FullMenu);
            return FullMenu;
        }

        private IEnumerable<IGrouping<int, MenuItem>> GroupCategoryItems(IEnumerable<IGrouping<int, MenuItem>> grouping, string categoryName)
        {
            int Id = Categories.First(c => c.Name == categoryName).CategoryId;
            return grouping.First(g => g.Key == Id).GroupBy(i => i.SubcategoryId);
        }

        private MenuCategoryContainer CategorizeItems(MenuCategoryContainer category, IEnumerable<IGrouping<int, MenuItem>> grouping)
        {
            foreach (IGrouping<int, MenuItem> group in grouping)
            {
                foreach (MenuItem item in group)
                {
                    if (category.Items.FirstOrDefault(i => i.SubcategoryId == item.SubcategoryId) == null)
                        AddSubcategory(category, item.SubcategoryId);

                    category.Items.First(x => x.SubcategoryId == item.SubcategoryId).Items.Add(item);
                }
            }

            category.Items = SortSubcategories(category);
            return category;
        }

        private List<SubcategoryItem> SortSubcategories(MenuCategoryContainer category)
        {
            return category.Items.OrderBy(m => Subcategories.First(s => s.SubcategoryId == m.SubcategoryId).SortPosition).ToList();
        }

        private void AddSubcategory(MenuCategoryContainer category, int subcategoryId)
        {
            Subcategory subcategory = Subcategories.FirstOrDefault(s => s.SubcategoryId == subcategoryId);
            category.Items.Add(new SubcategoryItem(subcategoryId, subcategory));
        }

        //private void WriteAllItemsToFilesDbg(FullMenu fullMenu)
        //{
        //    List<MenuCategoryContainer> TopCategories = new()
        //    {
        //        fullMenu.BreakfastMenu,
        //        fullMenu.LunchMenu,
        //        fullMenu.BeveragesMenu
        //    };

        //    foreach (MenuCategoryContainer category in TopCategories)
        //    {
        //        List<string> TopPath = new() { "RawData", "new_feb2022", category.Name };
        //        Directory.CreateDirectory(Path.Combine(TopPath.ToArray()));

        //        foreach (SubcategoryItem SubCat in category.Items)
        //        {
        //            List<string> SubPath = new List<string>(TopPath);
        //            SubPath.Add($"{SubCat.Name.Replace("&", "and")}.json");
        //            string NewPath = Path.Combine(SubPath.ToArray());

        //            string bfJson = JsonConvert.SerializeObject(SubCat.Items, Formatting.Indented);
        //            File.WriteAllText(NewPath, bfJson);
        //        }
        //    }
        //}
    }
}
