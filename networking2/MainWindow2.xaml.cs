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
using Microsoft.Win32;


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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Window_loaded");
        }
        //Populate all connections list
        private void populate_connections()
        {
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


        internal static string c_name, c_username, c_password, fileToDownload, error, file_loc = string.Empty;
        internal static string address = string.Empty;
        internal static string directory = string.Empty;
        internal static bool[] isDir = new bool[1000];

        internal static FtpWebRequest ftpRequest;
        internal static WebResponse ftpResponse;
        internal static Stream ftpStream;
        internal static StreamReader ftpReader;


        private void connectBT_Click(object sender, RoutedEventArgs e)  //connects to server and displays files
        {
            Console.WriteLine("Connect Clicked. " + connectionsLB.SelectedItem + " is selected.");


            c_name = string.Empty;
            c_username = string.Empty;
            c_password = string.Empty;
            error = string.Empty;
            file_loc = string.Empty;

            if (connectionsLB.SelectedIndex == -1)   //Checks to see if any selections to the list were made 
            {
                MessageBox.Show("No selection Chosen");

            }
            else
            {
                for (int i = 0; i < connectionsA.Length; i++)
                {
                    //if it is the item selected, set all credential strings
                    if (connectionsA[i].nameP.ToString() == connectionsLB.SelectedItem.ToString())
                    {
                        c_name = connectionsA[i].nameP;
                        address = connectionsA[i].serverP;
                        c_username = connectionsA[i].usernameP;
                        c_password = connectionsA[i].passwordP;

                        directory = "/";
                    }

                }

                refresh(lstDir);

                //makes buttons available to users after a successful connection has been established 
                downloadBT.Visibility = Visibility.Visible;
                uploadBT.Visibility = Visibility.Visible;
                mkdirBT.Visibility = Visibility.Visible;
                refreshBT.Visibility = Visibility.Visible;
            }

        }

        private void refreshBT_Click(object sender, RoutedEventArgs e)
        {
            refresh(lstDir);
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
                InputBox w4 = new InputBox();

                w4.ShowDialog();

                //  MessageBox.Show(InputBox.add_directory);

                FtpWebRequest mkDir = (FtpWebRequest)WebRequest.Create(address + directory + InputBox.add_directory);
                mkDir.Credentials = new NetworkCredential(c_username, c_password);
                mkDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                WebResponse mkDirResponse = (FtpWebResponse)mkDir.GetResponse();
                mkDirResponse.Close();
                mkDir = null;
            }
            catch
            {
                MessageBox.Show("could not make the directory");
            }

            refresh(lstDir);
        }

        private void uploadBT_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            var result = openFileDialog1.ShowDialog();
            string strFileLocation = "";

            string strDirectory = "C://";

            //Open the dialog box



            Console.WriteLine("Directory: " + strDirectory);
            openFileDialog1.InitialDirectory = strDirectory;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

                strFileLocation = openFileDialog1.FileName;
                Upload.upload_file = strFileLocation;
                Upload w2 = new Upload();
                w2.ShowDialog();
           
        }

        private void delBT_Click(object sender, RoutedEventArgs e)  //deletes a directory
        {
            try
            {
                FtpWebRequest rm = (FtpWebRequest)WebRequest.Create(address + directory + lstDir.SelectedItem.ToString());
                rm.Credentials = new NetworkCredential(c_username, c_password);
                rm.Method = WebRequestMethods.Ftp.RemoveDirectory;
                WebResponse rmResponse = (FtpWebResponse)rm.GetResponse();
                rmResponse.Close();
                rm = null;
            }
            catch
            {
                MessageBox.Show("could not delete directory: " + directory);
            }
            refresh(lstDir);
        }

        private void removeBT_Click(object sender, RoutedEventArgs e)   //Removes a file
        {
            try
            {
                //it is assumed that the address points to a file and not a directory
                ftpRequest = (FtpWebRequest)WebRequest.Create(address + directory + lstDir.SelectedItem.ToString());
                ftpRequest.Credentials = new NetworkCredential(c_username, c_password);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                
            }
            catch
            {
                MessageBox.Show("could not delete file: " + directory);
            }
            ftpResponse.Close();
            ftpResponse = null;
            refresh(lstDir);
        }

        private void chmodBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Permissions Button Clicked");
            if (lstDir.SelectedIndex == -1)   //Checks to see if any selections to the list were made 
            {
                MessageBox.Show("No selection Chosen");

            }
            else
            {
                CHMOD change = new CHMOD(lstDir.SelectedItem.ToString());
                change.ShowDialog();
            }
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
                    string linetocompare = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        //check each line in file and check if it is the item selected
                        for (int i = 0; i < connectionsA.Length; i++)
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

        private void downloadBT_Click(object sender, RoutedEventArgs e)
        {


            if (lstDir.SelectedIndex == -1)   //Checks to see if any selections to the list were made 
            {
                MessageBox.Show("No selection Chosen");

            }
            else
            {

                Download.download_file = fileToDownload = lstDir.SelectedItem.ToString();   //goes to download window
                Download w2 = new Download();
                w2.ShowDialog();

            }
        }




        //
        //refresh function
        //
        public bool refresh(ListBox listDir)
        {
            try
            {
                //create request
                ftpRequest = (FtpWebRequest)WebRequest.Create(address + directory);
                ftpRequest.Credentials = new NetworkCredential(c_username, c_password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                ftpReader = new StreamReader(ftpStream);
            }
            catch
            {
                MessageBox.Show("could not retrieve directory information from " + address + directory);
                return false;
            }
            // put files in listItem
            listDir.Items.Clear();
            int i = 0;
            while (ftpReader.Peek() != -1)
            {

                //read next file/directory information
                String line;
                line = ftpReader.ReadLine();

                //find the file name and add it to the listbox
                int pos = 0;
                while (line[pos++] != ':') ;
                while (line[pos++] != ' ') ;

                line.Trim();
                //Is it a directory?
                if (line[0] == 'd')
                {
                    listDir.Items.Add(line.Substring(pos) + "/");
                    isDir[i++] = true;
                }
                else
                {
                    listDir.Items.Add(line.Substring(pos));
                    isDir[i++] = false;
                }


            }

            //clear request so the refresh button may be used again
            ftpResponse.Close();
            ftpRequest = null;
            
            //update working directory
            updateDirectory();

            return true;
        }

        private void updateDirectory()
        {
            if (address.Length + directory.Length > 35 && address.Length > 10 && directory.Length > 15)
            {
                txtDirectory.Text = address.Substring(0, 10) + "..." + directory.Substring(directory.Length - 15);
            }
            else
            {
                txtDirectory.Text = address + directory;
            }
        }

        private void lstDir_MouseDoubleClick(object sender, System.EventArgs e)
        {
            if (lstDir.SelectedIndex != -1)
            {
                if (isDir[lstDir.SelectedIndex] == true)
                {
                    String oldDirectory = directory;
                    directory = directory + lstDir.SelectedItem.ToString();
                    updateDirectory();
                    chmodBT.Visibility = Visibility.Hidden;

                    if (!refresh(lstDir))
                    {
                        directory = oldDirectory;
                    }
                }
            }
        }

        private void lstDir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDir.SelectedIndex != -1)
            {

                if (isDir[lstDir.SelectedIndex] == true)
                {
                    removeBT.Visibility = Visibility.Hidden;
                    delBT.Visibility = Visibility.Visible;
                    chmodBT.Visibility = Visibility.Visible;
                }
                else
                {
                    removeBT.Visibility = Visibility.Visible;
                    delBT.Visibility = Visibility.Hidden;
                    chmodBT.Visibility = Visibility.Visible;
                }
            }

        }

        private void btnUpDir_Click(object sender, RoutedEventArgs e)
        {
            if (directory.Length < 2)
                return;
            int i = directory.Length - 2;
            while (directory[i--] != '/' && i > 0) ;

            directory = directory.Substring(0, i+1);
            updateDirectory();
            refresh(lstDir);
            chmodBT.Visibility = Visibility.Hidden;
        }

        private void connectionsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            connectBT_Click(sender, e);
        }

    }
}
