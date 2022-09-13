﻿using AutoMapper;
using HotelListing.IRepasitary;
using HotelListing.Models;
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
        [HttpGet("{id:int}"),Authorize]
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
    }
}

