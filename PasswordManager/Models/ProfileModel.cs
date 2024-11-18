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

        public enum TypeOfEncryption
        {
            gg, bb
        }

        private string _websiteName;
        private string _websiteURL;
        private string _login;
        private string _password;
        private TypeOfEncryption _typeEncryption;

        public string websiteName
        {
            get { return _websiteName; }
            set { _websiteName = value; }
        }

        public string websiteURL
        {
            get { return _websiteURL; }
            set { _websiteURL = value; }
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


        public TypeOfEncryption typeEncryption
        {
            get { return _typeEncryption; }
            set { _typeEncryption = value; }
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

            tempColumm1.Width = new GridLength(75); 
            tempColumm2.Width = new GridLength(225); 
            tempColumm3.Width = new GridLength(225); 
            tempColumm4.Width = new GridLength(225); 

            grid.ColumnDefinitions.Add(tempColumm1);
            grid.ColumnDefinitions.Add(tempColumm2);
            grid.ColumnDefinitions.Add(tempColumm3);
            grid.ColumnDefinitions.Add(tempColumm4);
            

            //Icon ----
            Wpf.Ui.Controls.ImageIcon imageIcon = new Wpf.Ui.Controls.ImageIcon();
            imageIcon.Height = 50;
            imageIcon.Width = 50;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("\"C:\\Users\\serge\\Desktop\\snake_got.jpg\"", UriKind.Relative);
            bi3.EndInit();

            imageIcon.Source = bi3 ;

            Grid.SetColumn(imageIcon, 0);
            grid.Children.Add(imageIcon);


            mainBorder.Child = grid;
            mainBorder.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#212226");


            //website name ----
            System.Windows.Controls.TextBlock websiteName = new System.Windows.Controls.TextBlock();

            websiteName.Foreground = Brushes.White;
            websiteName.FontSize = 16;
            Grid.SetColumn(websiteName, 1);
            websiteName.HorizontalAlignment = HorizontalAlignment.Left;
            websiteName.VerticalAlignment = VerticalAlignment.Center;
            websiteName.Margin = new Thickness(0, 0, 0, 25);

            websiteName.Text = _websiteName;

            

            //website url ----
            System.Windows.Controls.TextBlock websiteURL = new System.Windows.Controls.TextBlock();

            websiteURL.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#555b6a"); ;
            websiteURL.FontSize = 14;
            Grid.SetColumn(websiteURL, 1);
            websiteURL.HorizontalAlignment = HorizontalAlignment.Left;
            websiteURL.VerticalAlignment = VerticalAlignment.Center;
            websiteURL.Margin = new Thickness(0, 0, 0, -20);

            websiteURL.Text = _websiteURL;
            
            
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
            StackPanel loginPassword = new StackPanel();
            loginPanel.Height = 75;
            loginPanel.Width = 225;
            loginPanel.Orientation = Orientation.Horizontal;
            Grid.SetColumn(loginPanel, 2);

            //border1
            Border loginBorder11 = new Border();
            loginBorder1.Width = 10;

            loginPanel.Children.Add(loginBorder1);

            //textblock
            System.Windows.Controls.TextBlock passwordTextBlock = new System.Windows.Controls.TextBlock();
            loginTextBlock.Text = _login;
            loginTextBlock.Foreground = Brushes.White;
            loginTextBlock.VerticalAlignment = VerticalAlignment.Center;

            loginPanel.Children.Add(loginTextBlock);

            //border2
            Border loginBorder21 = new Border();
            loginBorder2.Width = 10;

            loginPanel.Children.Add(loginBorder2);



            //ui button
            Wpf.Ui.Controls.Button passwordButton = new Wpf.Ui.Controls.Button();
            loginButton.Height = 25;
            loginButton.Foreground = Brushes.White;
            loginButton.VerticalAlignment = VerticalAlignment.Center;
            loginButton.Width = 25;


            // добавить символ копирования -----------------------------------------------------------------------------------------------

            loginPanel.Children.Add(passwordButton);



            // grid chikldren add
            grid.Children.Add(websiteName);
            grid.Children.Add(websiteURL);
            grid.Children.Add(loginPanel);
            grid.Children.Add(loginPassword);
            return mainBorder;
        }
        

    }
}
