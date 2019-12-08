using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnDNPCs
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMainMenu();
            DisplayClosingScreen();
        }
        static void DisplayMainMenu()
        {
            DisplayScreenHeader("NPCs");
            DisplayMenu();

            DisplayContinuePrompt();
        }
        static void DisplayMenu()
        {
            bool quitApplication = false;
            string menuChoice;
            do
            {
                DisplayScreenHeader("Main Menu");
                //
                //get menu choice from user
                //

                Console.WriteLine("a) Display NPC Stats");
                Console.WriteLine("b) Add NPCs");
                Console.WriteLine("c) Modify NPCs");
                Console.WriteLine("d) Initiative List");
                Console.WriteLine("e) Add to Initiative");
                Console.WriteLine("f) N/A");
                Console.WriteLine("g) N/A");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine().ToUpper();

                //
                // process menu choice
                //

                switch (menuChoice)
                {
                    case "A":
                        DisplayNPCStats();
                        break;
                    case "B":
                        DisplayAddNPCs();
                        break;
                    case "C":
                        
                        break;
                    case "D":
                        
                        break;
                    case "E":
                        
                        break;
                    case "F":
                        DisplayScreenHeader("Not Availible");
                        DisplayContinuePrompt();
                        break;
                    case "G":
                        DisplayScreenHeader("Not Availible");
                        DisplayContinuePrompt();
                        break;
                    case "Q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a menu choice. ");
                        DisplayContinuePrompt();
                        break;

                }
            } while (!quitApplication);
        }
        static void DisplayNPCStats()
        {
            DisplayScreenHeader("NPCs");
            DisplayListChoice();
            DisplayContinuePrompt();
        }
        static void DisplayListChoice()
        {
            string dataPath = @"Data\NPCs.txt";

        }
        static void DisplayAddNPCs()
        {
            string dataPath = @"Data\NPCs.txt";
            List<string> NPC = new List<string>();
            File.WriteAllLines(dataPath, NPC.ToArray());

            {
                NPC newNPC = new NPC();

                DisplayScreenHeader("Add NPC");

                //
                // add NPC object property values
                //
                Console.Write("\tName: ");
                newNPC.Name = Console.ReadLine();
                Console.Write("\tAC: ");
                int.TryParse(Console.ReadLine(), out int AC);
                newNPC.AC = AC;
                Console.Write("\tTown: ");
                newNPC.Town = Console.ReadLine();
                //
                // echo new NPC properties
                //
                Console.WriteLine("\tNew NPC's Properties");
                DisplayContinuePrompt();

                NPC.Add(newNPC);
            }
        }
        //static void NPCInfo(NPC NPC)
        //{
        //    Console.WriteLine($"\tName: {NPC.Name}");
        //    Console.WriteLine($"\tAge: {NPC.Age}");
        //    Console.WriteLine($"\tAttitude: {NPC.Attitude}");
        //    Console.WriteLine($"\t" + NPC.Greeting());
        //}
        #region HELPER METHODS

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t Stat Tracker");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFair Well Traveler!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
