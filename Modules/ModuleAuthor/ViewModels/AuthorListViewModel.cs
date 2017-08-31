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

namespace ModuleAuthor.ViewModels
{
    public class AuthorListViewModel : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        #region Fields
        private IAuthorRepo authorRepo;

        private ObservableCollection<Author> authors;
        private Author selectedAuthor;

        #endregion

        #region Public Properties
        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set { SetProperty(ref authors, value); }
        }
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                SetProperty(ref selectedAuthor, value);
                EditAuthorCommand.RaiseCanExecuteChanged();
                DeleteAuthorCommand.RaiseCanExecuteChanged();
            }
        }
        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion

        #region Constructors
        public AuthorListViewModel(IAuthorRepo authorRepo)
        {
            this.authorRepo = authorRepo;

            Initialize();

            AddAuthorCommand = new DelegateCommand<Author>(OnAddAuthor);
            EditAuthorCommand = new DelegateCommand<Author>(OnEditAuthor, CanAuthor);
            DeleteAuthorCommand = new DelegateCommand(OnDeleteAuthor, CanAuthor);
        }

        #endregion

        #region Private Methods
        private bool CanAuthor()
        {
            if (selectedAuthor != null)
                return true;
            else
                return false;
        }

        private async void OnDeleteAuthor()
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);

            var settings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No"
            };

            var result =
                await metroWindow.ShowMessageAsync("Delete Author",
                "Are you sure you want to delete : " + SelectedAuthor.Name, MessageDialogStyle.AffirmativeAndNegative, settings);

        }

        private void OnEditAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        private bool CanAuthor(Author author)
        {
            author = selectedAuthor;
            if (selectedAuthor != null)
                return true;
            else
                return false;
        }

        private void OnAddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            Authors = authorRepo.GetItems().ToObservableCollection();
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

        #region Command Members

        public DelegateCommand<Author> AddAuthorCommand { get; private set; }
        public DelegateCommand<Author> EditAuthorCommand { get; private set; }

        public DelegateCommand DeleteAuthorCommand { get; set; }


        #endregion
    }
}
