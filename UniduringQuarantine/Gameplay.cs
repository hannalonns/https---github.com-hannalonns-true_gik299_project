using System;

namespace UniduringQuarantine
{
    public class Gameplay
    {
        private Map MyMap;
        public static Player currentPlayer = new Player(1, 15);

        // FIENDER

        public static Enemies currentEnemy = new Enemies(10, 13);
        // public static Enemies currentEnemy2 = new Enemies(2, 14);

        // NYCKLAR

        public static KeyCards keyCard1 = new KeyCards(1, 13);
        public static KeyCards keyCard2 = new KeyCards(4, 10);
        public static KeyCards keyCard3 = new KeyCards(4, 2);
        public static KeyCards keyCard4 = new KeyCards(1, 13);

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
            Console.ReadKey();
            Console.Clear();
            Console.Write("What is your name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("you awake in a cold and dark school, you're in Högskolan Dalarna in Borlänge.");
            Console.WriteLine("You vaguely remember everyone at school starting to cough and due to safety reasons a lockdown began, but...The teachers...\nThey didn't just cough. You think A teacher starting chasing the students, everybody was screaming.");
            if (currentPlayer.name == "")
            {
                Console.WriteLine("\nYou can't remember much, not even what your name is.");
                Console.ReadLine();
            }

            // HÄR ÄR EN LITEN EASTER EGG TILL THOMAS :) 

            else if (currentPlayer.name.ToLower() == "Thomas")
            {
                Console.WriteLine("\nYou can't remember much at all, but you have the same name as your favorite teacher!");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("\nYou can't remember much more, but you atleast know your name is {0} .", currentPlayer.name);
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("You can walk by writing go up (W), go down (S), go left (A), go right (D)");
            Console.ReadLine();
            Console.Clear();


            // HÄR ÄR KARTAN 

            string[,] grid =
           {

                {"=","=","=","=","=","=","=","=","=","=","X","="},
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

            // Dessa nedanför är för att kunna spela spelet igen.

            currentEnemy = new Enemies(10, 13);
            currentPlayer = new Player(1, 15);
            keyCard1 = new KeyCards(1, 13);
            keyCard2 = new KeyCards(4, 10);
            keyCard3 = new KeyCards(7, 5);
            keyCard4 = new KeyCards(4, 2);

            // Här körs spelets loop och storyline. 

            RunGameLoop();
            StoryLine();
        }


        // Här Ritas allt på kartan ut. 
        private void DrawFrame()
        {
            Console.Clear();
            MyMap.Draw();
            currentPlayer.Draw();
            currentEnemy.Draw();
            keyCard1.DrawKey1();
            keyCard2.DrawKey2();
            keyCard3.DrawKey3();
            keyCard4.DrawKey4();
        }


        // Här är lite text till kartan och spelarens olika input i consolen.
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
            StoryLine();
            Console.SetCursorPosition(1, 25);
            Console.WriteLine(currentPlayer.X + " " + currentPlayer.Y);
            Console.Write("Write here: ");
            string moveChoice = Console.ReadLine();
            switch (moveChoice)
            {
                case "go up":
                case "w":
                    if (MyMap.Walkable(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.Y -= 1;
                    }
                    break;
                case "go down":
                case "s":
                    if (MyMap.Walkable(currentPlayer.X, currentPlayer.Y + 1))
                    {
                        currentPlayer.Y += 1;
                    }
                    break;
                case "go left":
                case "a":
                    if (MyMap.Walkable(currentPlayer.X - 1, currentPlayer.Y))
                    {
                        currentPlayer.X -= 1;
                    }
                    break;
                case "go right":
                case "d":
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

                // kolla om man har mindre hälsa än 0.

                if (currentPlayer.health < 0)
                {
                    Console.Clear();
                    Console.WriteLine("YOU LOST THE GAME");
                    break;

                }

                // Detta för att förhindra blinkande.
                System.Threading.Thread.Sleep(20);

            }
        }

        public void StoryLine()

        // I denna sektion kommer alla olika koordinater ha sina properties som när man hittar nycklar, fiender eller vilken text det står på ett rum.

        {
            if (currentPlayer.X == currentEnemy.X && currentPlayer.Y == currentEnemy.Y) // om man är på samma position som en fiende.
            {

                {
                    currentEnemy.Teacher();
                }
            }


            if (keyCard1.X == currentPlayer.X && currentPlayer.Y == keyCard1.Y)  // om man är på samma position som nyckel 1.
            {

                currentPlayer.keycard += 1;
                Console.WriteLine("You picked up a keycard!");
                Console.WriteLine("You have {0} keycard in your pocket", currentPlayer.keycard);

                keyCard1.Y -= 1;

            }

            if (keyCard2.X == currentPlayer.X && currentPlayer.Y == keyCard2.Y) // om man är på samma position som nyckel 2.
            {

                currentPlayer.keycard += 1;
                Console.WriteLine("You pick up a dirty old book, and a keycard falls out!");
                Console.WriteLine("You have {0} keycards in your pocket", currentPlayer.keycard);

                keyCard2.Y -= 2;

            }

            if (keyCard3.X == currentPlayer.X && currentPlayer.Y == keyCard3.Y) // om man är på samma position som nyckel 3.
            {

                currentPlayer.keycard += 1;
                Console.WriteLine("Lying on the ground, in spilled coffee, lies a keycard!");
                Console.WriteLine("You have {0} keycards in your pocket", currentPlayer.keycard);

                keyCard3.Y -= 1;

            }

            if (keyCard4.X == currentPlayer.X && currentPlayer.Y == keyCard4.Y) // om man är på samma position som nyckel 4.
            {

                currentPlayer.keycard += 1;
                Console.WriteLine("You picked the last keycard! Hurry through the door to win!");
                Console.WriteLine("You have {0} keycards in your pocket", currentPlayer.keycard);

                keyCard4.Y -= 2;

            }
            
             else if (currentEnemy.X == 10 && currentEnemy.Y == 1) // så att fienden inte hamnar utanför kartan.
            {
                currentEnemy.Y += 11;
            }


            // RECEPTION // 


            else if (currentPlayer.X == 1 && currentPlayer.Y == 15)
            {
                Console.Write("You're standing in the main entrence of the school.\n There's a front desk further away, with some tables and chairs along the hallway.");
            }
            else if (currentPlayer.X == 1 && currentPlayer.Y == 14)
            {
                Console.Write("You hear a noise from... Somewhere. You better hurry finding that keycard.");
            }
            else if (currentPlayer.X == 2 && currentPlayer.Y == 14)
                Console.Write("You're walking past some broken chairs. What the hell happend here?");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 14)
                Console.Write("You can see a pamphlet stand next to you.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 14)
                Console.Write("You feel like you're being watched..");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 14)
                Console.Write("You're in the middle of the reception area.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 14)
                Console.Write("There is a broken phone on the table to your left, you look at it... Useless.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 14)
                Console.Write("You see the door to the library");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 14)
                Console.Write("You're still in the reception");

            else if (currentPlayer.X == 9 && currentPlayer.Y == 14)
                Console.Write("You just want to go home...");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 14)
                Console.Write("You're facing a door a couple steps ahead, leading to the library.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 13)
                Console.Write("You can see a painting hanging to your right. Covered in what looks like blood");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 13)
                Console.Write("You're standing behind the front desk. Papers are cluttered all over the place. \n An old coffeemug stands next to the computer, there are flies circling it. Gross!");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 13)
                Console.Write("You found a picture of some students, making you miss your classmates\n it gives you an eerie feeling of this sudden cold, deserted place...");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 13)
                Console.Write("The front desk ends here");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 13)
                Console.Write("You have a dead flower infront of you, once beautiful and alive");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 13)
                Console.Write("You feel a shiver crawling up your back. Cold wind is coming from somewhere");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 13)
                Console.Write("You can see a door some steps ahead");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 13)
                Console.Write("You're thinking of how much you miss this place before the lockdown.");

            else if (currentPlayer.X == 9 && currentPlayer.Y == 13)
                Console.Write("You're close to the door");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 13)
                Console.Write("You're close to the door");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 12)
            {

                if (currentPlayer.keycard < 1)
                {
                    Console.Write("You have a door infront of you leading to the library.\n You need a keycard to enter.");  // här flyttas man tillbaka ett steg om man ej har en keycard.
                    currentPlayer.Y += 1;
                }

                else if (currentPlayer.keycard > 0)
                    Console.Write("You have a door infront of you, leading to the library.\n You use the keycard to enter!");
            }


            // LIBRARY // 

            else if (currentPlayer.X == 10 && currentPlayer.Y == 11)
            {
                Console.Write("A dark gloomy area lays before you.\nThe ceiling height is phenomenal in here!\nLong, wooden shelves perched up against the sides of the room.");
            }
            else if (currentPlayer.X == 10 && currentPlayer.Y == 10)
            {
                Console.Write("You recognize familiar smell of old, second hand books.\nYou can see the bookcases dissapearing in to the dark before you.");
            }
            else if (currentPlayer.X == 9 && currentPlayer.Y == 10)
            {
                Console.Write("The book cases continue along the wall.\nThe knowledge of thousands in one room.");
            }
            else if (currentPlayer.X == 8 && currentPlayer.Y == 10)
                Console.Write("A small gap in the book cases reveal an old photo copier.\nNothing of interest really.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 10)
                Console.Write(" A blue, high back, semi circular sofa emerge before you from the darkness.\nA small wooden table in front of the sofa. You can see brown smudges on the table, must be coffee. Let us hope nothing got on the book.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 10)
                Console.Write("The bok cases appear again.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 10)
                Console.Write("You can see the light fading fast through the few windows in the library. It must be getting late.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 10)
                Console.Write("The book cases continue.");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 10)
                Console.Write("The ceiling height is back to normal now. It feels like a cave opening.\nThe lack of windows in here doesn't make wonders for the lighting situation.");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 10)
                Console.Write("It's getting really dark now.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 10)
                Console.Write("The darkness is so dense the air almost feels more compact here. You stop, almost walking in to the book case in front of you.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 9)
                Console.Write("You walk with cautious steps, your hand stretched out in front of you. One could say you can't C very # in this darkness.");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 9)
                Console.Write("You squint, trying to see through the darkness");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 9)
                Console.Write("The ceiling height drastically changes. The further in the room the lower it gets the far end feels almost cavelike, no windows.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 9)
                Console.Write("It's so dark in here, too bad my phone battrey died while i was knocked out cold.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 9)
                Console.Write("You walk past a book shelf, you notice the book Think Like a Programmer -An Introduction to Creative Problem Solving and get a flashback of all the late study nights.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 9)
                Console.Write("There is a small stair case leading up to an empty reading area, nothing of interest there.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 9)
                Console.Write("A coffee vending machine with a broken window, someone must have beed fiending for caffeine real bad");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 9)
                Console.Write("A brown puddle on the floor, the stench of stale coffee fills your nostrils.");

            else if (currentPlayer.X == 9 && currentPlayer.Y == 9)
                Console.Write("A bottle of hand sanitizer stands on a small piedestal, to the right of it a plaque telling you the importance of hand hygiene."); //

            else if (currentPlayer.X == 10 && currentPlayer.Y == 9)
                Console.Write("You're thinking of how much you miss this place before the qurantine.");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 8)
            {

                if (currentPlayer.keycard < 2)
                {
                    Console.Write("You have a door infront of you leading to cafeteria\n You need a keycard to enter.");
                    currentPlayer.Y += 1;
                }

                else if (currentPlayer.keycard > 1)
                    Console.Write("You have a door infront of you, leading to the cafeteria.\n You have a keycard so you can enter!");
            }



            // CAFETERIA

            else if (currentPlayer.X == 10 && currentPlayer.Y == 7)
            {
                Console.Write("Walking thorugh the door you see the cafeteria. A spacious area with a few small tables and some chairs. Suddenly you realize the hunger clenching you stomach.");
            }
            else if (currentPlayer.X == 10 && currentPlayer.Y == 6)
            {
                Console.Write("The cafeteria, once full of commotion, now lies dormant and empty.");
            }
            else if (currentPlayer.X == 9 && currentPlayer.Y == 6)
                Console.Write("A big poster hung on the wall.'Don't forget to recycle your trash'");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 6)
                Console.Write("Along the wall there is a small stage, where many students have performed their badly written spoken word.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 6)
                Console.Write("A curry sauce baguette, half eaten, lying there on the floor. They never tasted any good anyways.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 6)
                Console.Write("The massive bulletin board hanging there on the wall. Posters, flyers and nerdy memes fill almost all space.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 6)
                Console.Write("A small table, two chairs lying on the floor, food still on the table. Someone got up in a hurry here.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 6)
                Console.Write("Some windows lets some of the remaining light in to the cafeteria.");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 6)
                Console.Write("A kånken backpack hanging on the back of a chair. You look through it. All you find are some books and a phone charger. Too bad the power is out.");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 6)
                Console.Write("A window, you cherish the dim light coming through.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 6)
                Console.Write("The queue to the cafeteria counter starts here. Salads, soft drinks, sandwiches, coffee and tea. Way overpriced.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 5)
                Console.Write("The drawer to the cash register is open, money still inside.");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 5)
                Console.Write("You step in puddle of something sticky and dark. More blood? What the fuck happened here! Is this all because of the teachers?");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 5)
                Console.Write("An empty table in front of you.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 5)
                Console.Write("You feel your back aching. All those hours in front of the computer is taking it's toll!.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 5)
                Console.Write("A waste bin, almost full.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 5)
                Console.Write("The recycling area, pointless. Everybody just throws everything in to combustible waste.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 5)
                Console.Write("A smashed plate on the ground, food strewn over the floor.");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 5)
                Console.Write("The drywall has a big crack and a dent in it. Something must have bumped in to it, violently.");

            else if (currentPlayer.X == 9 && currentPlayer.Y == 5)
                Console.Write("Just a few steps to the door now.");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 5)
                Console.Write("You can't wait to come home after this.");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 4)
            {

                if (currentPlayer.keycard < 3)
                {
                    Console.Write("You have a door infront of you leading to the teachers lounge.\n You need a keycard to enter.");
                currentPlayer.Y += 1;
                }
                else if (currentPlayer.keycard > 2)
                    Console.Write("You have a door infront of you, leading to the teachers lounge.\n You have a keycard so you can enter!");



            }


            // STAFF ROOM

            else if (currentPlayer.X == 10 && currentPlayer.Y == 3)
            {
                Console.Write("The most mythical area of the school lies before you, where no student has set foot before, the teachers lounge!");
            }
            else if (currentPlayer.X == 10 && currentPlayer.Y == 2)
            {
                Console.Write("A enthralling smell of freshly made cinnamon buns and coffee finding it's way through your nose..");
            }
            else if (currentPlayer.X == 9 && currentPlayer.Y == 2)
                Console.Write("The most luxurious furniture you have ever seen. Beautiful arm chairs and reading lights next to a bookshelf");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 2)
                Console.Write("Beutiful paintings, all over the walls. So this is where the budget went!");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 2)
                Console.Write("Fancy massage chairs and a cooler, filled with beer.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 2)
                Console.Write("A coffe station. Espressos, americanos, lattes, chai, coffe syrup.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 2)
                Console.Write("A lavishly decorated highback chair.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 2)
                Console.Write("A home gym set. All the bells and whistles!");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 2)
                Console.Write("A big screen tv and recliner chairs.");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 2)
                Console.Write("A shelf, filled with fabergé eggs.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 2)
                Console.Write("A massive painting with a small shrine underneath it. The painting is of a young man with a glorious beard and a black cap.");

            else if (currentPlayer.X == 1 && currentPlayer.Y == 1)
                Console.Write("What the hell, who even has a boule field inside?");

            else if (currentPlayer.X == 2 && currentPlayer.Y == 1)
                Console.Write("The boule field continues.");

            else if (currentPlayer.X == 3 && currentPlayer.Y == 1)
                Console.Write("The boule field continues.");

            else if (currentPlayer.X == 4 && currentPlayer.Y == 1)
                Console.Write("A beautiful rug covers the floor.");

            else if (currentPlayer.X == 5 && currentPlayer.Y == 1)
                Console.Write("This is weird. The teachers lounge is untouched whilst the rest of the school is wrecked.");

            else if (currentPlayer.X == 6 && currentPlayer.Y == 1)
                Console.Write("This is surreal.");

            else if (currentPlayer.X == 7 && currentPlayer.Y == 1)
                Console.Write("A small snack bar.");

            else if (currentPlayer.X == 8 && currentPlayer.Y == 1)
                Console.Write("Just a few steps to the door now.");

            else if (currentPlayer.X == 9 && currentPlayer.Y == 1)
                Console.Write("So close!");

            else if (currentPlayer.X == 10 && currentPlayer.Y == 1)
            {
                if (currentPlayer.keycard < 4)
                {
                    Console.Write("You have a door infront of you leading out of here!.\n You need a keycard to enter.");
                currentPlayer.Y += 1;
                }

                else if (currentPlayer.keycard > 3)
                    Console.Write("You have a door infront of you, out of the school to your freedom!\n You have a keycard so you can enter!");

            }

          

            else if (currentPlayer.X == 10 && currentPlayer.Y == 0)   // När man vinner.
            {
                Console.Clear();
                Console.WriteLine("YOU WON THE GAME!!!!! ");
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.WriteLine("PRESS X TO EXIT");

            }

        }

    }

}




