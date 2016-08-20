using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Levels;

using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class LevelManager : BaseManager {
        public LevelManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<bool> CreateUpdate(LevelCreationRequestItem requestItem) {
            return new ReturnSet<bool>(true);
        }

        public ReturnSet<bool> Delete(int levelID)
        {
            throw new System.NotImplementedException();
        }
    }
}