using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileDemos
{
    class Program
    {
        //Main method calling the other methods
        static void Main(string[] args)
        {
            MethodClass methodClass = new MethodClass();
            Console.WriteLine("Enter The CSV File To be Read:");
            string basepath = Console.ReadLine() + ".csv";
            MethodClass.ReadCSV(basepath);
            Console.ReadLine();
            MethodClass.ConvertToJson(basepath);
            Console.ReadLine();
        }
    }
    //Class with the file properties
    public class FileUtil
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Filesize { get; set; }
        public string CreationTime { get; set; }
        public string LastAccessTime { get; set; }
    }
}
