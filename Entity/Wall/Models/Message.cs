using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Wall.Models{    
    public class Message{
        [Key]
        public int MessageId{get;set;}
        [Required]
        public string Content {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public List<Comment> Comments {get;set;}
        public Message(){
            Comments = new List<Comment>();
        }
    }
}