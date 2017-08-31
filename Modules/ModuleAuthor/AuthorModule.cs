using BookStore.Core;
using Microsoft.Practices.Unity;
using ModuleAuthor.Views;
using Prism.Regions;

namespace ModuleAuthor
{
    public class AuthorModule : ModuleBase
    {
        public AuthorModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }
        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(AuthorsButton));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<AuthorListView>();
        }

    }
}
