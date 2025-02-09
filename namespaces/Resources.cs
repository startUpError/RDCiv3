using System;
using RDCiv3;
using Game = RDCiv3.Program;

namespace RDCiv3.Resources {

    class Population {
        public static void Execute () {
            Console.WriteLine("How many people?");
            int executionAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Are you sure you want to execute {0} member(s) of your population?", executionAmount);
            switch (Console.ReadLine()) {
                case "Yes":
                    if(Game.data.population > executionAmount) {
                        Game.data.population -= executionAmount;
                        Game.data.fear += 0.05 * executionAmount;
                        Game.data.happiness -= 0.05 * executionAmount;
                        Game.data.actions--;
                        Console.WriteLine("{0} people were executed. Your people grow more fearful of you.", executionAmount);
                    } else {
                        Console.WriteLine("You wouldn't have enough people after this. Execution canceled.");
                    }
                    break;
                case "yes":
                    if(Game.data.population > executionAmount) {
                        Game.data.population -= executionAmount;
                        Game.data.fear += 0.05 * executionAmount;
                        Game.data.happiness -= 0.05 * executionAmount;
                        Game.data.actions--;
                        Console.WriteLine("{0} people were executed. Your people grow more fearful of you.", executionAmount);
                    } else {
                        Console.WriteLine("You wouldn't have enough people after this. Execution canceled.");
                    }
                    break;
                default:
                    Console.WriteLine("Your execution was cancelled");
                    break;
            }
        }
        public static void LimitPopulation () {
            Console.WriteLine("Would you like to toggle population growth [Toggle Population Growth], or set a population growth limit [Set Growth Limit]?");
            switch (Console.ReadLine()) {
                case "Toggle Population Growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "Toggle Population growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "Toggle population Growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "Toggle population growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "toggle Population Growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "toggle Population growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "toggle population Growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "toggle population growth":
                    if (Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out to stop having children. Your people aren't happy, but they oblige.");
                        Game.data.happiness -= 0.1;
                    } else if (!Game.data.doesPopGrow) {
                        Console.WriteLine("A notice has been put out that your population may have children again! They are overjoyed!");
                        Game.data.happiness += 0.1;
                    }
                    Game.data.doesPopGrow = !Game.data.doesPopGrow;
                    Game.data.actions--;
                    break;
                case "Set Growth Limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    int amount;
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    int changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness += changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "Set Growth limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "Set growth Limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "Set growth limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "set Growth Limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "set Growth limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "set growth Limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                case "set growth limit":
                    Console.WriteLine("What do you want the new limit to be?");
                    try {
                        amount = Convert.ToInt32(Console.ReadLine());
                    } catch (FormatException) {
                        Console.WriteLine("That was not a number, cancelling limit change");
                        break;
                    }
                    if (amount == Game.data.popGrowthLimit) {
                        Console.WriteLine("That was already the limit. Cancelling changes.");
                        break;
                    } else if (amount < 0) {
                        Console.WriteLine("The limit cannot be negative. It can be zero. Cancelling limit change");
                        break;
                    }
                    changeAmount = amount - Game.data.popGrowthLimit;
                    Game.data.popGrowthLimit = amount;
                    Game.data.actions--;
                    Game.data.happiness -= changeAmount * 0.01;
                    Console.WriteLine(changeAmount < 0 ? "A notice has been put out not to have more than {0} children. Your people aren't very happy though." : "A notice has been put out that your civilization can now have up to {0} kids. They are happy for this!", amount);
                    break;
                default:
                    Console.WriteLine("That wasn't an option, cancelling population changes");
                    break;
            }
        }
    }
    class Trading {
        //-.TODO: Money is useful in trade
        public static void Trade () {
            //Asks the material to trade
            Console.WriteLine("What would you like to trade? [Material1-Material2]");
            //Takes user input. Then takes input for how much, if the user has that much then it trades, other wise it calls again.
            switch (Console.ReadLine()) {
                case "Wood-Money":
                    Console.WriteLine("How much?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Wood-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-Money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-Money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-Money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-Money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-Money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-money":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.money += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Money-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "money-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.money) {
                        Game.data.money -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Quit":
                    Console.WriteLine("Quitting");
                    break;
                case "quit":
                    Console.WriteLine("Quitting");
                    break;
                default:
                    Console.WriteLine("That wasn't an option!");
                    Trade();
                    break;
            }
        }
    }
}