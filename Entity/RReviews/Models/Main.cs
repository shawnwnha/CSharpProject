using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RReviews.Models{
    public class Post{
        [Key]
        public int PostId { get; set; }
        [Required]
        public string XName { get; set; }
        [Required]
        public string YName { get; set; }
        [Required]
         [MinLength(10)]
        public string Review { get; set; } 
        [Required]
        public DateTime Datevisit { get; set; }
        [Required]
        public int Rating { get;set; }
    }
}
