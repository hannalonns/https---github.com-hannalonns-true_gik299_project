using System;

namespace UniduringQuarantine
{

    // ***** HÄR ÄR KARTAN SOM HÅLLER REDA PÅ NYCKLAR OCH FIENDER ******
    public class Map
    {

        private string[,] Grid;
        public int Rows;
        public int Cols;

        public Map(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);  // få antal rows
            Cols = Grid.GetLength(1);  // få antal columns
            KeyCards();
            Teachers();
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)  // för varje row, går denna loop igenom varje column.
            {
                for (int x = 0; x < Cols; x++)
                {
                    string rooms = Grid[y, x];  // y och x är bakvänt när vi specifierar tillgång till saker.
                    Console.SetCursorPosition(x, y);
                    Console.Write(rooms);
                }
            }
        }

        public string ObjectInRoom(int x, int y)
        {
            return Grid[y, x];
        }
        
        // här slumpas alla keycards ut. 
        public void KeyCards()  
        {
            Random rand = new Random();
            for (int i = 0; i < 10;)
            {
                int y = rand.Next(1, Rows);
                int x = rand.Next(1, Cols);
                if (Grid[y, x] == " ")
                {
                    Grid[y, x] = "?"; 
                    i++;
                }
            }
        }

        // Här slumpas alla fiender och görs osynliga för spelaren.
        public void Teachers()
        {
            Random rand = new Random();
            for (int i = 0; i < 10;)
            {
                int y = rand.Next(1, Rows);
                int x = rand.Next(1, Cols);
                if (Grid[y, x] == " ")
                {
                    Grid[y, x] = "   ";
                    i++;
                }
            }
        }
        public bool AccessGranted(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false; // Gör så att man inte kan gå utanför kartan.
            }
            // Gör så att man kan gå på delarna som ser ut som " " eller "X" på kartan.
            return Grid[y, x] == " " || Grid[y, x] == "X" || Grid[y, x] == "?" || Grid[y, x] == "   " || Grid[y, x] == "-";
        
        }
        public void MakeRoomEmpty(int x, int y)
        {
            Grid[y, x] = " ";
        }
    }
}
