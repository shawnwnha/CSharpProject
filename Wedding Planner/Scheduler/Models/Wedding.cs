using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Scheduler.Models{    
    public class Wedding{
        [Key]
        public int WeddingId {get;set;}
        [Required(ErrorMessage = "Wedder1 cannot be empty.")]
        [MinLength(2,ErrorMessage="Must be more than 2 characters.")]
        public string Wedder1 {get;set;}
        [Required(ErrorMessage = "Wedder2 cannot be empty.")]
        [MinLength(2,ErrorMessage="Must be more than 2 characters.")]
        public string Wedder2 {get;set;}
        [Required(ErrorMessage = "Date cannot be empty.")]
        public DateTime Date {get;set;}
        [Required(ErrorMessage = "Address cannot be empty.")]
        [MinLength(10,ErrorMessage="Address to short")]
        public string Address {get;set;}
        public int UserId {get;set;}
        public User Eventer {get;set;}
        public List<Joint> Attenders {get;set;}
        public Wedding(){
            Attenders = new List<Joint>();
        }
    }
}