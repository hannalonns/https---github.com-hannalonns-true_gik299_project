using System;

namespace UniduringQuarantine
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameplay currentGame = new Gameplay();
           do
           { 
            currentGame.Start();
           }
           
           while (true);

        }
    }
}

