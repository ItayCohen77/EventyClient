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
using EventyApp.Renderer;

namespace EventyApp.Services
{
    class EventyAPIProxy
    {
        private const string CLOUD_URL = "TBD"; //API url when going on the cloud
        private const string CLOUD_PHOTOS_URL = "TBD";
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:44409"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://10.0.2.2:44409"; //API url when using physucal device on android
        private const string DEV_WINDOWS_URL = "https://localhost:44409"; //API url when using windoes on development
        private const string DEV_ANDROID_EMULATOR_PHOTOS_URL = "http://10.0.2.2:44409/Images/"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_PHOTOS_URL = "http://10.0.2.2:44409/Images/"; //API url when using physucal device on android
        private const string DEV_WINDOWS_PHOTOS_URL = "https://localhost:44409/Images/"; //API url when using windoes on development

        private HttpClient client;
        public string baseUri;
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
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/login?email={email}&password={password}");

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
                HttpResponseMessage response = await client.PostAsync($"{this.baseUri}/EventyAPI/UploadImage", multipartFormDataContent);
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
                string url = $"{this.baseUri}/EventyAPI/signup";
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

        public async Task<Place> UploadPlace(string typePlace, bool featureOneBool, bool featureTwoBool, bool featureThreeBool, bool featureFourBool, bool featureFiveBool, string description, FileResult imageOne, FileResult imageTwo, FileResult imageThree, FileResult imageFour, FileResult imageFive, FileResult imageSix, string street, string apartment, string city, string zip, string country, int maxPeople, int costPerHour)
        {
            try
            {
                PlaceObj obj = new PlaceObj();
                User user = ((App)App.Current).CurrentUser;
                int typePlacedummy = -1;
                if(typePlace == "Apartment")
                {
                    Apartment a = new Apartment()
                    {
                        HasSpeakerAndMic = featureFiveBool,
                        HasAirConditioner = featureTwoBool,
                        HasCoffeeMachine = featureThreeBool,
                        HasTv = featureOneBool,
                        HasWaterHeater = featureFourBool
                    };

                    typePlacedummy = 1;
                    obj.apartmentObj = a;
                }
                else if(typePlace == "Hall")
                {
                    Hall h = new Hall()
                    {
                        HasSpeakerAndMic = featureThreeBool,
                        HasBar = featureFiveBool,
                        HasChairs = featureTwoBool,
                        HasProjector = featureFourBool,
                        HasTables = featureOneBool
                    };

                    typePlacedummy = 2;
                    obj.hallObj = h;
                }
                else if (typePlace == "Private house")
                {
                    PrivateHouse ph = new PrivateHouse()
                    {
                        HasSpeakerAndMic = featureFiveBool,
                        HasAirConditioner = featureTwoBool,
                        HasCoffeeMachine = featureThreeBool,
                        HasTv = featureOneBool,
                        HasWaterHeater = featureFourBool
                    };

                    apartment = "0";
                    typePlacedummy = 3;
                    obj.privateHouseObj = ph;
                }
                else
                {
                    HouseBackyard hb = new HouseBackyard()
                    {
                        HasBbq = featureTwoBool,
                        HasHotub = featureFiveBool,
                        HasChairs = featureFourBool,
                        HasPool = featureOneBool,
                        HasTables = featureThreeBool
                    };

                    typePlacedummy = 4;
                    obj.houseBackyardObj = hb;
                }

                if(apartment == null)
                {
                    apartment = "0";
                }
                
                Place place = new Place()
                {
                    PlaceType = typePlacedummy,
                    OwnerId = user.Id,
                    Price = costPerHour,
                    Summary = description,
                    PlaceImage1 = imageOne.FullPath,
                    PlaceImage2 = imageTwo.FullPath,
                    PlaceImage3 = imageThree.FullPath,
                    PlaceImage4 = imageFour.FullPath,
                    PlaceImage5 = imageFive.FullPath,
                    PlaceImage6 = imageSix.FullPath,
                    PlaceAddress = street,
                    Apartment = apartment,
                    City = city,
                    Zip = zip,
                    Country = country,
                    TotalOccupancy = maxPeople
                };

                obj.placeObj = place;

                string json = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{this.baseUri}/EventyAPI/hostplace";
                HttpResponseMessage response = await this.client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerSettings options = new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    };

                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Place returnedPlace = JsonConvert.DeserializeObject<Place>(jsonContent, options);
                    return returnedPlace;
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
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/email-exists?email={email}");
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

        //public async Task<bool> Logout()
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/logout");
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> UploadImage(string fullPath, string targetFileName)
        {
            try
            {
                var multipartFormDataContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(fullPath));
                multipartFormDataContent.Add(fileContent, "file", targetFileName);
                string url = $"{this.baseUri}/EventyAPI/uploadimage";

                HttpResponseMessage response = await client.PostAsync(url, multipartFormDataContent);
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

        public async Task<List<Place>> GetPlaces()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getplaces");
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(jsonContent);

                    return places;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<string>> GetCities()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/il-Cities.json");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();                  
                    List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(content, options);

                    return GetCitiesNameList(cities);
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
        private List<string> GetCitiesNameList(List<City> cities)
        {
            List<string> citiesName = new List<string>();

            foreach (City city in cities)
            {
                citiesName.Add(city.city);
            }
            citiesName.Remove(citiesName[0]);

            return citiesName;
        }

        public async Task<List<Place>> GetPlacesByCity(string city)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getplacesbycity?city={city.ToLower()}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(jsonContent);

                    return places;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Place> GetPlaceById(int placeId)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getplacebyid?placeId={placeId}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Place place = JsonConvert.DeserializeObject<Place>(jsonContent);

                    return place;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> AddLikedPlace(int placeID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/addlikedplace?placeID={placeID}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    bool worked = JsonConvert.DeserializeObject<bool>(content);
                    return worked;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> RemoveLikedPlace(int placeID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/removelikedplace?placeID={placeID}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    bool worked = JsonConvert.DeserializeObject<bool>(content);
                    return worked;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<Place>> GetLikedPlaces(int userID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getlikedplaces?userID={userID}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(content);
                    return places;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<Feature>> GetFeaturesList(Place p)
        {
            try
            {     
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getfeatureslist?placeId={p.Id}&placeT={p.PlaceTypeNavigation.TypeName}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Feature> features = JsonConvert.DeserializeObject<List<Feature>>(content);
                    return features;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Order> MakeOrder(Place p, int totalHours, DateTime eventDate, int peopleAmount, DateTime startTime, DateTime endTime)
        {
            try
            {
                User user = ((App)App.Current).CurrentUser;

                Order order = new Order()
                {
                    UserId = user.Id,
                    PlaceId = p.Id,
                    Price = p.Price,
                    Total = (p.Price * totalHours),
                    EventDate = eventDate,
                    AmountOfPeople = peopleAmount,
                    StartTime = startTime,
                    EndTime = endTime,
                    TotalHours = totalHours
                };

                string json = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{this.baseUri}/EventyAPI/makeorder";
                HttpResponseMessage response = await this.client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerSettings options = new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    };

                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Order returnedOrder = JsonConvert.DeserializeObject<Order>(jsonContent, options);
                    return returnedOrder;
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
        public async Task<List<Order>> GetOrders(int userID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getorders?userID={userID}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(content);
                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateProfileInfo(string firstName, string lastName, string phoneNum, string password)
        {
            try
            {
                string url = Uri.EscapeUriString($"{this.baseUri}/EventyAPI/updateprofileinfo?firstName={firstName}&lastName={lastName}&phoneNum={phoneNum}&password={password}");
                HttpResponseMessage response = await this.client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<Place>> GetEstates(int userID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/EventyAPI/getestates?userID={userID}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(content);
                    return places;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdatePlace(int totalOccupancy, string summary, string placeAddress, string apartment, string city, string zip, string country, int price, int placeId)
        {
            try
            {
                string url = Uri.EscapeUriString($"{this.baseUri}/EventyAPI/updateplaceinfo?totalOccupancy={totalOccupancy}&summary={summary}&placeAddress={placeAddress}&apartment={apartment}&city={city}&zip={zip}&country={country}&price={price}&placeId={placeId}");
                HttpResponseMessage response = await this.client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
