using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Models
{
    public class RatingRequest
    {
        public float Score { get; set; }
        public int RestaurantId { get; set; }
    }
}