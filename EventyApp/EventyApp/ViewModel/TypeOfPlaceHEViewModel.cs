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
    class TypeOfPlaceHEViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

 
        private string changeBorderColorApartment;
        public string ChangeBorderColorApartment
        {
            get
            {
                return this.changeBorderColorApartment;
            }
            set
            {
                if (this.changeBorderColorApartment != value)
                {
                    this.changeBorderColorApartment = value;
                    OnPropertyChanged(nameof(ChangeBorderColorApartment));
                }
            }
        }

        private string buttoncolor;
        public string ButtonColor
        {
            get
            {
                return this.buttoncolor;
            }
            set
            {
                if (this.buttoncolor != value)
                {
                    this.buttoncolor = value;
                    OnPropertyChanged(nameof(ButtonColor));
                }
            }
        }

        private string changeBorderColorPH;
        public string ChangeBorderColorPH
        {
            get
            {
                return this.changeBorderColorPH;
            }
            set
            {
                if (this.changeBorderColorPH != value)
                {
                    this.changeBorderColorPH = value;
                    OnPropertyChanged(nameof(ChangeBorderColorPH));
                }
            }
        }

        private string changeBorderColorHB;
        public string ChangeBorderColorHB
        {
            get
            {
                return this.changeBorderColorHB;
            }
            set
            {
                if (this.changeBorderColorHB != value)
                {
                    this.changeBorderColorHB = value;
                    OnPropertyChanged(nameof(ChangeBorderColorHB));
                }
            }
        }

        private string changeBorderColorH;
        public string ChangeBorderColorH
        {
            get
            {
                return this.changeBorderColorH;
            }
            set
            {
                if (this.changeBorderColorH != value)
                {
                    this.changeBorderColorH = value;
                    OnPropertyChanged(nameof(ChangeBorderColorH));
                }
            }
        }

        private bool pressed;
        public bool Pressed
        {
            get
            {
                return this.pressed;
            }
            set
            {
                if (this.pressed != value)
                {
                    this.pressed = value;
                    OnPropertyChanged(nameof(Pressed));
                }
            }
        }

        private string isenabled;
        public string IsEnabled
        {
            get
            {
                return this.isenabled;
            }
            set
            {
                if (this.isenabled != value)
                {
                    this.isenabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public ICommand ApartmentCommand => new Command(Apartment);
        private void Apartment()
        {
            if(!Pressed)
            {
                this.ChangeBorderColorApartment = "#FF5353";
                this.Pressed = true;
            }
            else if (this.changeBorderColorApartment == "#FF5353")
            {
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = false;
                this.IsEnabled = "False";
                this.ButtonColor = "#B7B7B7";
            }
            else
            {
                this.ChangeBorderColorApartment = "#FF5353";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = true;
            }

            if(Pressed)
            {
                this.IsEnabled = "True";
                this.ButtonColor = "#FF5353";
            }
        }

        public ICommand PrivateHouseCommand => new Command(PrivateHouse);
        private void PrivateHouse()
        {
            if (!Pressed)
            {
                this.ChangeBorderColorPH = "#FF5353";
                this.Pressed = true;
            }
            else if (this.changeBorderColorPH == "#FF5353")
            {
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = false;
                this.IsEnabled = "False";
                this.ButtonColor = "#B7B7B7";
            }
            else
            {
                this.ChangeBorderColorPH = "#FF5353";
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = true;
            }

            if (Pressed)
            {
                this.IsEnabled = "True";
                this.ButtonColor = "#FF5353";
            }
        }

        public ICommand HouseBackyardCommand => new Command(HouseBackyard);
        private void HouseBackyard()
        {
            if (!Pressed)
            {
                this.ChangeBorderColorHB = "#FF5353";
                this.Pressed = true;
            }
            else if (this.changeBorderColorHB == "#FF5353")
            {
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = false;
                this.IsEnabled = "False";
                this.ButtonColor = "#B7B7B7";
            }
            else
            {
                this.ChangeBorderColorHB = "#FF5353";
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = true;
            }

            if (Pressed)
            {
                this.IsEnabled = "True";
                this.ButtonColor = "#FF5353";
            }
        }

        public ICommand HallCommand => new Command(Hall);
        private void Hall()
        {
            if (!Pressed)
            {
                this.ChangeBorderColorH = "#FF5353";
                this.Pressed = true;
            }
            else if (this.changeBorderColorH == "#FF5353")
            {
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.ChangeBorderColorH = "#B7B7B7";
                this.Pressed = false;
                this.IsEnabled = "False";
                this.ButtonColor = "#B7B7B7";
            }
            else
            {
                this.ChangeBorderColorH = "#FF5353";
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.Pressed = true;
            }

            if (Pressed)
            {
                this.IsEnabled = "True";
                this.ButtonColor = "#FF5353";
            }
        }

        public ICommand NextCommand => new Command(Next);
        private void Next()
        {
            Push?.Invoke(new EventyApp.Views.HostEstateView.DescribeYourPlaceHEView());
        }
        public TypeOfPlaceHEViewModel()
        {
            this.ChangeBorderColorApartment = "#B7B7B7";
            this.ChangeBorderColorPH = "#B7B7B7";
            this.ChangeBorderColorHB = "#B7B7B7";
            this.ButtonColor = "#B7B7B7";
            this.ChangeBorderColorH = "#B7B7B7";
            this.Pressed = false;
            this.IsEnabled = "False";
        }
    }
}
