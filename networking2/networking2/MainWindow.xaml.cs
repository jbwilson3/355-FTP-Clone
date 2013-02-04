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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       internal static string c_username, c_password, error, file_loc = string.Empty;
        internal static string address = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
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
                error = textBox1.Text = "failed";
    return false;
            }
                 error = textBox1.Text = "Connection Established";
return true;
       }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            address = server.Text = "drwestfall.info";
            c_username = username.Text = "project01";
            c_password = pword.Text = "csci355";
            StringBuilder result = new StringBuilder();
            //isValidConnection(server.Text,username.Text,password.Text);


            
           FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://"+address);
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