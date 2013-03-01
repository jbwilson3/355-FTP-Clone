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
using System.ComponentModel;
using System.Net;
using System.IO;

namespace networking2
{
    /// <summary>
    /// Interaction logic for Download.xaml
    /// </summary>
    public partial class Download : Window
    {

        internal static string download_file;
        
        public string file_download;
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public Download()
        {
            InitializeComponent();
            dl_File.Text = download_file;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            file_download = download_file;
        }
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_Download.Value = e.ProgressPercentage;
            label1.Content = e.ProgressPercentage + " %";
           // progressBar.Value = e.ProgressPercentage;
        }



        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            label1.Content = "0/0";
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }






void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
 {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = download_file.ToString();
            dlg.Filter = "All files (*.*)|*.*";
            double progress;
            if (dlg.ShowDialog() == true)
            {
               
                 try
                {


                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(MainWindow.address + MainWindow.directory + MainWindow.fileToDownload);
                    request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    request.Proxy = null;

                    long fileSize; // this is the key for ReportProgress
                    using (WebResponse resp = request.GetResponse())
                        fileSize = resp.ContentLength;

                    request = (FtpWebRequest)WebRequest.Create(MainWindow.address + MainWindow.directory + MainWindow.fileToDownload);
                    request.Credentials = new NetworkCredential(MainWindow.c_username, MainWindow.c_password);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = responseFileDownload.GetResponseStream();
                    
                    
                   FileStream writeStream = (System.IO.FileStream)dlg.OpenFile();
                  

                        int Length = 1024;
                        Byte[] buffer = new Byte[Length];
                        int bytesRead = 0;
                        int bytes = 0;


                        do
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);

                            //  totalReadBytesCount += bytesRead;
                            bytes += bytesRead;
                            progress = bytes * 100.0 / fileSize;

                            // don't forget to increment bytesRead !
                            //   int totalSize = (int)(fileSize) / 1000; // Kbytes
                            backgroundWorker.ReportProgress((int)progress);
                        } while (bytesRead != 0);


                        writeStream.Close();
                        responseStream.Close();
                            
                        }
                    
                   
                   catch
                {
                    MessageBox.Show("Download fail");
                }
                finally
                {

                    MessageBox.Show("Download Completed");
                }



            }
                

}









            
       




        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
	{
	    MessageBox.Show("Download Completed");
	 
//	    btnStartDownload.Text = "Start Download";
	//    btnStartDownload.Enabled = true;
	}

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
     
       


    }
    }
    