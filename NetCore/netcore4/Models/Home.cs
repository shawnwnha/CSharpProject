using System;
using System.ComponentModel.DataAnnotations;
namespace netcore4.Models
{
    public class User
    {   
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
// ---------------------------------------------DOJODACHI-------------------------------------
    public class Dojo{
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; } 
        public string message { get; set; }
        Random rand = new Random();
        public Dojo(int hap = 20, int ful = 20, int ene = 50,int mea= 3, string mem = "hello"){
            happiness= hap;
            fullness = ful;
            energy = ene;
            meals = mea;
            message=mem;
        }
        public void feed(){
            Random index = new Random();
            if(index.Next(0,4)==3){
                if(meals <1){
                    Console.WriteLine("Cannot Feed");
                }
                else{
                    meals -= 1;
                    message = "I don't like it!! so you wasted meals!";                 
                }
            }
            else{
                if(meals <1){
                    Console.WriteLine("Cannot Feed");
                }
                else{
                    meals -= 1; 
                    int x = rand.Next(5,11);
                    fullness += x;
                    message ="Consumed 1 meal, and gained " + x +" fullness!";
                }
            }
        }
        public void play(){
            energy -= 5; 
            int x = rand.Next(5,11);
            happiness += x;
            message ="Consumed 5 energy, but gained " + x +" happiness!";
        }
        public void work(){
            energy -=5;
            int x = rand.Next(1,4);
            meals += x;
            message ="Consumed 5 energy, but gained " + x +" meals!";
        }
        public void sleep(){
            energy +=15;
            fullness -=5;
            happiness -=5;
            message ="Consumed 5 fullness and 5 happiness, but gained " + 15 +" energy!";
        }
    }
}