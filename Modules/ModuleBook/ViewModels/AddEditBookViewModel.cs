using BookStore.Core;
using Prism.Regions;
using System;

namespace ModuleBook.ViewModels
{
    public class AddEditBookViewModel : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionNavigationJournal journal;

        public bool KeepAlive { get { return false; } }
        

        #region INavigationAware Members
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            journal = navigationContext.NavigationService.Journal;
        } 

        public void Back()
        {
            journal.GoBack();
        }

        #endregion
    }
}
