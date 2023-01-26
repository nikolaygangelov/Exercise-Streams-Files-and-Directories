using System;

namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            
            for (int i = 0; i < lines.Length; i++)
            {
                int countOfLetters = 0;
                int countOfPunkt = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char currentLetter = lines[i][j];
                    if (char.IsPunctuation(currentLetter))
                    {
                        countOfPunkt++;
                    }
                    else if (char.IsLetter(currentLetter))
                    {
                        countOfLetters++;
                    }
                }
                lines[i] = $"Line {i+1}: {lines[i]} ({countOfLetters})({countOfPunkt})";
            }
            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
