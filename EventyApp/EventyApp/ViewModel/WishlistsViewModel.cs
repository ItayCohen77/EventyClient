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
    class WishlistsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;
        public WishlistsViewModel()
        {
            proxy = EventyAPIProxy.CreateProxy();
            FoundPlaces = new ObservableCollection<Place>();
            currentUser = ((App)App.Current).CurrentUser;            
            Start();
        }
        public async void Start()
        {
            if(currentUser != null)
            {
                await GetLikedPlaces();
            }
            else
            {
                this.DoesNtHaveLikedEvents = true;
                this.HaveLikedEvents = false;
            }
            if (FoundPlaces.Count == 0)
            {
                this.DoesNtHaveLikedEvents = true;
                this.HaveLikedEvents = false;
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

        private bool doesntHaveLikedEvents;
        public bool DoesNtHaveLikedEvents
        {
            get
            {
                return this.doesntHaveLikedEvents;
            }
            set
            {
                if (this.doesntHaveLikedEvents != value)
                {
                    this.doesntHaveLikedEvents = value;
                    OnPropertyChanged(nameof(DoesNtHaveLikedEvents));
                }
            }
        }

        private bool haveLikedEvents;
        public bool HaveLikedEvents
        {
            get
            {
                return this.haveLikedEvents;
            }
            set
            {
                if (this.haveLikedEvents != value)
                {
                    this.haveLikedEvents = value;
                    OnPropertyChanged(nameof(HaveLikedEvents));
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
        public async Task GetLikedPlaces()
        {
            List<Place> likedPlaces = await proxy.GetLikedPlaces(currentUser.Id);

            foreach (Place place in likedPlaces)
            {
                if(place != null)
                {
                    FoundPlaces.Add(place);
                }                
            }

            if(this.FoundPlaces.Count != 0)
            {
                this.HaveLikedEvents = true;
                this.DoesNtHaveLikedEvents = false;
            }
            else
            {
                this.HaveLikedEvents = false;
                this.DoesNtHaveLikedEvents = true;
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
            GetLikedPlaces();
            IsRefreshing = false;          
        }
    }
}
