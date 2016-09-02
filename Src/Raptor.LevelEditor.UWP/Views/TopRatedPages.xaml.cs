using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Raptor.LevelEditor.UWP.ViewModels;
using Raptor.PCL.WebAPI.Transports.LevelCreationBrowser;

namespace Raptor.LevelEditor.UWP.Views {
    public sealed partial class TopRatedLevelsPages {
        private TopRatedPageViewModel viewModel => (TopRatedPageViewModel)DataContext;

        public TopRatedLevelsPages() {
            this.InitializeComponent();

            DataContext = new TopRatedPageViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            var result = await viewModel.LoadData();

            if (result.HasError) {
                ShowMessage(result.ExceptionMessage);
            }
        }

        private async void AgvLevels_OnItemClick(object sender, ItemClickEventArgs e) {
            var item = (e.ClickedItem as LevelCreationBrowserResponseItem);
            
            if (item == null) {
                return;
            }

            var result = await viewModel.LoadDetailData(item.ID);

            if (result.HasError) {
                ShowMessage(result.ExceptionMessage);

                return;
            }

            if (!svLevel.IsPaneOpen) {
                svLevel.IsPaneOpen = true;
            }
        }
    }
}