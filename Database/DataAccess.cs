using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Xml.Serialization;
using System.Xml;
using WindowsServiceAssignment.CustomLogger;
using WindowsServiceAssignment.SMTPDemo;
using WindowsServiceAssignment.BusinessLayer;

namespace WindowsServiceAssignment.DataAccessLayer
{
    public class DataAccess
    {
        string conectionString = @"Data Source=LAPTOP-KV7BV9V0\SQLEXPRESS;Initial Catalog=EmployeeCatalog;User Id=sa;Password=sa123";
        Logger log = new Logger();
        SendMail mail = new SendMail();
        public void WriteToDatabase(List<Employee> records)
        {
          
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
                        cmd.Parameters.AddWithValue("@PlaceOne", item.EmployeePlace[0].Places);
                        cmd.Parameters.AddWithValue("@PincodeOne", item.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                        cmd.Parameters.AddWithValue("@PincodeTwo", item.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                        cmd.Parameters.AddWithValue("@PlaceTwo", item.EmployeePlace[1].Places);
                        cmd.Parameters.AddWithValue("@PincodeThree", item.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                        cmd.Parameters.AddWithValue("@PincodeFour", item.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        conn.Close();
                    }
                    log.WriteLog("Acquired data has been stored in Database" + Environment.NewLine);
                    mail.SendEmail("Database Update", "Data from file has been successfully stored in Database");
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.StackTrace);
                    mail.SendEmail("First Database Update", ex.Message);
                }
                finally
                {
                   
                }
            }
        }
        public List<Employee> GetDetailsFromDatabase()
        {
          
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
                    List<Place> place = new List<Place>();
                    Place place1 = new Place();
                    Place place2 = new Place();
                    List<Address> addresses1 = new List<Address>();
                    Address addr1 = new Address();
                    Address addr2 = new Address();
                    List<Address> addresses2 = new List<Address>();
                    Address addr3 = new Address();
                    Address addr4 = new Address();
                    Employee emp = new Employee();
                    emp.EmployeeID = reader.GetValue(0).ToString();
                    emp.EmployeeName = reader.GetValue(1).ToString();
                    emp.EmployeeEmail = reader.GetValue(2).ToString();
                    place1.Places = reader.GetValue(3).ToString();
                    addr1.Pincodes = reader.GetValue(4).ToString();
                    addr2.Pincodes = reader.GetValue(5).ToString();
                    place2.Places = reader.GetValue(6).ToString();
                    addr3.Pincodes = reader.GetValue(7).ToString();
                    addr4.Pincodes = reader.GetValue(8).ToString();
                    addresses1.Add(addr1);
                    addresses1.Add(addr2);
                    addresses2.Add(addr3);
                    addresses2.Add(addr4);
                    place1.EmployeeAddress = addresses1;
                    place2.EmployeeAddress = addresses2;
                    place.Add(place1);
                    place.Add(place2);
                    emp.EmployeePlace = place;
                    empl.Add(emp);
                }
                reader.Close();
                conn.Close();
                log.WriteLog("Data from Database has been acquired." + Environment.NewLine);
                return empl;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.StackTrace);
            }
            finally
            {
             
            }
            return null;
        }     
      
    }
}

