using System;

namespace UniduringQuarantine
{
    public class Player
    {

        public string Character;

        public string name;
        public int keycard = 0;  // man börjar med 0 nyckar
        public float health = 100; // ens hälsa 
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

        // Här sparas vart spelaren börjar.
        public Player(int startX, int startY) 
        
        {
            X = startX; 
            Y = startY;
            Character ="O";
        } 
        
        // här ritas spelaren ut på kartan.
        public void Draw()
        {
            Console.SetCursorPosition(X,Y);
            Console.Write(Character);
        } 
    }
}
