using System;
using System.Collections.Generic;

namespace Phones
{
    public abstract class Phone{
        public string _versionNumber { get; set; }
        public int _batteryPercentage { get; set; } 
        public string _carrier { get; set; } 
        public string _ringTone { get; set; }

        protected Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone){
            _versionNumber = versionNumber;
            _batteryPercentage = batteryPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }

        public abstract void DisplayInfo();
    }
}
