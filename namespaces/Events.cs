using System;
using RDCiv3;
using Game = RDCiv3.Program;

namespace RDCiv3.EventSystem {
    class Events {

        //Allows random number generation
        public static Random Random = new Random();

        //Runs every event check
        public static void All () {
            Immigrate();
            Emigrate();
            Revolt();
            Vandalism();
            Natural();
        }
        //Only runs events provided in the string
        public static void Given (string[] events) {
            foreach (string current in events) {
                switch (current) {
                    case "Immigrate":
                        Immigrate();
                        break;
                    case "Emigrate":
                        Emigrate();
                        break;
                    case "Revolt":
                        Revolt();
                        break;
                    case "Vandalism":
                        Vandalism();
                        break;
                    case "Natural":
                        Natural();
                        break;
                }
            }
        }

        //Population
        //TODO: Riots, Theft, Worker Strikes
        //Checks if people should immigrate (unique)
        public static void Immigrate () {
            //High happiness and 10 days since last immigration. Chance increases by time
            if (Game.data.days - Game.data.lastImmigration >= 10 && Game.data.happiness > 0.78 && Random.NextDouble() < Math.Pow(1.008, Game.data.days - Game.data.lastImmigration - 10) - 1) {
                int eventAmount = Random.Next(1, 11); //1-10
                Game.data.population += eventAmount;
                Console.WriteLine("{0} people just joined your town! Make sure you provide housing!", eventAmount);
                Game.data.lastImmigration = Game.data.days;
            }
        }
        //Checks if people should emmigrate (stat)
        public static void Emigrate () {
            //Low happiness and 5 days since last stat event. Chance decreases by happiness
            if (Game.data.days - Game.data.lastStatEvent > 5 && Game.data.happiness < 0.5 && Random.NextDouble() < Math.Pow(4, 0.5 - Game.data.happiness) - 1) {
                int eventAmount = Random.Next(1, 9); //1-8
                int counter;
                for(counter = 0; Game.data.population > 0 && counter <= eventAmount; counter++) {
                    Game.data.population--;
                }
                Console.WriteLine("{0} people left your town because they were unhappy!", counter);
                Game.data.lastStatEvent = Game.data.days;
            //Var 2: High fear and 5 days since last stat event. Chance increases by fear
            } else if (Game.data.days - Game.data.lastStatEvent > 5 && Game.data.fear > 0.5 && Random.NextDouble() < Math.Pow(4, Game.data.fear) - 1) {
                int eventAmount = Random.Next(1, 9); //1-8
                int counter;
                for(counter = 0; Game.data.population > 0 && counter <= eventAmount; counter++) {
                    Game.data.population--;
                }
                Console.WriteLine("{0} people left your town because they were scared!", counter);
                Game.data.lastStatEvent = Game.data.days;
            }
        }

        //Checks if people should revolt (stat; unlimited)
        public static void Revolt () {
            //High disonance. Increases by disonance. Checks if revolts are on.
            if (Game.data.disonance > 0.75 && Random.NextDouble() < Math.Pow(16, Game.data.disonance - 0.75) - 1 && Game.data.revolts) {
                Console.WriteLine("Game Over! You ran your town poorly, so your people revolted!");
                Environment.Exit(0);
                return;
            }
        }

        //Building
        //Checks if a building should be vandalized (stat)
        public static void Vandalism () {
            //Low happiness and 10 days since last stat event. Lower happiness and more time increase it, but fear decreases it
            if (Game.data.days - Game.data.lastStatEvent >= 10 && Game.data.happiness < 0.75 && Random.NextDouble() < Math.Pow(1.005, (Game.data.days - Game.data.lastStatEvent) * (1 - Game.data.happiness) - Game.data.fear) - 1) {
                int eventNumber = Random.Next(1, 3); //Chooses wood huts or stone quarries at random.
                int eventAmount = Random.Next(1, 3); //1-2
                if (eventNumber == 1 && Game.data.woodHuts > 0) {
                    HutVandalize(eventAmount);
                    Game.data.lastStatEvent = Game.data.days;
                } else if (eventNumber == 2 && Game.data.stoneQuarries > 0) {
                    QuarryVandalize(eventAmount);
                    Game.data.lastStatEvent = Game.data.days;
                } else if (Game.data.woodHuts == 0 && Game.data.stoneQuarries == 0) {
                    //Do nothing if the user has no wood huts or stone quarries
                } else if (Game.data.stoneQuarries == 0) { //User only has wood huts
                    HutVandalize(eventAmount);
                    Game.data.lastStatEvent = Game.data.days;
                } else if (Game.data.woodHuts == 0) { //User only has stone quarries
                    QuarryVandalize(eventAmount);
                    Game.data.lastStatEvent = Game.data.days;
                }
            }
        }
        //Vandalises a hut
        public static void HutVandalize (int eventAmount) {
            int counter;
            for(counter = 0; Game.data.woodHuts > 0 && counter <= eventAmount; counter++) {
                Game.data.woodHuts--;
            }
            Console.WriteLine("Someone vandalized {0} of your wood huts! They were destroyed!", counter);
        }
        //Vandalises a stone quarry
        public static void QuarryVandalize (int eventAmount) {
            int counter;
            for(counter = 0;  Game.data.stoneQuarries > 0 && counter <= eventAmount; counter++) {
                Game.data.stoneQuarries--;
            }
            Console.WriteLine("Someone vandalized {0} of your stone quarries! They were destroyed!", counter);
        }
        //Checks if a natural disaster should occur (nature)
        public static void Natural () {
            //7 days since last nature event. Increases by time
            if (Game.data.days - Game.data.lastNatureEvent >= 7 && Random.NextDouble() < Math.Pow(1.005, Game.data.days - Game.data.lastNatureEvent - 7) - 1) {
                int eventNumber = Random.Next(1, 3); //Chooses farms or houses at random
                int eventAmount = Random.Next(2, 5); //2-4
                if (eventNumber == 1 && Game.data.farms > 0) {
                    Flood(eventAmount);
                    Game.data.lastNatureEvent = Game.data.days;
                } else if (eventNumber == 2 && Game.data.houses > 0) {
                    Hurricane(eventAmount);
                    Game.data.lastNatureEvent = Game.data.days;
                } else if (Game.data.farms == 0 && Game.data.houses == 0) {
                    //Do nothing if the user has no farms or houses
                } else if (Game.data.farms == 0) { //User only has houses
                    Hurricane(eventAmount);
                    Game.data.lastNatureEvent = Game.data.days;
                } else if (Game.data.houses == 0) { //User only has farms
                    Flood(eventAmount);
                    Game.data.lastNatureEvent = Game.data.days;
                }
            }
        }
        //Floods destroy farms
        public static void Flood (int eventAmount) {
            int counter;
            for(counter = 0; Game.data.farms > 0 && counter <= eventAmount; counter++) {
                Game.data.farms--;
            }
            Console.WriteLine("Your town was flooded! You lost {0} farms!", counter);
        }
        //Hurricanes destroy houses
        public static void Hurricane (int eventAmount) {
            int counter;
            for(counter = 0;  Game.data.houses > 0 && counter <= eventAmount; counter++) {
                Game.data.houses--;
            }
            Console.WriteLine("A hurricane washed over your town! You lost {0} houses!", counter);
        }
    }
}