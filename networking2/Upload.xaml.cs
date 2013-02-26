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
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace networking2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    


    public partial class Upload : Window
    {
        internal static string upload_file;
        public string file_upload;
        private bool canceled = false;


        BackgroundWorker backgroundWorker = new BackgroundWorker();

        public Upload()
        {
            InitializeComponent();
            uploadFile.Text = upload_file;

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            file_upload = upload_file;
        }



        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            FileInfo toUpload = new FileInfo(file_upload);



            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + MainWindow.address + "/" + toUpload.Name);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
            Stream ftpStream = request.GetRequestStream();
            FileStream file = File.OpenRead(file_upload);
            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;

            long filesize = toUpload.Length;



            int totalReadBytesCount = 0;
            double progress;
            do
            {
                bytesRead = file.Read(buffer, 0, length);

                totalReadBytesCount += bytesRead;
                progress = totalReadBytesCount * 100.0 / toUpload.Length;
                backgroundWorker.ReportProgress((int)progress);
                ftpStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();

            MessageBox.Show("Upload Complete");
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {

            backgroundWorker.RunWorkerAsync();

        }

      
    }

}