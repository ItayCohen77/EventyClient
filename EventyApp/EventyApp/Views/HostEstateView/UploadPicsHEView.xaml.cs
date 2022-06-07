using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventyApp.ViewModel;

namespace EventyApp.Views.HostEstateView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPicsHEView : ContentPage
    {
        public UploadPicsHEView(string typePlace, bool featureOneBool, bool featureTwoBool, bool featureThreeBool, bool featureFourBool, bool featureFiveBool, string description)
        {
            UploadPicsHEViewModel upload = new UploadPicsHEViewModel(typePlace, featureOneBool, featureTwoBool, featureThreeBool, featureFourBool, featureFiveBool, description);
            this.BindingContext = upload;
            upload.SetImageSourceEvent += ChangeImagesSource;
            upload.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
        public void ChangeImagesSource(ImageSource imgSource, string num)
        {
            switch (num)
            {
                case "1":
                    ImageOne.Source = imgSource;
                    break;
                case "2":
                    ImageTwo.Source = imgSource;
                    break;
                case "3":
                    ImageThree.Source = imgSource;
                    break;
                case "4":
                    ImageFour.Source = imgSource;
                    break;
                case "5":
                    ImageFive.Source = imgSource;
                    break;
                case "6":
                    ImageSix.Source = imgSource;
                    break;
            }          
        }
    }
}