using System;

namespace UniduringQuarantine
{
    public class Gameplay
    {


        private Map MyMap;
        public static Player currentPlayer = new Player(1,15);
        public void Start()
        {
        

            Console.WriteLine(@"

                  __ __ __  __ __    ____   __ __ ____  __ __  __   ___     
                  || || ||\ || ||    || \\  || || || \\ || ||\ ||  // \\    
                  || || ||\\|| ||    ||  )) || || ||_// || ||\\|| (( ___    
                  \\_// || \|| ||    ||_//  \\_// || \\ || || \||  \\_||    
                 ___   __ __  ___  ____   ___  __  __ ______ __ __  __  ____
                // \\  || || // \\ || \\ // \\ ||\ || | || | || ||\ || ||   
               ((   )) || || ||=|| ||_// ||=|| ||\\||   ||   || ||\\|| ||== 
                \\_/\\ \\_// || || || \\ || || || \||   ||   || || \|| ||___
                                                          

                           __...--~~~~~-._   _.-~~~~~--...__
                         //               `V'               \\ 
                        //                 |                 \\ 
                       //__...--~~~~~~-._  |  _.-~~~~~~--...__\\ 
                      //__.....----~~~~._\ | /_.~~~~----.....__\\
                     ====================\\|//====================
                                         `---`");
            Console.WriteLine("\n\nWelcome to Uni During Quarantine. Press any key to continue");
            Console.ReadKey();
            Console.Write("What is your name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("you awake in a cold and dark school, you're in Högskolan Dalarna in Borlänge.");
            Console.WriteLine("You wagely remember everyone at school starting to cough and a lockdown began, but...The teachers...\nThey didn't just cough. You think A teacher starting chasing the students, everybody was screaming.");
            if (currentPlayer.name == "")
                Console.WriteLine("You can't remember much, not even your name.");
            else
            {
                Console.WriteLine("You can't remember much more, but you know your name is {0} atleast.", currentPlayer.name);
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("You can walk by writing go up, go down, go left, go right");
            Console.ReadLine();
            Console.Clear();
        

            string[,] grid =
           {

                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","="," ","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"="," ","=","=","=","=","=","=","=","=","=","="},
            };

            MyMap = new Map(grid);
            MyMap.Draw();
            currentPlayer.Draw();
            currentPlayer = new Player(1, 15);

            RunGameLoop();
            StoryLine();

        }

        private void DrawFrame()
        {
            Console.Clear();
            MyMap.Draw();
            currentPlayer.Draw();
        }

        private void Input()
        {
            Console.SetCursorPosition(1, 16);
            StoryLine();
            Console.SetCursorPosition(1, 19);
            // Console.WriteLine(currentPlayer.X + " " + currentPlayer.Y);
            Console.Write("Write here: ");
            string moveChoice = Console.ReadLine();
            switch (moveChoice)
            {
                case "go up":
                    if (MyMap.Walkable(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.Y -= 1;
                    }
                    break;
                case "go down":
                    if (MyMap.Walkable(currentPlayer.X, currentPlayer.Y + 1))
                    {
                        currentPlayer.Y += 1;
                    }
                    break;
                case "go left":
                    if (MyMap.Walkable(currentPlayer.X - 1, currentPlayer.Y))
                    {
                        currentPlayer.X -= 1;
                    }
                    break;
                case "go right":
                    if (MyMap.Walkable(currentPlayer.X + 1, currentPlayer.Y))
                    {
                        currentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        
        private void RunGameLoop()
        {
            while (true)
            {
                // Rita hela kartan.
                DrawFrame();


                // Kolla vad för input spelaren gör.
                Input();



                // Kolla om man nått slutet.
                string insideRoom = MyMap.RoomsAtPosition(currentPlayer.X, currentPlayer.Y);
                if (insideRoom == "X")
                {
                    break;
                }



                // Detta för att förhindra blinkande.
                System.Threading.Thread.Sleep(60);

            }
        }

        public void StoryLine()
        {

            // RECEPTION // 
            // Måste finnas ett effektivare sätt, kanske med listor och for loop? 
            

            if (currentPlayer.X == 1 && currentPlayer.Y == 15)
            {
                Console.Write("You're standing in the beginning of the reception at school.\n There's a front desk further away, with some tables and chairs along the hallway.");
            }
            else if (currentPlayer.X == 1 && currentPlayer.Y == 14)
            {
                Console.Write("There is a noise...Somewhere. You better hurry finding that keycard.");
            }
            else if (currentPlayer.X == 2 && currentPlayer.Y == 14)
            {
                Console.Write("You're walking past some broken chairs.");
            }
            else if (currentPlayer.X == 3 && currentPlayer.Y == 14)
            {
                Console.Write("You can see a pamplet stand next to you.");
            }
            else if (currentPlayer.X == 4 && currentPlayer.Y == 14)
            {
                Console.Write("You feel that someone is watching you..");
            }
            else if (currentPlayer.X == 5 && currentPlayer.Y == 14)
            {
                Console.Write("You're in the middle of the reception.");
            }
            else if (currentPlayer.X == 6 && currentPlayer.Y == 14)
            {
                Console.Write("There is a broken phone on the table to your left");
            }
            else if (currentPlayer.X == 7 && currentPlayer.Y == 14)
            {
                Console.Write("You see a door futher away infront of you");
            }
            else if (currentPlayer.X == 8 && currentPlayer.Y == 14)
            {
                Console.Write("You're still in the reception");
            }
            else if (currentPlayer.X == 9 && currentPlayer.Y == 14)
            {
                Console.Write("You just want to go home..");
            }
            else if (currentPlayer.X == 10 && currentPlayer.Y == 14)
            {
                Console.Write("You're facing a door a couple steps ahead, leading to the library.");
            }
            else if (currentPlayer.X == 1 && currentPlayer.Y == 13)
            {
                Console.Write("You can see a painting hanging to your right, is it covered in...blood?");
            }
            else if (currentPlayer.X == 2 && currentPlayer.Y == 13)
            {
                Console.Write("You're standing behind the front desk. Papers are cluttered all over the place. \n An old coffeemug are next to the computer.");
            }
            else if (currentPlayer.X == 3 && currentPlayer.Y == 13)
            {
                Console.Write("You found a picture of some students, making you miss your classmates\n giving you an eerie feeling of this sudden cold, deserted place..");
            }
            else if (currentPlayer.X == 4 && currentPlayer.Y == 13)
            {
                Console.Write("The front desk ends here");
            }
            else if (currentPlayer.X == 5 && currentPlayer.Y == 13)
            {
                Console.Write("You have a dead flower infront of you, once beautiful and alive");
            }
            else if (currentPlayer.X == 6 && currentPlayer.Y == 13)
            {
                Console.Write("You feel a cold wind coming from somewhere");
            }
            else if (currentPlayer.X == 7 && currentPlayer.Y == 13)
            {
                Console.Write("You can see a door some steps ahead");
            }
            else if (currentPlayer.X == 8 && currentPlayer.Y == 13)
            {
                Console.Write("You're thinking of how much you miss this place before the qurantine.");
            }
            else if (currentPlayer.X == 9 && currentPlayer.Y == 13)
            {
                Console.Write("You're close to the door");
            }
            else if (currentPlayer.X == 10 && currentPlayer.Y == 13)
            {
                if (currentPlayer.keycard > 2)
                    Console.Write("You have a door infront of you, leading to the library.\n You have a keycard so you can enter!");
                if (currentPlayer.keycard < 2)
                    Console.Write("You have a door infront of you leading to the library.\n You need a keycard to enter.");
            }


            // LIBRARY 
            // CLASSROOM
            // CAFETERIA
            // STAFFROOM


        }


        }

    }
