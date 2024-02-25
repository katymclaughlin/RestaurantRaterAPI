using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //used in order fulfill the remaining contraints (primary key, not null, and max length)

//NOTE - Define our data models and create DbSets(EF Representations of tables)

namespace RestaurantRaterAPI.Data
{
    public class Restaurant
    {
        [Key] // Primary key
        public int Id { get; set; }

        [Required] //Not null
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)] //Attributes can go in the same brackets
        public string Location { get; set; } = string.Empty;
    }
}