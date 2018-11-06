using System;
using System.ComponentModel.DataAnnotations;

namespace netcore3.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
}