using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // This class should contain any and all details of access to files

        List<string> newDocument = new List<string>();
        int counter = 0;

        //public List<string> GetList()
        //{
        //    AccessCateringItem();
        //    List<string> testList = new List<string>();
        //    testList = newDocument;
        //    return testList;
        //}

        public List<string> AccessCateringItem()
        {

            




            try
                {
                    string sourcefile = @"C:\Catering\cateringsystem.csv";

                    using (StreamReader sr = new StreamReader(sourcefile))
                    {
                        string[] words = new string[0];
                        while (!sr.EndOfStream && counter == 0)
                        {
                            
                            string line = sr.ReadLine();

                            words = line.Split('|');

                            foreach (string word in words)
                            {
                                newDocument.Add(word);
                            }
                        

                        }
                        
                    }
                }

                catch
                {
                    Console.WriteLine("done but broke");
                    Console.ReadLine();
                    
                }



            counter++;
            return newDocument;
        }
        
        public void CreateLogList(List <string> logList)
        {
            
            string logFile = @"C:\Catering\log.txt";

            using(StreamWriter sw = new StreamWriter(logFile))
            {
                foreach (string words in logList)
                {

                    sw.WriteLine(words);

                }
                    
            }
            

        }

    }
}
