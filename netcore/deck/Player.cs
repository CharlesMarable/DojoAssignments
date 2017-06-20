using System.Collections.Generic;
using System.Linq;

namespace BlackJack{
    public class Player{
        public string Name { get; set; }
        public List<Card> Hand { get; set;}

        public Player(string name){
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(Deck deck){
            Card DealtCard = deck.Deal();
            Hand.Add(DealtCard);
            return DealtCard;
        }
        public void GhostDraw(Card card){
            Hand.Add(card);
        }

        public Card Play(){
            Card val = Hand.First();
            // System.Console.WriteLine("-------------------");
            // System.Console.WriteLine(val);
            Hand.RemoveAt(0);
            int num =  val.Val;
            return val;
        }

        public Card Discard(int idx){
            idx--;
            if(idx > Hand.Count){
                return null;
            }
            Card DiscardedCard = Hand[idx];
            Hand.RemoveAt(idx);
            return DiscardedCard;
        }
        public int Count(){
            int mycount = Hand.Count;
            return mycount;
        }
        
    }
}