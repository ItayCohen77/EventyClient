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
    public class EventDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        public User currentUser;

        public EventDetailsViewModel(Order o)
        {
            proxy = EventyAPIProxy.CreateProxy();
            currentUser = ((App)App.Current).CurrentUser;
            this.Order = o;
            this.EventDate = Order.EventDate;
            this.City = Order.Place.City;
            this.Address = Order.Place.PlaceAddress;
            this.Amountofpeople = Order.AmountOfPeople;
            this.Total = Order.Total;
            this.Totalhours = Order.TotalHours;
        }

        private int amountofpeople;
        public int Amountofpeople
        {
            get
            {
                return this.amountofpeople;
            }
            set
            {
                if (this.amountofpeople != value)
                {
                    this.amountofpeople = value;
                    OnPropertyChanged(nameof(Amountofpeople));
                }
            }
        }

        private string city;
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (this.city != value)
                {
                    this.city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (this.address != value)
                {
                    this.address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        private DateTime eventDate;
        public DateTime EventDate
        {
            get
            {
                return this.eventDate;
            }
            set
            {
                if (this.eventDate != value)
                {
                    this.eventDate = value;
                    OnPropertyChanged(nameof(EventDate));
                }
            }
        }

        private int total;
        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                if (this.total != value)
                {
                    this.total = value;
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        
        private int totalhours;
        public int Totalhours
        {
            get
            {
                return this.totalhours;
            }
            set
            {
                if (this.totalhours != value)
                {
                    this.totalhours = value;
                    OnPropertyChanged(nameof(Totalhours));
                }
            }
        }

        private Order order;
        public Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                if (this.order != value)
                {
                    this.order = value;
                    OnPropertyChanged(nameof(Order));
                }
            }
        }

        public ICommand CancelEventCommand => new Command(CancelEvent);
        private async void CancelEvent()
        {
            bool success = await proxy.CancelEvent(Order.Id);
            if (success)
            {
                Order = null;
                Push?.Invoke(new TabControlView());
            }
        }
    }
}
