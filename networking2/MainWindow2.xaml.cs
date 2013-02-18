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
    public partial class MainWindow : Window
    {

        //struct containing all data needed for each connection. extendable. (port, new home~ dir...)
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

        public MainWindow()
        {
            InitializeComponent();
            populate_connections();
        }

        ~MainWindow()
        {
            Console.WriteLine("Deconstructing MainWindow2");
        }
    
        //Populate all connections list
        private void populate_connections(){
            connectionsLB.Items.Clear();
            //Read file "saved_connections.txt" and populate an array with data struct info
            try
            {
                //open file
                using (StreamReader saved_connections = new StreamReader("saved_connections.txt"))
                {
                    //lineCount == number of lines in file
                    var lineCount = File.ReadLines("saved_connections.txt").Count();
                    connectionsA = new Connection_Data[lineCount];// numbers is an array with the length == the number of lines

                    for (int i = 0; i < lineCount; i++)
                    {
                        //read every line, and parse data to connnectionsA struct array fields
                        String line = saved_connections.ReadLine();
                        char[] delimiterChars = { '#' };
                        string[] words = line.Split(delimiterChars);

                        //populate connectionsA array with data
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
                connectionsLB.Items.Add(connectionsA[i].nameP);
            }
        }


        internal static string c_name, c_username, c_password, error, file_loc = string.Empty;
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

        private void connectBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Connect Clicked. " + connectionsLB.SelectedItem + " is selected.");
            bool no_connection_found = true;

            c_name = string.Empty;
            c_username = string.Empty;
            c_password = string.Empty;
            error = string.Empty;
            file_loc = string.Empty;

            for (int i = 0; i < connectionsA.Length; i++)
            {
                //if it is the item selected, set all credential strings
                if (connectionsA[i].nameP.ToString() == connectionsLB.SelectedItem.ToString())
                {
                    c_name = connectionsA[i].nameP;
                    address = connectionsA[i].serverP;
                    c_username = connectionsA[i].usernameP;
                    c_password = connectionsA[i].passwordP;
                    no_connection_found = false;
                }
            }

            //this should not happen. but it is possible with no data maybe?
            if (no_connection_found)
            {
                MessageBox.Show("Select a new connection from the listbox.");
                Console.WriteLine("These are the current values: " + c_name + c_username + c_password+address);
            }
            else
            {
                StringBuilder result = new StringBuilder();
                //isValidConnection(server.Text,username.Text,password.Text);

                FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://" + address);
                requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
                requestDir.Credentials = new NetworkCredential(c_username, c_password);
                WebResponse response = requestDir.GetResponse();
                FtpWebResponse responseDir = (FtpWebResponse)requestDir.GetResponse();
                StreamReader readerDir = new StreamReader(responseDir.GetResponseStream());
                //error = "Connected to the server";
                //Upload w2 = new Upload();
                //w2.Show();
                // this.Hide();
                
            }

        }

        private void refreshBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Refresh Clicked");
            
            FtpWebRequest list = (FtpWebRequest)WebRequest.Create("ftp://" + address);
            list.Credentials = new NetworkCredential(c_username, c_password);
            list.Method = WebRequestMethods.Ftp.ListDirectory;
            WebResponse listResponse = (FtpWebResponse)list.GetResponse();
            Stream listStream = listResponse.GetResponseStream();
            StreamReader listReader = new StreamReader(listStream);
            //clear request so the refresh button may be used again
            
           // put files in listItem
            string fileName;
            lstDir.Items.Clear();
            while (listReader.Peek() != -1)
            {
                fileName = listReader.ReadLine();
                lstDir.Items.Add(fileName);
            }

            listResponse.Close();
            list = null;
        }

        private void addConnBT_Click(object sender, RoutedEventArgs e)
        {
            //Creates new add window, and shows it, making the parent window wait till add is closed
            Add add_window = new Add();
            add_window.ShowDialog();

            //repopulate list
            populate_connections();
        }

        private void mkdirBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Mkdir Button Clicked");

            try
            {
                FtpWebRequest mkDir = (FtpWebRequest)WebRequest.Create("ftp://" + address + "/mynewdir");
                mkDir.Credentials = new NetworkCredential(c_username, c_password);
                mkDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                WebResponse mkDirResponse = (FtpWebResponse)mkDir.GetResponse();
                mkDirResponse.Close();
                mkDir = null;
            }
            catch
            {
            }
        }

        private void uploadBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Upload Button Clicked");
        }

        private void browseBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Browse Button Clicked");
        }

        private void removeBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("RM Button Clicked");

            try
            {
                bool isDir = true;
                string file = lstDir.SelectedItem.ToString();
                if(file[file.Length-3] == '.' || file[file.Length-4] == '.')
                {
                    isDir = false;
                }
                FtpWebRequest rm = (FtpWebRequest)WebRequest.Create("ftp://" + address + "/" + lstDir.SelectedItem.ToString());
                rm.Credentials = new NetworkCredential(c_username, c_password);
                if (isDir)
                {
                    rm.Method = WebRequestMethods.Ftp.RemoveDirectory;
                }
                else
                {
                    rm.Method = WebRequestMethods.Ftp.DeleteFile;
                }
                WebResponse rmResponse = (FtpWebResponse)rm.GetResponse();
                rmResponse.Close();
                rm = null;
            }
            catch
            {
            }
        }

        private void chmodBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Permissions Button Clicked");
        }

        private void mvBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MV Button Clicked");
        }
        
        private void removeConnBT_Click(object sender, RoutedEventArgs e)
        {
            
            //creating a temp file to copy old file minus the removed item
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("saved_connections.txt"))
            {
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;
                    string linetocompare="";

                    while ((line = sr.ReadLine()) != null)
                    {
                        //check each line in file and check if it is the item selected
                        for (int i = 0; i < connectionsA.Length; i++ )
                        {
                            //if it is the item selected, set linetocompare == to the string it should be
                            if (connectionsA[i].nameP == connectionsLB.SelectedItem)
                            {
                                linetocompare = connectionsA[i].nameP + ":" + connectionsA[i].serverP + ":" 
                                    + connectionsA[i].usernameP + ":" + connectionsA[i].passwordP;
                            }
                        }
                        //write every line to the tempfile, as long as it is not the selected item
                        if (line != linetocompare)
                            sw.WriteLine(line);
                    }
                }
            }

            //update old file with new tempfile
            File.Delete("saved_connections.txt");
            File.Move(tempFile, "saved_connections.txt");

            //repopulate the connections list with new file
            this.populate_connections();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Window_loaded");
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ListBoxItem_Selected");
        } 
    }
}
