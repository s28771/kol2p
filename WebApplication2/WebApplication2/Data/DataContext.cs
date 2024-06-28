using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Color> Colors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Car_Rental> CarRentals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(c => c.IdClient);
            modelBuilder.Entity<Color>().HasKey(c => c.IdColor);
            modelBuilder.Entity<Model>().HasKey(m => m.IdModel);
            modelBuilder.Entity<Car>().HasKey(c => c.IdCar);
            modelBuilder.Entity<Car_Rental>().HasKey(cr => cr.IdCar_Rental);
            
            modelBuilder.Entity<Client>().HasData(new List<Client>
            {
                new Client {
                    IdClient = 1,
                    FirstName = "nnn",
                    LastName = "nnn",
                    Adress = "nnn"
                },
                new Client {
                    IdClient = 2,
                    FirstName = "kkk",
                    LastName = "kkk",
                    Adress = "kkkk"
                },
            });
            
            modelBuilder.Entity<Color>().HasData(new List<Color>
            {
                new Color {
                    IdColor = 1,
                    Name = "zolty",
                },
                new Color {
                    IdColor = 2,
                    Name = "pomarancz",
                },
            });
            
            modelBuilder.Entity<Model>().HasData(new List<Model>
            {
                new Model {
                    IdModel = 1,
                    Name = "xxxx",
                },
                new Model {
                    IdModel = 2,
                    Name = "ccc",
                },
            });
            
            modelBuilder.Entity<Car>().HasData(new List<Car>
            {
                new Car {
                    IdCar = 1,
                    VIN = "bbbb",
                    Name = "bbbb",
                    Seats = 5,
                    PricePerDay = 150,
                    IdModel = 1,
                    IdColor = 1
                },
                new Car {
                    IdCar = 2,
                    VIN = "bvbvbv",
                    Name = "bvbvb",
                    Seats = 3,
                    PricePerDay = 34,
                    IdModel = 2,
                    IdColor = 1
                },
            });
            
            modelBuilder.Entity<Car_Rental>().HasData(new List<Car_Rental>
            {
                new Car_Rental {
                    IdCar_Rental = 1,
                    IdClient = 1,
                    IdCar = 1,
                    DateFrom = new DateTime(2024, 12, 06),
                    DateTo = new DateTime(2023, 05, 06),
                    TotalPrice = 1000,
                    Disscount = 15
                },
                new Car_Rental {
                    IdCar_Rental = 2,
                    IdClient = 2,
                    IdCar = 2,
                    DateFrom = new DateTime(2024, 05, 08),
                    DateTo = new DateTime(2023, 04, 11),
                    TotalPrice = 420,
                },
            });
        }
    }
}
