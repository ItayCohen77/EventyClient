using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Services;
using EventyApp.Views;
using EventyApp.Models;
using Xamarin.Essentials;
using System.Linq;
//using EventyApp.AppFonts;
using System.Collections.ObjectModel;

namespace EventyApp.ViewModel
{
    internal class UploadPicsHEViewModel
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

        public ICommand NextCommand => new Command(Next);
        private void Next()
        {
            Push?.Invoke(new EventyApp.Views.HostEstateView.LocationHEView(this.TypePlace, this.FeatureOne, this.FeatureTwo, this.FeatureThree, this.FeatureFour, this.FeatureFive, this.Description ,this.ImageOne, this.ImageTwo, this.ImageThree, this.ImageFour, this.ImageFive, this.ImageSix));
        }

        public Command UploadCommand => new Command(() => Upload());
        public async void Upload()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
                {
                    Title = "Pick a profile picture"
                });

                //if (result != null)
                //{
                //    this.imageFileResult = result;

                //    var stream = await result.OpenReadAsync();
                //    ImageSource imgSource = ImageSource.FromStream(() => stream);
                //    if (SetImageSourceEvent != null)
                //        SetImageSourceEvent(imgSource);
                //    bool uploadImageSuccess = await proxy.UploadImage(imageFileResult.FullPath, $"p{Place.Id}.jpg");
                //    if (uploadImageSuccess)
                //        User.ProfileImage = $"a{User.Id}.jpg";
                //}
            }
            else
            {
                // add error popup
            }
        }

        public UploadPicsHEViewModel(string typePlace, string featureOne, string featureTwo, string featureThree, string featureFour, string featureFive, string description)
        {
            this.TypePlace = typePlace;
            this.FeatureOne = featureOne;
            this.FeatureTwo = featureTwo;
            this.FeatureThree = featureThree;
            this.FeatureFour = featureFour;
            this.FeatureFive = featureFive;
            this.Description = description;
            this.ImageOne = "default_pl.jpg";
            this.ImageTwo = "default_pl.jpg";
            this.ImageThree = "default_pl.jpg";
            this.ImageFour = "default_pl.jpg";
            this.ImageFive = "default_pl.jpg";
            this.ImageSix = "default_pl.jpg";
        }
    }
}
