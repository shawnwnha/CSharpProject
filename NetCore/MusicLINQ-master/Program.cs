using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();
            Console.WriteLine("###################################################################################");
            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================
            var theArtist = Artists.Where(x => x.Hometown =="Mount Vernon");
            foreach(var artist in theArtist){
                Console.Write(artist.ArtistName);
                Console.Write(artist.Age);
            }
            Console.WriteLine("###################################################################################");
            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?     $$$$$$$$$$$$$$$$$$ DMX - 46 
            //=========================================================

            //=========================================================
            //Who is the youngest artist in our collection of artists? $$$$$$$$$$$$$$$$$ Chance the Rapper - 23
            //=========================================================
            var youngartist = Artists.OrderBy(data =>data.Age).First();
            Console.WriteLine(youngartist.ArtistName+""+youngartist.Age);
            Console.WriteLine("###################################################################################");
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name     
            //=========================================================
            var william = Artists.Where(x=>
            x.RealName.Contains("William"));
            foreach(var x in william){
                Console.WriteLine(x.ArtistName);
            }
            Console.WriteLine("###################################################################################");
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            var lessName = Artists.Where(x=>x.ArtistName.Length <8);
            foreach(var y in lessName){
                Console.WriteLine(y.ArtistName);
            }
            Console.WriteLine("###################################################################################");
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var oldAtlanta = Artists.OrderByDescending(x=>x.Age).Where(y=>y.Hometown=="Atlanta").ToList();
            for(var i = 0; i <3;i++){
                Console.WriteLine(oldAtlanta[i].ArtistName);
            }
            Console.WriteLine("###################################################################################");
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================
            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================

        }
    }
}
