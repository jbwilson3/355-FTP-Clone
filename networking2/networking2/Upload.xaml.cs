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
using System.IO;
using System.Net;

namespace networking2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window 
    {
        public Upload()
        {
            InitializeComponent();
          // MessageBox.Show(MainWindow.
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
           // Uri target = new Uri("ftp"+);
            string fileName = "c:\\test2.txt";

           // if (File.Exists(fileName))


               // MessageBox.Show(MainWindow.error);

          //  else

               // MessageBox.Show(MainWindow.error);

           // MessageBox.Show(MainWindow.address);
            FileInfo toUpload = new FileInfo(fileName);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + MainWindow.address + "/" + toUpload.Name);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
            Stream ftpStream = request.GetRequestStream();
            FileStream file = File.OpenRead(fileName);
            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            do
            {
                bytesRead = file.Read(buffer, 0, length);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();

            MessageBox.Show("Upload Complete");

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
            byte[] fileData = request.DownloadData("ftp://" + MainWindow.address + "/" + "test2.txt");
            FileStream file = File.Create("c:\\yada\\" + "test2.txt");
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            MessageBox.Show("Download complete");

        }
    }
}
