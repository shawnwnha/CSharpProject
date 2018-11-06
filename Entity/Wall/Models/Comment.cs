using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Wall.Models{    
    public class Comment{
        [Key]
        public int CommentId {get;set;}
        [Required]
        public string Content {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public int UserId {get;set;}
        public User User{get;set;}
        public int MessageId {get;set;}
        public Message Message{get;set;}
    }
}