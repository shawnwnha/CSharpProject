using System;
using System.Collections.Generic;

namespace Phones
{
    public class Galaxy: Phone, IRingable{
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone): base(versionNumber,batteryPercentage,carrier,ringTone){

        }
        public string Ring(){
            return ($"... {_ringTone} ...");
        }

        public string Unlock(){
            return ($"Galaxy {_versionNumber} unlocked with fingerprint Scanner.");
        }

        public override void DisplayInfo(){
            Console.WriteLine("#########################");
            Console.WriteLine($"Galaxy: {_versionNumber}");
            Console.WriteLine($"Batter Percentage: {_batteryPercentage}");
            Console.WriteLine($"Carrier: {_carrier}");
            Console.WriteLine($"Ring Tone: {_ringTone}");
            Console.WriteLine("#########################");
        }
    }
}
