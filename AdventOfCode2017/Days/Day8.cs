using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Days
{
    public static class Day8
    {
        public static void Solve()
        {
            //Initialize
            StreamReader reader = new StreamReader(@"C:\Projects\VisualStudio\Advent2017\Data\Day8Data.txt");
            var instructionList = new List<Instruction>();
            var registerList = new Dictionary<string, int>();
            var allTimeMaxValue = 0;
            string line;

            //Setup
            while ((line = reader.ReadLine()) != null)
            {
                var lineArray = line.Split(" ");
                var registerName = lineArray[0];
                var incOrDec = lineArray[1] == "inc" ? 1 : -1;
                var tempInstruction = new Instruction()
                {
                    ChangeRegister = registerName,
                    IncOrDec = incOrDec,
                    ChangeAmount = int.Parse(lineArray[2]),
                    ConditionalRegister = lineArray[4],
                    ConditionalComparer = lineArray[5],
                    ConditionalChangeAmount = int.Parse(lineArray[6])
                };
                instructionList.Add(tempInstruction);

                if (!registerList.ContainsKey(registerName))
                {
                    registerList.Add(registerName, 0);
                }
            }

            //Solve

            foreach(var instruction in instructionList)
            {
                var process = false;
                switch (instruction.ConditionalComparer)
                {
                    case "==":
                        process = registerList[instruction.ConditionalRegister] == instruction.ConditionalChangeAmount;
                        break;
                    case "!=":
                        process = registerList[instruction.ConditionalRegister] != instruction.ConditionalChangeAmount;
                        break;
                    case ">=":
                        process = registerList[instruction.ConditionalRegister] >= instruction.ConditionalChangeAmount;
                        break;
                    case ">":
                        process = registerList[instruction.ConditionalRegister] > instruction.ConditionalChangeAmount;
                        break;
                    case "<=":
                        process = registerList[instruction.ConditionalRegister] <= instruction.ConditionalChangeAmount;
                        break;
                    case "<":
                        process = registerList[instruction.ConditionalRegister] < instruction.ConditionalChangeAmount;
                        break;
                    default:
                        Console.WriteLine("bad conditional sign");
                        break;
                }

                if (process)
                {
                    registerList[instruction.ChangeRegister] += instruction.ChangeAmount * instruction.IncOrDec;
                }

                if (registerList[instruction.ChangeRegister] > allTimeMaxValue)
                {
                    allTimeMaxValue = registerList[instruction.ChangeRegister];
                }


            }

            var maxValue = registerList.Values.Max();

            Console.Write("maxValue: "+ maxValue);
            Console.Write("allTimeMaxValue: "+ allTimeMaxValue);
            Console.ReadKey();


        } 
    }
    public class Instruction
    {
        public string ChangeRegister { get; set; }
        public int IncOrDec  { get; set; }
        
        public int ChangeAmount { get; set; }

        public string ConditionalRegister { get; set; }
        public string ConditionalComparer { get; set; }
        public int ConditionalChangeAmount { get; set; }
    }


}
