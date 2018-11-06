using System;
using System.Collections.Generic;
namespace DeckofCards
{
    public class Deck{
        public List<Card> cards;
        public Deck(){
            init();
        }
        public void init(){ 
            cards = new List<Card>();
            string[] Sval = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
            string[] Suits = {"Clubs","Spades","Hearts","Diamonds"};
            foreach(string suit in Suits){
                for(var i =0;i<Sval.Length;i++){
                    cards.Add(new Card(Sval[i],suit,i+1));
                }
            }
        }
        public Card deal(){
            Card deal = cards[0];
            cards.RemoveAt(0);
            return deal;
        }
        public void reset(){
            init();
        }
        public void shuffle(){
            Random rand = new Random();
            for(var i = 0; i <cards.Count-1;i++){
                Card temp = cards[i];
                int index = rand.Next(i+1,cards.Count);
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }
    }
}
