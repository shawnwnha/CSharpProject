using System;
using System.Collections.Generic;

namespace Phones
{
    class Program
    {
        static void Main(string[] args)
        {
            Galaxy s8 = new Galaxy("s8",100, "T-Mobile","Dooo Do Doo Dooo");
            Nokia elevenHundred = new Nokia("1100", 60, "Verizon", "Ringring Ring Ring RingRing");

            s8.DisplayInfo();
            Console.WriteLine(s8.Ring());
            Console.WriteLine(s8.Unlock());
            Console.WriteLine("");

            elevenHundred.DisplayInfo();
            Console.WriteLine(elevenHundred.Ring());
            Console.WriteLine(elevenHundred.Unlock());
            Console.WriteLine("");
        }
    }
}
