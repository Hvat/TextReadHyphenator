using System;
using System.IO;
using System.Text;

namespace TextReadHyphenator
{
    class FileOper
    {
        //private string filename;
        private string filePath;

        public string FilePath { get => filePath; set => filePath = value; }

        public string OpenFile(string filePath)
        {
            string text;
            FilePath = filePath;
            Stream st = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);

            using (StreamReader sr = new StreamReader(st, Encoding.Default))
            {
                text = sr.ReadToEnd();
            }
            //UpdateFileStatus();
            return text;
        }

        public void SaveFile(string lines)
        {
            FilePath = "D:/Repos/TextReadHyphenator/TextReadHyphenator/Formatted_doc/Doc.html";
            File.Delete(FilePath);

            Stream st = File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(st, Encoding.Default))
            {
                sw.WriteLine(lines);
            }
        }

        public void SaveFiles(string filePath, string[] lines)
        {
            FilePath = filePath;
            Stream st = File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(st, Encoding.Default))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
