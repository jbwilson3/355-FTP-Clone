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
        private bool which;

        public CHMOD(string selected)
        {
            InitializeComponent();
            owner = 0;
            group = 0;
            world = 0;
            item = selected;
            which = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool good = false;
            bool run = true;
            string check = chmodtxt.ToString().Remove(0, chmodtxt.ToString().Length - 3);
            //MessageBox.Show(check);
            if (which==true)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (check[i] == '0' || check[i] == '1' || check[i] == '2' || check[i] == '3' || check[i] == '4' || check[i] == '5' || check[i] == '6' || check[i] == '7')
                    {
                        good = true;
                    }
                    else
                    {
                        good = false;
                        break;
                    }
                }
                if (good == false)
                {
                    MessageBox.Show("Incorrect Format");
                    chmodtxt.Clear();
                    run = false;
                }
            }

            char owners = '7';
            char groups = '7';
            char worlds = '7';

            if (good == true && which==true)
            {
                owners = check[0];
                groups = check[1];
                worlds = check[2];
            }
            //MessageBox.Show("" + owners + groups + worlds);

            if (run == true)
            {
                try
                {
                    FtpConnection chmod = new FtpConnection(MainWindow.address.Remove(0, 6), MainWindow.c_username, MainWindow.c_password);
                    chmod.Open();
                    chmod.Login();
                    if (which == true)
                        chmod.SendCommand("SITE CHMOD " + owners + groups + worlds + " " + MainWindow.directory + item);
                    else
                        chmod.SendCommand("SITE CHMOD " + owner.ToString() + group.ToString() + world.ToString() + " " + MainWindow.directory + item);
                    //MessageBox.Show(MainWindow.address.Remove(0,6), "SITE CHMOD " + owner + group + world + " " + MainWindow.directory + item);
                    //MessageBox.Show(item + " permissions changed to " + owner + group + world);
                    chmod.Close();
                }

                catch
                {
                    MessageBox.Show("ERROR");
                }
                Close();
            }

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


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void numtab_clicked(object sender, RoutedEventArgs e)
        {
            numtab.IsEnabled = false;
            ckbxtab.IsEnabled = true;
            which = true;
            chmodtxt.Visibility = Visibility.Visible;

            ownert.Visibility = Visibility.Hidden;
            groupt.Visibility = Visibility.Hidden;
            worldt.Visibility = Visibility.Hidden;

            readt.Visibility = Visibility.Hidden;
            writet.Visibility = Visibility.Hidden;
            exet.Visibility = Visibility.Hidden;

            OwnerRead.Visibility = Visibility.Hidden;
            GroupRead.Visibility = Visibility.Hidden;
            WorldRead.Visibility = Visibility.Hidden;

            OwnerWrite.Visibility = Visibility.Hidden;
            GroupWrite.Visibility = Visibility.Hidden;
            WorldWrite.Visibility = Visibility.Hidden;

            OwnerExec.Visibility = Visibility.Hidden;
            GroupExec.Visibility = Visibility.Hidden;
            WorldExec.Visibility = Visibility.Hidden;
            
        }

        private void ckbxtab_clicked(object sender, RoutedEventArgs e)
        {
            numtab.IsEnabled = true;
            ckbxtab.IsEnabled = false;
            which = false;
            chmodtxt.Visibility = Visibility.Hidden;

            ownert.Visibility = Visibility.Visible;
            groupt.Visibility = Visibility.Visible;
            worldt.Visibility = Visibility.Visible;

            readt.Visibility = Visibility.Visible;
            writet.Visibility = Visibility.Visible;
            exet.Visibility = Visibility.Visible;
            
            OwnerRead.Visibility = Visibility.Visible;
            GroupRead.Visibility = Visibility.Visible;
            WorldRead.Visibility = Visibility.Visible;

            OwnerWrite.Visibility = Visibility.Visible;
            GroupWrite.Visibility = Visibility.Visible;
            WorldWrite.Visibility = Visibility.Visible;

            OwnerExec.Visibility = Visibility.Visible;
            GroupExec.Visibility = Visibility.Visible;
            WorldExec.Visibility = Visibility.Visible;
            
        }

               
    }
}
