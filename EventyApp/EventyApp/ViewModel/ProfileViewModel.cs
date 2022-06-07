using EventyApp.Models;
using EventyApp.Services;
using EventyApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace EventyApp.ViewModel
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Action<Page> Push;
        private EventyAPIProxy proxy;
        private FileResult imageFileResult;
        public event Action<ImageSource> SetImageSourceEvent;

        private bool notlogIn;
        public bool NotLogIn
        {
            get
            {
                return this.notlogIn;
            }
            set
            {
                if (this.notlogIn != value)
                {
                    this.notlogIn = value;
                    OnPropertyChanged(nameof(NotLogIn));
                }
            }
        }

        private bool yeslogIn;
        public bool YesLogIn
        {
            get
            {
                return this.yeslogIn;
            }
            set
            {
                if (this.yeslogIn != value)
                {
                    this.yeslogIn = value;
                    OnPropertyChanged(nameof(YesLogIn));
                }
            }
        }

        private string profileImage;
        public string ProfileImage
        {
            get
            {
                return this.profileImage;
            }
            set
            {
                if (this.profileImage != value)
                {
                    this.profileImage = value;
                    OnPropertyChanged(nameof(ProfileImage));
                }
            }
        }

        private User user;
        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                if (this.user != value)
                {
                    this.user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        private string fullname;
        public string FullName
        {
            get
            {
                return this.fullname;
            }
            set
            {
                if (this.fullname != value)
                {
                    this.fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private DateTime joinedAt;
        public DateTime JoinedAt
        {
            get
            {
                return this.joinedAt;
            }
            set
            {
                if (this.joinedAt != value)
                {
                    this.joinedAt = value;
                    OnPropertyChanged(nameof(JoinedAt));
                }
            }
        }

        public ProfileViewModel()
        {
            proxy = EventyAPIProxy.CreateProxy();
            LoadProfile();
        }

        public void LoadProfile()
        {
            User = ((App)App.Current).CurrentUser;

            if (User == null)
            {
                NotLogIn = true;
                YesLogIn = false;
            }
            else
            {
                NotLogIn = false;
                YesLogIn = true;
                FullName = $"{User.FirstName} {User.LastName}";
                JoinedAt = User.CreatedAt.Date;
                ProfileImage = $"{proxy.baseUri}/imgs/{User.ProfileImage}";
            }
        }

        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new LoginView());
        }

        public ICommand LogOutCommand => new Command(LogOut);
        private void LogOut()
        {
            //bool success = await proxy.Logout();
            //if (success)
            //{
                ((App)App.Current).CurrentUser = null;
                Push?.Invoke(new TabControlView());
            //}
        }

        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            Push?.Invoke(new SignUpView());
        }
        public ICommand HostCommand => new Command(Host);
        private void Host()
        {
            Push?.Invoke(new EventyApp.Views.HostEstateView.WelcomeHEView());
        }
        public ICommand EditCommand => new Command(Edit);
        private void Edit()
        {
            Push?.Invoke(new EventyApp.Views.EditUserInfoView());
        }

        public Command ChangePfpCommand => new Command(() => ChangePfp());
        public async void ChangePfp()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
                {
                    Title = "Pick a profile picture"
                });

                if (result != null)
                {
                    this.imageFileResult = result;

                    var stream = await result.OpenReadAsync();
                    ImageSource imgSource = ImageSource.FromStream(() => stream);
                    if (SetImageSourceEvent != null)
                        SetImageSourceEvent(imgSource);
                    bool uploadImageSuccess = await proxy.UploadImage(imageFileResult.FullPath, $"a{User.Id}.jpg");
                    if (uploadImageSuccess)
                        User.ProfileImage = $"a{User.Id}.jpg";
                }
            }
            else
            {
                // add error popup
            }
        }
    }
}
