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

        private string typePlace;
        public string TypePlace
        {
            get
            {
                return this.typePlace;
            }
            set
            {
                if (this.typePlace != value)
                {
                    this.typePlace = value;
                    OnPropertyChanged(nameof(TypePlace));
                }
            }
        }

        #region Options
        private string optionOne, optionTwo, optionThree, optionFour, optionFive;
        public string OptionOne
        {
            get
            {
                return this.optionOne;
            }
            set
            {
                if (this.optionOne != value)
                {
                    this.optionOne = value;
                    OnPropertyChanged(nameof(OptionOne));
                }
            }
        }

        public string OptionTwo
        {
            get
            {
                return this.optionTwo;
            }
            set
            {
                if (this.optionTwo != value)
                {
                    this.optionTwo = value;
                    OnPropertyChanged(nameof(OptionTwo));
                }
            }
        }

        public string OptionThree
        {
            get
            {
                return this.optionThree;
            }
            set
            {
                if (this.optionThree != value)
                {
                    this.optionThree = value;
                    OnPropertyChanged(nameof(OptionThree));
                }
            }
        }

        public string OptionFour
        {
            get
            {
                return this.optionFour;
            }
            set
            {
                if (this.optionFour != value)
                {
                    this.optionFour = value;
                    OnPropertyChanged(nameof(OptionFour));
                }
            }
        }

        public string OptionFive
        {
            get
            {
                return this.optionFive;
            }
            set
            {
                if (this.optionFive != value)
                {
                    this.optionFive = value;
                    OnPropertyChanged(nameof(OptionFive));
                }
            }
        }

        #endregion

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

        public DescribeYourPlaceHEViewModel(string typePlace)
        {
            this.TypePlace = typePlace;

            this.ApartmentF = new List<string>();
            this.ApartmentF.Add("Tv");
            this.ApartmentF.Add("Air conditioner");
            this.ApartmentF.Add("Coffee Machine");
            this.ApartmentF.Add("Water heater");
            this.ApartmentF.Add("Speaker + Mic");

            this.YardF = new List<string>();
            this.YardF.Add("Pool");
            this.YardF.Add("BBQ");
            this.YardF.Add("Tables");
            this.YardF.Add("Chairs");
            this.YardF.Add("Hot Tub");

            this.HallF = new List<string>();
            this.HallF.Add("Tables");
            this.HallF.Add("Chairs");
            this.HallF.Add("Speaker + Mic");
            this.HallF.Add("Projector");
            this.HallF.Add("Bar");

            this.PrivateHF = new List<string>();
            this.PrivateHF.Add("Tv");
            this.PrivateHF.Add("Air conditioner");
            this.PrivateHF.Add("Coffee Machine");
            this.PrivateHF.Add("Water heater");
            this.PrivateHF.Add("Speaker + Mic");

            if(this.TypePlace == "Apartment")
            {
                this.OptionOne = this.ApartmentF[0];
                this.OptionTwo = this.ApartmentF[1];
                this.OptionThree = this.ApartmentF[2];
                this.OptionFour = this.ApartmentF[3];
                this.OptionFive = this.ApartmentF[4];
            }
            else if(this.TypePlace == "HB")
            {
                this.OptionOne = this.YardF[0];
                this.OptionTwo = this.YardF[1];
                this.OptionThree = this.YardF[2];
                this.OptionFour = this.YardF[3];
                this.OptionFive = this.YardF[4];
            }
            else if(this.TypePlace == "PH")
            {
                this.OptionOne = this.PrivateHF[0];
                this.OptionTwo = this.PrivateHF[1];
                this.OptionThree = this.PrivateHF[2];
                this.OptionFour = this.PrivateHF[3];
                this.OptionFive = this.PrivateHF[4];
            }
            else
            {
                this.OptionOne = this.HallF[0];
                this.OptionTwo = this.HallF[1];
                this.OptionThree = this.HallF[2];
                this.OptionFour = this.HallF[3];
                this.OptionFive = this.HallF[4];
            }
        }
    }
}
