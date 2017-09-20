using System.Threading.Tasks;
using Raptor.Library.Common;
using Raptor.Library.WebAPI.Common;
using Raptor.Library.WebAPI.Transports.Levels;

namespace Raptor.Library.WebAPI.Handlers {
    public class LevelCreationHandler : BaseHandler {
        public LevelCreationHandler(HandlerWrapperItem wrapperItem) : base(wrapperItem) { }

        protected override string BaseControllerName() => "LevelCreation";

        public async Task<ReturnSet<LevelResponseItem>> GetLevelAsync(int levelID)
            => await GetAsync<ReturnSet<LevelResponseItem>>($"levelID={levelID}");

        public async Task<ReturnSet<bool>> DeleteLevelAsync(int levelID)
            => await DeleteAsync($"levelID={levelID}");

        public async Task<ReturnSet<bool>> AddLevelAsync(LevelCreationRequestItem requestItem)
            => await PutAsync<LevelCreationRequestItem, ReturnSet<bool>>(requestItem);

        public async Task<ReturnSet<bool>> UpdateLevelAsync(LevelCreationUpdateRequestItem requestItem)
            => await PostAsync<LevelCreationUpdateRequestItem, ReturnSet<bool>>(requestItem);
    }
}