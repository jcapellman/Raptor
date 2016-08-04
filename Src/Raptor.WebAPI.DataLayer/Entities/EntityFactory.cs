using System.Data.Entity;
using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.DataLayer.Entities {
    public class EntityFactory : DbContext {
        public DbSet<Content> Content { get; set; }
    }
}