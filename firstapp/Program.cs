using System;
using System.Collections.Generic;

namespace firstapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Human user1 = new Human("Shawn");
            Wizard user2 = new Wizard("Killa");
            Ninja user3 = new Ninja("NINJAA");
            Samurai user4 = new Samurai("KingPin");
            Samurai user5 = new Samurai("JohnJones");

            
            Console.WriteLine(user1.health);
            Console.WriteLine(user3.health);
            user3.steal(user1);
            Console.WriteLine(user1.health);
            Console.WriteLine(user3.health);
            user3.get_away();
            Console.WriteLine(user3.health);
            for(var i = 0; i<4;i++){
                user4.attack(user3);
                Console.WriteLine("Attack!");
            };
            Console.WriteLine(user3.health);
            user4.dealth_blow(user3);
            if(user3.health == 0){
                Console.WriteLine($"User:{user3.name} DEAD");
            }
            user4.mediatate(); //when how_many() is private; bottom is when public.
            // Console.WriteLine(user4.how_many()); 
        }
    }
}
