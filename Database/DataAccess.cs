using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Timers;
using System.Xml.Serialization;
using WindowsServiceAssignment.CustomLogger;
using WindowsServiceAssignment.SMTPDemo;

namespace WindowsServiceAssignment.DataAccessLayer
{
    public class DataAccess
    {
        string conectionString = @"Data Source=LAPTOP-KV7BV9V0\SQLEXPRESS;Initial Catalog=EmployeeCatalog;User Id=sa;Password=sa123";
        string myPath = ConfigurationManager.AppSettings["myPath"];
        Logger log = new Logger();
        SendMail mail = new SendMail();
        Timer timer = new Timer();



        public List<Employee> GetEmployeeDetails()
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
                        string[] placeTemp1 = addressSplit[0].Split(':');
                        string placeOne = placeTemp1[0].Trim();
                        emp.PlaceOne = placeOne;
                        string[] placeTemp2 = placeTemp1[1].Split('{');
                        string[] placeTemp3 = placeTemp2[1].Split(',');
                        string pincodeOne = placeTemp3[0].Trim();
                        string pincodeTwo = placeTemp3[1].Trim();
                        emp.PincodeOne = pincodeOne;
                        emp.PincodeTwo = pincodeTwo;
                        string[] placeTemp4 = addressSplit[1].Split('{');
                        string[] placeTemp5 = placeTemp4[1].Split(',');
                        string pincodeThree = placeTemp5[0].Trim();
                        string pincodeFour = placeTemp5[1].Trim();
                        string[] placeTemp6 = placeTemp4[0].Split(':');
                        string[] placeTemp7 = placeTemp6[0].Split(',');
                        string placeTwo = placeTemp7[1].Trim();
                        emp.PlaceTwo = placeTwo;
                        emp.PincodeThree = pincodeThree;
                        emp.PincodeFour = pincodeFour;
                        employee.Add(emp);

                    }
                }
                log.WriteLog("Data read from Catalog.txt input file and stored in a list."+Environment.NewLine);
                return employee;
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
        public void WriteToDatabase(List<Employee> records)
        {
            timer.Stop();

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into EmployeeDetails(ID,Name,Email,PlaceOne,PincodeOne,PincodeTwo,PlaceTwo,PincodeThree,PincodeFour) values (@ID,@Name,@Email,@PlaceOne,@PincodeOne,@PincodeTwo,@PlaceTwo,@PincodeThree,@PincodeFour)");
                cmd.Connection = conn;
                try
                {
                    foreach (var item in records)
                    {
                        cmd.Parameters.AddWithValue("@ID", item.EmployeeID);
                        cmd.Parameters.AddWithValue("@Name", item.EmployeeName);
                        cmd.Parameters.AddWithValue("@Email", item.EmployeeEmail);
                        cmd.Parameters.AddWithValue("@PlaceOne", item.PlaceOne);
                        cmd.Parameters.AddWithValue("@PincodeOne", item.PincodeOne);
                        cmd.Parameters.AddWithValue("@PincodeTwo", item.PincodeTwo);
                        cmd.Parameters.AddWithValue("@PlaceTwo", item.PlaceTwo);
                        cmd.Parameters.AddWithValue("@PincodeThree", item.PincodeThree);
                        cmd.Parameters.AddWithValue("@PincodeFour", item.PincodeFour);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        conn.Close();
                    }
                    log.WriteLog("Acquired data has been stored in Database" + Environment.NewLine);
                    mail.SendEmail("First Database Update", "Data from file has been successfully stored in Database");
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.StackTrace);
                    mail.SendEmail("First Database Update", ex.Message);
                }
                finally
                {
                    timer.Start();
                }


            }

        }

        public List<Employee> GetDetailsFromDatabase()
        {
            timer.Stop();
            SqlConnection conn = new SqlConnection(conectionString);
            SqlCommand cmd;
            SqlDataReader reader;
            string query = "select * from dbo.EmployeeDetails";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Employee> empl = new List<Employee>();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = reader.GetValue(0).ToString();
                    emp.EmployeeName = reader.GetValue(1).ToString();
                    emp.EmployeeEmail = reader.GetValue(2).ToString();
                    emp.PlaceOne = reader.GetValue(3).ToString();
                    emp.PincodeOne = reader.GetValue(4).ToString();
                    emp.PincodeTwo = reader.GetValue(5).ToString();
                    emp.PlaceTwo = reader.GetValue(6).ToString();
                    emp.PincodeThree = reader.GetValue(7).ToString();
                    emp.PincodeFour = reader.GetValue(8).ToString();
                    empl.Add(emp);
                }     
                reader.Close();
                conn.Close();
                log.WriteLog("Data from Database has been acquired."+Environment.NewLine);
                return empl;
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
            string xmlPath = configXmlPath + "Catalog" + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".xml";
            try
            {
                var myFile = File.Create(xmlPath);
                myFile.Close();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                using (TextWriter writer = new StreamWriter(xmlPath))
                {
                   
                    serializer.Serialize(writer, catalog);
                    
                }
                log.WriteLog("Catalog.xml File is Created." + Environment.NewLine);
                log.WriteLog("Data from database has been serialized and stored in Catalog.xml" + Environment.NewLine);
                mail.SendEmail("Second Database Update", "Data from database has been serialized and stored in Catalog.xml successfully");
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.StackTrace);
                mail.SendEmail("Second Database Update", ex.Message);
            }
            finally
            {
                timer.Start();
            }



        }
    }
}

