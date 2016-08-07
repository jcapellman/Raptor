using System;
using System.Data.Entity;

using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.DataLayer.Entities {
    public class EntityFactory : DbContext {
        public DbSet<Content> Content { get; set; }

        public DbSet<ContentTypes> ContentTypes { get; set; }
        
        public DbSet<Errors> Errors { get; set; }

        public DbSet<Platforms> Platforms { get; set; }

        public DbSet<HighScores> HighScores { get; set; }

        public override int SaveChanges() {
            foreach (var item in ChangeTracker.Entries()) {
                if (item.State == EntityState.Deleted || item.State == EntityState.Modified ||
                    item.State == EntityState.Added) {
                    item.Member("Modified").CurrentValue = DateTimeOffset.Now;
                }

                switch (item.State) {
                    case EntityState.Deleted:
                        item.Member("Active").CurrentValue = false;
                        break;
                    case EntityState.Added:
                        item.Member("Created").CurrentValue = DateTimeOffset.Now;
                        item.Member("Active").CurrentValue = true;
                        break;
                }
            }

            return base.SaveChanges();
        }
        
        public EntityFactory(string connectionString) : base(connectionString) { }        
    }
}