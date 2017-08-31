using BookStore.Core;
using Microsoft.Practices.Prism.Commands;
using Prism.Regions;

namespace BookStore.Viewer
{
    public class MainWindowViewModel
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<object> NavigateCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            NavigateCommand = new DelegateCommand<object>(Navigate);
            GlobalCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        private void Navigate(object navigationPath)
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath.ToString());
        }
    }
}
