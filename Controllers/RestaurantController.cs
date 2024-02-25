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
    //NOTE - CREATE a restaurant to the restaurants table
    //Async POST Endpoint
    [HttpPost]
    public async Task<IActionResult> PostRestaurant([FromBody] Restaurant request)
    {
        if (ModelState.IsValid)
        {
            _context.Restaurants.Add(request);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest(ModelState);
    }
    //NOTE - READ (GET)
    //Async GET Endpoint
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

    //NOTE - Update a restaurant
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromForm] RestaurantEdit model, [FromRoute] int id)
    {
         var oldRestaurant = await _context.Restaurants.FindAsync(id);
         if (oldRestaurant == null)
         {
            return NotFound();
         }
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         if (!string.IsNullOrEmpty(model.Name))
        {
          oldRestaurant.Name = model.Name;
        }
        if (!string.IsNullOrEmpty(model.Location))
        {
          oldRestaurant.Location = model.Location;
        }
            await _context.SaveChangesAsync();
             return Ok();
    }    
    // Async PUT Endpoint
[HttpPut]
    public async Task<IActionResult> PutRestaurant([FromBody] Restaurant request)
    {
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    Restaurant? restaurant = await _context.Restaurants.FindAsync(request.Id);
    if (restaurant is null)
    {
        return NotFound();
    }
    
    restaurant.Name = request.Name;
    restaurant.Location = request.Location;

    _context.Restaurants.Update(restaurant);
    await _context.SaveChangesAsync();
    return Ok();
    }
    
    //NOTE - Delete endpoint
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
           if (restaurant == null)
            {
             return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok();
    }
   
    }
}