using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace WindowsServiceAssignment.CustomLogger
{
   public class Logger
    {
        //string logPath = ConfigurationManager.AppSettings["logPath"];
        string logPath = ConfigurationManager.AppSettings["logPath"];
        public void CreateLogFile()
        {
            if (!File.Exists(logPath))
            {
                var myFile = File.Create(logPath);
                myFile.Close();
            }
            else
            {
                  
            }
        }
  
        public void WriteLog(string message)
        {

            if (File.Exists(logPath))
            {              
                File.AppendAllText(logPath, DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " " + message);               
            }
            else
            {
               
            }
        }       
    }
}
