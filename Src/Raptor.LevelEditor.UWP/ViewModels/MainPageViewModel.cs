using System.Threading.Tasks;

using Windows.UI.Xaml;

using Raptor.PCL.WebAPI.Transports.Users;

namespace Raptor.LevelEditor.UWP.ViewModels {
    public class MainPageViewModel : BaseViewModel {
        private bool _isOnline;

        public bool IsOnline { get { return _isOnline; } set { _isOnline = value; OnPropertyChanged(); } }

        private UserResponseItem _currentUser;

        public UserResponseItem CurrentUser { get { return _currentUser; } set { _currentUser = value; OnPropertyChanged(); } }

        public string WelcomeDisplay {
            get {
                var username = "GUEST, please login";

                if (CurrentUser != null) {
                    username = $"back {CurrentUser.DisplayName}";
                }

                return $"Welcome {username}";
            }
        }

        public static Visibility CheckUser(UserResponseItem user) =>
            (user != null ? Visibility.Visible : Visibility.Collapsed);

        public async Task<bool> LoadData() {
            IsOnline = App.HasInternet;

            CurrentUser = App.CurrentUser;

            return true;
        }
    }
}