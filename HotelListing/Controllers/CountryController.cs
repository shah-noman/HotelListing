﻿using AutoMapper;
using HotelListing.IRepasitary;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;


        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper  mapper) 
        {
            _unitOfWork =  unitOfWork;
            _logger =  logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SOmething went worng in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal server error. place try Again latter");
                 
            }
        }
         [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
         {
            try
           {
                 var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> {"Hotels"}  );
                var result  = _mapper.Map<CountryDTO>(country);
               return Ok(result);
           }
            catch (Exception ex)
           {
              _logger.LogError(ex, $"SOmething went worng in the {nameof(GetCountry)}");
               return StatusCode(500, "Internal server error. place try Again latter");

            }
         }
    }
}
