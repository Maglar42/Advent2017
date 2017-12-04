using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day2
    {

        public static void SolveDay2()
        {

            var dataList = streamreader.ReadStream("Day2Data.txt");
            int total1 = 0;
            int total2 = 0;
            foreach(var row in dataList)
            {
                var intList = new List<int>();
                foreach (var num in row.Split('\t'))
                {
                    var isInt = int.TryParse(num, out var tempInt);

                    if (isInt)
                    {
                        intList.Add(tempInt);
                    }
                }
                total1 += intList.Max() - intList.Min();
                intList.Sort();
                foreach (var outerNumb in intList)
                {
                    var tempIntList = new List<int>();
                    tempIntList.AddRange(intList);
                    tempIntList.Remove(outerNumb);
                    foreach (var innerNum in tempIntList)
                    {
                        if (innerNum%outerNumb == 0)
                        {
                            total2 += innerNum / outerNumb;
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine("total1: " + total1);
            Console.WriteLine("total2: " + total2);
            Console.ReadKey();

        }
    }
}
