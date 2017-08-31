using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace BookStore.Core
{
    public abstract class ModuleBase : IModule
    {
        protected IUnityContainer Container { get; private set; }
        protected IRegionManager RegionManager { get; private set; }

        public ModuleBase(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterTypes();
            InitializeModule();
        }

        protected abstract void RegisterTypes();
        protected abstract void InitializeModule();
    }
}
