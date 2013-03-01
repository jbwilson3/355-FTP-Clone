using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FtpLib;

namespace networking2
{
    /// <summary>
    /// Interaction logic for CHMOD.xaml
    /// </summary>
    public partial class CHMOD : Window
    {
        private int owner;
        private int group;
        private int world;
        private string item;

        public CHMOD(string selected)
        {
            InitializeComponent();
            owner = 0;
            group = 0;
            world = 0;
            item = selected;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                FtpConnection chmod = new FtpConnection(MainWindow.address.Remove(0,6), MainWindow.c_username, MainWindow.c_password);
                chmod.Open();
                chmod.Login();
                chmod.SendCommand("SITE CHMOD " + owner + group + world + " " + MainWindow.directory + item);
                //MessageBox.Show(MainWindow.address.Remove(0,6), "SITE CHMOD " + owner + group + world + " " + MainWindow.directory + item);
                MessageBox.Show(item + " permissions changed to " + owner + group + world);
                chmod.Close();
            }

            catch
            {
                MessageBox.Show("ERROR");
            }
            Close();

        }

        //Start Checked Code
        private void OwnerRead_Checked(object sender, RoutedEventArgs e)
        {
            owner = owner + 4;
        }

        private void GroupRead_Checked(object sender, RoutedEventArgs e)
        {
            group = group + 4;
        }

        private void WorldRead_Checked(object sender, RoutedEventArgs e)
        {
            world = world + 4;
        }

        private void OwnerWrite_Checked(object sender, RoutedEventArgs e)
        {
            owner = owner + 2;
        }

        private void GroupWrite_Checked(object sender, RoutedEventArgs e)
        {
            group = group + 2;
        }

        private void WorldWrite_Checked(object sender, RoutedEventArgs e)
        {
            world = world + 2;
        }

        private void OwnerExec_Checked(object sender, RoutedEventArgs e)
        {
            owner = owner + 1;
        }

        private void GroupExec_Checked(object sender, RoutedEventArgs e)
        {
            group = group + 1;
        }

        private void WorldExec_Checked(object sender, RoutedEventArgs e)
        {
            world = world + 1;
        }




        //Start Unchecked Code
        private void OwnerRead_Unchecked(object sender, RoutedEventArgs e)
        {
            owner = owner - 4;
        }

        private void GroupRead_Unchecked(object sender, RoutedEventArgs e)
        {
            group = group - 4;
        }

        private void WorldRead_Unchecked(object sender, RoutedEventArgs e)
        {
            world = world - 4;
        }

        private void OwnerWrite_Unchecked(object sender, RoutedEventArgs e)
        {
            owner = owner - 2;
        }

        private void GroupWrite_Unchecked(object sender, RoutedEventArgs e)
        {
            group = group - 2;
        }

        private void WorldWrite_Unchecked(object sender, RoutedEventArgs e)
        {
            world = world - 2;
        }

        private void OwnerExec_Unchecked(object sender, RoutedEventArgs e)
        {
            owner = owner - 1;
        }

        private void GroupExec_Unchecked(object sender, RoutedEventArgs e)
        {
            group = group - 1;
        }

        private void WorldExec_Unchecked(object sender, RoutedEventArgs e)
        {
            world = world - 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
