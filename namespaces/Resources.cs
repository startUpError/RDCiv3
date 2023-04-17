using System;
using RDCiv3;
using Game = RDCiv3.Program;

namespace Resources {
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
                case "Wood-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Wood-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-Food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-food":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.food += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Wood-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Wood-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "wood-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.wood) {
                        Game.data.wood -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Food-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-Stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "food-stone":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.food) {
                        Game.data.food -= amount;
                        Game.data.stone += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "Stone-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-Wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
                case "stone-wood":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= Game.data.stone) {
                        Game.data.stone -= amount;
                        Game.data.wood += amount;
                        Game.data.actions--;
                    } else {
                        Console.WriteLine("You don't have enough");
                        Trade();
                    }
                    break;
            }
        }
    }
}