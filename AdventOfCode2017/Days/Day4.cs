using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Days
{
    public class Day4
    {
        //TODO Do this.

        public static void Solve()
        {

            //var dataList = streamreader.ReadStream("Day2Data.txt");

            StreamReader reader = new StreamReader(@"C:\Projects\VisualStudio\Advent2017\Data\Day4Data.txt");

            int star1VaildCount = 0;
            int star2VaildCount = 0;
            int reviewed = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var passphraseArray = line.Split(' ');

                var distinctWords = passphraseArray.Distinct().Count();
                var hasNoDup = distinctWords == passphraseArray.Count();

                var passphraseDictList = new List<string>();

                foreach(var word in passphraseArray)
                {
                    var tempDict = new Dictionary<char, int>();
                    foreach(var character in word)
                    {
                        if (!tempDict.ContainsKey(character))
                        {
                            tempDict.Add(character, 1);

                        }else
                        {
                            tempDict[character] += 1;
                        }
                    }
                    var tempResult = ConvertDictToString(tempDict);

                    passphraseDictList.Add(tempResult);
                }

                var distinctDict = passphraseDictList.Distinct().Count();
                var hasNoAnagram = distinctDict == passphraseDictList.Count();

                if (hasNoDup)
                {
                    star1VaildCount += 1;
                    if (hasNoAnagram)
                    {
                        star2VaildCount += 1;
                    }

                }

                reviewed += 1;
            }

            Console.WriteLine("star1VaildCount: " + star1VaildCount);
            Console.WriteLine("star2VaildCount: " + star2VaildCount);
            Console.WriteLine("reviewed: " + reviewed);
            Console.ReadKey();

        }


        public static string ConvertDictToString(Dictionary<char, int> dict)
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charArray = letters.ToLower().ToCharArray();
            var result = "";

            foreach (char c in charArray)
            {
                if (dict.ContainsKey(c))
                {
                    result += c.ToString() + dict[c];
                }
            }



            return result;
        }




    }
}
