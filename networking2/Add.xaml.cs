using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace networking2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();	
        }

        ~Add()
        {
            Console.WriteLine("deconstructing add");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void addBT_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter add_conn = File.AppendText("saved_connections.txt"))
            {
                if (this.connNameTB.Text != "" && this.serverTB.Text != "" && this.usernameTB.Text != "" && this.passwordTB.Text != "")
                {
                    add_conn.WriteLine(this.connNameTB.Text+"#"+this.serverTB.Text+"#"+this.usernameTB.Text+"#"+this.passwordTB.Text);
                    add_conn.Close();
                    this.Close();
                }
                else{
                    MessageBox.Show("Make sure all fields are filled out!");
                }
            }
        }

        private void cancelBT_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Cancel Clicked");
            this.Close();
        }
    }
}
