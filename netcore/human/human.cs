namespace ConsoleApplication{
    public class Human{
        public string name {get; set;}
        public int strength {get; set;}
        public int intelligence {get; set;}
        public int dexterity {get; set;}
        public int health {get; set;}
        public int damage {get; set;}
        
        public Human(string name, int strength, int intelligence, int dexterity, int health)
            name = name;
            strength = strength;
            intelligence = intelligence;
            dexterity = dexterity;
            health = health;
        }
        public Attack(Human Allen){
            Allen.damage = Allen.strength*3;
        }
    }
}