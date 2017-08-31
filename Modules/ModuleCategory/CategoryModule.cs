using BookStore.Core;
using Microsoft.Practices.Unity;
using ModuleCategory.Views;
using Prism.Regions;

namespace ModuleCategory
{
    public class CategoryModule : ModuleBase
    {
        public CategoryModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }
        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(CategoriesButton));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<CategoriesListView>();
        }
    }
}
