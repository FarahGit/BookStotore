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

namespace ModuleBook.ViewModels
{
    public class BookListViewModel : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        #region Fields
        private IBookRepo bookRepo;
        //private IDialogService dialogService;

        private ObservableCollection<Book> books;
        private Book selectedBook;

        #endregion

        #region Public Properties
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { SetProperty(ref books, value); }
        }
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                SetProperty(ref selectedBook, value);
                EditBookCommand.RaiseCanExecuteChanged();
                DeleteBookCommand.RaiseCanExecuteChanged();
            }
        }
        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion
       
        #region Constructors
        public BookListViewModel(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;

            Initialize();

            AddBookCommand = new DelegateCommand<Book>(OnAddBook);
            EditBookCommand = new DelegateCommand<Book>(OnEditBook, CanBook);
            DeleteBookCommand = new DelegateCommand(OnDeleteBook, CanBook);
        }

        #endregion

        #region Private Methods
        private bool CanBook()
        {
            if (selectedBook != null)
                return true;
            else
                return false;
        }

        private async void OnDeleteBook()
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);

            var settings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                
            };

            var result =
                await metroWindow.ShowMessageAsync("Delete Book",
                "Are you sure you want to delete : " + SelectedBook.Title, MessageDialogStyle.AffirmativeAndNegative, settings);
                
        }

        private void OnEditBook(Book book)
        {
            throw new NotImplementedException();
        }

        private bool CanBook(Book book)
        {
            book = selectedBook;
            if (selectedBook != null)
                return true;
            else
                return false;
        }

        private void OnAddBook(Book book)
        {

        }

        private void Initialize()
        {
            Books = bookRepo.GetItems().ToObservableCollection();
        }

        #endregion

        #region INavigationAware Members
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameter = navigationContext.Parameters["Book"];

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

        public DelegateCommand<Book> AddBookCommand { get; private set; }
        public DelegateCommand<Book> EditBookCommand { get; private set; }

        public DelegateCommand DeleteBookCommand { get; set; }


        #endregion
    }
}