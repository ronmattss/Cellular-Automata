using System;
using System.Collections;
using System.Globalization;


namespace Cellular_Automata
{
    public class CellularAutomata
    {
        int[] cells;
        int generation;
        public int[] ruleset = new int[8];

        int w = 5;

        public CellularAutomata(int[] r, int width)
        {
            ruleset = r;
            cells = new int[width / w];
            Restart();
        }
        public CellularAutomata(int r, int width)
        {
            string binaryArray = Convert.ToString(r,2);
            char[] arr = binaryArray.ToCharArray();
            Array.Reverse(arr);
            for(int i = 0;i<arr.Length;i++)
            {
                ruleset[i] =(int) Char.GetNumericValue(arr[i]);
                System.Console.Write(ruleset[i]);
            }
            Array.Reverse(ruleset);
            cells = new int[width / w];
            Restart();
        }
        public CellularAutomata(int width)
        {
            Randomize();
            cells = new int[width / w];
            Restart();
        }
        public CellularAutomata()
        {

        }
        // generate a random ruleset
        public void Randomize()
        {
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                ruleset[i] = (int)rand.Next(2);
            }
        }
        void Restart()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = 0;
            }
            cells[cells.Length / 2] = 1;
            generation = 0;
            for (int i = 0; i < cells.Length; i++)
            {
                System.Console.Write((cells[i]));
            }
        }
        void Generate()
        {
            int[] newGen = new int[cells.Length];
            for (int i = 1; i < cells.Length - 1; i++)
            {
                int left = cells[i - 1];
                int center = cells[i];
                int right = cells[i + 1];
                newGen[i] = Rules(left, center, right);
            }
            cells = newGen;
            generation++;
        }
        int Rules(int left, int center, int right)
        {
            String s = $"{left}{center}{right}";
            //System.Console.WriteLine($"String{s}");
            int index = Convert.ToInt32(s, 2);
            //  System.Console.WriteLine("Index: " + index);
            return ruleset[index];
        }
        public void DisplayGeneration(int a)
        {
            //Console.WindowHeight = 83;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < cells.Length; j++)
                {
                    if (cells[j] == 1)
                        System.Console.Write("" + "▓" + "");
                    else
                        System.Console.Write("" + " " + "");
                }
                System.Console.WriteLine();
                Generate();
            }
            System.Console.WriteLine("Ruleset");
            for (int i = 0; i < ruleset.Length; i++)
            {
                System.Console.Write(ruleset[i]);
            }

            string s = string.Join("", ruleset);
            System.Console.WriteLine();
            System.Console.WriteLine(Convert.ToInt32(s, 2));
        }




    }
}