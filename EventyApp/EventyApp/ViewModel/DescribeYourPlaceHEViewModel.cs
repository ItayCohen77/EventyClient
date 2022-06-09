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

        private bool featureOneBool;

        public bool FeatureOneBool
        {
            get => featureOneBool;
            set
            {
                if(value!=featureOneBool)
                {
                    featureOneBool = value;
                    OnPropertyChanged("FeatureOneBool");
                }
            }

        }

        private bool featureTwoBool;

        public bool FeatureTwoBool
        {
            get => featureTwoBool;
            set
            {
                if (value != featureTwoBool)
                {
                    featureTwoBool = value;
                    OnPropertyChanged("FeatureTwoBool");
                }
            }

        }

        private bool featureThreeBool;

        public bool FeatureThreeBool
        {
            get => featureThreeBool;
            set
            {
                if (value != featureThreeBool)
                {
                    featureThreeBool = value;
                    OnPropertyChanged("FeatureThreeBool");
                }
            }

        }

        private bool featureFourBool;

        public bool FeatureFourBool
        {
            get => featureFourBool;
            set
            {
                if (value != featureFourBool)
                {
                    featureFourBool = value;
                    OnPropertyChanged("FeatureFourBool");
                }
            }

        }

        private bool featureFiveBool;

        public bool FeatureFiveBool
        {
            get => featureFiveBool;
            set
            {
                if (value != featureFiveBool)
                {
                    featureFiveBool = value;
                    OnPropertyChanged("FeatureFiveBool");
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

        private string desError;
        public string DesError
        {
            get
            {
                return this.desError;
            }
            set
            {
                if (this.desError != value)
                {
                    this.desError = value;
                    OnPropertyChanged(nameof(DesError));
                }
            }
        }

        private bool showDesError;
        public bool ShowDesError
        {
            get
            {
                return this.showDesError;
            }
            set
            {
                if (this.showDesError != value)
                {
                    this.showDesError = value;
                    OnPropertyChanged(nameof(ShowDesError));
                }
            }
        }

        private void ValidateDes()
        {
            if (Description == null)
            {
                this.DesError = "Please fill the description entry";
                this.ShowDesError = true;
            }
            else
            {
                this.ShowDesError = false;
            }
        }

        private bool ValidateForm()
        {
            ValidateDes();

            return !(ShowDesError);
        }

        public ICommand NextCommand => new Command(Next);
        private void Next()
        {
            if(ValidateForm())
            {
                Push?.Invoke(new EventyApp.Views.HostEstateView.UploadPicsHEView(this.TypePlace, this.FeatureOneBool, this.FeatureTwoBool, this.FeatureThreeBool, this.FeatureFourBool, this.FeatureFiveBool, this.Description));
            }            
        }

        public DescribeYourPlaceHEViewModel(string typePlace)
        {
            this.TypePlace = typePlace;

            this.ApartmentF = new List<string>();
            this.ApartmentF.Add("TV");
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
                this.FeatureOne = this.ApartmentF[0];
                this.FeatureTwo = this.ApartmentF[1];
                this.FeatureThree = this.ApartmentF[2];
                this.FeatureFour = this.ApartmentF[3];
                this.FeatureFive = this.ApartmentF[4];
            }
            else if(this.TypePlace == "House backyard")
            {
                this.FeatureOne = this.YardF[0];
                this.FeatureTwo = this.YardF[1];
                this.FeatureThree = this.YardF[2];
                this.FeatureFour = this.YardF[3];
                this.FeatureFive = this.YardF[4];
            }
            else if(this.TypePlace == "Private house")
            {
                this.FeatureOne = this.PrivateHF[0];
                this.FeatureTwo = this.PrivateHF[1];
                this.FeatureThree = this.PrivateHF[2];
                this.FeatureFour = this.PrivateHF[3];
                this.FeatureFive = this.PrivateHF[4];
            }
            else
            {
                this.FeatureOne = this.HallF[0];
                this.FeatureTwo = this.HallF[1];
                this.FeatureThree = this.HallF[2];
                this.FeatureFour = this.HallF[3];
                this.FeatureFive = this.HallF[4];
            }
        }
    }
}
