using HotelListing.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateHotelDTO
    {
         
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Hotel Name IS To Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Address IS To Long")]
        public string Address { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
    public class UpdateHotelDTO : CreateHotelDTO
    {

    }
    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
    
}
