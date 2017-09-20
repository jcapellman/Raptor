using System.Collections.Generic;
using System.Threading.Tasks;
using Raptor.Library.Common;
using Raptor.Library.WebAPI.Common;
using Raptor.Library.WebAPI.Transports.LevelCreationBrowser;

namespace Raptor.Library.WebAPI.Handlers {
    public class LevelCreationBrowserHandler : BaseHandler {
        protected override string BaseControllerName() => "LevelCreationBrowser";

        public async Task<ReturnSet<List<LevelCreationBrowserResponseItem>>> GetLevelListing()
            => await GetAsync<ReturnSet<List<LevelCreationBrowserResponseItem>>>();

        public async Task<ReturnSet<LevelCreationBrowserDetailResponseItem>> GetLevelDetail(int levelID)
            => await GetAsync<ReturnSet<LevelCreationBrowserDetailResponseItem>>($"levelID={levelID}");

        public LevelCreationBrowserHandler(HandlerWrapperItem wrapperItem) : base(wrapperItem) { }
    }
}