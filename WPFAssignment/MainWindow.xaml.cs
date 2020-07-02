﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsServiceAssignment.DataAccessLayer;
using WindowsServiceAssignment.BusinessLayer;

namespace WPFAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess access = new DataAccess();
        BusinessLogic logic = new BusinessLogic();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           
          
            if (String.IsNullOrEmpty(txtInput.Text))
            {
                lblErrorMessage.Content = "Please enter ID";
            }
            else if (String.IsNullOrWhiteSpace(txtInput.Text))
            {
                lblErrorMessage.Content = "Please enter valid ID";
            }
           else if (Convert.ToInt32(txtInput.Text) <= 0 || Convert.ToInt32(txtInput.Text) >= 2000)
            {
                lblErrorMessage.Content = "No Records Found";

            }
            else
            {
                lblErrorMessage.Content = "";
                int a = Convert.ToInt32(txtInput.Text);
                Employee em;
                em = access.GetEmployee(a);
                txtOutputId.Text = em.EmployeeID;
                txtOuputName.Text = em.EmployeeName;
                txtOutputEmail.Text = em.EmployeeEmail;
                dropdown1.Items.Add(em.EmployeePlace[0].Places);
                dropdown1.Items.Add(em.EmployeePlace[1].Places);

            }
        }

        private void dropdown1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = Convert.ToInt32(txtInput.Text);
            Employee em;
            em = access.GetEmployee(a);
            if (dropdown1.SelectedItem.ToString() == em.EmployeePlace[0].Places)
            {
                dropdown2.Items.Remove(em.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                dropdown2.Items.Remove(em.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                dropdown2.Items.Add(em.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                dropdown2.Items.Add(em.EmployeePlace[0].EmployeeAddress[1].Pincodes);

            }
            else
            {
                dropdown2.Items.Remove(em.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                dropdown2.Items.Remove(em.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                dropdown2.Items.Add(em.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                dropdown2.Items.Add(em.EmployeePlace[1].EmployeeAddress[1].Pincodes);
         
            }
         

        }



        private void dropdown2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
