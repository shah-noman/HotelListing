using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseConext : DbContext
    {
        public DatabaseConext(DbContextOptions options) : base(options)
        {}

         
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
               new Country
               {
                   Id = 1,
                   Name = "Pakistan",
                   ShortName = "PK"


               },
               new Country
               {
                   Id = 2,
                   Name = "Bahamas",
                   ShortName = "BS"
               },
               new Country
               {
                   Id = 3,
                   Name = "Cyman Island",
                   ShortName = "CI"
               });
            builder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Pearal Continantal",
                   Address = "Lahore",
                   CountryId = 1,
                   Rating = 7



               }, new Hotel
               {
                   Id = 2,
                   Name = "ComFort Nea",
                   Address = "Negril",
                   CountryId = 2,
                   Rating = 6
               }, new Hotel
               {
                   Id = 3,
                   Name = "Grand Palldium",
                   Address = "Nassua",
                   CountryId = 3,
                   Rating = 6.8
               });
        }

    }
}
