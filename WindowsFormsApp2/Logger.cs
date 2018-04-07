using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameShark
{
    public class Logger
    {
        List<string> list = new List<string>();

        public void CreateLogRecord(string record)
        {
            lock (list)
            {
                list.Add(DateTime.Now.ToString() + ": " + record);
            }
        }
    
        public void LoggingAsync()
        {
            using (var streamWriter = new StreamWriter("log.txt"))
            {
                while (true)
                {
                    if (list.Count != 0)
                    { 
                        lock (list)                     
                        { 
                            foreach (var record in list)
                            {
                                streamWriter.WriteLine(record);                            
                            }
                            list.Clear();
                        }
                    }
                    streamWriter.Flush();
                }
            };
        }
    }
}
