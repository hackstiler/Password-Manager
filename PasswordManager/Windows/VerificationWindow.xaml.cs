using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        public VerificationWindow()
        {
            InitializeComponent();
        }

        private void Next_Btn_Click(object sender, RoutedEventArgs e)
        {

            Encoder encoder = new Encoder();

            if(BCrypt.Net.BCrypt.EnhancedVerify(Password_textbox.Text, Properties.Settings.Default.MainPassword))
            {
                Encoder.keyWord = encoder.p_VigenereEncryptionTextToText(Properties.Settings.Default.KeyWord,Password_textbox.Text);
                this.Close();
            }
            else
            {
                Password_textbox.Text = "";
            }
            
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
                Console.WriteLine("drag");
            }
        }

        private void update_LayoutUpdated(object sender, EventArgs e)
        {
            if (Password_textbox.Text != "")
            {
                Next_Btn.IsEnabled = true;
            }
            else Next_Btn.IsEnabled = false;
        }
    }
}
