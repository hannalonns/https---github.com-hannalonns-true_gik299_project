using System;

namespace UniduringQuarantine
{
    public class Gameplay
    {
        public static Map MyMap;

        Enemies currentEnemy = new Enemies();
        public static Player currentPlayer = new Player(1, 15);

        public void Start()
        {

            //@ för att acceptera 
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
                                          `---`
                            
                              A text-based adventure by:
             ||  Alice Forssblad  ||  Hanna Lönn  ||  Martin Lundstedt  ||");
            Console.WriteLine(@"                                  
                      Press any key to play. ||  Press x to exit. ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "x")
            {
                Environment.Exit(0);
            }
            Console.Clear();
            Console.Write("What is your name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("you awake in a cold and dark school, you're in Högskolan Dalarna in Borlänge.");
            Console.WriteLine("You vaguely remember everyone at school starting to cough and due to safety reasons a lockdown began, but...The teachers...\nThey didn't just cough. You think A teacher starting chasing the students, everybody was screaming.");
            if (currentPlayer.name == "")
            {
                Console.WriteLine("\nYou can't remember much, not even what your name is.");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            // HÄR ÄR EN LITEN EASTER EGG TILL THOMAS OCH SAMI :) 
            else if (currentPlayer.name.ToLower() == "thomas" || currentPlayer.name.ToLower() == "sami")
            {
                Console.WriteLine("\nYou can't remember much at all, but you have the same name as your favorite teacher!");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("\nYou can't remember much more, but you atleast know your name is {0} .", currentPlayer.name);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Your goal is to collect 10 keycards (?) while sneaking past zombie teachers that lures all around you. \n You win by going to the X-spot on the map.");
            Console.WriteLine("You can walk by writing go up (W), go down (S), go left (A), go right (D)");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();


            // HÄR ÄR KARTAN 
            string[,] grid =
            {

                {"=","=","=","=","=","=","=","=","=","=","X","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"=","=","=","=","=","=","=","=","=","=","-","="},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                {"=","-","=","=","=","=","=","=","=","=","=","="},
            };

            MyMap = new Map(grid);
            currentPlayer = new Player(1, 15);

            // Här körs spelets loop och DescribeRooms. 
            RunGameLoop();
            DescribeRooms();
        }

        // Här ritas spelaren och kartan ut. 
        private void DrawFrame()
        {
            Console.Clear();
            MyMap.Draw();
            currentPlayer.Draw();
        }
        private void Input()
        {
            Console.SetCursorPosition(40, 5);
            Console.Write("***MAP OF SCHOOL GROUND***");
            Console.SetCursorPosition(14, 1);
            Console.Write("*TEACHERS LOUNGE*");
            Console.SetCursorPosition(14, 5);
            Console.Write("*CAFETERIA*");
            Console.SetCursorPosition(14, 9);
            Console.Write("*LIBRARY*");
            Console.SetCursorPosition(14, 13);
            Console.Write("*RECEPTION*");
            Console.SetCursorPosition(1, 16);
            CheckEnemy();
            CheckKey();
            DescribeRooms();
            Console.SetCursorPosition(1, 20);
            Console.Write("Write here: ");
            string moveChoice = Console.ReadLine();
            switch (moveChoice)
            {
                case "go up":
                case "w":
                    if (MyMap.AccessGranted(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.Y -= 1;
                    }
                    break;
                case "go down":
                case "s":
                    if (MyMap.AccessGranted(currentPlayer.X, currentPlayer.Y + 1))
                    {
                        currentPlayer.Y += 1;
                    }
                    break;
                case "go left":
                case "a":
                    if (MyMap.AccessGranted(currentPlayer.X - 1, currentPlayer.Y))
                    {
                        currentPlayer.X -= 1;
                    }
                    break;
                case "go right":
                case "d":
                    if (MyMap.AccessGranted(currentPlayer.X + 1, currentPlayer.Y))
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
                string insideRoom = MyMap.ObjectInRoom(currentPlayer.X, currentPlayer.Y);
                if (insideRoom == "X")
                {
                    break;
                }

                // kolla om man har mindre hälsa än 0.
                if (currentPlayer.health < 0)
                {
                    break;
                }

                // Detta för att förhindra blinkande.
                System.Threading.Thread.Sleep(20);
            }
        }
        // Kollar om man är på samma position som en fiende.
        public void CheckEnemy()
        {
            string currentRoomObj = MyMap.ObjectInRoom(currentPlayer.X, currentPlayer.Y);
            if (currentRoomObj == "   ")
            {
                Random enemyChoice = new Random();
                switch (enemyChoice.Next(1, 4))
                {
                    case 1:
                        currentEnemy.Teacher();
                        MyMap.MakeRoomEmpty(currentPlayer.X, currentPlayer.Y);
                        Console.Clear();
                        Console.WriteLine("You close your eyes just for one sec..\n\n press anything to see again..");
                        break;


                    case 2:
                        currentEnemy.Teacher();
                        if (Gameplay.currentPlayer.health < 0)
                            break;
                        Console.WriteLine("Wait...You hear someone else..");
                        currentEnemy.Teacher();
                        MyMap.MakeRoomEmpty(currentPlayer.X, currentPlayer.Y);
                        Console.Clear();
                        Console.WriteLine("You close your eyes just for one sec..\n\n press anything to see again");
                        break;


                    case 3:
                        currentEnemy.Teacher();
                        if (Gameplay.currentPlayer.health < 0)
                            break;
                        Console.WriteLine("Wait...You hear someone else..");
                        currentEnemy.Teacher();
                        if (Gameplay.currentPlayer.health < 0)
                            break;
                        Console.WriteLine("Wait...You hear someone else..");
                        currentEnemy.Teacher();
                        MyMap.MakeRoomEmpty(currentPlayer.X, currentPlayer.Y);
                        Console.Clear();
                        Console.WriteLine("You close your eyes just for one sec..\n\n press anything to see again");
                        break;
                }

            }
        }
        // Kollar om man är på samma position som en nyckel.
        public void CheckKey()
        {

            string currentRoomObj = MyMap.ObjectInRoom(currentPlayer.X, currentPlayer.Y);
            if (currentRoomObj == "?")
            {
                currentPlayer.keycard += 1;
                Console.WriteLine("You look down and pick up keycard! You have {0} and need 10!", currentPlayer.keycard);

                MyMap.MakeRoomEmpty(currentPlayer.X, currentPlayer.Y);
            }

        }
        // En string array för rumsbeskrivningar. Två positions-arrayer för att loopa igenom alla möjliga rumkoordinater.
        // en if-sats för att jämföra spelarens nuvarande position med koordinaterna. För att sedan räkna ut rumsnummret och skriva ut beskrivningarna.
        public void DescribeRooms()
        {
            string[] descs = new string[80];

            // Reception
            descs[0] = "You're standing in the main entrence of the school.\n There's a front desk further away, with some tables and chairs along the hallway.";
            descs[1] = "You hear a noise from... Somewhere. You better hurry finding that keycard.";
            descs[2] = "You're walking past some broken chairs. What the hell happened here?";
            descs[3] = "You can see a pamphlet stand next to you.";
            descs[4] = "You feel like you're being watched..";
            descs[5] = "There is a broken phone on the table to your left, you look at it... Useless.";
            descs[6] = "You just want to go home...";
            descs[7] = "You have a dead flower infront of you, once beautiful and alive.";
            descs[8] = "You feel a shiver crawling up your back. Cold wind is coming from somewhere.";
            descs[9] = "You feel trapped in this corner.";
            descs[10] = "You can see a painting hanging to your right. Covered in what looks like blood.";
            descs[11] = "You're standing behind the front desk. Papers are cluttered all over the place. \n An old coffeemug stands next to the computer, there are flies circling it. Gross!";
            descs[12] = "You found a picture of some students, making you miss your classmates.\n it gives you an eerie feeling of this sudden cold, deserted place...";
            descs[13] = "The front desk ends here.";
            descs[14] = "You're thinking of how much you miss this place before the lockdown.";
            descs[15] = "You're holding your C# book tightly, in case of errors in your thoughts.";
            descs[16] = "To your left is a big poster of the school grounds.";
            descs[17] = "You wonder how many students that will survive this lockdown.";
            descs[18] = "You can see a light ahead.";
            descs[19] = "You're facing an open door that leads into the library.";

            //Library       
            descs[20] = "The darkness is so dense the air almost feels more compact here. You stop, almost walking in to the book case in front of you.";
            descs[21] = "It's getting really dark now.";
            descs[22] = "The ceiling height is back to normal now. It feels like a cave opening.\nThe lack of windows in here doesn't make wonders for the lighting situation.";
            descs[23] = "You can see the light fading fast through the few windows in the library. It must be getting late.";
            descs[24] = "The book cases appear again.";
            descs[25] = "A blue, high back, semi circular sofa emerge before you from the darkness.\nA small wooden table in front of the sofa. You can see brown smudges on the table, must be coffee. Let us hope nothing got on the book.";
            descs[26] = "A small gap in the book cases reveal an old photo copier.\nNothing of interest really.";
            descs[27] = "The book cases continue along the wall.\nThe knowledge of thousands in one room.";
            descs[28] = "You recognize familiar smell of old, second hand books.\nYou can see the bookcases dissapearing in to the dark before you";
            descs[29] = "A dark gloomy area lays before you.\nThe ceiling height is phenomenal in here!\nLong, wooden shelves perched up against the sides of the room.";
            descs[30] = "You walk with cautious steps, your hand stretched out in front of you. One could say you can't C very # in this darkness.";
            descs[31] = "You squint, trying to see through the darkness";
            descs[32] = "The ceiling height drastically changes. The further in the room the lower it gets the far end feels almost cavelike, no windows.";
            descs[33] = "It's so dark in here, too bad my phone battrey died while i was knocked out cold.";
            descs[34] = "You walk past a book shelf, you notice the book Think Like a Programmer -An Introduction to Creative Problem Solving and get a flashback of all the late study nights.";
            descs[35] = "There is a small stair case leading up to an empty reading area, nothing of interest there.";
            descs[36] = "A coffee vending machine with a broken window, someone must have beed fiending for caffeine real bad";
            descs[37] = "A brown puddle on the floor, the stench of stale coffee fills your nostrils.";
            descs[38] = "A bottle of hand sanitizer stands on a small piedestal, to the right of it a plaque telling you the importance of hand hygiene.";
            descs[39] = "You have an open door infront of you leading to cafeteria";

            //Cafeteria
            descs[40] = "A window, you cherish the dim light coming through.";
            descs[41] = "A kånken backpack hanging on the back of a chair. You look through it. All you find are some books and a phone charger. Too bad the power is out.";
            descs[42] = "Some windows lets some of the remaining light in to the cafeteria.";
            descs[43] = "A small table, two chairs lying on the floor, food still on the table. Someone got up in a hurry here.";
            descs[44] = "The massive bulletin board hanging there on the wall. Posters, flyers and nerdy memes fill almost all space.";
            descs[45] = "A curry sauce baguette, half eaten, lying there on the floor. They never tasted any good anyways.";
            descs[46] = "Along the wall there is a small stage, where many students have performed their badly written spoken word.";
            descs[47] = "A big poster hung on the wall.'Don't forget to recycle your trash'";
            descs[48] = "The cafeteria, once full of commotion, now lies dormant and empty.";
            descs[49] = "Walking thorugh the door you see the cafeteria. A spacious area with a few small tables and some chairs. Suddenly you realize the hunger clenching you stomach.";
            descs[50] = "The queue to the cafeteria counter starts here. Salads, soft drinks, sandwiches, coffee and tea. Way overpriced.";
            descs[51] = "The drawer to the cash register is open, money still inside.";
            descs[52] = "You step in puddle of something sticky and dark. More blood? What the fuck happened here! Is this all because of the teachers?";
            descs[53] = "An empty table in front of you.";
            descs[54] = "You feel your back aching. All those hours in front of the computer is taking it's toll!";
            descs[55] = "A waste bin, almost full.";
            descs[56] = "The recycling area, pointless. Everybody just throws everything in to combustible waste.";
            descs[57] = "A smashed plate on the ground, food strewn over the floor.";
            descs[58] = "The drywall has a big crack and a dent in it. Something must have bumped in to it, violently.";
            descs[59] = "A door to the most fabeled room in the history of school, the teachers lounge!\nYou will now bravely go where no other student has gone before!.";

            //Teachers lounge
            descs[60] = "A massive painting with a small shrine underneath it. The painting is of a young man with a glorious beard and a black cap.";
            descs[61] = "A shelf, filled with fabergé eggs, because why not?";
            descs[62] = "A home gym set. All the bells and whistles!";
            descs[63] = "A lavishly decorated highback chair.";
            descs[64] = "A coffe station. Espressos, americanos, lattes, chai, coffe syrup.";
            descs[65] = "Fancy massage chairs and a cooler, filled with beer.";
            descs[66] = "Beautiful paintings, all over the walls. So this is where the budget went!";
            descs[67] = "The most luxurious furniture you have ever seen. Beautiful arm chairs and reading lights next to a bookshelf";
            descs[68] = "A enthralling smell of freshly made cinnamon buns and coffee finding it's way through your nose..";
            descs[69] = "The most mythical area of the school lies before you, where no student has set foot before, the teachers lounge!";
            descs[70] = "What the hell, who even has a boule field inside?";
            descs[71] = "The boule field continues.";
            descs[72] = "The boule field continues even further. 'How long are theese things?!'";
            descs[73] = "A beautiful rug covers the floor.";
            descs[74] = "This is weird. The teachers lounge is untouched whilst the rest of the school is wrecked.";
            descs[75] = "This is surreal.";
            descs[76] = "A small snack bar with every snack you could ever imagine.";
            descs[77] = "Just a few steps to the emergency exit now!";
            descs[78] = "You can almost reach the emergency exit in the back of the room now!";
            descs[79] = "";


            int[] playerY = { 14, 13, 10, 9, 6, 5, 2, 1 };
            int[] playerX = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int x = 0; x < playerX.Length; x++)
            {
                for (int y = 0; y < playerY.Length; y++)
                {
                    if (currentPlayer.X == playerX[x] && currentPlayer.Y == playerY[y])
                    {
                        int roomNumber = int.Parse(y.ToString() + x.ToString());
                        Console.SetCursorPosition(1, 17);
                        Console.WriteLine(descs[roomNumber]);
                    }
                }
            }
            // Kollar om man har 10 keycards.
            if (currentPlayer.X == 10 && currentPlayer.Y == 1)
            {
                if (currentPlayer.keycard < 10)
                {
                    Console.Write("You have a door infront of you leading out of here!.\n You need 10 keycards to enter.");
                    currentPlayer.Y += 1;
                }
                if (currentPlayer.X == 10 && currentPlayer.Y == 1)
                {

                if (currentPlayer.keycard > 9)
                        Console.Write("You have a door infront of you, out of the school to your freedom!\n You have all the keycards so you can enter!");
                }
            }

            if (currentPlayer.health < 0)
            {
                Console.Clear();
                Console.WriteLine("YOU LOST THE GAME");
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.WriteLine("PRESS X TO EXIT");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
            }


            // När man vinner.
            if (currentPlayer.X == 10 && currentPlayer.Y == 0)
            {
                Console.Clear();
                Console.WriteLine(@"
──────────────────███─────────────█
─────────────███████████████───────█
──────────█████████████████████────█
──────██████████████████████████──█
──────███████████████████████████──█
────███████████████████████────█───█
──███████████████████████────▄█─█──█
████████████████████████████████████████
═══██═█████████═══█████████═██════
═══██═█████████═══█████████═██════
═████════███═════════███════████══
█████════█═█═════════█═█════█████═
█████════███═════════███════█████═
█████═══════════════════════█████═
█████═══════════════════════█████═
█████══════════███══════════█████═
█████═══════════█═══════════█████═
═████═══════════════════════████══
═══███████████████████████████════
═══█═██═██═██═██═██═██═██═██═█════
═══███████████████████████████════
═══██████═══════════════██████════
═══█═██═█═══════════════█═██═█════
═══███████═════════════███████════
═══███████████████████████████════
═══█═██═██═██═██═██═██═██═██═█════
═══███████████████████████████════
                ");
                Console.WriteLine("YOU WON THE GAME!!!!! ");
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.WriteLine("PRESS X TO EXIT");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    Environment.Exit(0);
                }

            }

        }

    }
}
