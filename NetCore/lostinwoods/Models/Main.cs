using System;
using System.ComponentModel.DataAnnotations;

namespace lostinwoods.Models
{
    public abstract class BaseEntity {}
    public class Trail :BaseEntity
    {
        [Key]
        public long Id {get;}

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description {get; set;}  

        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Length must be numeric with points.")]
        public float Length {get; set;}

        [RegularExpression("^[0-9]*$", ErrorMessage = "Length must be only numeric.")]
        public int Elevation {get;set;}

        [Required]
        public float Longitude {get;set;}
        
        [Required]
        public float Latitude {get;set;}
    }
}