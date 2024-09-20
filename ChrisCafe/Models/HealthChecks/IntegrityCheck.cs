using Microsoft.Extensions.Diagnostics.HealthChecks;
using ChrisCafe.Data.Caches;
using ChrisCafe.Data.Factories;
using ChrisCafe.Models.ViewModels;

namespace ChrisCafe.Models.HealthChecks
{
    public class IntegrityCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var CachedMenu = Cache.Menu.CachedFullMenu;
            var MenuFactory = new MenuFactory();
            var FreshMenu = MenuFactory.Setup();

            // Check a random item from each main category
            // Breakfast
            var BreakfastCategory = GetSubcategory(FreshMenu.BreakfastMenu);
            var BreakfastItem = GetItemFromSubcategory(BreakfastCategory);
            bool BreakfastMatches = MatchMenuItems(CachedMenu.BreakfastMenu, BreakfastCategory, BreakfastItem);

            // Lunch
            var LunchCategory = GetSubcategory(FreshMenu.LunchMenu);
            var LunchItem = GetItemFromSubcategory(LunchCategory);
            bool LunchMatches = MatchMenuItems(CachedMenu.LunchMenu, LunchCategory, LunchItem);

            if (BreakfastMatches && LunchMatches)
                return Task.FromResult(HealthCheckResult.Healthy());
            else
                return Task.FromResult(HealthCheckResult.Unhealthy());
        }

        private static SubcategoryItem GetSubcategory(MenuCategoryContainer menu)
        {
            Random Rand = new();
            int SubcategoryIndex = Rand.Next(0, menu.Items.Count);
            return menu.Items[SubcategoryIndex];
        }

        private static MenuItem GetItemFromSubcategory(SubcategoryItem subcategory)
        {
            Random Rand = new();
            int index = Rand.Next(0, subcategory.Items.Count);
            return subcategory.Items[index];
        }

        private static bool MatchMenuItems(MenuCategoryContainer cachedCategory, SubcategoryItem subcategory, MenuItem item)
        {
            // Match category
            var matchedCategory = cachedCategory.Items.Find(i => i.Name == subcategory.Name);
            if (matchedCategory == null) return false;

            // Match item
            var matchedItem = matchedCategory.Items.Find(i => i.Name == item.Name);
            return matchedItem != null;
        }
    }
}
