using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day6
    {
        public static void Solve()
        {
            //Example String
            //var dataString = "0\t2\t7\t0";

            //star 1 string
            var dataString = "4	10	4	1	8	4	9	14	5	1	14	15	0	15	3	5";

            // final state of star 1, used to calcualte star 2
            //var dataString = "1\t0\t14\t14\t12\t11\t10\t9\t9\t7\t5\t5\t4\t3\t7\t1";  


            var dataArray = dataString.Split("\t");
            var memoryBlocks = new List<int>();
            foreach(var block in dataArray)
            {
                memoryBlocks.Add(int.Parse(block));
            }

            var stateList = new List<string>();
            var starterString = string.Join(",", memoryBlocks);
            stateList.Add(starterString);

            var cycleCount = 0;

            var noDup = true;
            do
            {
                var maxBlock = -1;
                var blockLocation = -1;
                for(int i = 0; i < memoryBlocks.Count;i++)
                {
                    if (memoryBlocks[i] > maxBlock)
                    {
                        maxBlock = memoryBlocks[i];
                        blockLocation = i;                        
                    }
                }

                memoryBlocks[blockLocation] = 0;

                


                while (maxBlock > 0)
                {
                    if (blockLocation == memoryBlocks.Count - 1)
                    {
                        blockLocation = 0;
                    }else
                    {
                        blockLocation += 1;
                    }
                    memoryBlocks[blockLocation] += 1;
                    maxBlock -= 1;
                }



                var stateString = string.Join(",", memoryBlocks);
                stateList.Add(stateString);

                cycleCount += 1;

                if( stateList.Distinct().Count() < stateList.Count)
                {
                    noDup = false;
                    break;
                }

            } while (noDup);






            var finalState = stateList[cycleCount];
            Console.WriteLine("cycleCount: " + cycleCount);
            
            Console.ReadKey();

        }




    }
}
