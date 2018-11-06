using System;
using System.Collections.Generic;
namespace DeckofCards
{
    public class Card{
        public string stringVal;
        public string suits;
        public int val; 
        public Card(string x, string y, int z){
            stringVal = x;
            suits = y; 
            val = z;
        }
    }
}
