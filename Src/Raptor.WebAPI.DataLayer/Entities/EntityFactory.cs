using System;

using Microsoft.EntityFrameworkCore;

using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.DataLayer.Entities {
    public class EntityFactory : DbContext {
        public DbSet<Content> Content { get; set; }

        public DbSet<ContentTypes> ContentTypes { get; set; }
        
        public DbSet<Errors> Errors { get; set; }

        public DbSet<Platforms> Platforms { get; set; }

        public DbSet<HighScores> HighScores { get; set; }

        public DbSet<WebAPIRequests> WebAPIRequests { get; set; }

        public DbSet<WebAPIRequestLog> WebAPIRequestLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(databaseConnection);
        }

        public override int SaveChanges() {
            foreach (var item in ChangeTracker.Entries()) {
                if (item.State == EntityState.Deleted || item.State == EntityState.Modified ||
                    item.State == EntityState.Added) {
                    item.Property("Modified").CurrentValue = DateTimeOffset.Now;
                }

                switch (item.State) {
                    case EntityState.Deleted:
                        item.Property("Active").CurrentValue = false;
                        break;
                    case EntityState.Added:
                        item.Property("Created").CurrentValue = DateTimeOffset.Now;
                        item.Property("Active").CurrentValue = true;
                        break;
                }
            }

            return base.SaveChanges();
        }

        private readonly string databaseConnection;

        public EntityFactory(string connectionString) {
            databaseConnection = connectionString;
        }        
    }
}