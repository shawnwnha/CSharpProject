using System;
using System.Collections.Generic;


namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck.shuffle();
            Player User1 = new Player("Shawn");
        }
    }
}
