using System;
using Buildings;
using AccessData;
using EventSystem;
using Resources;

//TODO: Add other civilizations, include "Ethan's Village"
namespace RDCiv3
{

    //Stores game data
    //TODO: Population includes children, adults, and elders.
    /*
        TODO: User can delegate work to adults.
        TODO Worker Types:
        + Builder
        + Woodcutter
        + Miner
        + Farmer
    */
    //-.TODO: Money
    struct GameData {
        //Time variables
        public int days = 0;
        public int actions = 3;
        //Population variables
        public int population = 5;
        public List<int> children = new List<int>();
        public List<int> adults = new List<int>();
        public List<int> elders = new List<int>();

        public int builders = 2;
        public int woodCutters = 1;
        public int miners = 1;
        public int farmers = 1;
        //Material variables
        public double money = 0.00;
        public int food = 10;
        public int wood = 5;
        public int stone = 5;
        //Building variables
        public int farms = 1;
        public int houses = 5;
        public int woodHuts = 1;
        public int stoneQuarries = 1;
        public int parks = 0;

        //Hidden variables
        public double fear = 0.00;
        public double happiness = 0.75;
        public double disonance = 0.00;
        public bool doesPopGrow = true;
        public int popGrowthLimit = 1000000;

        //Hidden counters
        public int lastNatureEvent = 0;
        public int lastStatEvent = 0;
        public int lastImmigration = 0;
        public int housingFails = 0;
        
        //Cheat variables
        public bool cheats = false;
        public bool revolts = true;

        //Prevents error assigns the 5 adults
        public GameData () {
            for (int i = 0; i < 5; i++)
            {
                adults.Add(0);
            }
        }
    }

    class Program
    {
        
        //Stores game data
        public static GameData data = new GameData();

        //Entry point for the program
        public static void Main ()
        {
            //Creates the save data folder if it doesn't already exist
            Directory.CreateDirectory(Data.gamePath);
            //Checks if the user wants to load save
            Console.WriteLine("Load saved data? (No/[file name])");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "No":
                    break;
                case "no":
                    break;
                default:
                    //Loads the save file provided
                    Data.LoadData(input);
                    break;
            }
            //Game loop
            while (true)
            {

                //Updates the hidden stats
                data.disonance = data.fear <= 0.99 ? (1 - data.happiness) - (data.fear * 0.35) : 10;

                if (data.happiness > 1) {
                    data.happiness = 1;
                } else if (data.happiness < 0.02 * data.parks) { //Minimum happiness is limited to how many parks you have. +2% for each park
                    data.happiness = 0.02 * data.parks;
                }
                if (data.fear > 1) {
                    data.fear = 1;
                } else if (data.fear < 0) {
                    data.fear = 0;
                }

                for (int i = 0; i < data.children.Count; i++) {
                    data.children[i]++;
                    if (data.children[i] > 7) {
                        data.children.Remove(data.children[i]);
                        data.adults.Add(0);
                    }
                }
                for (int i = 0; i < data.adults.Count; i++) {
                    data.adults[i]++;
                    if (data.adults[i] > 15) {
                        data.adults.Remove(data.adults[i]);
                        data.elders.Add(0);
                    }
                }
                foreach (int current in data.elders) {
                    if (current > 5) {
                        data.adults.Remove(current);
                    }
                }

                //Updates total population count
                data.population = data.children.Count + data.adults.Count + data.elders.Count;

                //Removes workers in priority order if there aren't enough adults
                //Builders, Wood Cutters, Miners, then Farmers
                if (data.builders + data.woodCutters + data.miners + data.farmers > data.adults.Count) {
                    if (data.adults.Count != 0) {
                        while(data.builders + data.woodCutters + data.miners + data.farmers > data.adults.Count && data.builders > 0) {
                            data.builders--;
                        }
                        if (data.woodCutters + data.miners + data.farmers > data.adults.Count) {
                            while(data.woodCutters + data.miners + data.farmers > data.adults.Count && data.woodCutters > 0) {
                                data.woodCutters--;
                            }
                            if (data.miners + data.farmers > data.adults.Count) {
                                while(data.miners + data.farmers > data.adults.Count && data.miners > 0) {
                                    data.miners--;
                                }
                                if (data.farmers > data.adults.Count) {
                                    while(data.farmers > data.adults.Count && data.farmers > 0) {
                                        data.farmers--;
                                    }
                                }
                            }
                        }
                    } else {
                        data.builders = 0;
                        data.woodCutters = 0;
                        data.miners = 0;
                        data.farmers = 0;
                    }
                }

                //Checks and runs events
                Events.All();

                //Adds materials for each worker in a building if its not the first day
                //-.TODO: Material growth scales to workers of that type
                if (data.days != 0)
                {
                    //Wood Huts => 3 slots
                    if (data.woodHuts * 3 >= data.woodCutters) { //Checks if there are enough empty slots for all the workers and adds wood for each worker if so.
                        data.wood += data.woodCutters * 2;
                    } else { //Otherwise only adds wood for the slots filled
                        data.wood += data.woodHuts * 6; //huts * 3 * 2
                    }
                    //Stone Quarries => 2 slots
                    if (data.stoneQuarries * 2>= data.miners) {
                        data.stone += data.miners * 2;
                    } else {
                        data.stone += data.stoneQuarries * 4; //quarries * 2 * 2
                    }
                    //Farms => 4 slots
                    if (data.farms * 4 >= data.farmers) {
                        data.food += data.farmers * 3;
                    } else {
                        data.food += data.farms * 12; //farms * 4 * 3
                    }
                }

                //Checks if its a game over, or removes food/population accordingly if not
                if (data.food >= data.population && data.population > 0) // If you have more food than people, and more than 0 people
                {
                    //Take away 1 food for every person
                    data.food -= data.population;
                    if (data.days == 0) {
                        //If its the first day, say new game message
                        Console.WriteLine("You have started a new game!");
                    } else {
                        //Otherwise say the new day message
                        Console.WriteLine("Your population has survived another day.");
                        //Add happiness if everyone is fed
                        data.happiness += 0.01;
                    }
                    //Add to the day counter and reset action counter
                    data.days++;
                    data.actions = 3;
                } else if (data.food == 0) { //No food is a guarenteed not enough food
                    Console.WriteLine("Game Over! You did not have enough food for your civilization!");
                    Environment.Exit(0);
                    return;
                } else if (data.population > 0) { //Less food than people, but still more than zero people
                    data.happiness -= (data.population - data.food) / 100;
                    data.population = data.food;
                    data.food = 0;
                    Console.WriteLine("Some of your population survived, but some died due to lack of food");
                    data.days++;
                    data.actions = 3;
                } else { //Only possible if you have zero people
                    //Write no people game over message and quit the game
                    Console.WriteLine("Game Over! You had no population remaining, so you had no civilization to run.");
                    Environment.Exit(0);
                    return;
                }

                //If you have more people then houses, count a housing failure
                if (data.population > data.houses) {
                    data.housingFails++;
                    //Take away happiness for each person without a house
                    data.happiness -= 0.01 * (data.population - data.houses);
                    //If you have 4 or more housing failures then the people without houses die
                    if (data.housingFails >= 4) {
                        data.population -= (data.population - data.houses);
                        Console.WriteLine("Some of your population died because they went without shelter for too long.");
                        //Reset housing failures
                        data.housingFails = 0;
                    }
                } else { //Reset housing failures if you have enough houses again
                    data.housingFails = 0;
                }

                //Population grows to fill empty houses if you have double the food
                /*
                    -TODO: Improve the growth system. 
                    -EG. User can set a pop-growth cap
                    -EG. User can toggle pop-growth
                */
                if (data.food >= data.adults.Count * 2 && data.houses > data.population && data.doesPopGrow && data.population < data.popGrowthLimit)
                {
                    //For each new person, 1 more food is consumed
                    data.food -= data.adults.Count * (data.houses - data.population);
                    data.population += (data.houses - data.population) < data.popGrowthLimit ? (data.houses - data.population) : data.popGrowthLimit - data.population;
                    //People are happy for the civilization to grow
                    data.happiness += 0.06;
                }

                //Daily action loop
                while (true)
                {
                    //Display the stats
                    Display();
                    //Ask for an action as input
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Build, Demolish, Execute, Trade, Limit Population, Skip, Skip Day, Save, Quit");
                    //Check possibilities and run code accordingly
                    switch (Console.ReadLine())
                    {
                        case "Build":
                            Building.Build();
                            break;
                        case "Skip":
                            data.actions--;
                            break;
                        case "Quit":
                            Environment.Exit(0);
                            return;
                        case "quit":
                            Environment.Exit(0);
                            break;
                        case "Save":
                            input = Console.ReadLine();
                            Data.SaveData(input);
                            break;
                        case "save":
                            input = Console.ReadLine();
                            Data.SaveData(input);
                            break;
                        case "build":
                            Building.Build();
                            break;
                        case "skip":
                            data.actions--;
                            break;
                        //TODO: Fix execution to kill population ages in priority order. Otherwise population refills after execution.
                        case "Execute":
                            Population.Execute();
                            break;
                        case "execute":
                            Population.Execute();
                            break;
                        case "Trade":
                            Trading.Trade();
                            break;
                        case "trade":
                            Trading.Trade();
                            break;
                        case "": //An easier skip action
                            data.actions--;
                            break;
                        case "Demolish":
                            Building.Demolish();
                            break;
                        case "demolish":
                            Building.Demolish();
                            break;
                        case "Skip Day":
                            data.actions = 0;
                            break;
                        case "Skip day":
                            data.actions = 0;
                            break;
                        case "skip Day":
                            data.actions = 0;
                            break;
                        case "skip day":
                            data.actions = 0;
                            break;
                        case "Limit Population":
                            Population.LimitPopulation();
                            break;
                        case "Limit population":
                            Population.LimitPopulation();
                            break;
                        case "limit Population":
                            Population.LimitPopulation();
                            break;
                        case "limit population":
                            Population.LimitPopulation();
                            break;
                        //Cheat options below
                        case "K1ll":
                            if (data.cheats) {
                                data.population -= Convert.ToInt32(Console.ReadLine());
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "cheats on":
                            data.cheats = true;
                            break;
                        case "getFood":
                            if (data.cheats) {
                                data.food += 10000;
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "getDayz":
                            if (data.cheats) {
                                data.days += 10000;
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "getFarms":
                            if (data.cheats) {
                                data.farms += 10000;
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "getPops":
                            if (data.cheats) {
                                data.population += 10000;
                                data.food += 10000;
                                data.houses += 10000;
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "showHiddenStats":
                            if (data.cheats) {
                                Console.WriteLine("fear = {0}", data.fear);
                                Console.WriteLine("happiness = {0}", data.happiness);
                                Console.WriteLine("disonance = {0}", data.disonance);
                                Console.WriteLine("lastNatureEvent = {0}", data.lastNatureEvent);
                                Console.WriteLine("lastStatEvent = {0}", data.lastStatEvent);
                                Console.WriteLine("lastImmigration = {0}", data.lastImmigration);
                            } else {
                                Console.WriteLine("That isn't an option");
                            }
                            break;
                        case "happiness":
                            if (data.cheats) {
                                data.happiness += Convert.ToDouble(Console.ReadLine());
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "fear":
                            if (data.cheats) {
                                data.fear += Convert.ToDouble(Console.ReadLine());
                            } else {
                                Console.WriteLine("That isn't an option.");
                            }
                            break;
                        case "noRevolts":
                            data.revolts = false;
                            break;
                        default: //If it isnt found, loop through again
                            Console.WriteLine("That isn't an option.");
                            break;
                    }

                    //If you have no actions left for the day, break the action loop
                    if (data.actions <= 0) {
                        break;
                    }
                }
            }
        }

        //Displays the current stats
        public static void Display ()
        {
            Console.WriteLine("Day = {0}", data.days);
            Console.WriteLine("Actions remaining = {0}", data.actions);
            Console.WriteLine("Population = {0}", data.population);
            Console.WriteLine("Children = {0}, Adults = {1}, Elders = {2}", data.children.Count, data.adults.Count, data.elders.Count);
            Console.WriteLine("Builders = {0}, Wood Cutters [Produces 2 wood] = {1}, Miners [Produces 2 stone] = {2}, Farmers [Produces 3 food] = {3}", data.builders, data.woodCutters, data.miners, data.farmers);
            Console.WriteLine("Money = {0}", data.money);
            Console.WriteLine("Food = {0}", data.food);
            Console.WriteLine("Wood = {0}", data.wood);
            Console.WriteLine("Stone = {0}", data.stone);
            Console.WriteLine("Farms [4 Work Slots] = {0}", data.farms);
            Console.WriteLine("Houses = {0}", data.houses);
            Console.WriteLine("Wood Huts [3 Work Slots] = {0}", data.woodHuts);
            Console.WriteLine("Stone Quarries [2 Work Slots] = {0}", data.stoneQuarries);
            Console.WriteLine("Parks = {0}", data.parks);
        }
    }
}