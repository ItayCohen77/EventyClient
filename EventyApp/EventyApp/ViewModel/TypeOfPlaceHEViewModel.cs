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

        private string isvisible;
        public string IsVisible
        {
            get
            {
                return this.isvisible;
            }
            set
            {
                if (this.isvisible != value)
                {
                    this.isvisible = value;
                    OnPropertyChanged(nameof(IsVisible));
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
                this.Pressed = false;
                this.IsVisible = "False";
            }
            else
            {
                this.ChangeBorderColorApartment = "#FF5353";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.Pressed = true;
            }

            if(Pressed)
            {
                this.IsVisible = "True";
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
                this.Pressed = false;
                this.IsVisible = "False";
            }
            else
            {
                this.ChangeBorderColorPH = "#FF5353";
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorHB = "#B7B7B7";
                this.Pressed = true;
            }

            if (Pressed)
            {
                this.IsVisible = "True";
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
                this.Pressed = false;
                this.IsVisible = "False";
            }
            else
            {
                this.ChangeBorderColorHB = "#FF5353";
                this.ChangeBorderColorApartment = "#B7B7B7";
                this.ChangeBorderColorPH = "#B7B7B7";
                this.Pressed = true;
            }

            if (Pressed)
            {
                this.IsVisible = "True";
            }
        }

        public TypeOfPlaceHEViewModel()
        {
            this.ChangeBorderColorApartment = "#B7B7B7";
            this.ChangeBorderColorPH = "#B7B7B7";
            this.ChangeBorderColorHB = "#B7B7B7";
            this.Pressed = false;
            this.IsVisible = "False";
        }
    }
}
