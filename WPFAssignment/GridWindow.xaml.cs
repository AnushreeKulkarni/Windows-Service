using System;
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
        public GridWindow()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = BinddataGrid();
        }
        private List<Employee> BinddataGrid()
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
    }
}
