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
                new Category { Id = 3, Name = "Puzzles" },
                new Category { Id = 4, Name = "Building Blocks" },
                new Category { Id = 5, Name = "Board Games" },
                new Category { Id = 6, Name = "Remote Control" },
                new Category { Id = 7, Name = "Educational" },
                new Category { Id = 8, Name = "Outdoor & Sports" }
            );

            modelBuilder.Entity<Toy>().HasData(
                // Action Figures
                new Toy { Id = 1, Name = "Superman Figure", CategoryId = 1 },
                new Toy { Id = 2, Name = "Batman Action Figure", CategoryId = 1 },
                new Toy { Id = 3, Name = "Spider-Man Figure", CategoryId = 1 },
                new Toy { Id = 4, Name = "Wonder Woman Figure", CategoryId = 1 },

                // Dolls
                new Toy { Id = 5, Name = "Barbie Doll", CategoryId = 2 },
                new Toy { Id = 6, Name = "American Girl Doll", CategoryId = 2 },
                new Toy { Id = 7, Name = "Baby Alive Doll", CategoryId = 2 },
                new Toy { Id = 8, Name = "Ken Doll", CategoryId = 2 },

                // Puzzles
                new Toy { Id = 9, Name = "Jigsaw Puzzle", CategoryId = 3 },
                new Toy { Id = 10, Name = "1000 Piece Landscape Puzzle", CategoryId = 3 },
                new Toy { Id = 11, Name = "3D Puzzle Castle", CategoryId = 3 },
                new Toy { Id = 12, Name = "Rubik's Cube", CategoryId = 3 },

                // Building Blocks
                new Toy { Id = 13, Name = "LEGO Classic Creative Bricks", CategoryId = 4 },
                new Toy { Id = 14, Name = "LEGO City Fire Station", CategoryId = 4 },
                new Toy { Id = 15, Name = "Mega Bloks Building Set", CategoryId = 4 },
                new Toy { Id = 16, Name = "Lincoln Logs Cabin", CategoryId = 4 },

                // Board Games
                new Toy { Id = 17, Name = "Monopoly", CategoryId = 5 },
                new Toy { Id = 18, Name = "Scrabble", CategoryId = 5 },
                new Toy { Id = 19, Name = "Chess Set", CategoryId = 5 },
                new Toy { Id = 20, Name = "Candy Land", CategoryId = 5 },
                new Toy { Id = 21, Name = "Risk Strategy Game", CategoryId = 5 },

                // Remote Control
                new Toy { Id = 22, Name = "RC Racing Car", CategoryId = 6 },
                new Toy { Id = 23, Name = "RC Helicopter", CategoryId = 6 },
                new Toy { Id = 24, Name = "RC Drone with Camera", CategoryId = 6 },
                new Toy { Id = 25, Name = "RC Monster Truck", CategoryId = 6 },

                // Educational
                new Toy { Id = 26, Name = "Science Experiment Kit", CategoryId = 7 },
                new Toy { Id = 27, Name = "Learn to Code Board Game", CategoryId = 7 },
                new Toy { Id = 28, Name = "Electronic Learning Tablet", CategoryId = 7 },
                new Toy { Id = 29, Name = "Microscope Set", CategoryId = 7 },
                new Toy { Id = 30, Name = "Solar System Model", CategoryId = 7 },

                // Outdoor & Sports
                new Toy { Id = 31, Name = "Soccer Ball", CategoryId = 8 },
                new Toy { Id = 32, Name = "Basketball", CategoryId = 8 },
                new Toy { Id = 33, Name = "Frisbee", CategoryId = 8 },
                new Toy { Id = 34, Name = "Jump Rope", CategoryId = 8 },
                new Toy { Id = 35, Name = "Pogo Stick", CategoryId = 8 },
                new Toy { Id = 36, Name = "Skateboard", CategoryId = 8 }
            );
        }
    }
}