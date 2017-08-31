using BookStore.Core;
using ModuleStatusbar.Views;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleStatusbar
{
    public class StatusbarModule : IModule
    {
        private readonly IRegionManager regionManager;

        public StatusbarModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.StatusbarRegion, typeof(StatusBarView));
        }
    }
}
