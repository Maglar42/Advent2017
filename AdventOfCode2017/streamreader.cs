using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2017
{
    class streamreader
    {
        public static List<string> ReadStream(string fileName)
        {

            var filePath = @"C:\Projects\VisualStudio\Advent2017\Data\";
            var dataList = new List<string>();

            using (StreamReader reader = new StreamReader(filePath + fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }

            return dataList;
        }
    }
}
