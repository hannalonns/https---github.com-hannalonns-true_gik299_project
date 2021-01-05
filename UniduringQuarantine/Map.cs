using System;

namespace UniduringQuarantine
{

    // ***** HÄR ÄR KARTAN, DÄR NYCKLAR OCH FIENDERS POSITION SKA FINNAS ******
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
        }

        public void Draw()
        {
            // y = row
            // x = column
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

        public string RoomsAtPosition(int x, int y)
        {
            return Grid[y, x];
        }

        public bool Walkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false; // Gör så att man inte kan gå utanför kartan.
            }
            // Gör så att man kan gå på delarna som ser ut som " " eller "X" på kartan.
            return Grid[y, x] == " ";
        }


    }
}
