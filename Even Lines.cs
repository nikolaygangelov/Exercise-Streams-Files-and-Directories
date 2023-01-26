using System;

namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string text1 = string.Empty;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;
                int rowNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (rowNumber % 2 == 0)
                    {
                        text1 += line;
                    }
                    rowNumber++;
                }
            }
                char symbol = '@';
                char[] ch = new char[] { '-', ',', '.', '!', '?' };
                for (int i = 0; i < ch.Length; i++)
                {
                    char currentCharacter = ch[i];
                    text1 = text1.Replace(currentCharacter, symbol);
                }

                string reversedWords = ReverseWords(text1);
                return reversedWords;
            
            

            
        }

        private static string ReverseWords(string text1)
        {
            string[] reversedWords = text1
                .Split()
                .Reverse()
                .ToArray();
            return string.Join(" ", reversedWords);
        }
    }
}

