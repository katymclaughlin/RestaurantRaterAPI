using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantRaterAPI.Data;

namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly ILogger<RatingController> _logger;
        private RestaurantDbContext _context;

        public RatingController(ILogger<RatingController> logger, RestaurantDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    
    //NOTE - POST Method that takes in an instance of the RestaurantEdit model as a parameter
    [HttpPost]
    public async Task<IActionResult> RateRestaurant([FromForm] RatingEdit model) 
        {
            if (!ModelState.IsValid) 
            {
            return BadRequest(ModelState);
          }

          _context.Ratings.Add(new Rating() {
            Score = model.Score,
            RestaurantId = model.RestaurantId,
          });

          await _context.SaveChangesAsync();

          return Ok();
        }
    }
}