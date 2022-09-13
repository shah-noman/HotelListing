using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entity
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}