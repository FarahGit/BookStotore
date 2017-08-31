using BookStore.Core;
using Microsoft.Practices.Unity;
using ModuleBook.Views;
using Prism.Regions;

namespace ModuleBook
{
    public class BookModule : ModuleBase
    {
        public BookModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }
        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(BooksButton));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<BookListView>();
            Container.RegisterTypeForNavigation<AddEditBookView>();
        }
    }
}
