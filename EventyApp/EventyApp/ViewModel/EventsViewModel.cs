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
    class EventsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;
        public EventsViewModel()
        {
            proxy = EventyAPIProxy.CreateProxy();
            FoundEvents = new ObservableCollection<Order>();
            currentUser = ((App)App.Current).CurrentUser;
            Start();
            this.EventCommand = new Command<Order>((o) => ShowEvent(o));
        }
        public async void Start()
        {
            if (currentUser != null)
            {
                await GetOrders();
            }
            else
            {
                this.DoesNtHaveEvents = true;
                this.HaveEvents = false;
            }
            if(FoundEvents.Count == 0)
            {
                this.DoesNtHaveEvents = true;
                this.HaveEvents = false;
            }
        }

        private ObservableCollection<Order> foundEvents;
        public ObservableCollection<Order> FoundEvents
        {
            get => foundEvents;
            set
            {
                foundEvents = value;
                OnPropertyChanged("FoundEvents");
            }
        }

        private bool doesntHaveEvents;
        public bool DoesNtHaveEvents
        {
            get
            {
                return this.doesntHaveEvents;
            }
            set
            {
                if (this.doesntHaveEvents != value)
                {
                    this.doesntHaveEvents = value;
                    OnPropertyChanged(nameof(DoesNtHaveEvents));
                }
            }
        }

        private bool haveEvents;
        public bool HaveEvents
        {
            get
            {
                return this.haveEvents;
            }
            set
            {
                if (this.haveEvents != value)
                {
                    this.haveEvents = value;
                    OnPropertyChanged(nameof(HaveEvents));
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

        private string placeImage;
        public string PlaceImage
        {
            get
            {
                return this.placeImage;
            }
            set
            {
                if (this.placeImage != value)
                {
                    this.placeImage = value;
                    OnPropertyChanged(nameof(PlaceImage));
                }
            }
        }
        public async Task GetOrders()
        {
            List<Order> orders = await proxy.GetOrders(currentUser.Id);

            foreach (Order order in orders)
            {
                FoundEvents.Add(order);
            }
            
            if (this.FoundEvents.Count != 0)
            {
                this.HaveEvents = true;
                this.DoesNtHaveEvents = false;
            }
            else
            {
                this.HaveEvents = false;
                this.DoesNtHaveEvents = true;
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
            this.FoundEvents.Clear();
            IsRefreshing = true;
            GetOrders();
            IsRefreshing = false;          
        }
        public Command EventCommand { protected set; get; }
        private void ShowEvent(Order o)
        {
            Push.Invoke(new EventyApp.Views.EventDetailsView(o));
        }
    }
}
