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
    class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;

        public SignUpViewModel()
        {
            this.SignUpCommand = new Command(() => SignUp());

            proxy = EventyAPIProxy.CreateProxy();
        }

        #region Email
        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private bool showAgeError;

        public bool ShowAgeError
        {
            get => showAgeError;
            set
            {
                showAgeError = value;
                OnPropertyChanged("ShowAgeError");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }


        private string firstname;
        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            set
            {
                if (this.firstname != value)
                {
                    this.firstname = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string lastname;
        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                if (this.lastname != value)
                {
                    this.lastname = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string comfirmpassword;
        public string ConfirmPassword
        {
            get
            {
                return this.comfirmpassword;
            }
            set
            {
                if (this.comfirmpassword != value)
                {
                    this.comfirmpassword = value;
                    OnPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }

        private DateTime birthdate;
        public DateTime BirthDate
        {
            get
            {
                return this.birthdate;
            }
            set
            {
                if (this.birthdate != value)
                {
                    this.birthdate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        private string phonenum;
        public string PhoneNum
        {
            get
            {
                return this.phonenum;
            }
            set
            {
                if (this.phonenum != value)
                {
                    this.phonenum = value;
                    OnPropertyChanged(nameof(PhoneNum));
                }
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private string ageError;

        public string AgeError
        {
            get => ageError;
            set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }

        private async void ValidateEmail()
        {
            bool? exists = await proxy.EmailExists(Email);
            if (exists == true)
            {
                this.ShowEmailError = true;
                this.EmailError = "Email address already exists";
            }
            else if (exists == null)
            {
                ShowGeneralError = true;
                GeneralError = "Unknown error occured. Try again later";
            }
            else
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    this.ShowEmailError = addr.Address != Email;
                }
                catch
                {
                    EmailError = "Invalid email address";
                    this.ShowEmailError = true;
                }
            }

        }
        #endregion

        private void ValidateAge()
        {
            int year = BirthDate.Year;
            int currentYear = DateTime.Now.Year;

            if(currentYear - year < 18)
            {
                this.AgeError = "Must be 18 or older to sign up...";
                this.ShowAgeError = true;
            }
            else
            {
                this.ShowAgeError = false;
            }
        }

        #region Password
        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }     

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            ShowPasswordError = true;
            if (string.IsNullOrEmpty(Password))
                PasswordError = "Password cannot be blank";
            else if (Password.Length < 8)
                PasswordError = "Password must be more than 8 characters";
            else
                ShowPasswordError = false;

            ShowConfirmPasswordError = true;
            if (string.IsNullOrEmpty(ConfirmPassword))
                ConfirmPasswordError = "ConfirmPassword cannot be blank";
            else if (ConfirmPassword.Length < 8)
                ConfirmPasswordError = "ConfirmPassword must be more than 8 characters";
            else if (ConfirmPassword != Password)
                ConfirmPasswordError = "Passwords must match";
            else
                ShowConfirmPasswordError = false;
        }
        #endregion

        #region Confirm Password
        private bool showConfirmPasswordError;

        public bool ShowConfirmPasswordError
        {
            get => showConfirmPasswordError;
            set
            {
                showConfirmPasswordError = value;
                OnPropertyChanged("ShowConfirmPasswordError");
            }
        }

        private string confirmPasswordError;

        public string ConfirmPasswordError
        {
            get => confirmPasswordError;
            set
            {
                confirmPasswordError = value;
                OnPropertyChanged("ConfirmPasswordError");
            }
        }
        #endregion    

        #region General Error
        private bool showGeneralError;

        public bool ShowGeneralError
        {
            get => showGeneralError;
            set
            {
                showGeneralError = value;
                OnPropertyChanged("ShowGeneralError");
            }
        }

        private string generalError;

        public string GeneralError
        {
            get => generalError;
            set
            {
                generalError = value;
                OnPropertyChanged("GeneralError");
            }
        }
        #endregion

        private bool ValidateForm()
        {
            ValidateEmail();
            ValidatePassword();
            ValidateAge();

            return !(ShowEmailError || ShowPasswordError || ShowConfirmPasswordError || ShowAgeError);
        }

        public Command GoToLoginCommand { protected set; get; }
        private void GoToLogin()
        {

        }

        public Command SignUpCommand { protected set; get; }
        private async void SignUp()
        {
            if (ValidateForm())
            {
                User user = await proxy.SignUp(Email, Password, FirstName, LastName, BirthDate, PhoneNum);
                ((App)App.Current).CurrentUser = user;
                Push?.Invoke(new LoginView());
            }
        }
    }
}
