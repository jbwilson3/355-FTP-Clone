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

namespace networking2
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    
    public partial class InputBox : Window
    {

        internal static string add_directory; 
        public InputBox()
        {
            InitializeComponent();
            directoryname.Text = "";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (directoryname.Text == null)
                MessageBox.Show("no value entered");
            else
            {
                add_directory = directoryname.Text;
                this.Hide();
            }
        }

        private void input_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
