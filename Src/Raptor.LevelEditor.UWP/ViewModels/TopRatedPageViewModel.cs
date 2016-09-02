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

        private LevelCreationBrowserDetailResponseItem _detailItem;

        public LevelCreationBrowserDetailResponseItem DetailItem {
            get { return _detailItem; }
            set { _detailItem = value; OnPropertyChanged(); }
        }

        public async Task<bool> LoadDetailData(int levelID) {
            var levelCreationHandler = new LevelCreationBrowserHandler(null);

            var result = await levelCreationHandler.GetLevelDetail(levelID);

            if (result.HasError) {
                throw new Exception(result.ExceptionMessage);
            }

            DetailItem = result.ReturnValue;

            return true;
        }

        public async Task<bool> LoadData() {
#if DEBUG
            Levels = new ObservableCollection<LevelCreationBrowserResponseItem>();

            Levels.Add(new LevelCreationBrowserResponseItem {
                NumberDownloads = 100,
                Name = "Test"
            });

            Levels.Add(new LevelCreationBrowserResponseItem {
                NumberDownloads = 10,
                Name = "Test"
            });
#else
            var result = await levelCreationHandler.GetLevelListing();

            if (result.HasError) {
                throw new Exception(result.ExceptionMessage);
            }

            Levels = new ObservableCollection<LevelCreationBrowserResponseItem>(result.ReturnValue);
#endif
            return true;
        }
    }
}