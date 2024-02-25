using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Data
{

//NOTE - Model to show the average Rating Score along with Id, Name, and Location of a Restaurant without returning the ratings
    public class RestaurantListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float AverageScore { get; set; }
    }
}