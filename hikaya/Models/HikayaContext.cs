using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace hikaya.Models
{
    public partial class HikayaContext : DbContext
    {
        public HikayaContext()
            : base("name=HikayaContext1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<FeaturedMessage> FeaturedMessages { get; set; }
        public virtual DbSet<SavedStory> SavedStories { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<StoryPlot> StoryPlots { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>()
                .HasMany(e => e.StoryPlots)
                .WithOptional(e => e.Story)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Admin)
                .WithRequired(e => e.User);
        }
    }
}
