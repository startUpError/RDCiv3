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
            }
        }
    }
}