using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace netcore2.Models{
    public class Message{
        public string contents {get;set;}
    }

    public class Number{
        public int[] numbers {get;set;}
    }
    public class User{
        [Required]
        [MinLength(3)]
        public string Name {get;set;}
        public string Location {get;set;}
        public string Language {get;set;}
        public string Comment {get;set;}
    }

    public class Users{
        public List<string> people {get;set;}
    }
}