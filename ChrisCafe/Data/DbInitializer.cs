using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChrisCafe.Models;

namespace ChrisCafe.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //Check for existing content before seeding
            if (context.MenuItems.Any())
            {
                return;
            }

            //Categories -- If updated in any way, update the lookups before Menu Items, too.
            var Categories = new Category[]
            {
                new Category { Name = "Breakfast" },
                new Category { Name = "Lunch" },
                new Category { Name = "Dinner" },
            };

            foreach (Category c in Categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            //Subcategories -- If updated in any way, update the lookups before Menu Items, too.
            var Subcategories = new Subcategory[]
            {
                //Breakfast
                new Subcategory { Name = "Breakfast Combinations", Description = "Substitute toast or English muffin with a scone for $1.00.", SortPosition = 1 },
                new Subcategory { Name = "Omelets", Description = "3 eggs omelets served with hash browns and toast or English muffin. Your choice of cheese: Pepper Jack, Swiss, Cheddar, American.", SortPosition = 2 },
                new Subcategory { Name = "Pancakes & French Toast", Description = "Served with real butter and warm maple syrup.", SortPosition = 3 },
                new Subcategory { Name = "Breakfast Sandwiches", SortPosition = 4},
                new Subcategory { Name = "Meat Lovers", SortPosition = 5},
                new Subcategory { Name = "Breakfast Extras", SortPosition = 6 },
                new Subcategory { Name = "Breakfast Kids Menu", SortPosition = 7 },
                new Subcategory { Name = "Breakfast Beverages", SortPosition = 8 },

                //Lunch
                new Subcategory { Name = "Burgers and Chicken", Description = "Served with lettuce, tomato, onion, pickles and fries. Substitute fries with onion rings $1.00.", SortPosition = 1 },
                new Subcategory { Name = "Sandwiches", Description = "Served with fries. Substitute fries with onion rings $1.00.", SortPosition = 2},
                new Subcategory { Name = "Salads", SortPosition = 3 },
                new Subcategory { Name = "Sides", SortPosition = 4 },
                new Subcategory { Name = "Dessert", SortPosition = 5 },
                new Subcategory { Name = "Lunch Kids Menu", SortPosition = 6 },
                new Subcategory { Name = "Lunch Beverages", SortPosition = 7 },

                //Dinner
                new Subcategory { Name = "Dinner Salads", Description = "Served with a house roll. Dressings: Ranch, Blue Cheese, Thousand Island, Caesar or Oriental Sesame Asian.", SortPosition = 1 },
                new Subcategory { Name = "Dinners", Description = "Served with a house roll.", SortPosition = 2 },
                new Subcategory { Name = "Dinner Sandwiches", Description = "Served with fries.", SortPosition = 3 },
                new Subcategory { Name = "Dinner Kids' Menu", Description = "", SortPosition = 4 },
            };

            foreach (Subcategory s in Subcategories)
            {
                context.Subcategories.Add(s);
            }
            context.SaveChanges();

            //Retrieve Category and SubCategory IDs to lower the number of lookups needed.
            //Category IDs
            int CategoryBreakfastId = context.Categories.First(c => c.Name == "Breakfast").CategoryId,
                CategoryLunchId = context.Categories.First(c => c.Name == "Lunch").CategoryId,
                CategoryDinnerId = context.Categories.First(c => c.Name == "Dinner").CategoryId;

            //Subcategory (sc) IDs
            //Breakfast
            int scBreakfastCombinations = context.Subcategories.First(s => s.Name == "Breakfast Combinations").SubcategoryId,
                scOmelets = context.Subcategories.First(s => s.Name == "Omelets").SubcategoryId,
                scPancakesFrenchToast = context.Subcategories.First(s => s.Name == "Pancakes & French Toast").SubcategoryId,
                scBreakfastSandwhiches = context.Subcategories.First(s => s.Name == "Breakfast Sandwiches").SubcategoryId,
                scBreakfastExtras = context.Subcategories.First(s => s.Name == "Breakfast Extras").SubcategoryId,
                scBreakfastBeverages = context.Subcategories.First(s => s.Name == "Breakfast Beverages").SubcategoryId,
                scBreakfastKidsMenu = context.Subcategories.First(s => s.Name == "Breakfast Kids Menu").SubcategoryId,
                scBreakfastMeatLovers = context.Subcategories.First(s => s.Name == "Meat Lovers").SubcategoryId;

            //Lunch
            int scBurgersChicken = context.Subcategories.First(s => s.Name == "Burgers and Chicken").SubcategoryId,
                scSandwiches = context.Subcategories.First(s => s.Name == "Sandwiches").SubcategoryId,
                scSalads = context.Subcategories.First(s => s.Name == "Salads").SubcategoryId,
                scSides = context.Subcategories.First(s => s.Name == "Sides").SubcategoryId,
                scDessert = context.Subcategories.First(s => s.Name == "Dessert").SubcategoryId,
                scLunchBeverages = context.Subcategories.First(s => s.Name == "Lunch Beverages").SubcategoryId,
                scLunchKidsMenu = context.Subcategories.First(s => s.Name == "Lunch Kids Menu").SubcategoryId;

            //Dinner
            int scDinnerEntres = context.Subcategories.First(s => s.Name == "Dinners").SubcategoryId,
                scDinnerSalads = context.Subcategories.First(s => s.Name == "Dinner Salads").SubcategoryId,
                scDinnerSandwiches = context.Subcategories.First(s => s.Name == "Dinner Sandwiches").SubcategoryId,
                scDinnerKidsMenu = context.Subcategories.First(s => s.Name == "Dinner Kids' Menu").SubcategoryId;

            //Menu Items
            var MenuItems = new MenuItem[]
            {
                /* ### --- Breakfast --- ### */
                #region Breakfast

                /* ---- Breakfast Combinations ----- */
                new MenuItem {
                    Name = "#1",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Ham, bacon, or sausage with 2 eggs, hash browns. Toast or English muffin.",
                    Price = 7.00,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "#2",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Two slices French toast with 2 eggs and your choice of ham, bacon or sausage.",
                    Price = 7.00,
                    DisplayOrder = 2
                },
                new MenuItem {
                    Name = "#3",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Two pancakes with 2 eggs and your choice of ham, bacon or sausage.",
                    Price = 7.00,
                    DisplayOrder = 3
                },
                new MenuItem {
                    Name = "#4",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Two biscuits split and covered with country gravy, 2 eggs and your choice of ham, bacon or sausage.",
                    Price = 7.00,
                    DisplayOrder = 4
                },
                new MenuItem {
                    Name = "#5",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Eggs Benedict, split English muffin, 2 poached eggs, ham, covered in Hollandaise sauce.",
                    Price = 7.00,
                    DisplayOrder = 5
                },
                new MenuItem {
                    Name = "#6",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastCombinations,
                    Description = "Meatless. 2 eggs, hash browns. Toast or English muffin.",
                    Price = 5.50,
                    DisplayOrder = 6
                },

                /* ----- Omelets ----- */
                new MenuItem {
                    Name = "#7 Cheese Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Price = 6.50,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "#8 Ham and Cheese Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Price = 8.00,
                    DisplayOrder = 2
                },
                new MenuItem {
                    Name = "#9 Denver Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Description = "Ham, green peppers, onions, and cheese.",
                    Price = 8.00,
                    DisplayOrder = 3
                },
                new MenuItem {
                    Name = "#10 California Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Description = "Swiss cheese, tomato, onion and avocado.",
                    Price = 7.00,
                    DisplayOrder = 4
                },
                new MenuItem {
                    Name = "#11 Meat Lovers Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Description = "Ham, bacon, sausage and cheese.",
                    Price = 8.25,
                    DisplayOrder = 5
                },
                new MenuItem {
                    Name = "#12 Veggie Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Description = "Cheese, mushrooms, spinach, tomatoes, peppers and onions.",
                    Price = 7.50,
                    DisplayOrder = 6
                },
                new MenuItem {
                    Name = "#13 Build your own Omelet",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scOmelets,
                    Description = "Start with a cheese omelet and choose from the following items: Mushrooms, onions, green peppers, olives, tomatoes, spinach, extra cheese ($0.50 per item). Bacon, sausage, ham ($1.00 per item).",
                    Price = 6.50,
                    DisplayOrder = 7
                },

                /* ----- Pancakes & French Toast ----- */
                new MenuItem {
                    Name = "Stack (3)",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scPancakesFrenchToast,
                    Description = "Traditional cakes or our signature banana cakes.",
                    Price = 5.50,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "Short Stack (2)",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scPancakesFrenchToast,
                    Description = "Traditional cakes or our signature banana cakes.",
                    Price = 4.00,
                    DisplayOrder = 2
                },
                new MenuItem {
                    Name = "Shorty (1)",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scPancakesFrenchToast,
                    Description = "Traditional cakes or our signature banana cakes.",
                    Price = 3.00,
                    DisplayOrder = 3
                },
                new MenuItem {
                    Name = "Thick-Cut French Toast (3)",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scPancakesFrenchToast,
                    Description = "Sprinkled with cinnamon.",
                    Price = 5.50,
                    DisplayOrder = 4
                },

                /* ----- Breakfast Sandwiches  ----- */
                new MenuItem {
                    Name = "English Muffin Sandwich",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastSandwhiches,
                    Description = "With egg, cheddar cheese, and ham, bacon, veggie sausage or sausage.",
                    Price = 5.50,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "Breakfast Burrito",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastSandwhiches,
                    Description = "2 eggs, hash browns, cheese, onions and green chilies rolled in a flour tortilla with salsa on the side. Add ham, bacon or sausage $1.00.",
                    Price = 6.00,
                    DisplayOrder = 2
                },

                /* ----- Meat Lovers  ----- */
                new MenuItem
                {
                    Name = "Chicken Fried Steak with 2 Eggs",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastMeatLovers,
                    Description = "Hashbrowns, toast and country gravy.",
                    Price = 9.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Steak with 2 Eggs",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastMeatLovers,
                    Description = "(6 oz Choice Sirloin) Hashbrowns and toast.",
                    Price = 12.00,
                    DisplayOrder = 2
                },

                /* ----- Breakfast Extras  ----- */
                new MenuItem {
                    Name = "Veggie Scramble",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "Scrambled eggs with mushrooms, spinach, green peppers, onions, tomatoes topped with cheese. Served with salsa and toast.",
                    Price = 7.00,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "Oatmeal",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "Steel cut oats, served with brown sugar, raisins, and milk.",
                    Price = 4.50,
                    DisplayOrder = 2
                },
                new MenuItem {
                    Name = "Biscuits and Gravy",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "Two biscuits split and covered with country gravy.",
                    Price = 4.50,
                    DisplayOrder = 3
                },
                new MenuItem {
                    Name = "Sweet Roll",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "With cream cheese frosting.",
                    Price = 3.50,
                    DisplayOrder = 4
                },
                new MenuItem {
                    Name = "Scone with Honey Butter",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Price = 3.00,
                    DisplayOrder = 5
                },
                new MenuItem {
                    Name = "***Extra Honey Butter",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Price = 0.50,
                    DisplayOrder = 6
                },
                new MenuItem {
                    Name = "Toast or English Muffin",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "2 slices",
                    Price = 1.50,
                    DisplayOrder = 7
                },
                new MenuItem {
                    Name = "Bacon",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "3 strips",
                    Price = 4.00,
                    DisplayOrder = 8
                },
                new MenuItem {
                    Name = "Sausage",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "3 patties or 3 links",
                    Price = 3.50,
                    DisplayOrder = 9
                },
                new MenuItem {
                    Name = "Ham",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "",
                    Price = 3.50,
                    DisplayOrder = 10
                },
                new MenuItem {
                    Name = "1 Egg",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "",
                    Price = 1.25,
                    DisplayOrder = 11
                },
                new MenuItem {
                    Name = "Hash browns",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastExtras,
                    Description = "",
                    Price = 2.50,
                    DisplayOrder = 12
                },

                /* ----- Breakfast Kids Menu ----- */
                new MenuItem {
                    Name = "1 Small Pancake",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastKidsMenu,
                    Description = "Traditional cake or our signature banana cake. $3.50 with 1 bacon strip or 1 sausage link.",
                    Price = 2.50,
                    DisplayOrder = 1
                },

                new MenuItem {
                    Name = "1 Thick-Cut French Toast",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastKidsMenu,
                    Description = "$3.50 with 1 bacon strip or 1 sausage link.",
                    Price = 2.50,
                    DisplayOrder = 2
                },

                /* ----- Breakfast Beverages  ----- */
                new MenuItem
                {
                    Name = "Coffee, Hot Chocolate, Iced Tea",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastBeverages,
                    Description = "",
                    Price = 2.00,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Sodas",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastBeverages,
                    Description = "Pepsi, Diet Pepsi, Dr. Pepper, Mountain Dew, Root Beer, Diet Coke and Pink Lemonade.",
                    Price = 2.00,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Juice",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastBeverages,
                    Description = "Orange, Apple, Cranberry, Grapefruit or Tomato.",
                    Price = 2.25,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Milk",
                    CategoryId = CategoryBreakfastId,
                    SubcategoryId = scBreakfastBeverages,
                    Description = "Whole or Chocolate.",
                    Price = 2.00,
                    DisplayOrder = 4
                },
                #endregion

                /* ### --- Lunch --- ### */
                #region Lunch

                /* ----- Burgers  ----- */
                new MenuItem
                {
                    Name = "Hamburger",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "1/3 pound patty. $8.00 with cheddar, swiss, pepper jack or provolone cheese.",
                    Price = 7.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Double Hamburger",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "$10.50 with cheddar, swiss, pepper jack or provolone cheese.",
                    Price = 10.00,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Bacon Burger",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "$9.50 with cheddar, swiss, pepper jack or provolone cheese.",
                    Price = 9.00,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Mushroom and Swiss Burger",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "Heaped with sautéed onions and mushrooms.",
                    Price = 8.00,
                    DisplayOrder = 4
                },
                new MenuItem
                {
                    Name = "Hot Burger",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "One patty with sautéed onions on a toasted onion roll, generously covered with brown gravy. $8.00 with gravy on fries.",
                    Price = 7.50,
                    DisplayOrder = 5
                },
                new MenuItem
                {
                    Name = "Patty Melt",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "1/3 lb. patty smothered with caramelized onions with Swiss cheese on toasted rye bread.",
                    Price = 8.50,
                    DisplayOrder = 6
                },
                new MenuItem
                {
                    Name = "Chicken Sandwich",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "Grilled chicken with ranch dressing. $8.00 with cheddar, Swiss cheese, pepper jack or provolone.",
                    Price = 7.50,
                    DisplayOrder = 7
                },
                new MenuItem
                {
                    Name = "Chicken Cordon Bleu",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "Grilled chicken with ham, Swiss cheese and Hollandaise sauce.",
                    Price = 8.00,
                    DisplayOrder = 8
                },
                new MenuItem
                {
                    Name = "Grilled Chicken Club",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scBurgersChicken,
                    Description = "Grilled chicken, bacon and provolone cheese on a toasted ciabatta bun.",
                    Price = 8.50,
                    DisplayOrder = 9
                },

                /* ----- Sandwiches  ----- */
                new MenuItem
                {
                    Name = "Turkey, Bacon, and Avocado",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Sliced, oven roasted turkey, bacon, avocado, lettuce, tomato.",
                    Price = 7.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "French Dip",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Tender roast beef thinly sliced, stacked on a hoagie roll. Served with Au Jus. $10.50 Make it Deluxe, add grilled onions, mushrooms and Swiss cheese.",
                    Price = 9.50,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Philly Cheesesteak",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Sliced ribeye, grilled onions, peppers and Cheez Whiz. Served on a hoagie roll.",
                    Price = 9.00,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Reuben",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Corned beef, Swiss cheese, sauerkraut, Thousand Island dressing on marble rye bread.",
                    Price = 9.50,
                    DisplayOrder = 4
                },
                new MenuItem
                {
                    Name = "Grilled Cheese",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "",
                    Price = 4.00,
                    DisplayOrder = 5
                },
                new MenuItem
                {
                    Name = "Grilled Ham and Cheese",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "",
                    Price = 5.50,
                    DisplayOrder = 6
                },
                new MenuItem
                {
                    Name = "B.L.T.",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Bacon, lettuce and tomato served on toasted white bread.",
                    Price = 8.00,
                    DisplayOrder = 7
                },
                new MenuItem
                {
                    Name = "Chicken Fried Steak Sandwich",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "Chicken Fried Steak, pepper jack cheese on a ciabatta bun with country gravy..",
                    Price = 9.50,
                    DisplayOrder = 8
                },
                new MenuItem
                {
                    Name = "Grilled Meatloaf Sandwich",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSandwiches,
                    Description = "A thick cut of meat loaf grilled with caramelized onions, pepper jack cheese on a toasted ciabatta bun.",
                    Price = 9.00,
                    DisplayOrder = 9
                },

                /* ----- Salads  ----- */
                new MenuItem
                {
                    Name = "Cobb",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSalads,
                    Description = "Tossed greens, grilled chicken, blue cheese crumbles, tomatoes, avocado, hard boiled egg and bacon.",
                    Price = 7.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Chef Salad",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSalads,
                    Description = "Tossed greens, carrots, tomatoes, cucumbers, hardboiled egg, Cheddar cheese. Topped with diced ham and turkey.",
                    Price = 6.50,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Side Salad",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSalads,
                    Description = "Tossed greens, carrots, cucumbers, tomatoes, cheese and croutons.",
                    Price = 4.00,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Bowl of Soup and Side Salad",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSalads,
                    Description = "",
                    Price = 6.50,
                    DisplayOrder = 4
                },

                /* ----- Sides  ----- */
                new MenuItem
                {
                    Name = "Bowl of Soup",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSides,
                    Description = "",
                    Price = 4.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Cup of Soup",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSides,
                    Description = "",
                    Price = 3.00,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "French Fries",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSides,
                    Description = "",
                    Price = 2.00,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Onion Rings",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scSides,
                    Description = "",
                    Price = 2.50,
                    DisplayOrder = 4
                },

                /* ----- Dessert ----- */
                new MenuItem
                {
                    Name = "Sweet Roll",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scDessert,
                    Description = "With cream cheese icing.",
                    Price = 3.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Bread Pudding",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scDessert,
                    Description = "Topped with warm caramel sauce and whipped cream.",
                    Price = 4,
                    DisplayOrder = 1
                },

                /* ----- Lunch Kids Menu ----- */
                new MenuItem {
                    Name = "Grilled Cheese Sandwich",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchKidsMenu,
                    Description = "$4.00 with fries.",
                    Price = 3.00,
                    DisplayOrder = 1
                },
                new MenuItem {
                    Name = "Cheese Quesadilla",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchKidsMenu,
                    Description = "",
                    Price = 3.00,
                    DisplayOrder = 2
                },
                new MenuItem {
                    Name = "Beef Corn Dog and Fries",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchKidsMenu,
                    Description = "",
                    Price = 3.00,
                    DisplayOrder = 3
                },

                /* ----- Beverages  ----- */
                new MenuItem
                {
                    Name = "Coffee, Hot Chocolate, Iced Tea",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchBeverages,
                    Description = "",
                    Price = 2.00,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Sodas",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchBeverages,
                    Description = "Pepsi, Diet Pepsi, Dr. Pepper, Mountain Dew, Root Beer, Diet Coke and Pink Lemonade.",
                    Price = 2.00,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Juice",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchBeverages,
                    Description = "Orange, Apple, Cranberry, Grapefruit or Tomato.",
                    Price = 2.25,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Milk",
                    CategoryId = CategoryLunchId,
                    SubcategoryId = scLunchBeverages,
                    Description = "Whole or Chocolate.",
                    Price = 2.00,
                    DisplayOrder = 4
                },
                #endregion


                // ### --- Dinner --- ###
                #region Dinner
                // ----- Dinners -----
                new MenuItem
                {
                    Name = "Roasted New York Strip",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "Tender, juicy 12 0z. New York Strip Loin served with roasted garlic mashed potatoes, fresh vegetables, Au Jus and horseradish.",
                    Price = 18.95,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Homemade Meatloaf",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "Homemade meatloaf served with roasted garlic mashed potatoes and fresh vegetables.",
                    Price = 14.50,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Chicken Fried Steak",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "8 oz. chicken fried steak smothered in white country gravy. Served with fresh vegetables.",
                    Price = 12.50,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Grilled Chicken Pasta",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "Chargrilled chicken breast served on a bed of linguini pasta and smothered in alfredo sauce, topped with fresh grated parmesan cheese.",
                    Price = 12.50,
                    DisplayOrder = 4
                },
                new MenuItem
                {
                    Name = "Chile Verde Enchiladas",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "Two corn tortillas filled with chile verde, topped with chile verde and one fried egg. Served with rice and beans.",
                    Price = 12.50,
                    DisplayOrder = 5
                },
                new MenuItem
                {
                    Name = "Beer Battered Cod Fish and Chips",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerEntres,
                    Description = "Three pieces of cod deep fried in our special beer tempura batter. Served with fries, lemon wedge and tartar sauce.",
                    Price = 12.95,
                    DisplayOrder = 6
                },                    

                // ----- Dinner Salads -----
                new MenuItem
                {
                    Name = "Cobb Salad",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSalads,
                    Description = "Tossed greens, grilled chicken, blue cheese crumbles, tomatoes, avocado, hard boiled egg, croutons, bacon and your choice of dressing.",
                    Price = 9.95,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Black and Blue",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSalads,
                    Description = "Tossed greens, 6 oz Top Sirloin chargrilled and sliced, blue cheese crumbles, tomatoes, cucumbers, hard boiled egg and your choice of dressing.",
                    Price = 13.95,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Garden Salad",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSalads,
                    Description = "Tossed greens, carrots, tomatoes, cucumbers, hard boiled egg, cheddar cheese, croutons and your choice of dressing.",
                    Price = 7.95,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Dinner Side Salad",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSalads,
                    Description = "Tossed greens, cucumbers, tomatoes, croutons, and your choice of dressing.",
                    Price = 3.00,
                    DisplayOrder = 4
                },

                // ----- Dinner Sandwiches -----
                new MenuItem
                {
                    Name = "Bacon Cheese Burger",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSandwiches,
                    Description = "1/3 lb. patty, our thick cut bacon, lettuce, tomato, onion, pickles and your choice of cheese.",
                    Price = 9.50,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Deluxe French Dip",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerSandwiches,
                    Description = "Tender roast beef thinly sliced, grilled onions, mushrooms and Swiss cheese stacked on a hoagie roll. Served with Au Jus.",
                    Price = 10.50,
                    DisplayOrder = 2
                },

                // ----- Dinner Kids Menu -----
                
                new MenuItem
                {
                    Name = "Grilled Cheese Sandwich and Fries",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerKidsMenu,
                    Description = "",
                    Price = 4.00,
                    DisplayOrder = 1
                },
                new MenuItem
                {
                    Name = "Cheese Quesadilla and Fries",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerKidsMenu,
                    Description = "",
                    Price = 4.00,
                    DisplayOrder = 2
                },
                new MenuItem
                {
                    Name = "Beef Corn Dog and Fries",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerKidsMenu,
                    Description = "",
                    Price = 4.00,
                    DisplayOrder = 3
                },
                new MenuItem
                {
                    Name = "Chicken Tenders and Fries",
                    CategoryId = CategoryDinnerId,
                    SubcategoryId = scDinnerKidsMenu,
                    Description = "",
                    Price = 5.50,
                    DisplayOrder = 4
                },
                #endregion
            };

            foreach (MenuItem m in MenuItems)
            {
                context.MenuItems.Add(m);
            }

            context.SaveChanges();
        }
    }
}
