using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBookApi.Models;
using Microsoft.Extensions.Logging;

namespace AddressBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressBookContext _context;
        private readonly ILogger _logger;

        public AddressController(AddressBookContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<ActionResult<AddressModel>> GetAddresses()
        {
            if (_context.Addresses.Count() > 0)
            {
                return await _context.Addresses.FirstAsync();
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/AddressModels/5
        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetAddressModel(string city)
        {
            city = city.ToLower();
            var addressModel = await _context.Addresses.Where(x => x.CityName == city).ToListAsync();

            if (addressModel.Count() == 0)
            {
                return NotFound();
            }

            return addressModel;
        }

       
        [HttpPost]
        public async Task<ActionResult<AddressModel>> PostAddressModel(AddressModel addressModel)
        {
            addressModel.CityName = addressModel.CityName.ToLower();
            _context.Addresses.Add(addressModel);
            await _context.SaveChangesAsync();

            _logger.LogInformation(MyLogEvents.GenerateItems, $"Adding PhoneNumber {addressModel.PhoneNumber}");
            return NoContent();
        }

    
      
    }
}
