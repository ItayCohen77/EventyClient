using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using EventyApp.Services;
using EventyApp.Models;

namespace EventyApp.ViewModel
{
    class DescribeYourPlaceHEViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        private List<string> apartmentF;
        public List<string> ApartmentF
        {
            get
            {
                return this.apartmentF;
            }
            set
            {
                if (this.apartmentF != value)
                {
                    this.apartmentF = value;
                    OnPropertyChanged(nameof(ApartmentF));
                }
            }
        }

        private List<string> yardF;
        public List<string> YardF
        {
            get
            {
                return this.yardF;
            }
            set
            {
                if (this.yardF != value)
                {
                    this.yardF = value;
                    OnPropertyChanged(nameof(YardF));
                }
            }
        }

        private List<string> hallF;
        public List<string> HallF
        {
            get
            {
                return this.hallF;
            }
            set
            {
                if (this.hallF != value)
                {
                    this.hallF = value;
                    OnPropertyChanged(nameof(HallF));
                }
            }
        }

        private List<string> privateHF;
        public List<string> PrivateHF
        {
            get
            {
                return this.privateHF;
            }
            set
            {
                if (this.privateHF != value)
                {
                    this.privateHF = value;
                    OnPropertyChanged(nameof(PrivateHF));
                }
            }
        }

        public DescribeYourPlaceHEViewModel()
        {
            this.ApartmentF.Add("Tv");
            this.ApartmentF.Add("Air conditioner");
            this.ApartmentF.Add("Coffee Machine");
            this.ApartmentF.Add("Water heater");
            this.ApartmentF.Add("Speaker");

            this.YardF.Add("Pool");
            this.YardF.Add("BBQ");
            this.YardF.Add("Table");
            this.YardF.Add("Chairs");
            this.YardF.Add("Table");
        }
    }
}
