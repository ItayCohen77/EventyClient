using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EventyApp.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using Newtonsoft.Json;

namespace EventyApp.Services
{
    class EventyAPIProxy
    {
        private const string CLOUD_URL = "TBD"; //API url when going on the cloud
        private const string CLOUD_PHOTOS_URL = "TBD";
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:44409/EventyAPI"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://10.0.2.2:44409/EventyAPI"; //API url when using physucal device on android
        private const string DEV_WINDOWS_URL = "https://localhost:44409/EventyAPI"; //API url when using windoes on development
        private const string DEV_ANDROID_EMULATOR_PHOTOS_URL = "http://10.0.2.2:44409/Images/"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_PHOTOS_URL = "http://10.0.2.2:44409/Images/"; //API url when using physucal device on android
        private const string DEV_WINDOWS_PHOTOS_URL = "https://localhost:44409/Images/"; //API url when using windoes on development

        private HttpClient client;
        private string baseUri;
        private string basePhotosUri;
        private static EventyAPIProxy proxy = null;

        public static EventyAPIProxy CreateProxy()
        {
            string baseUri;
            string basePhotosUri;
            if (App.IsDevEnv)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (DeviceInfo.DeviceType == DeviceType.Virtual)
                    {
                        baseUri = DEV_ANDROID_EMULATOR_URL;
                        basePhotosUri = DEV_ANDROID_EMULATOR_PHOTOS_URL;
                    }
                    else
                    {
                        baseUri = DEV_ANDROID_PHYSICAL_URL;
                        basePhotosUri = DEV_ANDROID_PHYSICAL_PHOTOS_URL;
                    }
                }
                else
                {
                    baseUri = DEV_WINDOWS_URL;
                    basePhotosUri = DEV_WINDOWS_PHOTOS_URL;
                }
            }
            else
            {
                baseUri = CLOUD_URL;
                basePhotosUri = CLOUD_PHOTOS_URL;
            }

            if (proxy == null)
                proxy = new EventyAPIProxy(baseUri, basePhotosUri);
            return proxy;
        }


        private EventyAPIProxy(string baseUri, string basePhotosUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
            this.basePhotosUri = basePhotosUri;
        }

        public string GetBasePhotoUri() { return this.basePhotosUri; }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/login?email={email}&password={password}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    User returnedAccount = JsonConvert.DeserializeObject<User>(jsonContent);

                    return returnedAccount;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> UploadImage(Models.FileInfo fileInfo)
        {
            try
            {
                var multipartFormDataContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(fileInfo.Name));
                multipartFormDataContent.Add(fileContent, "file", "kuku.jpg");
                HttpResponseMessage response = await client.PostAsync($"{this.baseUri}/UploadImage", multipartFormDataContent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<User> SignUp(string email, string password, string fName, string lName, DateTime birthdate, string phonenumber)
        {
            try
            {
                User a = new User()
                {
                    Email = email,
                    Pass = password,
                    FirstName = fName,
                    LastName = lName,
                    BirthDate = birthdate,
                    PhoneNumber = phonenumber,
                    ProfileImage = "default_pfp.jpg"
                };

                string json = JsonConvert.SerializeObject(a);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{this.baseUri}/signup";
                HttpResponseMessage response = await this.client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerSettings options = new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    };

                    string jsonContent = await response.Content.ReadAsStringAsync();
                    User returnedAccount = JsonConvert.DeserializeObject<User>(jsonContent, options);
                    return returnedAccount;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool?> EmailExists(string email)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/email-exists?email={email}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    bool? b = JsonConvert.DeserializeObject<bool?>(content);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
