namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = @"..\..\..\..\3. Copy Binary File";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string information = string.Empty;
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);

            FileInfo[] filesInfos = dir.GetFiles("*");
            StringBuilder sb = new StringBuilder();
            Dictionary<string, List<FileInfo>> fileNamesByTypes = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo file in filesInfos)
            {
                string type = file.Extension;
                if (!fileNamesByTypes.ContainsKey(type))
                {
                    fileNamesByTypes.Add(type, new List<FileInfo>());
                }
                fileNamesByTypes[type].Add(file);
            }

            foreach (var (type, names) in fileNamesByTypes.OrderByDescending(n => n.Value.Count).ThenBy(t => t.Key))
            {
                sb.AppendLine(type);
                foreach (var fileName in names.OrderBy(f => f.Length))
                {
                    information = $"--{fileName.Name} - {(double)fileName.Length / 1024:f3}kb";
                    sb.AppendLine(information);
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}