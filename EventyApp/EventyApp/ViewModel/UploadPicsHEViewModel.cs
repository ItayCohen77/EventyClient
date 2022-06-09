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
    public class UploadPicsHEViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        public event Action<ImageSource,string> SetImageSourceEvent;

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

        private string picError;
        public string PicError
        {
            get
            {
                return this.picError;
            }
            set
            {
                if (this.picError != value)
                {
                    this.picError = value;
                    OnPropertyChanged(nameof(PicError));
                }
            }
        }

        private bool showPicError;
        public bool ShowPicError
        {
            get
            {
                return this.showPicError;
            }
            set
            {
                if (this.showPicError != value)
                {
                    this.showPicError = value;
                    OnPropertyChanged(nameof(ShowPicError));
                }
            }
        }

        private void ValidatePic()
        {
            if (ImageOne == null || ImageTwo == null || ImageThree == null || ImageFour == null || ImageFive == null || ImageSix == null)
            {
                this.PicError = "Please upload all 6 pictures";
                this.ShowPicError = true;
            }
            else
            {
                this.ShowPicError = false;
            }
        }

        private bool ValidateForm()
        {
            ValidatePic();

            return !(ShowPicError);
        }

        public ICommand NextCommand => new Command(Next);
        private void Next()
        {
            if(ValidateForm())
            {
                Push?.Invoke(new EventyApp.Views.HostEstateView.LocationHEView(this.TypePlace, this.FeatureOneBool, this.FeatureTwoBool, this.FeatureThreeBool, this.FeatureFourBool, this.FeatureFiveBool, this.Description, this.ImageOne, this.ImageTwo, this.ImageThree, this.ImageFour, this.ImageFive, this.ImageSix));
            }           
        }

        public Command UploadCommand => new Command<string>((n) => Upload(n));
        public async void Upload(string num)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
                {
                    Title = "Pick a profile picture"
                });

                if (result != null)
                {
                    switch(num)
                    {
                        case "1":
                            this.ImageOne = result;
                            break;
                        case "2":
                            this.ImageTwo = result;
                            break;
                        case "3":
                            this.ImageThree = result;
                            break;
                        case "4":
                            this.ImageFour = result;
                            break;
                        case "5":
                            this.ImageFive = result;
                            break;
                        case "6":
                            this.ImageSix = result;
                            break;
                    }                 

                    var stream = await result.OpenReadAsync();
                    ImageSource imgSource = ImageSource.FromStream(() => stream);

                    if (SetImageSourceEvent != null)
                        SetImageSourceEvent(imgSource, num);                 
                }
            }
            else
            {
                // add error popup
            }
        }

        public UploadPicsHEViewModel(string typePlace, bool featureOneBool, bool featureTwoBool, bool featureThreeBool, bool featureFourBool, bool featureFiveBool, string description)
        {
            this.TypePlace = typePlace;
            this.FeatureOneBool = featureOneBool;
            this.FeatureTwoBool = featureTwoBool;
            this.FeatureThreeBool = featureThreeBool;
            this.FeatureFourBool = featureFourBool;
            this.FeatureFiveBool = featureFiveBool;
            this.Description = description;
        }
    }
}
