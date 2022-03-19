using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;

namespace EventyApp.ViewModel
{
    class TabControlViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public TabControlViewModel()
        {
            SelectedViewModelIndex = 0;
        }

        private int selectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get => selectedViewModelIndex;
            set
            {
                selectedViewModelIndex = value;
                OnPropertyChanged("SelectedViewModelIndex");
            }
        }

        public event Action<Page> Push;
    }
}
