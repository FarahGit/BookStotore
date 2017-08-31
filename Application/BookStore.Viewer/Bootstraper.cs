using BookStore.Interface;
using BookStore.SqlRepo.Persistence.Repositories;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace BookStore.Viewer
{
    public class Bootstraper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {

            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = @".\Modules" };
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<ICategoryRepo, CategoryRepo>()
                .RegisterType<IBookRepo, BookRepo>()
                .RegisterType<IAuthorRepo, AuthorRepo>(
                new ContainerControlledLifetimeManager());
        }
    }
}
