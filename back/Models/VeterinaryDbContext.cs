using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace back.Models
{
    public class VeterinaryDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public VeterinaryDbContext(DbContextOptions<VeterinaryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Pet> petsInit = new List<Pet>
            {
                new Pet()
                {
                    Id = 1,
                    Name = "Misha",
                    Weight = 20,
                    Age = 4,
                    Color = "Brown",
                    CreationDate = DateTime.Now,
                    Breet = "Cat"
                },
                new Pet()
                {
                    Id = 2,
                    Name = "Zombra",
                    Weight = 30,
                    Age = 9,
                    Color = "Black",
                    CreationDate = DateTime.Now,
                    Breet = "Dog"
                },
                new Pet()
                {
                    Name = "Max",
                    Breet = "Labrador",
                    Age = 3,
                    Weight = 15,
                    Color = "Black",
                    CreationDate = DateTime.Parse("2021-01-01")
                },
                new Pet()
                {
                    Name = "Buddy",
                    Breet = "Golden Retriever",
                    Age = 2,
                    Weight = 20,
                    Color = "Golden",
                    CreationDate = DateTime.Parse("2021-02-01")
                },
                new Pet()
                {
                    Name = "Charlie",
                    Breet = "French Bulldog",
                    Age = 1,
                    Weight = 10,
                    Color = "White",
                    CreationDate = DateTime.Parse("2021-03-01")
                },
                new Pet()
                {
                    Name = "Lucy",
                    Breet = "Poodle",
                    Age = 4,
                    Weight = 7,
                    Color = "Gray",
                    CreationDate = DateTime.Parse("2021-04-01")
                },
                new Pet()
                {
                    Name = "Daisy",
                    Breet = "Chihuahua",
                    Age = 6,
                    Weight = 5,
                    Color = "Brown",
                    CreationDate = DateTime.Parse("2021-05-01")
                },
                new Pet()
                {
                    Name = "Rocky",
                    Breet = "German Shepherd",
                    Age = 5,
                    Weight = 25,
                    Color = "Black and Tan",
                    CreationDate = DateTime.Parse("2021-06-01")
                },
                new Pet()
                {
                    Name = "Sadie",
                    Breet = "Australian Shepherd",
                    Age = 2,
                    Weight = 18,
                    Color = "Blue Merle",
                    CreationDate = DateTime.Parse("2021-07-01")
                },
                new Pet()
                {
                    Name = "Molly",
                    Breet = "Beagle",
                    Age = 7,
                    Weight = 22,
                    Color = "Brown and White",
                    CreationDate = DateTime.Parse("2021-08-01")
                },
                new Pet()
                {
                    Name = "Bailey",
                    Breet = "Shih Tzu",
                    Age = 3,
                    Weight = 12,
                    Color = "Gray and White",
                    CreationDate = DateTime.Parse("2021-09-01")
                },
                new Pet()
                {
                    Name = "Lola",
                    Breet = "Siberian Husky",
                    Age = 4,
                    Weight = 30,
                    Color = "White and Gray",
                    CreationDate = DateTime.Parse("2021-10-01")
                }
            };

            modelBuilder.Entity<Pet>(pet =>
            {
                pet.ToTable("Pets");
                pet.Property(p => p.Id)
                    .IsRequired()
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                pet.Property(p => p.Name).IsRequired().HasMaxLength(250);
                pet.Property(p => p.Color).IsRequired().HasMaxLength(50);
                pet.Property(p => p.Breet).IsRequired().HasMaxLength(50);
                pet.Property(p => p.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");
                pet.HasData(petsInit);
            });

        }
    }
}
