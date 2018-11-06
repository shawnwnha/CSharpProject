using System;
using System.Collections.Generic;

namespace firstapp{
    public class Human{
        public string name;
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }

        public Human(string n){
            name = n;
            strength = 3;
            intelligence = 3;
            dexterity =3;
            health= 100;
        }
        public Human(string n, int str, int intel, int dex, int hp){
            name = n;
            strength = str;
            intelligence= intel;
            dexterity= dex;
            health = hp;
        }

        public void attack(object obj){
            Human x = obj as Human;
            if(x == null){
                Console.WriteLine("Faild to Attack");
            }
            else{
                x.health -= strength*5;  
            }
        }
    }

    public class Wizard: Human{
        public Wizard(string n) : base(n){
            health = 50;
            intelligence = 25;
        }
        public void heal(){
            health += 10* intelligence;
        }

        public void fireball(object x){
            Random rand = new Random();
            Human victim = x as Human;
            victim.health -= rand.Next(20,51);
        }

    }

    public class Ninja: Human{
        public Ninja(string n): base(n){
            dexterity = 175;
        }

        public void steal(object x){
            Human victim = x as Human;
            attack(x);
            health +=10; 
        } 
        public void get_away(){
            health -=15;
        }
    }

    public class Samurai: Human{
        public static int count = 0;
        public Samurai(string n): base(n){
            health=200;
            count += 1; 
        }

        public void dealth_blow(object x){
            Human victim = x as Human;
            if(victim.health<50){
                victim.health = 0;
            }
            else{
                Console.WriteLine("Failed death_blow");
            }
        }
        private int how_many(){//when private.
            return count;
        }
        public void mediatate(){
            health =200;
            Console.WriteLine(how_many());
        }
    }
}