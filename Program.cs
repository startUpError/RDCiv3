﻿using System;
using RDCiv3.Buildings;
using RDCiv3.AccessData;
using RDCiv3.EventSystem;
using RDCiv3.Resources;

//TODO: Add other civilizations, include "Ethan's Village"
namespace RDCiv3
{

    //Stores game data
    struct GameData {
        //Time variables
        public int days = 0;
        public int actions = 3;
        //Population variables
        public int population = 5;

        //Material variables
        public double money = 0.00; //TODO: Make a float for program speed, as with only two decimal places there is no need for precision
        public int food = 20;
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

        public GameData() //Constructor; not necessary as all variables have defaults
        {
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

                //Limit the stats to their bounds
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
                
                //Set disonence to 100 if the people have 100% fear, otherwise, make it related to hoew unhappy they are minus how scared they are
                data.disonance = data.fear <= 0.99 ? (1 - data.happiness) - (data.fear * 0.35) : 10;

                //Checks and runs events (See the Events namespace)
                Events.All();

                //Adds materials for each building if not the first day
                //Each building produces 1 of its corresponding material
                if (data.days != 0)
                {
                    data.wood += data.woodHuts;
                    data.stone += data.stoneQuarries;
                    data.food += data.farms;
                }

                //Checks if its a game over, or removes food/population accordingly if not
                if (data.food >= data.population && data.population > 0) // If you have more food than people, and more than 0 people
                {
                    //Take away 1 food for every person
                    data.food -= data.population;
                    if (data.days == 0) {   //TODO: Move this logic elsewhere
                        //If its the first day, say new game message
                        Console.WriteLine("You have started a new game!");
                    } else {
                        //Otherwise say the new day message
                        Console.WriteLine("Your population has survived another day.");
                        //Add happiness if everyone is well fed
                        data.happiness += 0.01;
                    }
                    //Add to the day counter and reset action counter
                    data.days++;
                    data.actions = 3;
                } else if (data.food == 0) { //No food is a guarenteed not enough food  //TODO: Give some lee-way of no food days
                    Console.WriteLine("Game Over! You did not have enough food for your civilization!");
                    Environment.Exit(0); //TODO: Don't completely exit the program (maybe make main menu)
                    return;
                } else if (data.population > 0) { //Less food than people, but still more than zero people  //TODO: Give some lee-way of no food days
                    data.happiness -= (data.population - data.food) / 100; //Remove happiness based on how many excess people there are
                    data.population = data.food; //Only people with food can survive
                    data.food = 0; //All the food gets eaten
                    Console.WriteLine("Some of your population survived, but some died due to lack of food");
                    data.days++;
                    data.actions = 3;
                } else { //Only possible if you have zero people
                    //Write no people game over message and quit the game
                    Console.WriteLine("Game Over! You had no population remaining, so you had no civilization to run.");
                    Environment.Exit(0); //TODO: Don't completely exit the program (maybe make main menu)
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
                        //Reset housing failures (because now everyone left has a house)
                        data.housingFails = 0;
                    }
                } else { //Reset housing failures if you have enough houses again
                    data.housingFails = 0;
                }

                //Population grows to fill empty houses if you have double the food, but only if you let the population grow, and there is less than hte limit you set
                if (data.food >= data.population * 2 && data.houses > data.population && data.doesPopGrow && data.population < data.popGrowthLimit)
                {
                    int popGrowthAmount = Math.Min(data.houses - data.population, data.popGrowthLimit - data.population);
                    //For each new person, 1 more food is consumed
                    data.food -= popGrowthAmount;
                    data.population += popGrowthAmount;
                    //People are happy for the civilization to grow
                    data.happiness += 0.06 + Math.Round(0.002, 2); //TODO: ? Why is this Round here?
                }

                //Daily action loop
                while (true)
                {
                    //Display the stats
                    Display();
                    //Ask for an action as input
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Build, Demolish, Execute, Trade, Limit Population, Skip [enter], Skip Day [sd], Save, Quit");
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
                        case "sd":
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
                    if (data.actions <= 0)
                    {
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
            Console.WriteLine("Money = {0}", data.money);
            Console.WriteLine("Food = {0}", data.food);
            Console.WriteLine("Wood = {0}", data.wood);
            Console.WriteLine("Stone = {0}", data.stone);
            Console.WriteLine("Farms = {0}", data.farms);
            Console.WriteLine("Houses = {0}", data.houses);
            Console.WriteLine("Wood Huts = {0}", data.woodHuts);
            Console.WriteLine("Stone Quarries = {0}", data.stoneQuarries);
            Console.WriteLine("Parks = {0}", data.parks);
        }
    }
}