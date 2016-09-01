using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Raptor.PCL.WebAPI.Handlers;
using Raptor.PCL.WebAPI.Transports.LevelCreationBrowser;

namespace Raptor.LevelEditor.UWP.ViewModels {
    public class TopRatedPageViewModel : BaseViewModel {
        private ObservableCollection<LevelCreationBrowserResponseItem> _levels;

        public ObservableCollection<LevelCreationBrowserResponseItem> Levels {
            get { return _levels; }
            set { _levels = value; OnPropertyChanged(); }
        }

        public async Task<bool> LoadData() {
            var levelCreationHandler = new LevelCreationBrowserHandler(null);

            var result = await levelCreationHandler.GetLevelListing();

            if (result.HasError) {
                throw new Exception(result.ExceptionMessage);
            }

            Levels = new ObservableCollection<LevelCreationBrowserResponseItem>(result.ReturnValue);

            return true;
        }
    }
}