using System;

namespace UniduringQuarantine
{
    public class Player
    {

        public string Character;

        public string name;
        public int keycard = 0;  // man börjar med 0 nyckar
        public int health = 100; // ens hälsa 
        public int damage = 10;  // man tar 10 damage av fiender.
        public int potion = 10; // man får 10 hälsa av fiender ibland. 
        public int attack = 1;  // man ger 1 damage i en fight. 

        // En konstruktor som har en get och set, som gör att man kan röra sig i kartan. 

        public int X 
        { 
        get; 
        set; 
        }
        public int Y 
        { 
        get; 
        set; 
        }

        

        public Player(int startX, int startY) 
        // Här sparas vart spelaren börjar.
        {
            X = startX; 
            Y = startY;
            Character ="O";
        }
        public void Draw() // här ritas spelaren ut på kartan.
        {
            Console.SetCursorPosition(X,Y);
            Console.Write(Character);
        } 
    }
}