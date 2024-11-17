using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PasswordManager.Models
{
    internal class ProfileModel
    {

        public enum TypeOfEncryption
        {
            gg, bb
        }

        private string _website;
        private string _login;
        private string _password;
        private TypeOfEncryption _typeEncryption;

        public string website
        {
            get { return _website; }
            set { _website = value; }
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

        public Canvas CreateProfile()
        {
            Canvas canvas = new Canvas();
            canvas.Width = 750;
            canvas.Height = 75;
            canvas.Background = Brushes.AliceBlue;
            Grid grid = new Grid();

            Rectangle rectangle = new Rectangle();
            rectangle.Height = 50;
            rectangle.Width = 50;

            ColumnDefinition tempColumm = new ColumnDefinition();
            tempColumm.Width =  new GridLength(75);
            grid.ColumnDefinitions.Add(tempColumm);

            canvas.Children.Add(grid);
            canvas.Children.Add(rectangle);

            

            return canvas;
        }
        

    }
}
