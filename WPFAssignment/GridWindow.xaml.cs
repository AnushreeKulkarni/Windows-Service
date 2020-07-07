﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WindowsServiceAssignment.BusinessLayer;
using WindowsServiceAssignment.DataAccessLayer;
using System.Configuration;



namespace WPFAssignment
{
    /// <summary>
    /// Interaction logic for GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {
        
        List<Employee> empList;


        public GridWindow()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = BinddataGrid();
            DataAccess access = new DataAccess();
            empList = access.GetDetailsFromDatabase();

            dropdown2.Items.Add("Basic Filter");
            dropdown2.Items.Add("Order by");
            dropdown2.Items.Add("Join");
            dropdown2.Items.Add("Group by");


        }
        public List<Employee> BinddataGrid()
        {
           
            try
            {
                DataAccess access = new DataAccess();
                List<Employee> list;
                list = access.GetDetailsFromDatabase();
                return list;
            }
            catch(Exception)
            {
                MessageBox.Show("Error Displaying Records");
            }
            return null;
        }



        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //Data should be exported to excel sheet
            string configExcelPath = ConfigurationManager.AppSettings["excelPath"];
            string excelPath = configExcelPath + "Records" + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".xls";
            try
            {
               
                var myFile = File.Create(excelPath);
                myFile.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Couldn't create Excel File");
            }
            try
            {
                dataGrid1.SelectAllCells();
                dataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid1);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                dataGrid1.UnselectAllCells();
                using (StreamWriter file = new StreamWriter(excelPath))
                {
                    file.WriteLine(result);
                }
                //file.Close();
                MessageBox.Show(" Exported DataGrid data to Excel file");
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to Export Data");
            }

            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void dropdown2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           dataGrid1.ItemsSource = GetDetail();
        }
        public List<Employee> GetDetail()
        {
            List<Employee> list;
            LinqMethods methods = new LinqMethods();
            if (dropdown2.SelectedItem.ToString() == "Basic Filter")
            {
                
                list = methods.BasicFilter(empList);
                return list;
            }
            else if(dropdown2.SelectedItem.ToString()=="Order by")
            {
                list = methods.OrderBy(empList);
                return list;
            }
            else if(dropdown2.SelectedItem.ToString()=="Join")
            {
                list = methods.Join(empList);
                return list;
            }
            else if(dropdown2.SelectedItem.ToString()=="Group by")
            {
                list = methods.GroupBy(empList);
                return list;
            }
            return null;
            
        }

        private void dataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}