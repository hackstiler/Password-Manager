using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using static System.Net.WebRequestMethods;

namespace PasswordManager.Models
{
    internal class ProfileModel
    {
        private string _profileName;
        private string _websiteAdress;
        private string _login;
        private string _password;
        private Encoder.EncryptionType _encryptionType = Encoder.EncryptionType.None;
        private Encoder _encoder = new Encoder();

        public Encoder.EncryptionType EncryptionType
        {
            get {return _encryptionType; }
            set { _encryptionType = value; }
        }

        public string profileName
        {
            get { return _profileName; }
            set { _profileName = value; }
        }

        public string websiteAdress
        {
            get { return _websiteAdress; }
            set { _websiteAdress = value; }
        }
        public string login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }




        public Border CreateProfile()
        {
            Border mainBorder = new Border();
            mainBorder.Height = 75;

            //grid creations
            Grid grid = new Grid();

            ColumnDefinition tempColumm1 = new ColumnDefinition();
            ColumnDefinition tempColumm2 = new ColumnDefinition();
            ColumnDefinition tempColumm3 = new ColumnDefinition();
            ColumnDefinition tempColumm4 = new ColumnDefinition();
            ColumnDefinition tempColumm5 = new ColumnDefinition();

            tempColumm1.Width = new GridLength(75);
            tempColumm2.Width = new GridLength(210);
            tempColumm3.Width = new GridLength(210);
            tempColumm4.Width = new GridLength(210);
            tempColumm5.Width = new GridLength(45);

            grid.ColumnDefinitions.Add(tempColumm1);
            grid.ColumnDefinitions.Add(tempColumm2);
            grid.ColumnDefinitions.Add(tempColumm3);
            grid.ColumnDefinitions.Add(tempColumm4);
            grid.ColumnDefinitions.Add(tempColumm5);


            //Icon ----
            Wpf.Ui.Controls.ImageIcon imageIcon = new Wpf.Ui.Controls.ImageIcon();
            imageIcon.Height = 50;
            imageIcon.Width = 50;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("\"C:\\Users\\serge\\Desktop\\snake_got.jpg\"", UriKind.Relative);
            bi3.EndInit();

            imageIcon.Source = bi3;

            Grid.SetColumn(imageIcon, 0);


            mainBorder.Child = grid;
            mainBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#212226");


            //website name ----
            System.Windows.Controls.TextBlock profileName = new System.Windows.Controls.TextBlock();

            profileName.Foreground = Brushes.White;
            profileName.FontSize = 16;
            Grid.SetColumn(profileName, 1);
            profileName.HorizontalAlignment = HorizontalAlignment.Left;
            profileName.VerticalAlignment = VerticalAlignment.Center;
            profileName.Margin = new Thickness(0, 0, 0, 25);

            profileName.Text = _profileName;



            //website url ----
            System.Windows.Controls.TextBlock websiteAdress = new System.Windows.Controls.TextBlock();

            websiteAdress.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#555b6a"); ;
            websiteAdress.FontSize = 14;
            Grid.SetColumn(websiteAdress, 1);
            websiteAdress.HorizontalAlignment = HorizontalAlignment.Left;
            websiteAdress.VerticalAlignment = VerticalAlignment.Center;
            websiteAdress.Margin = new Thickness(0, 0, 0, -20);

            websiteAdress.Text = _websiteAdress;


            //Login ----

            //stackpanel
            StackPanel loginPanel = new StackPanel();
            loginPanel.Height = 75;
            loginPanel.Width = 225;
            loginPanel.Orientation = Orientation.Horizontal;
            Grid.SetColumn(loginPanel, 2);

            //border1
            Border loginBorder1 = new Border();
            loginBorder1.Width = 10;

            loginPanel.Children.Add(loginBorder1);

            //textblock
            System.Windows.Controls.TextBlock loginTextBlock = new System.Windows.Controls.TextBlock();
            loginTextBlock.Text = _login;
            loginTextBlock.Foreground = Brushes.White;
            loginTextBlock.VerticalAlignment = VerticalAlignment.Center;

            loginPanel.Children.Add(loginTextBlock);

            //border2
            Border loginBorder2 = new Border();
            loginBorder2.Width = 10;

            loginPanel.Children.Add(loginBorder2);



            //ui button
            Wpf.Ui.Controls.Button loginButton = new Wpf.Ui.Controls.Button();
            loginButton.Height = 25;
            loginButton.Foreground = Brushes.White;
            loginButton.VerticalAlignment = VerticalAlignment.Center;
            loginButton.Width = 25;


            // добавить символ копирования -----------------------------------------------------------------------------------------------

            loginPanel.Children.Add(loginButton);

            //Password ----
            //stackpanel
            StackPanel passwordPanel = new StackPanel();
            passwordPanel.Height = 75;
            passwordPanel.Width = 225;
            passwordPanel.Orientation = Orientation.Horizontal;
            Grid.SetColumn(passwordPanel, 3);

            //border1
            Border passwordBorder1 = new Border();
            passwordBorder1.Width = 10;

            passwordPanel.Children.Add(passwordBorder1);

            //passwordBox
            Wpf.Ui.Controls.PasswordBox passwordBox = new Wpf.Ui.Controls.PasswordBox();
            passwordBox.Text =  _encoder.Decoding(_password,_encryptionType);
            passwordBox.IsReadOnly = true;
            passwordBox.ClearButtonEnabled = false;

            passwordPanel.Children.Add(passwordBox);

            //border2
            Border passwordBorder2 = new Border();
            passwordBorder2.Width = 10;

            passwordPanel.Children.Add(passwordBorder2);

            //ui button
            Wpf.Ui.Controls.Button passwordButton = new Wpf.Ui.Controls.Button();
            passwordButton.Height = 25;
            passwordButton.Foreground = Brushes.White;
            passwordButton.VerticalAlignment = VerticalAlignment.Center;
            passwordButton.Width = 25;

            passwordPanel.Children.Add(passwordButton);

            // добавить символ копирования -----------------------------------------------------------------------------------------------


            grid.Children.Add(imageIcon);
            grid.Children.Add(profileName);
            grid.Children.Add(websiteAdress);
            grid.Children.Add(loginPanel);
            grid.Children.Add(passwordPanel);

            return mainBorder;
        }
    }
}
