using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Raptor.PCL.Common;
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

        public async Task<ReturnSet<bool>> LoadDetailData(int levelID) {
#if DEBUG
            DetailItem = new LevelCreationBrowserDetailResponseItem {
                Dislikes = 1,
                Likes = 100,
                LongDescription = "This is a really long level description",
                Name = "Test",
                NumDownloads = 1001,
                Reviews = new List<string>()
            };
#else
            var levelCreationHandler = new LevelCreationBrowserHandler(null);

            var result = await levelCreationHandler.GetLevelDetail(levelID);

            if (result.HasError) {
                throw new Exception(result.ExceptionMessage);
            }

            DetailItem = result.ReturnValue;
#endif
            return new ReturnSet<bool>(true);
        }

        public async Task<ReturnSet<bool>> LoadData() {
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
            return new ReturnSet<bool>(true);
        }
    }
}