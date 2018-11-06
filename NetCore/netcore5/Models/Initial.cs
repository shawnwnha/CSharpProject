using System;
using System.ComponentModel.DataAnnotations;
namespace netcore5.Models
{
    public abstract class BaseEntity {}
    public class User: BaseEntity
    {
        [Key]
        public long id {get;set;}

        [Required]
        [MinLength(3)]
        public string name { get; set; }
 
        [Required]
        [MinLength(3)]
        public string quote { get; set; }

        public string created_at {get;set;}

        public string updated_at {get;set;}
 
    }
}