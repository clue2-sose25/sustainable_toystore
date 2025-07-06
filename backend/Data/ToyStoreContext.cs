using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class ToyStoreContext : DbContext
    {
        public ToyStoreContext(DbContextOptions<ToyStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Toy>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Toys)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action Figures" },
                new Category { Id = 2, Name = "Dolls" },
                new Category { Id = 3, Name = "Puzzles" }
            );

            modelBuilder.Entity<Toy>().HasData(
                new Toy { Id = 1, Name = "Superman Figure", CategoryId = 1 },
                new Toy { Id = 2, Name = "Barbie Doll", CategoryId = 2 },
                new Toy { Id = 3, Name = "Jigsaw Puzzle", CategoryId = 3 }
            );
        }
    }
}