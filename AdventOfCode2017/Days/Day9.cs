using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day9
    {
        public static  void Solve()
        {
            //Initialize
            StreamReader reader = new StreamReader(@"C:\Projects\VisualStudio\Advent2017\Data\Day9Data.txt");
            var fullCharArray = reader.ReadLine().ToCharArray();
            //var fullCharArray = "{{<!!>},{<!!>},{<!!>},{<!!>}}".ToCharArray();
            var postCancelRemoval = new List<char>();
            var cleanList = new List<char>();

            for (var c=0;c< fullCharArray.Length;c++)
            {
                if (fullCharArray[c] == '!')
                {
                    c++;
                    continue;
                }
                postCancelRemoval.Add(fullCharArray[c]);
            }

            var inGarbage = false;
            var totalGarbage = 0;
            foreach (char c in postCancelRemoval)
            {
                if(inGarbage)
                {
                    if(c == '>')
                    {
                        inGarbage = false;
                        continue;
                    }
                    totalGarbage += 1;
                    continue;
                }
                if (c == '<')
                {
                    inGarbage = true;
                    continue;
                }

                inGarbage = false;
                cleanList.Add(c);
            }

            var openGroups = 0;
            var totalScore = 0;

            foreach(char c in cleanList)
            {
                if (c == '{')
                {
                    openGroups += 1;
                }
                if (c =='}' && openGroups > 0)
                {
                    totalScore += openGroups;
                    openGroups -= 1;
                }
            }

            Console.WriteLine(totalScore);
            Console.WriteLine(totalGarbage);
            Console.ReadKey();
        }

    }
}
