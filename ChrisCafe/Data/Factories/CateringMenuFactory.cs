using ChrisCafe.Models.Catering;

namespace ChrisCafe.Data.Factories
{
    public class CateringMenuFactory
    {
        public static string[] Categories { get; } = new string[] { 
            "Breakfast", "Lunch", "Salads", "Large Group Salads",
            "Soups", "Desserts", "Drinks"
        };
        private CateringMenu Menu { get; set; } = new CateringMenu();

        public CateringMenu Setup()
        {
            FillSeedData();
            return Menu;
        }

        private void FillSeedData()
        {
            for (int i = 0; i < Categories.Length; i++)
            {
                Menu.MenuItems.Add(new CateringMenuCategory()
                {
                    DisplayOrder = i,
                    Name = Categories[i],
                    MenuItems = CateringMenuSeedData
                        .Where(c => c.Category == Categories[i])
                        .OrderBy(c => c.DisplayOrder)
                        .ToList()
                });
            }
        }

        private List<CateringMenuItem> CateringMenuSeedData = new List<CateringMenuItem>()
        {
            //The catering menu hierarchy goes like this:
            //  CateringMenuCache is one-to-one with CateringMenu.
            //  CateringMenu is one-to-many with CateringMenuCategory.
            //  CateringMenuCategory is one-to-many with CateringMenuItem.
            //  CateringMenuItem is one-to-many with CateringMenuItemParts.

            //Create parent object.
            //  The menu knows its categories and will create its CateringMenuItem collection objects based on its categories.
            //  (See CateringMenu constructor and FillSeedData() method for setup stuff.)


            //DISPLAY ORDERING STARTS AT ZERO FOR EACH SECTION!
            // --- Breakfast ---
            new CateringMenuItem(){
                Name = "Danish or Croissant Platter",
                Category = "Breakfast",
                DisplayOrder = 0,
                Price = null,
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "12 large assorted Danishes",
                        Price = 39.95
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "18 small assorted Danishes",
                        Price = 28.95
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "12 small assorted croissants",
                        Price = 18.95
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "10/8 small Danishes/croissants",
                        Price = 27.95
                    },
                }
            },
            new CateringMenuItem(){
                Name = "Group Breakfast",
                Category = "Breakfast",
                DisplayOrder = 1,
                Price = 150,
                ServingSize = "Serves 12 people",
                AdditionalServingCosts = new string[]
                {
                    "5 servers + $62.00",
                    "10 servings + $124.00"
                },
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "24 cinnamon brioche French toast halves",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "24 scrambled eggs",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "6 lbs. hash browns",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "24 pieces bacon or sausage",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "French Toast Breakfast",
                Category = "Breakfast",
                DisplayOrder = 2,
                Price = 60,
                ServingSize = "Serves 12 people",
                AdditionalServingCosts = new string[]
                {
                    "5 servers + $24.50",
                    "10 servings + $49.00"
                },
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "24 pieces of French toast",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Cut strawberries",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Whipped cream or caramel sauce",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "Meat & Eggs Breakfast",
                Category = "Breakfast",
                DisplayOrder = 3,
                Price = 47.95,
                ServingSize = "Serves 6 people",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Scrambled eggs",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Hash browns",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Bacon or sausage",
                        Price = null
                    }
                }
            },

            // --- Lunch ---
            new CateringMenuItem(){
                Name = "Boxed Lunch Sandwich",
                Category = "Lunch",
                DisplayOrder = 0,
                Price = 8.99,
                ServingSize = "6 person minimum",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Roast beef, ham or turkey served on white or wheat bread",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Potato, macaroni salad or bag of chips",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Cookie (chocolate chip or oatmeal raisin)",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Mayo and mustard packets",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "Sandwich Platter",
                Category = "Lunch",
                DisplayOrder = 1,
                Price = 109,
                ServingSize = "Serves 12 people",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Sandwiches served on white or wheat bread",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "4 half roast beef sandwiches ",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "4 half ham sandwiches",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "4 half turkey sandwiches",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "12 bags of chips or 12 servings of macaroni or potato salad",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "12 cookies, chocolate chip or oatmeal raisin",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "Mayonnaise and mustard packets",
                        Price = null
                    }
                }
            },

            // --- Salads ---
            new CateringMenuItem(){
                Name = "Cobb",
                Category = "Salads",
                DisplayOrder = 0,
                Price = 8.95,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Tossed spring greens, grilled chicken, blue cheese crumbles, tomatoes, avocado, hard boiled egg*, bacon and croutons",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "1 cookie, chocolate chip or raisin oatmeal",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "Chef Salad",
                Category = "Salads",
                DisplayOrder = 1,
                Price = 8.95,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Tossed spring greens, carrots, tomatoes, cucumbers, hardboiled egg*, cheddar cheese. Topped with diced ham and turkey and croutons",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "1 cookie, chocolate chip or raisin oatmeal",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "Turkey Bacon Avocado Salad",
                Category = "Salads",
                DisplayOrder = 2,
                Price = 8.95,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Tossed spring greens, cucumbers, tomatoes, sliced turkey, bacon crumbles, sliced avocado and croutons",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "1 cookie, chocolate chip or raisin oatmeal",
                        Price = null
                    }
                }
            },
            new CateringMenuItem(){
                Name = "Turkey Bacon Avocado Salad",
                Category = "Salads",
                DisplayOrder = 3,
                Price = 8.25,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Tossed spring greens, carrots, tomatoes, Cucumbers, avocado slices and croutons",
                        Price = null
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "1 cookie, chocolate chip or raisin oatmeal",
                        Price = null
                    }
                }
            },

            // --- Large Group Salads ---
            new CateringMenuItem(){
                Name = "Potato Salad",
                Category = "Large Group Salads",
                DisplayOrder = 0,
                Price = 13.95,
                ServingSize = "Serves 12",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){ }
            },
            new CateringMenuItem(){
                Name = "Macaroni Salad",
                Category = "Large Group Salads",
                DisplayOrder = 1,
                Price = 13.95,
                ServingSize = "Serves 12",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){ }
            },
            new CateringMenuItem(){
                Name = "Garden Salad",
                Category = "Large Group Salads",
                DisplayOrder = 0,
                Price = 26,
                ServingSize = "Serves 12",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "Fresh greens, cucumbers, tomatoes, carrots, croutons, red onions, cheddar cheese",
                        Price = null
                    },
                }
            },

            // --- Soups ---
            //None?

            // --- Desserts ---
            new CateringMenuItem(){
                Name = "Cinnamon Rolls",
                Category = "Desserts",
                DisplayOrder = 0,
                Price = null,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "12",
                        Price = 26.95
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "24",
                        Price = 51.95
                    },
                }
            },
            new CateringMenuItem(){
                Name = "Bread Pudding with Caramel Sauce",
                Category = "Desserts",
                DisplayOrder = 1,
                Price = 21.95,
                ServingSize = "Serves 6",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){}
            },
            new CateringMenuItem(){
                Name = "Apple or Apple/Raspberry Crisp",
                Category = "Desserts",
                DisplayOrder = 2,
                Price = null,
                ServingSize = "",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){}
            },
            new CateringMenuItem(){
                Name = "Cookies",
                Category = "Desserts",
                DisplayOrder = 3,
                Price = null,
                ServingSize = "Serves 6",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>()
                {
                    new CateringMenuItemParts()
                    {
                        Description = "12",
                        Price = 12.95
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "18",
                        Price = 19.50
                    },
                    new CateringMenuItemParts()
                    {
                        Description = "24",
                        Price = 25.95
                    }
                }
            },

            // --- Drinks ---
            new CateringMenuItem(){
                Name = "Orange Juice",
                Category = "Drinks",
                DisplayOrder = 0,
                Price = 22.95,
                ServingSize = "1 gallon / 16 8oz servings",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){}
            },
            new CateringMenuItem(){
                Name = "Apple Juice",
                Category = "Drinks",
                DisplayOrder = 1,
                Price = 22.95,
                ServingSize = "1 gallon / 16 8oz servings",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){}
            },
            new CateringMenuItem(){
                Name = "Coffee",
                Category = "Drinks",
                DisplayOrder = 2,
                Price = 22.95,
                ServingSize = "Cups, straws, sugar and creamer",
                AdditionalServingCosts = new string[0],
                MenuItemParts = new List<CateringMenuItemParts>(){}
            },
        };
    }
}
