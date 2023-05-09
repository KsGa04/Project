using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project
{
    public partial class CookingBookContext : DbContext
    {
        public CookingBookContext()
        {
        }

        public CookingBookContext(DbContextOptions<CookingBookContext> options)
            : base(options)
        {
        }
        private string _databasePath;
        public virtual DbSet<Administrator> Administrators { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Meal> Meals { get; set; }

        public virtual DbSet<Moderator> Moderators { get; set; }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public CookingBookContext(string databasePath)
        {
            _databasePath = databasePath;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Administrator>(entity =>
        //    {
        //        entity.HasKey(e => e.IdAdministrator).HasName("PK__Administ__27833EB911B77CA9");

        //        entity.ToTable("Administrator");

        //        entity.Property(e => e.Mail).HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.HasKey(e => e.IdCategory).HasName("PK__Category__CBD74706587D227F");

        //        entity.ToTable("Category");

        //        entity.Property(e => e.ImageCategory).HasColumnType("image");
        //    });

        //    modelBuilder.Entity<Comment>(entity =>
        //    {
        //        entity.HasKey(e => e.IdComment).HasName("PK__Comment__57C9AD58D20D0EF7");

        //        entity.ToTable("Comment");

        //        entity.Property(e => e.DateComement).HasColumnType("datetime");

        //        entity.HasOne(d => d.IdRecipeNavigation).WithMany(p => p.Comments)
        //            .HasForeignKey(d => d.IdRecipe)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK__Comment__IdRecip__398D8EEE");

        //        entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Comments)
        //            .HasForeignKey(d => d.IdUser)
        //            .HasConstraintName("FK__Comment__IdUser__38996AB5");
        //    });

        //    modelBuilder.Entity<Meal>(entity =>
        //    {
        //        entity.HasKey(e => e.IdMeal).HasName("PK__Meal__4D7C3B3A7991B1AE");

        //        entity.ToTable("Meal");

        //        entity.Property(e => e.ImageMeal).HasColumnType("image");

        //        entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Meals)
        //            .HasForeignKey(d => d.IdCategory)
        //            .HasConstraintName("FK__Meal__IdCategory__267ABA7A");
        //    });

        //    modelBuilder.Entity<Moderator>(entity =>
        //    {
        //        entity.HasKey(e => e.IdModerator).HasName("PK__Moderato__39AD95824135A023");

        //        entity.ToTable("Moderator");

        //        entity.Property(e => e.DateOfBirth).HasColumnType("date");
        //        entity.Property(e => e.Mail).HasMaxLength(50);
        //        entity.Property(e => e.NikName).HasMaxLength(50);

        //        entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Moderators)
        //            .HasForeignKey(d => d.IdCategory)
        //            .HasConstraintName("FK__Moderator__IdCat__2B3F6F97");
        //    });

        //    modelBuilder.Entity<Recipe>(entity =>
        //    {
        //        entity.HasKey(e => e.IdRecipe).HasName("PK__Recipe__2FEC16D488E94528");

        //        entity.ToTable("Recipe");

        //        entity.Property(e => e.ImageRecipe).HasColumnType("image");

        //        entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Recipes)
        //            .HasForeignKey(d => d.IdCategory)
        //            .OnDelete(DeleteBehavior.Cascade)
        //            .HasConstraintName("FK__Recipe__IdCatego__30F848ED");

        //        entity.HasOne(d => d.IdMealNavigation).WithMany(p => p.Recipes)
        //            .HasForeignKey(d => d.IdMeal)
        //            .HasConstraintName("FK__Recipe__IdMeal__31EC6D26");

        //        entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Recipes)
        //            .HasForeignKey(d => d.IdUser)
        //            .OnDelete(DeleteBehavior.Cascade)
        //            .HasConstraintName("FK__Recipe__IdUser__300424B4");
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C9263887E7A06E");

        //        entity.Property(e => e.DateOfBirth).HasColumnType("date");
        //        entity.Property(e => e.Mail).HasMaxLength(50);
        //        entity.Property(e => e.NikName).HasMaxLength(50);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
