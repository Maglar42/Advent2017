using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day5
    {

        public static void Solve()
        {

            StreamReader reader = new StreamReader(@"C:\Projects\VisualStudio\Advent2017\Data\Day5Data.txt");

            var instructionList = new List<int>();
            var location = 0;
            var steps = 0;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                instructionList.Add(int.Parse(line));
            }

            do
            {
                steps += 1;
                var jump = instructionList[location];
                if (instructionList[location] >= 3)
                {
                    instructionList[location] -= 1;
                }else
                {
                    instructionList[location] += 1;
                }

                
                location += jump;
                
            } while (location < instructionList.Count);

            Console.WriteLine("Steps: " + steps);
            Console.ReadKey();


        }
    }

}
