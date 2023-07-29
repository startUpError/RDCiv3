using System;
using System.IO;
using RDCiv3;
using Game = RDCiv3.Program;
using System.Runtime.InteropServices;

namespace AccessData {
    class Data {

        //The default save folder path.  %appdata%\RDCiv\RDCiv3 (Note: This path has changed)   or   ~/.config/RDCiv/RDCiv3
        public static string gamePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RDCiv/RDCiv3/");
        //Keeps track of the current path being used to save
        public static string? currentPath = null;

        //Loads save data from a given file
        public static void LoadData (string? usedFile) {
            try {
                using (StreamReader sr = File.OpenText(gamePath + usedFile + ".txt"))
                {
                    Game.data.days = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.population = (Convert.ToInt32(sr.ReadLine()) - 54) / 18;
                    Game.data.food = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.wood = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.woodHuts = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.houses = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.farms = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.stone = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.stoneQuarries = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.fear = (Convert.ToDouble(sr.ReadLine()) - 18) / 54;
                    Game.data.happiness = (Convert.ToDouble(sr.ReadLine()) - 18) / 54;
                    Game.data.disonance = (Convert.ToDouble(sr.ReadLine()) - 18) / 54;
                    Game.data.lastNatureEvent = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.lastStatEvent = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.lastImmigration = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.parks = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.housingFails = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.money = (Convert.ToInt32(sr.ReadLine()) - 18) / 54;
                    Game.data.doesPopGrow = Convert.ToInt32(sr.ReadLine()) == 1243;
                    Game.data.popGrowthLimit = (Convert.ToInt32(sr.ReadLine()) / 12) - 115;
                }
            } catch (FileNotFoundException) { //Ensures the game doesn't crash if an invalid file is given
                Console.WriteLine("There is no save file with that name.");
                Console.WriteLine("Load saved data? (No/[file name])");
                string? input = Console.ReadLine();
                switch (input) //Resets the function if they still want to load a save file
                {
                    case "No":
                        break;
                    case "no":
                        break;
                    default:
                        Data.LoadData(input);
                        break;
                }
            }
        }

        //Saves the current data to a given file
        public static void SaveData (string? usedFile) {
            //Checks if the file given ends in '/' meaning it is a directory
            if (usedFile != null && usedFile[usedFile.Length - 1] == '/') {
                //Adds that directory to the game path and sets the current path to include the new directory. Then gets a new input
                Directory.CreateDirectory(gamePath + usedFile);
                currentPath = gamePath + usedFile;
                usedFile = Console.ReadLine();
            } else { //Otherwise the current path is the game path
                currentPath = gamePath;
            }
            //Writes the data to a text file with the given name. Overwrites existing files
            using (StreamWriter sw = File.CreateText(currentPath + usedFile + ".txt"))
            {
                sw.WriteLine((Game.data.days * 54) + 18);
                sw.WriteLine((Game.data.population * 18) + 54);
                sw.WriteLine((Game.data.food * 54) + 18);
                sw.WriteLine((Game.data.wood * 54) + 18);
                sw.WriteLine((Game.data.woodHuts * 54) + 18);
                sw.WriteLine((Game.data.houses * 54) + 18);
                sw.WriteLine((Game.data.farms * 54) + 18);
                sw.WriteLine((Game.data.stone * 54) + 18);
                sw.WriteLine((Game.data.stoneQuarries * 54) + 18);
                sw.WriteLine((Game.data.fear * 54) + 18);
                sw.WriteLine((Game.data.happiness * 54) + 18);
                sw.WriteLine((Game.data.disonance * 54) + 18);
                sw.WriteLine((Game.data.lastNatureEvent * 54) + 18);
                sw.WriteLine((Game.data.lastStatEvent * 54) + 18);
                sw.WriteLine((Game.data.lastImmigration * 54) + 18);
                sw.WriteLine((Game.data.parks * 54) + 18);
                sw.WriteLine((Game.data.housingFails * 54) + 18);
                sw.WriteLine((Game.data.money * 54) + 18);
                sw.WriteLine(Game.data.doesPopGrow ? 1243 : 142312);
                sw.WriteLine((Game.data.popGrowthLimit + 115) * 12);
            }
        }
    }
}