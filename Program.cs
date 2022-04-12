using System;

namespace Cellular_Automata
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ruleset = { 0, 1, 0, 0, 1, 0, 0, 0 };
            int[] ruleset90 = { 0, 0, 0, 1, 1, 1, 1, 0 };
            int[] manualRuleSet = new int[8];
            System.Console.WriteLine("Enter Ruleset:");
            int manualRules = Convert.ToInt32(Console.ReadLine());
            CellularAutomata CA = new CellularAutomata(manualRules, 240);
            Console.WriteLine("Hello World!");
            CA.DisplayGeneration(16);

        }
    }
}
