using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;

namespace FileDemos
{
  public  class MethodClass
    {
        public static string[] FetchLines(string path)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("path");
                }
                List<string> list = new List<string>();
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string item;
                    while ((item = streamReader.ReadLine()) != null)
                    {
                        list.Add(item);
                    }
                }
                return list.ToArray();
            }
            catch(IOException e)
            {
                Console.WriteLine("Invalid Path for the file");
                List<string> list = new List<string>();
                return list.ToArray();
            }
        }
       public static void ReadCSV(string path)
        {
            var lines = FetchLines(path);
            var list = new List<FileUtil>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                var fileUtil = new FileUtil()
                {
                    FileName = values[0],
                    FileType = values[1],
                    Filesize = values[2],
                    CreationTime = values[3],
                   LastAccessTime = values[4]
                };
                list.Add(fileUtil);
            }
            list.ForEach(x => Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", x.FileName, x.FileType, x.Filesize,
                                                    x.CreationTime, x.LastAccessTime));
        }
        //Method to convert the text to Json and Write to another file
      public   static void ConvertToJson(string path)
        {
             var lines = FetchLines(path);
            var list1 = new List<FileUtil>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                var fileUtil = new FileUtil()
                {
                    FileName = values[0],
                    FileType = values[1],
                    Filesize = values[2],
                    CreationTime = values[3],
                    LastAccessTime = values[4]
                };
                list1.Add(fileUtil);
            }
            // list1.ForEach(x => Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", x.FileName, x.FileType, x.Filesize, 
            // x.CreationTime, x.LastAccessTime));
            string Json = JsonConvert.SerializeObject(list1.ToArray());
            File.WriteAllText(@"Test.json", Json);
            Console.WriteLine("Text has been converted to JSON");
        }
    }
}