using System;
using System.Collections.Generic;
namespace DeckofCards
{
    public class Player{
        public string name;
        public List<Card> hand = new List<Card>();

        public Player(string n){
            name = n;
        }
        public Card draw(Deck deck){
            Card newCard = deck.deal();
            hand.Add(newCard);
            return newCard;
        }

        public Card discard(int index){
            if(hand.Count ==0){
                return null;
            }
            else{
                Card temp = hand[index];
                hand.RemoveAt(index);
                return temp;  
            }
        }
    }
}
