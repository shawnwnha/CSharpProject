using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProductM.Models{    
    public class Product{
        [Key]
        public int ProductId {get;set;}
        [Required(ErrorMessage ="Product Name must be filled")]
        [MinLength(2,ErrorMessage="Product Name must be more than 2 characters.")]
        public string Name {get;set;}
        [Required(ErrorMessage ="Product Description must be filled")]
        [MinLength(8,ErrorMessage="Description must be more than 8 characters")]
        public string Description {get;set;}
        [Required(ErrorMessage ="Price must be filled")]
        public double Price {get;set;}
        public DateTime Created_at {get;set;}
        public List<ProCat> Categories {get;set;}
        public Product(){
            Categories = new List<ProCat>();
        }
    }
}