using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using EventyApp.Services;
using EventyApp.Models;
using System.Threading;

namespace EventyApp.ViewModel
{
    class UserEstatesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;

        public UserEstatesViewModel()
        {
            proxy = EventyAPIProxy.CreateProxy();
            FoundPlaces = new ObservableCollection<Place>();
            currentUser = ((App)App.Current).CurrentUser;
            this.EditPlaceCommand = new Command<Place>((p) => EditPlace(p));
            Start();
        }

        public async void Start()
        {
            if (currentUser != null)
            {
                await GetEstates();
            }
            else
            {
                this.DoesNtHaveEstates = true;
                this.HaveEstates = false;
            }
        }

        private ObservableCollection<Place> foundPlaces;
        public ObservableCollection<Place> FoundPlaces
        {
            get => foundPlaces;
            set
            {
                foundPlaces = value;
                OnPropertyChanged("FoundPlaces");
            }
        }

        private bool doesntHaveEstates;
        public bool DoesNtHaveEstates
        {
            get
            {
                return this.doesntHaveEstates;
            }
            set
            {
                if (this.doesntHaveEstates != value)
                {
                    this.doesntHaveEstates = value;
                    OnPropertyChanged(nameof(DoesNtHaveEstates));
                }
            }
        }

        private bool haveEstates;
        public bool HaveEstates
        {
            get
            {
                return this.haveEstates;
            }
            set
            {
                if (this.haveEstates != value)
                {
                    this.haveEstates = value;
                    OnPropertyChanged(nameof(HaveEstates));
                }
            }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                if (this.isRefreshing != value)
                {
                    this.isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }
        public async Task GetEstates()
        {
            List<Place> estates = await proxy.GetEstates(currentUser.Id);

            foreach (Place place in estates)
            {
                FoundPlaces.Add(place);
            }

            if (this.FoundPlaces != null)
            {
                this.HaveEstates = true;
                this.DoesNtHaveEstates = false;
            }
            else
            {
                this.HaveEstates = false;
                this.DoesNtHaveEstates = true;
            }
        }
        public ICommand ExploreCommand => new Command(Explore);
        private void Explore()
        {
            Push.Invoke(new TabControlView());
        }
        public ICommand RefreshCommand => new Command(Refresh);
        public void Refresh()
        {
            this.FoundPlaces.Clear();
            IsRefreshing = true;
            GetEstates();
            IsRefreshing = false;
        }
        public Command EditPlaceCommand { protected set; get; }
        private void EditPlace(Place p)
        {
            Push.Invoke(new EventyApp.Views.EditPlaceView(p));
        }
    }
}
