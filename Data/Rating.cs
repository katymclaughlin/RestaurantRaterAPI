using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //used for the foreign key relationship

//NOTE - Define our data models and create DbSets(EF Representations of tables)

namespace RestaurantRaterAPI.Data
{
    public class Rating
    {
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Range(0,5)]
    public double Score { get; set; }

    [Required]
    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }
    }
}