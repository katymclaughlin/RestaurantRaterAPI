using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

//This is where we will create API endpoints(CRUD methods to access our data)

namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)
        {
        _context = context;
        }
    
    //NOTE - READ (GET)
    //Async Get Endpoint
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
        return Ok(restaurants);
    }

    //NOTE - Retrieve a specific Restaurant using the Primary Key, or Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRestaurantById(int id)
    {
        //fetch the Restaurant data from the database
        Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant is null)
        {
        return NotFound();
        }
        return Ok(restaurant);
        }
    }
}