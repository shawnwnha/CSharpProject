using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BankAccount.Models{    
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
        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string Confirm { get;set; }
        public List<Book> Books{ get;set; }
        public User(){
            Books = new List<Book>();
        }
    }
    public class Book{
        public int BookId{get;set;}
        public double Balance {get;set;}
        public double AmountT{get;set;}
        public DateTime DateT{get;set;}
        public int UserId {get;set;}
        public User User{get;set;}
    }
}