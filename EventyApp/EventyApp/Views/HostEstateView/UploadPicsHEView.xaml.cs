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
        public UploadPicsHEView(string typePlace, string featureOne, string featureTwo, string featureThree, string featureFour, string featureFive, string description)
        {
            UploadPicsHEViewModel upload = new UploadPicsHEViewModel(typePlace, featureOne, featureTwo, featureThree, featureFour, featureFive, description);
            this.BindingContext = upload;
            upload.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}