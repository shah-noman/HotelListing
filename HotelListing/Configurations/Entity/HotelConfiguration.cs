using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entity
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
