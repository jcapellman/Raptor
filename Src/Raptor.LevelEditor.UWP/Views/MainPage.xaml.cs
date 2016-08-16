using Windows.UI.Xaml.Controls;

using Raptor.LevelEditor.UWP.ViewModels;

namespace Raptor.LevelEditor.UWP.Views {
    public sealed partial class MainPage : Page {
        private MainPageViewModel viewModel => (MainPageViewModel) DataContext;

        public MainPage() {
            this.InitializeComponent();

            DataContext = new MainPageViewModel();
        }
    }
}