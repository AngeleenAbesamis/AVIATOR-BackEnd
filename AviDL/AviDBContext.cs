using System;
using AviModels;
using Microsoft.EntityFrameworkCore;


namespace AviDL
{
    public class AviDBContext : DbContext
    {
        public AviDBContext(DbContextOptions options) : base(options) {}
        protected AviDBContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<SceneFile> SceneFiles { get; set; }
        public DbSet<Pilot> Pilots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contributor>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Script>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Scene>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<File>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SceneFile>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SceneFile>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pilot>()
                .Property(x => x.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pilot>()
               .HasOne(p => p.Script)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
  
}
