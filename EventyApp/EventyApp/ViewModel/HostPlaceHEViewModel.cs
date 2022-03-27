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
    class HostPlaceHEViewModel : INotifyPropertyChanged
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

        private string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        #region Features
        private string featureOne, featureTwo, featureThree, featureFour, featureFive;
        public string FeatureOne
        {
            get
            {
                return this.featureOne;
            }
            set
            {
                if (this.featureOne != value)
                {
                    this.featureOne = value;
                    OnPropertyChanged(nameof(FeatureOne));
                }
            }
        }

        public string FeatureTwo
        {
            get
            {
                return this.featureTwo;
            }
            set
            {
                if (this.featureTwo != value)
                {
                    this.featureTwo = value;
                    OnPropertyChanged(nameof(FeatureTwo));
                }
            }
        }

        public string FeatureThree
        {
            get
            {
                return this.featureThree;
            }
            set
            {
                if (this.featureThree != value)
                {
                    this.featureThree = value;
                    OnPropertyChanged(nameof(FeatureThree));
                }
            }
        }

        public string FeatureFour
        {
            get
            {
                return this.featureFour;
            }
            set
            {
                if (this.featureFour != value)
                {
                    this.featureFour = value;
                    OnPropertyChanged(nameof(FeatureFour));
                }
            }
        }

        public string FeatureFive
        {
            get
            {
                return this.featureFive;
            }
            set
            {
                if (this.featureFive != value)
                {
                    this.featureFive = value;
                    OnPropertyChanged(nameof(FeatureFive));
                }
            }
        }

        #endregion

        #region Images
        private string imageOne;
        public string ImageOne
        {
            get
            {
                return this.imageOne;
            }
            set
            {
                if (this.imageOne != value)
                {
                    this.imageOne = value;
                    OnPropertyChanged(nameof(ImageOne));
                }
            }
        }

        private string imageTwo;
        public string ImageTwo
        {
            get
            {
                return this.imageTwo;
            }
            set
            {
                if (this.imageTwo != value)
                {
                    this.imageTwo = value;
                    OnPropertyChanged(nameof(ImageTwo));
                }
            }
        }

        private string imageThree;
        public string ImageThree
        {
            get
            {
                return this.imageThree;
            }
            set
            {
                if (this.imageThree != value)
                {
                    this.imageThree = value;
                    OnPropertyChanged(nameof(ImageThree));
                }
            }
        }

        private string imageFour;
        public string ImageFour
        {
            get
            {
                return this.imageFour;
            }
            set
            {
                if (this.imageFour != value)
                {
                    this.imageFour = value;
                    OnPropertyChanged(nameof(ImageFour));
                }
            }
        }

        private string imageFive;
        public string ImageFive
        {
            get
            {
                return this.imageFive;
            }
            set
            {
                if (this.imageFive != value)
                {
                    this.imageFive = value;
                    OnPropertyChanged(nameof(ImageFive));
                }
            }
        }

        private string imageSix;
        public string ImageSix
        {
            get
            {
                return this.imageSix;
            }
            set
            {
                if (this.imageSix != value)
                {
                    this.imageSix = value;
                    OnPropertyChanged(nameof(ImageSix));
                }
            }
        }
        #endregion

        private string street;
        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                if (this.street != value)
                {
                    this.street = value;
                    OnPropertyChanged(nameof(Street));
                }
            }
        }

        private string apartment;
        public string Apartment
        {
            get
            {
                return this.apartment;
            }
            set
            {
                if (this.apartment != value)
                {
                    this.apartment = value;
                    OnPropertyChanged(nameof(Apartment));
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

        private string zip;
        public string Zip
        {
            get
            {
                return this.zip;
            }
            set
            {
                if (this.zip != value)
                {
                    this.zip = value;
                    OnPropertyChanged(nameof(Zip));
                }
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country != value)
                {
                    this.country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private int maxPeople;
        public int MaxPeople
        {
            get
            {
                return this.maxPeople;
            }
            set
            {
                if (this.maxPeople != value)
                {
                    this.maxPeople = value;
                    OnPropertyChanged(nameof(MaxPeople));
                }
            }
        }

        private int costPerHour;
        public int CostPerHour
        {
            get
            {
                return this.costPerHour;
            }
            set
            {
                if (this.costPerHour != value)
                {
                    this.costPerHour = value;
                    OnPropertyChanged(nameof(CostPerHour));
                }
            }
        }
    }
}
