using PasswordManager.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace PasswordManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public MainWindow window;



        RegistrationProfileWindow registrationProfileWindow;
        int num = 0;

        public MainWindow()
        {
            InitializeComponent();
            window = this;
        }

        private void Btn_CreateProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileModel profile = new ProfileModel();
            profile.websiteName = "gg" + num; num++;
            profile.websiteURL = "gg.com";
            profile.login = "dasdasdasdasda";
            profile.password = "12345678";
            StackPanel_Profile.Children.Add(profile.CreateProfile());

            Border separatorBorder = new Border();
            separatorBorder.Height = 2;
            StackPanel_Profile.Children.Add(separatorBorder);


            registrationProfileWindow = new RegistrationProfileWindow();
            registrationProfileWindow.Owner = this;

            registrationProfileWindow.Show();


            Console.WriteLine("click");

        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
                Console.WriteLine("drag");  
            }
        }


    }
}
