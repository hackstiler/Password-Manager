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
using Wpf.Ui.Controls;

namespace PasswordManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для FirstLaunchWindow.xaml
    /// </summary>
    public partial class FirstLaunchWindow : Window
    {
        public FirstLaunchWindow()
        {
            InitializeComponent();
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
                Console.WriteLine("drag");
            }
        }

        private void Next_Btn_Click(object sender, RoutedEventArgs e)
        {
            Encoder.keyWord = KeyWord_textbox.Text;
            Encoder encoder = new Encoder();
            Properties.Settings.Default.FirstLaunch = false;
            Properties.Settings.Default.MainPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(Password_textbox.Text,13);
            Properties.Settings.Default.KeyWord = encoder.p_TextToVigenereEncryption(KeyWord_textbox.Text,Password_textbox.Text);
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void update_LayoutUpdated(object sender, EventArgs e)
        {
            if (Password_textbox.Text != "" && KeyWord_textbox.Text != "")
            {
                Next_Btn.IsEnabled = true;
            }
            else Next_Btn.IsEnabled = false;
        }
    }
}
