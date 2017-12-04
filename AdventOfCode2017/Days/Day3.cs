using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day3
    {

        public static void Solve()
        {

            int y = 0;
            int x = 0;
            const int target = 312051;
            //const int target = 49;
            var grid = new Dictionary<int, string>();
            var grid2 = new Dictionary<string, ulong>();
            grid.Add(1, x + "," + y);
            grid2.Add(x + "," + y, 1);
            var nextDirection = "RU";
            var steps = 1;
            var day3Helper = new Day3Helper();

            int val = 2;
            while (val <= target)
            {
                switch (nextDirection)
                {
                    case "RU":

                        for (int j = 0; j <= steps - 1; j++)
                        {
                            
                            x += 1;
                            var location = x + "," + y;
                            grid.Add(val, location);
                            grid2.Add(location, day3Helper.CalculateNewValue(location, grid2));
                            val += 1;
                        }
                        for (int j = 0; j <= steps - 1; j++)
                        {
                            y += 1;
                            var location = x + "," + y;
                            grid.Add(val, location);
                            grid2.Add(location, day3Helper.CalculateNewValue(location, grid2));
                            val += 1;
                        }

                        break;

                    case "LD":
                        for (int j = 0; j <= steps - 1; j++)
                        {
                            x -= 1;
                            var location = x + "," + y;
                            grid.Add(val, location);
                            grid2.Add(location, day3Helper.CalculateNewValue(location, grid2));
                            val += 1;
                        }
                        for (int j = 0; j <= steps - 1; j++)
                        {
                            y -= 1;
                            var location = x + "," + y;
                            grid.Add(val, location);
                            grid2.Add(location, day3Helper.CalculateNewValue(location, grid2));
                            val += 1;
                        }
                        break;
                }


                nextDirection = nextDirection == "RU" ? "LD" : "RU";

                steps += 1;

            }

            //foreach(var item in grid)
            //{
            //    Console.WriteLine(item.Key+":"+item.Value);
            //}

            var targetLocation = grid[target];
            var locationArray = targetLocation.Split(',');
            var finalSteps = Math.Abs(int.Parse(locationArray[0])) + Math.Abs(int.Parse(locationArray[1]));
            Console.WriteLine(targetLocation);
            Console.WriteLine(finalSteps);




            ulong part2Answer = 0;


            foreach (var item in grid2)
            {
                if (item.Value > target)
                {
                    part2Answer = item.Value;
                    break;
                }
            }



            Console.WriteLine(part2Answer);

            Console.ReadKey();

        }





    }

    public class Day3Helper
    {

        public ulong CalculateNewValue(string cord, Dictionary<string,ulong> gridToCheck)
        {
            ulong value = 0;
            var cordArray = cord.Split(',');

            int x = int.Parse(cordArray[0]);
            int y = int.Parse(cordArray[1]);

            for (int temp1 = -1; temp1<=1; temp1++)
            {
                for (int temp2 = -1; temp2 <= 1; temp2++)
                {
                    var locationKey = (x + temp1) + "," + (y + temp2);
                    if (locationKey == cord)
                    {
                        continue;
                    }
                    value += gridToCheck.ContainsKey(locationKey) ? gridToCheck[locationKey]: 0;
                }
            }
            return value;
        }
    }


}
