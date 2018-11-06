using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProductM.Models{    
    public class Category{
        [Key]
        public int CategoryId {get;set;}
        [Required(ErrorMessage = "Category must be filled.")]
        [MinLength(2,ErrorMessage="Category must be more than 2 characters.")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Category must be characters only.")]
        public string Name {get;set;}
        public DateTime Created_at {get;set;}
        public List<ProCat> Products {get;set;}
        public Category(){
            Products = new List<ProCat>();
        }
    }
}