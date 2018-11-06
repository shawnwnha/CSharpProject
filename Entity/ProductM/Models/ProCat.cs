using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProductM.Models{    
    public class ProCat{
        [Key]
        public int ProCatId {get;set;}
        public int ProductId {get;set;}
        public Product Product {get;set;}
        public int CategoryId {get;set;}
        public Category Category {get;set;}
    }
}