using System;

namespace BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to War!");
            Player Player1 = new Player("Player1");
            Player Player2 = new Player("Player2");
            Deck MyDeck = new Deck();
            MyDeck.Shuffle();
            System.Console.WriteLine("Let's Play Some War! Enter ('Deal')");
                bool gameOn = true;
                while(gameOn == true){
                    System.Console.WriteLine("Enter ('Battle')");
                    string res = Console.ReadLine();
                    switch(res){
                        case "Deal":
                            for(int i = 1; i<=26;i++){
                                Player1.Draw(MyDeck);
                                Player2.Draw(MyDeck);
                            }
                            System.Console.WriteLine("Please enter command ('Battle'):");
                            break;
                        case "Battle":
                            int count1 = Player1.Count();
                            int count2 = Player2.Count();
                            System.Console.WriteLine(count1);
                            if(count1 >0 && count2 >0){
                                System.Console.WriteLine("--------------------");
                                Card card1 = Player1.Play();
                                Card card2 = Player2.Play();
                                if(card1.Val > card2.Val){
                                    Player1.GhostDraw(card1);
                                    Player1.GhostDraw(card2);
                                    int player1count = Player1.Count();

                                    System.Console.WriteLine("Player1 wins {0}", player1count);
                                }
                                if(card2.Val > card1.Val){
                                    Player2.GhostDraw(card1);
                                    Player2.GhostDraw(card2);
                                    int player2count = Player2.Count();
                                    System.Console.WriteLine("Player2 wins {0}", player2count);
                                }
                                else if(card1.Val == card2.Val) {
                                    
                                        Card card3 = Player1.Play();
                                        Card card4 = Player2.Play();
                                        if(card3.Val > card4.Val){
                                            Player1.GhostDraw(card1);
                                            Player1.GhostDraw(card2);
                                            Player1.GhostDraw(card3);
                                            Player1.GhostDraw(card4);
                                            int player1count = Player1.Count();
                                            System.Console.WriteLine("Player1 wins battle {0}", player1count);
                                        }
                                        else if(card4.Val > card3.Val){
                                            Player2.GhostDraw(card1);
                                            Player2.GhostDraw(card2);
                                            Player2.GhostDraw(card3);
                                            Player2.GhostDraw(card4);
                                            int player2count = Player2.Count();
                                            System.Console.WriteLine("Player2 wins battle {0}", player2count);
                                        }
                                    
                                }
                            }
                            break;
                        case "Quit":
                            gameOn = false;
                            break;
                        default:
                        System.Console.WriteLine("Sorry, I didn't recognize that command. Please enter one of the following commands: 'Battle' or 'Quit'");
                        break;
                        }
                    }
                    System.Console.WriteLine("Good bye!");
                }
    }
}