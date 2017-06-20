using System;
namespace ConsoleApplication { 
    public class Ninja : Human
    {
        public Ninja(string n) : base(n)
        {
            dexterity = 175;
        }
        public void Steal(object target){
            Human enemy = target as Human;
            if(enemy != null){
                health += 10;
                attack(enemy);
            }
        }
        public void get_away(){
            health -= 15;
        }
        
    }
}