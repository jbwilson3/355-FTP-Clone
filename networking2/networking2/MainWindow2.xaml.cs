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
        public struct Connection_Data
        {
            public string nameP, serverP, usernameP, passwordP;

            public Connection_Data(string name, string server, string username, string password)
            {
                nameP = name;
                serverP = server;
                usernameP = username;
                passwordP = password;
            }
        }

        //initialize connection array
        Connection_Data[] connectionsA; // declare numbers as an int array of any size
       
        public Connection_Data[] ExportData()
        {
            return connectionsA;
        }

        public MainWindow2()
        {
            InitializeComponent();
         
            //Read file "saved_connections.txt" and populate an array with data struct info
            try
            {
                //open file
                using (StreamReader saved_connections = new StreamReader("saved_connections.txt"))
                {
                    //lineCount == number of lines in file
                    var lineCount = File.ReadLines("saved_connections.txt").Count();
                    connectionsA = new Connection_Data[lineCount];// numbers is a 10-element array

                    for (int i = 0; i < lineCount; i++)
                    {
                        //read every line, and parse data to connnectionsA struct array fields
                        String line = saved_connections.ReadLine();
                        char[] delimiterChars = { ':' };
                        string[] words = line.Split(delimiterChars);
 
                        //populate connectionsA array
                        connectionsA[i].nameP = words[0];
                        connectionsA[i].serverP = words[1];
                        connectionsA[i].usernameP = words[2];
                        connectionsA[i].passwordP = words[3];
                    }
                    saved_connections.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

           // Loop through and dynamically add items to the ListBox. 
            for (int i = 0; i < connectionsA.Length; i++)
            {
                lstConnections.Items.Add(connectionsA[i].nameP);
            }
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
         
        }

        private void btnConnect_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Connect Clicked");
            address = connectionsA[0].serverP;
            c_username = connectionsA[0].usernameP;
            c_password = connectionsA[0].passwordP;
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
/*            // this.Hide();
*/
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Refresh Clicked");
            /*
            FtpWebRequest list = (FtpWebRequest)WebRequest.Create("ftp://" + address);
            list.Credentials = new NetworkCredential(c_username, c_password);
            list.Method = WebRequestMethods.Ftp.ListDirectory;
            WebResponse listResponse = (FtpWebResponse)list.GetResponse();
            Stream listStream = listResponse.GetResponseStream();
            StreamReader listReader = new StreamReader(listStream);
            try
            {
                string fileName;
                lstDir.Items.Clear();
                while (listReader.Peek() != -1)
                {
                    fileName = listReader.ReadLine();
                    lstDir.Items.Add(fileName);
                }
            }
            catch
            {
            }
            */
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add Clicked");
            Add add = new Add();
            add.Show();
        }

        private void btnMkdir_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Mkdir Clicked");
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Upload Clicked");
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Browse Clicked");
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("RM Clicked");
        }

        private void btnChMod_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Permissions Clicked");
        }

        private void btnRename_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MV Clicked");
        }



    }
}
