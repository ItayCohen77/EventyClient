﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using EventyApp.Services;
using EventyApp.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;



namespace EventyApp.ViewModel
{
    class MaxGuestsHEViewModel : INotifyPropertyChanged
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
        private bool featureOneBool, featureTwoBool, featureThreeBool, featureFourBool, featureFiveBool;
        public bool FeatureOneBool
        {
            get
            {
                return this.featureOneBool;
            }
            set
            {
                if (this.featureOneBool != value)
                {
                    this.featureOneBool = value;
                    OnPropertyChanged(nameof(FeatureOneBool));
                }
            }
        }

        public bool FeatureTwoBool
        {
            get
            {
                return this.featureTwoBool;
            }
            set
            {
                if (this.featureTwoBool != value)
                {
                    this.featureTwoBool = value;
                    OnPropertyChanged(nameof(FeatureTwoBool));
                }
            }
        }

        public bool FeatureThreeBool
        {
            get
            {
                return this.featureThreeBool;
            }
            set
            {
                if (this.featureThreeBool != value)
                {
                    this.featureThreeBool = value;
                    OnPropertyChanged(nameof(FeatureThreeBool));
                }
            }
        }

        public bool FeatureFourBool
        {
            get
            {
                return this.featureFourBool;
            }
            set
            {
                if (this.featureFourBool != value)
                {
                    this.featureFourBool = value;
                    OnPropertyChanged(nameof(FeatureFourBool));
                }
            }
        }

        public bool FeatureFiveBool
        {
            get
            {
                return this.featureFiveBool;
            }
            set
            {
                if (this.featureFiveBool != value)
                {
                    this.featureFiveBool = value;
                    OnPropertyChanged(nameof(FeatureFiveBool));
                }
            }
        }

        #endregion

        #region Images
        private FileResult imageOne;
        public FileResult ImageOne
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

        private FileResult imageTwo;
        public FileResult ImageTwo
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

        private FileResult imageThree;
        public FileResult ImageThree
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

        private FileResult imageFour;
        public FileResult ImageFour
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

        private FileResult imageFive;
        public FileResult ImageFive
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

        private FileResult imageSix;
        public FileResult ImageSix
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

        private string error;
        public string Error
        {
            get
            {
                return this.error;
            }
            set
            {
                if (this.error != value)
                {
                    this.error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        private bool showError;
        public bool ShowError
        {
            get
            {
                return this.showError;
            }
            set
            {
                if (this.showError != value)
                {
                    this.showError = value;
                    OnPropertyChanged(nameof(ShowError));
                }
            }
        }

        private void ValidateMax()
        {
            if (MaxPeople == 0 || CostPerHour == 0)
            {
                this.Error = "Please choose a number that is not 0 (People amount and price per hour)";
                this.ShowError = true;
            }
            else
            {
                this.ShowError = false;
            }
        }

        private bool ValidateForm()
        {
            ValidateMax();

            return !(ShowError);
        }

        public Command DoneCommand { protected set; get; }
        private async void Done()
        {
            if(ValidateForm())
            {
                Place place = await proxy.UploadPlace(TypePlace, FeatureOneBool, FeatureTwoBool, FeatureThreeBool, FeatureFourBool, FeatureFiveBool, Description, ImageOne, ImageTwo, ImageThree, ImageFour, ImageFive, ImageSix, Street, Apartment, City, Zip, Country, MaxPeople, CostPerHour);
                Push?.Invoke(new TabControlView());
            }     
        }

        public MaxGuestsHEViewModel(string typePlace, bool featureOneBool, bool featureTwoBool, bool featureThreeBool, bool featureFourBool, bool featureFiveBool, string description, FileResult imageOne, FileResult imageTwo, FileResult imageThree, FileResult imageFour, FileResult imageFive, FileResult imageSix, string street, string apartment, string city, string zip, string country)
        {
            this.TypePlace = typePlace;
            this.FeatureOneBool = featureOneBool;
            this.FeatureTwoBool = featureTwoBool;
            this.FeatureThreeBool = featureThreeBool;
            this.FeatureFourBool = featureFourBool;
            this.FeatureFiveBool = featureFiveBool;
            this.Description = description;
            this.ImageOne = imageOne;
            this.ImageTwo = imageTwo;
            this.ImageThree = imageThree;
            this.ImageFour = imageFour;
            this.ImageFive = imageFive;
            this.ImageSix = imageSix;
            this.Street = street;
            this.Apartment = apartment;          
            this.City = city;
            this.Zip = zip;
            this.Country = country;
            this.DoneCommand = new Command(() => Done());
            proxy = EventyAPIProxy.CreateProxy();
        }
    }
}
