using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
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
        private BitmapImage _profileImage;
        private int _index;


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

        public int index
        {
            get { return _index; }
            set { _index = value; }
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
            imageIcon.Height = 32;
            imageIcon.Width = 32;


            _profileImage = new BitmapImage(new Uri("pack://application:,,,/Assets/ProfileIcon_4.png"));

            
            Task.Run(async () =>
            {
                var Icon = await FaviconHelper.GetFaviconAsync(_websiteAdress);
                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    imageIcon.Source = Icon;
                });
            });

            if(imageIcon.Source == null)
            {
                imageIcon.Source = _profileImage;
            }

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
            loginTextBlock.Width = 150;

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
            loginButton.Click += CopyLogin_Click;
            loginButton.Foreground = Brushes.White;
            loginButton.Padding = new Thickness(0);
            loginButton.FontSize = 16;
            loginButton.FontFamily = new System.Windows.Media.FontFamily("Segoe Fluent Icons");
            loginButton.Content = "\uE8C8";

            SymbolIcon symbolIcon = new SymbolIcon();
            symbolIcon.Symbol = SymbolRegular.Copy16;
            


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
            passwordBox.Width = 150;

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
            passwordButton.Click += CopyPassword_Click;
            passwordButton.Foreground = Brushes.White;
            passwordButton.Padding = new Thickness(0);
            passwordButton.FontSize = 16;
            passwordButton.FontFamily = new System.Windows.Media.FontFamily("Segoe Fluent Icons");
            passwordButton.Content = "\uE8C8";
            //passwordButton.Content = new SymbolIcon { Symbol = SymbolRegular.Copy24, FontSize = 15, Foreground = Brushes.White };

            passwordPanel.Children.Add(passwordButton);

            //ui deletebutton

            Wpf.Ui.Controls.Button deleteButton = new Wpf.Ui.Controls.Button();
            deleteButton.Height = 25;
            deleteButton.Foreground = Brushes.White;
            deleteButton.VerticalAlignment = VerticalAlignment.Center;
            deleteButton.HorizontalAlignment = HorizontalAlignment.Right;
            deleteButton.Margin = new Thickness(10);
            deleteButton.Width = 25;
            deleteButton.Click += RemoveProfile_Click;
            deleteButton.Foreground = Brushes.White;
            deleteButton.Padding = new Thickness(0);
            deleteButton.FontSize = 16;
            deleteButton.FontFamily = new System.Windows.Media.FontFamily("Segoe Fluent Icons");
            deleteButton.Content = "\ue74d";
            deleteButton.Name = "DeleteButton" + _index;
            Grid.SetColumn(deleteButton, 4);


            grid.Children.Add(imageIcon);
            grid.Children.Add(profileName);
            grid.Children.Add(websiteAdress);
            grid.Children.Add(loginPanel);
            grid.Children.Add(passwordPanel);
            grid.Children.Add(deleteButton);

            return mainBorder;
        }

        private void CopyPassword_Click(object sender, RoutedEventArgs e)
        {
            var data = new DataObject();
            data.SetData(DataFormats.UnicodeText, _encoder.Decoding(_password, _encryptionType), true);
            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void CopyLogin_Click(object sender, RoutedEventArgs e)
        {
            var data = new DataObject();
            data.SetData(DataFormats.UnicodeText, _login, true);
            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void RemoveProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = MainWindow.window;

            var bt = (Wpf.Ui.Controls.Button)sender;
            string btName = bt.Name;
            btName = btName.Remove(0,"DeleteButton".Length);
            int ind = Convert.ToInt32(btName);
            mainWindow.RemoveProfile(Convert.ToInt32(bt.Name.Remove(0, "DeleteButton".Length)));


        }
    }





    public static class FaviconHelper
    {
        public static Task<BitmapImage> GetFaviconAsync(string url)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (!url.Contains("https://"))
                    {
                        url = "https://" + url;
                    }

                    var uri = new Uri(url);
                    string faviconUrl = $"{uri.Scheme}://{uri.Host}/favicon.ico";

                    using (var client = new HttpClient())
                    using (var response = await client.GetAsync(faviconUrl))
                    {
                        if (!response.IsSuccessStatusCode)
                            return new BitmapImage(new Uri("pack://application:,,,/Assets/ProfileIcon_2.png")); ;
                            

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            return LoadBitmapImage(stream);
                        }
                    }
                }
                catch
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/Assets/ProfileIcon_2.png")); ;
                }
            });
        }

        private static BitmapImage LoadBitmapImage(Stream stream)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }

    }
}
