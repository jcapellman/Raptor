using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.Levels;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class LevelManager : BaseManager {
        public LevelManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<bool> Create(LevelCreationRequestItem requestItem) {
            return new ReturnSet<bool>(true);
        }

        public ReturnSet<bool> Update(LevelCreationRequestItem requestItem) {
            return new ReturnSet<bool>(true);
        }

        public ReturnSet<bool> Delete(int levelID) {
            throw new System.NotImplementedException();
        }

        public ReturnSet<LevelResponseItem> Get(int levelID) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                return new ReturnSet<LevelResponseItem>();
            }
        }

    }
}