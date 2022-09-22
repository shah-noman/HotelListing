using AutoMapper;
using HotelListing.Data;
using HotelListing.IRepasitary;
using HotelListing.Models;
using HotelListing.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;


        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController>logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SOmething went worng in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. place try Again latter");

            }
        }
        [Authorize]
        [HttpGet("{id:int}" ,Name ="GetHotel") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         
        public async Task<IActionResult> GetHotel (int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SOmething went worng in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal server error. place try Again latter");

            }
        }
         [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    
        public async Task<IActionResult> CreateHotel([FromBody]CreateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHotel)}");
                return BadRequest(ModelState);
             }
            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unitOfWork.Hotels.Insert(hotel);
                await _unitOfWork.Save();
                
                return CreatedAtRoute("GetHotel",new {id = hotel.Id}, hotel);  
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"SOmething went worng in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal server error. place try Again latter");

            }

        }


        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHotel(int id,[FromBody] UpdateHotelDTO hotelDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalide UPDATE Attempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);
            }
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
                if(hotel == null)
                {
                    _logger.LogError($"Invalide UPDATE Attempt in {nameof(UpdateHotel)}");
                    return BadRequest("Submitted Data is Invalid");
                }
                _mapper.Map(hotelDTO, hotel);
                _unitOfWork.Hotels.Update(hotel);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"SOmething went worng in the {nameof(UpdateHotel)}");
                return StatusCode(500, "Internal server error. place try Again latter");
            }
        }


        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHotel(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalide Delete Attempt in {nameof(DeleteHotel)}");
            return BadRequest(ModelState);
        }
        try
        {
            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
            if (hotel == null)
            {
                _logger.LogError($"Invalide DELET Attempt in {nameof(DeleteHotel)}");
                return BadRequest("Submitted Data is Invalid");
            }

                await _unitOfWork.Hotels.Delete(id);
                  await _unitOfWork.Save();

            return NoContent();
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, $"SOmething went worng in the {nameof(DeleteHotel)}");
            return StatusCode(500, "Internal server error. place try Again latter");
        }
    }
}
}

