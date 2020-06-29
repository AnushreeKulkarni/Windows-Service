using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Globalization;
using System.Security.AccessControl;
using System.Timers;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Net.Mail;
using WindowsServiceAssignment.SMTPDemo;
using WindowsServiceAssignment.CustomLogger;



namespace WindowsServiceAssignment.WindowsServiceAssignment
{
    public partial class Service1 : ServiceBase
    {
        string myPath = ConfigurationManager.AppSettings["myPath"];
        string inputxmlPath = ConfigurationManager.AppSettings["inputxmlPath"];
        SendMail mail = new SendMail();
        Logger log = new Logger();
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
            log.CreateLogFile();
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            //number in milisecinds  
            timer.Interval = 60000;
            timer.Enabled = true;


        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            var curTime = DateTime.Now;
            int hour = curTime.Hour;
            int min = curTime.Minute;
            if (hour % 2 == 0 && min == 15)
            {
                List<Employee> result;
                //Read Data from .txt file and store in a list
                result = EmployeeDetail();
                // Serialize the input list and store it in .xml file
                WriteXML(result);
            }
            else if (hour % 2 == 1 && min == 30)
            {
                // Deserialize the list
                List<Employee> me;
                me = GetEmployeeListXML();
                // Store the deserialized list in .txt file
                StoreEmployeeListTXT(me);
            }

        }
        public List<Employee> EmployeeDetail()
        {
            timer.Stop();
            List<Employee> employee = new List<Employee>();
            try
            {
                if (File.Exists(myPath))
                {
                    var fileLines = File.ReadAllLines(myPath).ToList();
                    foreach (string line in fileLines)
                    {
                        List<Place> places = new List<Place>();
                        Employee emp = new Employee();
                        string input = line;
                        string[] templine = input.Split(',');
                        string employeeName = templine[0].Trim();
                        string employeeID = templine[1].Trim();
                        string employeeEmail = templine[2].Trim();
                        emp.EmployeeName = employeeName;
                        emp.EmployeeID = employeeID;
                        emp.EmployeeEmail = employeeEmail;
                        string addressInfoTemp = input.Substring(templine[0].Length + templine[1].Length + templine[2].Length + 3);
                        string addressInfo = addressInfoTemp.Substring(1, addressInfoTemp.Length - 2);
                        string[] addressSplit = addressInfo.Split('}');
                        for (int i = 0; i < addressSplit.Length - 1; i++)
                        {
                            List<Address> addresses = new List<Address>();
                            Place place = new Place();                        
                            string[] placeTemp1 = addressSplit[i].Split(':');
                            string[] placeTemp2 = placeTemp1[0].Split(',');
                            string Employeeplace = placeTemp2[placeTemp2.Length - 1];
                            string[] addressArray = placeTemp1[1].Substring(1).Split(',');
                            place.Places = Employeeplace;
                            foreach (var array in addressArray)
                            {
                                Address address = new Address();
                                address.Pincodes = array;
                                addresses.Add(address);
                            }
                            place.EmployeeAddress = addresses;
                            places.Add(place);             
                        }                       
                        emp.EmployeePlace = places;
                        employee.Add(emp);

                    }
                    
                }

                log.WriteLog("Data read from Catalog.txt input file and stored in a list.\n");
                return employee;
            }

            catch (Exception ex)
            {
                log.WriteLog(ex.StackTrace);
            }
            finally
            {
                timer.Start();
            }         
            return null;
        }
        public void WriteXML(List<Employee> catalog)
        {
            timer.Stop();
            string configXmlPath = ConfigurationManager.AppSettings["xmlPath"];
            string xmlPath = configXmlPath +"Catalog" + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".xml";
            try
            {
                var myFile = File.Create(xmlPath);
                myFile.Close();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                using (TextWriter writer = new StreamWriter(xmlPath))
                {
                    serializer.Serialize(writer, catalog);
                }
                log.WriteLog("Catalog.xml File is Created."+Environment.NewLine);
                log.WriteLog("Data is serialized and written to the Catalog.xml."+Environment.NewLine);                
                mail.SendEmail("XML file","XML file has been written successfully.");               
            }
            catch(Exception ex)
            {
                log.WriteLog(ex.StackTrace);
                mail.SendEmail("XML file", ex.Message);
            }
            finally
            {
                timer.Start();
            }
            
        }
        public List<Employee> GetEmployeeListXML()
        {
            timer.Stop();
            try
            {
                List<Employee> result;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                using (XmlReader read = XmlReader.Create(inputxmlPath))
                {
                    result = (List<Employee>)serializer.Deserialize(read);
                }
                log.WriteLog("Data has been deserialized.\n");
                return result;
            }
            catch(Exception ex)
            {
                log.WriteLog(ex.StackTrace);
            }
            finally
            {
                timer.Start();
            }
            return null;

        }
        public void StoreEmployeeListTXT(List<Employee> employee)
        {
            timer.Stop();
            string configTxtPath = ConfigurationManager.AppSettings["txtPath"];
            string txtPath = configTxtPath+"Catalog" + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt";

            try { 
                var myFile = File.Create(txtPath);
                myFile.Close();
                foreach (var detail in employee)
                {
                    string str;
                    string Name = detail.EmployeeName;
                    string ID = detail.EmployeeID;
                    string Email = detail.EmployeeEmail;
                    str= String.Concat(Name, ",", ID, ",", Email,",{");                       

                    for (int i = 0; i< employee[i].EmployeePlace.Count(); i++)
                    {
                        string EmployeePlace = detail.EmployeePlace[i].Places;
                        str = str + String.Concat(EmployeePlace, ":{");
                        for (int j = 0; j < employee[i].EmployeePlace[i].EmployeeAddress.Count(); j++)
                        {
                            string EmployeeAddress = detail.EmployeePlace[i].EmployeeAddress[j].Pincodes;
                            str = str + String.Concat(EmployeeAddress);
                            if (j!=employee[i].EmployeePlace[i].EmployeeAddress.Count()-1)
                            {
                                str = str + String.Concat(",");
                            }

                        }
                        str = str + String.Concat("}");
                        if (i != employee[i].EmployeePlace.Count() - 1)
                        {
                            str = str + String.Concat(",");
                        }
                    }
                    using (StreamWriter write = File.AppendText(txtPath))
                    {
                        str = str + String.Concat("}");
                        write.WriteLine(str);
                    }
                    
                }
                log.WriteLog("Catalog.txt File is created\n");
                log.WriteLog("Deserialized list is stored in Catalog.txt\n");
                mail.SendEmail("TXT file", "TXT file has been written successfully.");
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.StackTrace);
                mail.SendEmail("TXT file", ex.Message);

            }
            finally
            {
                timer.Start();
            }
        }
        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
