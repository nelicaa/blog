using Microsoft.EntityFrameworkCore;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.dataAccess
{
    public class projekatDbContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags  { get; set; }
        public DbSet<Role> Roles  { get; set; }
        public DbSet<PostTag> PostTags  { get; set; }
        public DbSet<Likes> Likes  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<UserUseCase> UserUseCase { get; set; }
        public DbSet<UseCaseLogs> UseCaseLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E53VAMG\SQLEXPRESS;Initial Catalog=projekat;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Likes>().HasKey(x => new { x.UserId, x.PostId });
            modelBuilder.Entity<PostTag>().HasKey(x => new { x.TagId, x.PostId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

        }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                           // e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
