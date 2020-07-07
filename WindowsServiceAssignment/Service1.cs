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
using WindowsServiceAssignment.DataAccessLayer;
using WindowsServiceAssignment.BusinessLayer;



namespace WindowsServiceAssignment.WindowsServiceAssignment
{
    public partial class Service1 : ServiceBase
    {
        string myPath = ConfigurationManager.AppSettings["myPath"];
        string inputxmlPath = ConfigurationManager.AppSettings["inputxmlPath"];
        BusinessLogic business = new BusinessLogic();
        DataAccess access = new DataAccess();
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

            Employee em;
            em = access.GetEmployee(1000);

            var curTime = DateTime.Now;
            int hour = curTime.Hour;
            int min = curTime.Minute;
            if (hour % 2 == 0 && min == 15)
            {
                List<BusinessLayer.Employee> result;
                //Read Data from .txt file and store in a list
                result = business.EmployeeDetail();
                // Serialize the input list and store it in .xml file
                business.WriteXML(result);
            }
            else if (hour % 2 == 1 && min == 30)
            {
                // Deserialize the list
                List<BusinessLayer.Employee> me;
                me = business.GetEmployeeListXML();
                // Store the deserialized list in .txt file
                business.StoreEmployeeListTXT(me);
            }
            else if(hour%2==0 && min==30)
            {
                List<BusinessLayer.Employee> list;
                //Gets data from txt file and stores in list
                list = business.EmployeeDetail();
                //stores the data from list to database
                access.WriteToDatabase(list);
                //acquires stored data from database and stores in list
                list = access.GetDetailsFromDatabase();
                //serializes the list and stores the serialized output in .xml file
                business.WriteXML(list);
            }
            else if(hour %2==1 && min==15)
            {
                List<BusinessLayer.Employee> list;
                //Gets data from xml file and stores in list
                list = business.GetEmployeeListXML();
                //stores the data from list to database
                access.WriteToDatabase(list);
                //acquires data from database and stores in list
                list = access.GetDetailsFromDatabase();
                //stores data from list to txt file
                business.StoreEmployeeListTXT(list);
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
