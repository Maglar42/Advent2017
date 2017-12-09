using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day7
    {
        public static void Solve()
        {

            StreamReader reader = new StreamReader(@"C:\Projects\VisualStudio\Advent2017\Data\Day7Data.txt");

            var programDict= new Dictionary<string,ProgramObject>();
            var supportedPrograms = new List<string>();
            var simpleProgramDict = new Dictionary<string,int>();
            var supporterProgram = new Dictionary<string, string>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var dataArray = line.Split("|");
                var name = dataArray[0];
                var weight = int.Parse(dataArray[1]);
                var heldPrograms = dataArray[2].Split(",");

                var programObject = new ProgramObject()
                {
                    Name = name,
                    Weight = weight,
                    HeldPrograms = heldPrograms
                };
                programDict.Add(name,programObject);
                supportedPrograms.AddRange(heldPrograms);
                simpleProgramDict.Add(name, weight);

                foreach(var program in heldPrograms)
                {
                    if (program != "")
                    {
                        supporterProgram.Add(program, name);
                    }
                }

            }

            supportedPrograms = supportedPrograms.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            var supportingProgramKeys = simpleProgramDict.Keys;
            var baseProgram = supportingProgramKeys.Except(supportedPrograms).ToList().ToString();


            //TODO star 2 is not done
            //BAd...
            foreach (var keyValue in programDict)
            {
                if (keyValue.Value.HeldPrograms.Count() > 1)
                {
                    continue;
                }

                var heldWeights = new List<int>();
                foreach (var program in keyValue.Value.HeldPrograms)
                {
                    if (program != "")
                    {
                        heldWeights.Add(programDict[program].Weight);

                    }
                
                }


                var diffWeights = heldWeights.Distinct().Count();

                if (diffWeights>1)
                {
                    var output = string.Join(',', heldWeights);
                    Console.WriteLine(output);


                    break;
                }

            }

            var tiers = new List<List<string>>();
            

           
            var nextTierList = new List<string>();
            var temp = programDict.Where(x => x.Value.HeldPrograms[0] == "").ToList();

            foreach(var item in temp)
            {

            }


            //tiers.AddRange(temp)

            //nextTierList.Add









            Console.WriteLine("baseProgram: " + baseProgram);
            Console.ReadKey();

        }

    }

    public class ProgramObject
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string[] HeldPrograms { get; set; }
    }


}
