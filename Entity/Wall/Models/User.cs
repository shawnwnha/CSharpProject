using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Wall.Models{    
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="First name must be more than 2 characters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must be characters only.")]
        public string Firstname { get;set; }
        [Required]
        [MinLength(2,ErrorMessage="Last name must be more than 2 characters.")] 
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must be characters only.")]
        public string Lastname  {get;set; }
        [Required]
        [EmailAddress]
        public string Email { get;set; }
        [Required]
        [MinLength(8,ErrorMessage="Password must be more than 8 characters")]
        public string Password { get;set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string Confirm { get;set; }
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public List<Message> Messages{ get;set; }
        public List<Comment> Comments {get;set;}
        public User(){
            Messages = new List<Message>();
            Comments = new List<Comment>();
        }
    }
}