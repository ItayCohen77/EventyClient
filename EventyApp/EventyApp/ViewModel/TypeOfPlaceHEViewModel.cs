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
    class TypeOfPlaceHEViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

 
        private Color changeBorderColorApartment;
        public Color ChangeBorderColorApartment
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

        private Color changeBorderColorPH;
        public Color ChangeBorderColorPH
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

        private Color changeBorderColorHB;
        public Color ChangeBorderColorHB
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

        public ICommand ApartmentCommand => new Command(Apartment);
        private void Apartment()
        {
            this.ChangeBorderColorApartment = new Color(255, 83, 83);
        }

        public TypeOfPlaceHEViewModel()
        {
            this.ChangeBorderColorApartment = new Color(192, 192, 192);
            this.ChangeBorderColorPH = new Color(192, 192, 192);
            this.ChangeBorderColorHB = new Color(192, 192, 192);
        }
    }
}
