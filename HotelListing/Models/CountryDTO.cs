using HotelListing.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
     
    public class CreateCountryDTO
    {
         
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name IS To Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Country ShortName IS To Long")]
        public string ShortName { get; set; }

    }
    public class UpdateCountryDTO : CreateCountryDTO
    {
        //public IList<CreateHotelDTO> Hotels { get; set; } 
    }
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; } 

    }
}
