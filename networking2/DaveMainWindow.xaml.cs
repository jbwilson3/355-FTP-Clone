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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Threading;

namespace networking2
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
    
        internal static string c_username, c_password, error, file_loc = string.Empty;
        internal static string address = string.Empty;


       private bool isValidConnection(string url, string user, string password)
             {
           
                 try 
            {
                
                FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://"+address);
                requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
                requestDir.Credentials = new NetworkCredential(c_username, c_password);
                WebResponse response = requestDir.GetResponse();
                
            }
            catch
            {
                error = txtWD.Text = "failed";
                return false;
            }
                error = txtWD.Text = "Connection Established";
                return true;
            }
        


        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            address = "drwestfall.info";
            c_username = "project01";
            c_password =  "csci355";
            StringBuilder result = new StringBuilder();
            //isValidConnection(server.Text,username.Text,password.Text);



            FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://" + address);
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
            requestDir.Credentials = new NetworkCredential(c_username, c_password);
            WebResponse response = requestDir.GetResponse();
            FtpWebResponse responseDir = (FtpWebResponse)requestDir.GetResponse();
            StreamReader readerDir = new StreamReader(responseDir.GetResponseStream());
            //error = "Connected to the server";
            Upload w2 = new Upload();
            w2.Show();
            // this.Hide();
        }


    }
}
