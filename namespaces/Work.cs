using System;
using RDCiv3;
using Game = RDCiv3.Program;

namespace Work {
    class WorkForce {
        public static void AssignWork () {
            Console.WriteLine("From which job, to which job? [original-new]");
            switch (Console.ReadLine()) {
                case "None-Builder":
                    Console.WriteLine("How much?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.builders += amount;
                        Console.WriteLine("{0} people were transfered from no work to builders.", amount);
                    }
                    break;
                case "None-builder":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.builders += amount;
                        Console.WriteLine("{0} people were transfered from no work to builders.", amount);
                    }
                    break;
                case "none-Builder":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.builders += amount;
                        Console.WriteLine("{0} people were transfered from no work to builders.", amount);
                    }
                    break;
                case "none-builder":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.builders += amount;
                        Console.WriteLine("{0} people were transfered from no work to builders.", amount);
                    }
                    break;
                case "None-Wood Cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "None-Wood cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "None-wood Cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "None-wood cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "none-Wood Cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "none-Wood cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "none-wood Cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "none-wood cutter":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.woodCutters += amount;
                        Console.WriteLine("{0} people were transfered from no work to wood cutters.", amount);
                    }
                    break;
                case "None-Miner":
                    Console.WriteLine("How much?");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (Game.data.adults.Count - (Game.data.builders + Game.data.woodCutters + Game.data.miners + Game.data.farmers) > amount) {
                        Game.data.miners += amount;
                        Console.WriteLine("{0} people were transfered from no work to miner.", amount);
                    }
                    break;
            }
        }
    }
}