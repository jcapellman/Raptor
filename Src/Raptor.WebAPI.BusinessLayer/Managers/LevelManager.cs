using System;
using System.Linq;

using Raptor.Library.Common;
using Raptor.Library.WebAPI.Transports.Levels;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;
using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class LevelManager : BaseManager {
        public LevelManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<bool> Create(LevelCreationRequestItem requestItem) {
            try {
                using (var eFactory = new EntityFactory(DatabaseConnection)) {
                    var level = new Levels {
                        UserGUID = CurrentUserGUID,
                        LevelData = requestItem.LevelData,
                        LevelDescription = requestItem.LevelDescription,
                        LevelName = requestItem.LevelName
                    };

                    eFactory.Levels.Add(level);
                    eFactory.SaveChanges();

                    return new ReturnSet<bool>(true);
                }
            } catch (Exception ex) {
                return new ReturnSet<bool>(ex);
            }
        }

        public ReturnSet<bool> Update(LevelCreationUpdateRequestItem requestItem) {
            try {
                using (var eFactory = new EntityFactory(DatabaseConnection)) {
                    var level = eFactory.Levels.FirstOrDefault(a => a.ID == requestItem.LevelID && a.UserGUID == CurrentUserGUID && a.Active);

                    if (level == null) {
                        throw new Exception($"Level {requestItem.LevelID} could not be found");
                    }

                    level.LevelData = requestItem.LevelData;
                    level.LevelDescription = requestItem.LevelDescription;
                    level.LevelName = requestItem.LevelName;
                
                    eFactory.SaveChanges();

                    return new ReturnSet<bool>(true);
                }
            } catch (Exception ex) {
                return new ReturnSet<bool>(ex);
            }
        }

        public ReturnSet<bool> Delete(int levelID) {
            try {
                using (var eFactory = new EntityFactory(DatabaseConnection)) {
                    var level = eFactory.Levels.FirstOrDefault(a => a.ID == levelID && a.UserGUID == CurrentUserGUID && a.Active);

                    if (level == null) {
                        throw new Exception($"Level {levelID} could not be found");
                    }

                    return new ReturnSet<bool>(true);
                }
            } catch (Exception ex) {
                return new ReturnSet<bool>(ex);
            }
        }

        public ReturnSet<LevelResponseItem> Get(int levelID) {
            try {
                using (var eFactory = new EntityFactory(DatabaseConnection)) {
                    var level = eFactory.Levels.FirstOrDefault(a => a.ID == levelID && a.UserGUID == CurrentUserGUID && a.Active);

                    if (level == null) {
                        throw new Exception($"Level {levelID} could not be found");
                    }

                    var respone = new LevelResponseItem {
                        LevelID = levelID,
                        LevelData = level.LevelData,
                        LevelDescription = level.LevelDescription,
                        LevelName = level.LevelName
                    };
                    
                    return new ReturnSet<LevelResponseItem>(respone);
                }
            } catch (Exception ex) {
                return new ReturnSet<LevelResponseItem>(ex);
            }
        }
    }
}