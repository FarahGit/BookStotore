using BookStore.Core;
using BookStore.Extension;
using BookStore.Interface;
using BookStore.Shared;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ModuleCategory.ViewModels
{
    public class CategoriesListViewModel : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        private ICategoryRepo categoryRepo;

        private ObservableCollection<Category> categories;
        private Category selectedCategory;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                SetProperty(ref selectedCategory, value);
                EditCategoryCommand.RaiseCanExecuteChanged();
                DeleteCategoryCommand.RaiseCanExecuteChanged();

            }
        }

        public bool KeepAlive
        {
            get { return false; }
        }

        public CategoriesListViewModel(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
            Intialize();

            AddCategoryCommand = new DelegateCommand<Category>(OnAddCategory);
            EditCategoryCommand = new DelegateCommand<Category>(OnEditCategory, CanCategory);
            DeleteCategoryCommand = new DelegateCommand(OnDeleteCategory, CanCategory);

        }

        private void Intialize()
        {
            Categories = categoryRepo.GetItems().ToObservableCollection();
        }

        #region Public Methods

        #region Private Methods

        private bool CanCategory()
        {
            if (selectedCategory != null)
                return true;
            else
                return false;
        }

        private async void OnDeleteCategory()
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);

            var settings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No"
            };

            var result =
                await metroWindow.ShowMessageAsync("Delete Category",
                "Are you sure you want to delete : " + SelectedCategory.Name, MessageDialogStyle.AffirmativeAndNegative, settings);

        }

        private void OnEditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        private bool CanCategory(Category category)
        {
            category = selectedCategory;
            if (category != null)
                return true;
            else
                return false;
        }

        private void OnAddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region INavigationAware Members
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion

        #endregion

        #region Command Members

        public DelegateCommand<Category> AddCategoryCommand { get; private set; }
        public DelegateCommand<Category> EditCategoryCommand { get; private set; }
        public DelegateCommand DeleteCategoryCommand { get; set; }


        #endregion
    }
}
