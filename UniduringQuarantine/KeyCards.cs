using System;

namespace UniduringQuarantine
{
    public class KeyCards
    {


        public void Keycard()
        {
            Gameplay.currentPlayer.keycard += 1;
            Console.WriteLine("You picked up a keycard here");

            Gameplay.keyCard1.Y -= 1;
        }

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


        public string Key1;


        public KeyCards(int startX, int startY)
        {
            X = startX;
            Y = startY;


        }
       

        public void DrawKey1() // här ritas nyckeln ut på kartan.
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Key1);

        }

        public string Key2;

        public void DrawKey2() 
        {

            
            Console.SetCursorPosition(X, Y);
            Console.Write(Key2);

        }

        public string Key3;

        public void DrawKey3()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Key3);

        }

        public string Key4;

        public void DrawKey4() 
        {

            Console.SetCursorPosition(X, Y);
            Console.Write(Key4);

        }
    }
}