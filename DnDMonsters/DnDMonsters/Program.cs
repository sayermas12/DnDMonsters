using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnDMonsters
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
            List<NPC> npcs = new List<NPC>();
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
                Console.WriteLine("c) Delete NPCs");
                Console.WriteLine("d) Initiative List");
                Console.WriteLine("e) Add to Initiative");
                Console.WriteLine("f) Load Data");
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
                        DisplayAllNPCs(npcs);
                        break;
                    case "B":
                        npcs.Add(DisplayAddNPCs());
                        SaveNPCs(npcs);
                        break;
                    case "C":
                        DisplayDeleteNPC(npcs);
                        break;
                    case "D":
                        
                        break;
                    case "E":
                        Initiaitves(npcs);
                        break;
                    case "F":
                        npcs = LoadNPCs();
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
        #region NPC
        static void DisplayDeleteNPC(List<NPC> npcs)
        {
            DisplayScreenHeader("Delete NPC");

            //
            // display all NPC names
            //
            Console.WriteLine("\tNPC Names");
            Console.WriteLine("\t-------------");
            foreach (NPC npc in npcs)
            {
                Console.WriteLine("\t" + npc.Name);
            }

            //
            // get user NPC choice
            //
            Console.WriteLine();
            Console.Write("\tEnter name:");
            string NPCName = Console.ReadLine();

            //
            // get NPC object
            //
            NPC selectedNPC = null;
            foreach (NPC npc in npcs)
            {
                if (npc.Name == NPCName)
                {
                    selectedNPC = npc;
                    break;
                }
            }

            //
            // delete NPC
            //
            if (selectedNPC != null)
            {
                npcs.Remove(selectedNPC);
                Console.WriteLine();
                Console.WriteLine($"\t{selectedNPC.Name} deleted");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"\t{NPCName} not found");
            }

            DisplayContinuePrompt();
        }
        private static void SaveNPCs(List<NPC> npcs)
        {
            string dataPath = @"Data\NPC.txt";
            List<string> cereal = new List<string>();
            string current = "";
            foreach (NPC npc in npcs)
            {
                current = npc.Name + ",";
                current += npc.AC + ",";
                current += npc.Dex + ",";
                current += npc.Town;
                cereal.Add(current);
            }
            File.WriteAllLines(dataPath, cereal.ToArray());
        }
        private static List<NPC> LoadNPCs()
        {
            List<NPC> listnpc = new List<NPC>();
            string dataPath = @"Data\NPC.txt";
            string[] cereal = File.ReadAllLines(dataPath);
            string[] values;
            foreach (String npc in cereal)
            {
                
                values = npc.Split(',');
                listnpc.Add(new NPC()
                {
                    Name = values[0],
                    AC = int.Parse(values[1]),
                    Dex = int.Parse(values[2]),
                    Town = values[3]
                });

            }
            DisplayScreenHeader("File Loaded");
            DisplayContinuePrompt();
            return listnpc;
        }
        static void DisplayNPCStats(List<NPC> npcs)
        {
            DisplayScreenHeader("NPCs");

            DisplayContinuePrompt();
        }
        static NPC DisplayAddNPCs()
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
            Console.Write("\tDex Mod: ");
            int.TryParse(Console.ReadLine(), out int Dex);
            newNPC.Dex = Dex;
            Console.Write("\tTown: ");
            newNPC.Town = Console.ReadLine();
            //
            // echo new NPC properties
            //
            Console.WriteLine("\tNew NPC's Properties");
            DisplayContinuePrompt();

            return newNPC;
            
        }
        static void DisplayAllNPCs(List<NPC> npcs)
        {
            DisplayScreenHeader("All Monsters");

            Console.WriteLine("\t***************************");
            foreach (NPC npc in npcs)
            {
                NPCInfo(npc);
                Console.WriteLine();
                Console.WriteLine("\t***************************");
            }

            DisplayContinuePrompt();
        }
        static void NPCInfo(NPC npc)
        {
            Console.WriteLine($"\tName: {npc.Name}");
            Console.WriteLine($"\tAC: {npc.AC}");
            Console.WriteLine($"\tDex: {npc.Dex}");
            Console.WriteLine($"\tTown: {npc.Town}");
        }
        #endregion
        static void Initiaitves(NPC npc, List<NPC> npcs)
        {
            int Roll;
            //
            // display all NPC names
            //
            Console.WriteLine("\tNPC Names");
            Console.WriteLine("\t-------------");
            foreach (NPC npci in npcs)
            {
                Console.WriteLine("\t" + npc.Name);
            }

            //
            // get user NPC choice
            //
            Console.WriteLine();
            Console.Write("\tEnter name:");
            string NPCName = Console.ReadLine();

            //
            // get NPC object
            //
            NPC selectedNPC = null;
            foreach (NPC npci in npcs)
            {
                if (npc.Name == NPCName)
                {
                    selectedNPC = npc;
                    break;
                }
            }
            Console.WriteLine("Input Initiative Roll.");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out Roll);
            int DexNum = npc.Dex;
            int Initiative = Roll + DexNum;
        }
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
