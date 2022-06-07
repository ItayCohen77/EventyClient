using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EventyApp.Views;
using System.ComponentModel;
using EventyApp.Services;
using EventyApp.Models;
using System.Collections.ObjectModel;
using EventyApp.Renderer;
using System.Threading;

namespace EventyApp.ViewModel
{
    class PlaceORViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private EventyAPIProxy proxy;
        public List<Feature> fList;
        public PlaceORViewModel(string city, DateTime date, int peopleAmount, TimeSpan startTime, TimeSpan endTime, int totalHours, int placeId)
        {
            this.City = city;
            this.EventDate = date;
            this.PeopleAmount = peopleAmount;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.TotalHours = totalHours;
            this.PlaceId = placeId;
            proxy = EventyAPIProxy.CreateProxy();
            fList = new List<Feature>();

            Start();

            User currentUser = ((App)App.Current).CurrentUser;
            
            if(currentUser != null)
            {
                IsLikedPlace = currentUser.LikedPlaces.Exists(p => p.PlaceId == PlaceId);
            }           
        }

        public async void Start()
        {
            await GetPlaceInfo(placeId);

            this.TypeName = Place.PlaceTypeNavigation.TypeName;

            Source = new List<SliderImage>();
            Feature = new List<Feature>();

            await GetFeaturesList();
            CreateImagesCollection();         
        }

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                if (this.startTime != value)
                {
                    this.startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                if (this.endTime != value)
                {
                    this.endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        private DateTime eventDate;
        public DateTime EventDate
        {
            get
            {
                return this.eventDate;
            }
            set
            {
                if (this.eventDate != value)
                {
                    this.eventDate = value;
                    OnPropertyChanged(nameof(EventDate));
                }
            }
        }

        private int totalHours;
        public int TotalHours
        {
            get
            {
                return this.totalHours;
            }
            set
            {
                if (this.totalHours != value)
                {
                    this.totalHours = value;
                    OnPropertyChanged(nameof(TotalHours));
                }
            }
        }

        private int peopleAmount;
        public int PeopleAmount
        {
            get
            {
                return this.peopleAmount;
            }
            set
            {
                if (this.peopleAmount != value)
                {
                    this.peopleAmount = value;
                    OnPropertyChanged(nameof(PeopleAmount));
                }
            }
        }

        private string typeName;
        public string TypeName
        {
            get
            {
                return this.typeName;
            }
            set
            {
                if (this.typeName != value)
                {
                    this.typeName = value;
                    OnPropertyChanged(nameof(TypeName));
                }
            }
        }

        private string city;
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (this.city != value)
                {
                    this.city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private int placeId;
        public int PlaceId
        {
            get
            {
                return this.placeId;
            }
            set
            {
                if (this.placeId != value)
                {
                    this.placeId = value;
                    OnPropertyChanged(nameof(PlaceId));
                }
            }
        }

        private IList<SliderImage> source;
        public IList<SliderImage> Source
        {
            get
            {
                return this.source;
            }
            set
            {
                if (this.source != value)
                {
                    this.source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }

        private ObservableCollection<SliderImage> sliderImage;
        public ObservableCollection<SliderImage> SliderImage
        {
            get
            {
                return this.sliderImage;
            }
            set
            {
                if (this.sliderImage != value)
                {
                    this.sliderImage = value;
                    OnPropertyChanged(nameof(SliderImage));
                }
            }
        }

        private IList<Feature> feature;
        public IList<Feature> Feature
        {
            get
            {
                return this.feature;
            }
            set
            {
                if (this.feature != value)
                {
                    this.feature = value;
                    OnPropertyChanged(nameof(Feature));
                }
            }
        }

        private ObservableCollection<Feature> features;
        public ObservableCollection<Feature> Features
        {
            get
            {
                return this.features;
            }
            set
            {
                if (this.features != value)
                {
                    this.features = value;
                    OnPropertyChanged(nameof(Features));
                }
            }
        }

        private Place place;
        public Place Place
        {
            get
            {
                return this.place;
            }
            set
            {
                if (this.place != value)
                {
                    this.place = value;
                    OnPropertyChanged(nameof(Place));
                }
            }
        }

        private bool isLikedPlace;
        public bool IsLikedPlace
        {
            get => isLikedPlace;
            set
            {
                isLikedPlace = value;
                OnPropertyChanged("IsLikedPlace");
            }
        }

        private async void LoadAsync(int placeId)
        {
            await GetPlaceInfo(placeId);
        }

        public Command LikePlaceCommand => new Command(() => LikePlace());
        private async void LikePlace()
        {
            bool worked = await proxy.AddLikedPlace(Place.Id);
            this.IsLikedPlace = worked;

            if (worked)
            {
                ((App)App.Current).CurrentUser.LikedPlaces.Add(new LikedPlace()
                {
                    UserId = ((App)App.Current).CurrentUser.Id,
                    PlaceId = Place.Id
                });
            }
        }

        public Command UnlikePlaceCommand => new Command(() => UnlikePlace());
        private async void UnlikePlace()
        {
            bool worked = await proxy.RemoveLikedPlace(Place.Id);
            IsLikedPlace = !worked;

            if (worked)
            {
                LikedPlace likedPlace = ((App)App.Current).CurrentUser.LikedPlaces.Find(p => p.PlaceId == Place.Id);
                if (likedPlace != null)
                    ((App)App.Current).CurrentUser.LikedPlaces.Remove(likedPlace);
            }
        }

        public async Task GetPlaceInfo(int placeId)
        {
            this.Place = await proxy.GetPlaceById(placeId);
            User currentUser = ((App)App.Current).CurrentUser;            
        }

        public async Task GetFeaturesList()
        {
            this.fList = await proxy.GetFeaturesList(Place);

            if(this.fList.Count != 0)
            {
                foreach (Feature feature in this.fList)
                {
                    this.Feature.Add(feature);
                }

                Features = new ObservableCollection<Feature>(Feature);
            }
            else
            {
                Feature f = new Feature();
                f.FeatureType = "This place does not have features";
                this.Feature.Add(f);
                Features = new ObservableCollection<Feature>(Feature);
            }
        }
        void CreateImagesCollection()
        {
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage1
            });
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage2
            });
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage3
            });
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage4
            });
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage5
            });
            Source.Add(new SliderImage
            {
                ImageUrl = Place.PlaceImage6
            });
            SliderImage = new ObservableCollection<SliderImage>(Source);
        }

        public Command DoneCommand => new Command(Done);
        private async void Done()
        {
            Order order = await proxy.MakeOrder(Place, TotalHours, EventDate, PeopleAmount, Convert.ToDateTime(StartTime.ToString()), Convert.ToDateTime(EndTime.ToString()));
            Push?.Invoke(new TabControlView());
        }
    }
}
