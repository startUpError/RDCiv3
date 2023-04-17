using System;
using RDCiv3;
using Game = RDCiv3.Program;

namespace Buildings
{

    class Building {
        //TODO: Some buildings require more builder workers than others.
        public static void Build ()
        {
            //Asks what building to build as input
            Console.WriteLine("Would you like to build a house [4 wood, 3 stone], farm [3 wood, 2 stone], wood hut [2 wood], stone quarry [4 wood], or park [6 wood, 8 stone]? You may also quit.");
            //Checks all possibilities, then if the user has the required materials, then builds if they do, and resets this function if they don't
            switch (Console.ReadLine())
            {
                case "House":
                    if (Game.data.wood >= 4 && Game.data.stone >= 3)
                    {
                        Game.data.houses++;
                        Game.data.wood -= 4;
                        Game.data.stone -= 3;
                        Console.WriteLine("One house has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 4 wood and 3 stone to build a house, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                        Build();
                    }
                    break;
                case "Wood Hut":
                    if (Game.data.wood >= 2)
                    {
                        Game.data.woodHuts++;
                        Game.data.wood -= 2;
                        Console.WriteLine("One wood hut has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It takes 2 wood to build a wood hut, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "Stone Quarry":
                    if (Game.data.wood >= 4)
                    {
                        Game.data.stoneQuarries++;
                        Game.data.wood -= 4;
                        Console.WriteLine("One stone quarry has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It take 4 wood to build a stone quarry, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "Farm":
                    if (Game.data.wood >= 3 && Game.data.stone >= 2)
                    {
                        Game.data.farms++;
                        Game.data.wood -= 3;
                        Game.data.stone -= 2;
                        Console.WriteLine("One farm has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 3 wood and 2 stone to build a farm, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                    }
                    break;
                case "Quit": //Quits building if needed
                    Console.WriteLine("Quiting.");
                    break;
                case "house":
                    if (Game.data.wood >= 4 && Game.data.stone >= 3)
                    {
                        Game.data.houses++;
                        Game.data.wood -= 4;
                        Game.data.stone -= 3;
                        Console.WriteLine("One house has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 4 wood and 3 stone to build a house, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                        Build();
                    }
                    break;
                case "wood hut":
                    if (Game.data.wood >= 2)
                    {
                        Game.data.woodHuts++;
                        Game.data.wood -= 2;
                        Console.WriteLine("One wood hut has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It takes 2 wood to build a wood hut, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "stone quarry":
                    if (Game.data.wood >= 4)
                    {
                        Game.data.stoneQuarries++;
                        Game.data.wood -= 4;
                        Console.WriteLine("One stone quarry has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It take 4 wood to build a stone quarry, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "farm":
                    if (Game.data.wood >= 3 && Game.data.stone >= 2)
                    {
                        Game.data.farms++;
                        Game.data.wood -= 3;
                        Game.data.stone -= 2;
                        Console.WriteLine("One farm has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 3 wood and 2 stone to build a farm, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                    }
                    break;
                case "quit":
                    Console.WriteLine("Quiting.");
                    break;
                case "Wood hut":
                    if (Game.data.wood >= 2)
                    {
                        Game.data.woodHuts++;
                        Game.data.wood -= 2;
                        Console.WriteLine("One wood hut has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It takes 2 wood to build a wood hut, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "Stone quarry":
                    if (Game.data.wood >= 4)
                    {
                        Game.data.stoneQuarries++;
                        Game.data.wood -= 4;
                        Console.WriteLine("One stone quarry has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It take 4 wood to build a stone quarry, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "wood Hut":
                    if (Game.data.wood >= 2)
                    {
                        Game.data.woodHuts++;
                        Game.data.wood -= 2;
                        Console.WriteLine("One wood hut has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It takes 2 wood to build a wood hut, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "stone Quarry":
                    if (Game.data.wood >= 4)
                    {
                        Game.data.stoneQuarries++;
                        Game.data.wood -= 4;
                        Console.WriteLine("One stone quarry has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood. It take 4 wood to build a stone quarry, you have {0}.", Game.data.wood);
                        Build();
                    }
                    break;
                case "Park":
                    if (Game.data.wood >= 6 && Game.data.stone >= 8)
                    {
                        Game.data.parks++;
                        Game.data.wood -= 6;
                        Game.data.stone -= 8;
                        Game.data.happiness += 0.02; //People are happy when parks are built
                        Console.WriteLine("One park has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 6 wood and 8 stone to build a park, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                        Build();
                    }
                    break;
                case "park":
                    if (Game.data.wood >= 6 && Game.data.stone >= 8)
                    {
                        Game.data.parks++;
                        Game.data.wood -= 6;
                        Game.data.stone -= 8;
                        Game.data.happiness += 0.02;
                        Console.WriteLine("One park has been built");
                        Game.data.actions--;
                    } else
                    {
                        Console.WriteLine("You don't have enough wood and/or stone. It takes 6 wood and 8 stone to build a park, you have {0} wood and {1} stone.", Game.data.wood, Game.data.stone);
                        Build();
                    }
                    break;
                default: //If they don't input a valid building, it resets the function
                    Console.WriteLine("That wasn't an option. (Maybe try a different capitialization)");
                    Build();
                    break;
            }
        }

        public static void Demolish ()
        {
            //Asks for a building as input
            Console.WriteLine("Would you like to demolish a house [2 wood, 1 stone], farm [1 wood, 1 stone], wood hut [1 wood], stone quarry [2 wood], or park [3 wood, 4 stone]? You may also quit.");
            //Checks every possible combination, then if they have that building, then gives them resources and destroys the building, or resets this function.
            switch (Console.ReadLine())
            {
                case "House":
                    if (Game.data.houses >= 1) {
                        Game.data.houses--;
                        Game.data.wood += 2;
                        Game.data.stone += 1;
                        Console.WriteLine("One house has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Wood Hut":
                    if (Game.data.woodHuts >= 1) {
                        Game.data.woodHuts--;
                        Game.data.wood += 1;
                        Console.WriteLine("One wood hut has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Stone Quarry":
                    if (Game.data.stoneQuarries >= 1) {
                        Game.data.stoneQuarries--;
                        Game.data.wood += 2;
                        Console.WriteLine("One stone quarry has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Farm":
                    if (Game.data.farms >= 1) {
                        Game.data.farms--;
                        Game.data.wood += 1;
                        Game.data.stone += 1;
                        Console.WriteLine("One farm has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Quit": //Quits the demolish action if necessary
                    Console.WriteLine("Quiting.");
                    break;
                case "quit":
                    Console.WriteLine("Quiting.");
                    break;
                case "house":
                    if (Game.data.houses >= 1) {
                        Game.data.houses--;
                        Game.data.wood += 2;
                        Game.data.stone += 1;
                        Console.WriteLine("One house has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "wood hut":
                    if (Game.data.woodHuts >= 1) {
                        Game.data.woodHuts--;
                        Game.data.wood += 1;
                        Console.WriteLine("One wood hut has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "stone quarry":
                    if (Game.data.stoneQuarries >= 1) {
                        Game.data.stoneQuarries--;
                        Game.data.wood += 2;
                        Console.WriteLine("One stone quarry has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "farm":
                    if (Game.data.farms >= 1) {
                        Game.data.farms--;
                        Game.data.wood += 1;
                        Game.data.stone += 1;
                        Console.WriteLine("One farm has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Wood hut":
                    if (Game.data.woodHuts >= 1) {
                        Game.data.woodHuts--;
                        Game.data.wood += 1;
                        Console.WriteLine("One wood hut has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Stone quarry":
                    if (Game.data.stoneQuarries >= 1) {
                        Game.data.stoneQuarries--;
                        Game.data.wood += 2;
                        Console.WriteLine("One stone quarry has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "wood Hut":
                    if (Game.data.woodHuts >= 1) {
                        Game.data.woodHuts--;
                        Game.data.wood += 1;
                        Console.WriteLine("One wood hut has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "stone Quarry":
                    if (Game.data.stoneQuarries >= 1) {
                        Game.data.stoneQuarries--;
                        Game.data.wood += 2;
                        Console.WriteLine("One stone quarry has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "Park":
                    if (Game.data.parks >= 1) {
                        Game.data.parks--;
                        Game.data.wood += 3;
                        Game.data.stone += 4;
                        Game.data.happiness -= 0.02; //People are sad if parks are destroyed
                        Console.WriteLine("One park has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                case "park":
                    if (Game.data.parks >= 1) {
                        Game.data.parks--;
                        Game.data.wood += 3;
                        Game.data.stone += 4;
                        Game.data.happiness -= 0.02;
                        Console.WriteLine("One park has been demolished");
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have one");
                        Demolish();
                    }
                    break;
                default: //If the input wasn't an option, reset the function
                    Console.WriteLine("That wasn't an option. (Maybe try a different capitialization)");
                    Demolish();
                    break;
            }
        }
    }
}