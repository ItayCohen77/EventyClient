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
        public UploadPicsHEView()
        {
            UploadPicsHEViewModel upload = new UploadPicsHEViewModel();
            this.BindingContext = upload;
            upload.SetImageSourceEvent += OnSetImageSource;
            upload.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
            itemImage.Source = ((Item)item).ImgSource;
        }

        private void ToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopUpAddImage(this.BindingContext));
        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            itemImage.Source = imgSource;
        }
    }
}