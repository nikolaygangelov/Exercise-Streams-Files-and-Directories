
namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fileRead = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fileWrite = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int bytesToRead = fileRead.Read(buffer);
                        if (bytesToRead == 0)
                        {
                            break;
                        }
                        //for (int i = 0; i < bytesToRead; i++)
                        //{
                        //    buffer[i] = 
                        //} 
                        fileWrite.Write(buffer, 0, bytesToRead);
                    }


                }
            }


        }
    }
}
