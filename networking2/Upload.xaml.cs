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
    
  //public delegate void ProgressWorkerDelegate(IProgressContext progressContext);

    public partial class Upload : Window, IProgressContext
    {
        internal static string upload_file;

        private bool canceled = false;
     //   private ProgressWorkerDelegate workDelegate = null;

        public bool Canceled
        {
            get { return canceled; }
        }

        public Upload()
        {
            InitializeComponent();
            uploadFile.Text = upload_file;

            CancelButton.Click += new RoutedEventHandler(CancelButton_Click);
        }


        public void UpdateProgress(double progress)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (SendOrPostCallback)delegate { Progress.SetValue(ProgressBar.ValueProperty, progress); }, null);
        }

        public void UpdateStatus(string status)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (SendOrPostCallback)delegate { StatusText.SetValue(TextBlock.TextProperty, status); }, null);
        }

        public void Finish()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                (SendOrPostCallback)delegate { Close(); }, null);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
          FileInfo toUpload = new FileInfo(uploadFile.Text);

            
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + MainWindow.address + "/" + toUpload.Name);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
            Stream ftpStream = request.GetRequestStream();
            FileStream file = File.OpenRead(uploadFile.Text);
            int length = 1024;
            byte[] buffer = new byte[length];
            int bytesRead = 0;
            
            double divide = 1;

            long filesize = toUpload.Length;

/*            if (filesize < 100000)
                divide = 1;
            if (filesize > 100000)
                divide = 0.001;

            for (int i = 0; i < filesize; i++)
                {
                    if (this.Canceled)
                        break;

                    this.UpdateProgress((double)i/divide);
                    this.UpdateStatus("Doing Step " + i);
                }
  */
            int totalReadBytesCount = 0;
            double progress;
            do
            {
                bytesRead = file.Read(buffer, 0, length);
                
                totalReadBytesCount += bytesRead;
                progress = totalReadBytesCount * 100.0 / toUpload.Length;

                this.UpdateProgress((double) progress);
                this.UpdateStatus("Doing Step " + progress);
                ftpStream.Write(buffer, 0, bytesRead);
             }
            while (bytesRead != 0);

            file.Close();
            ftpStream.Close();

            this.Finish();

            MessageBox.Show("Upload Complete");
        }

           

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            canceled = true;
            CancelButton.IsEnabled = false;
        }


    }

}