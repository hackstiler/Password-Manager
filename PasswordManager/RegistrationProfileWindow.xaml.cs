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

namespace PasswordManager
{
    /// <summary>
    /// Логика взаимодействия для RegistrationProfileWindow.xaml
    /// </summary>
    public partial class RegistrationProfileWindow : Window
    {

        ApplicationContext db;

        public RegistrationProfileWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            encryption_combobox.ItemsSource = Enum.GetValues(typeof(Profile.EncryptionType));
            encryption_combobox.SelectedValue = Profile.EncryptionType.gg;


        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
                Console.WriteLine("drag");
            }
        }

        private void CreateProfile_Btn_Click(object sender, RoutedEventArgs e)
        {
            //сохранение данных в БД

            string login = Login_textbox.Text;
            string password = Password_textbox.Text;
            string profileName = ProfileName_textbox.Text;
            string websiteAdress = websiteAdress_textbox.Text;

            //шифрование пароля(можно и остальных данных, изменяется в настройках)


            Profile profile = new Profile(login,password,profileName,websiteAdress,encryption_combobox.SelectedValue.ToString()) ;

            db.Profiles.Add(profile);
            db.SaveChanges();


            MainWindow.window.collectingВatafromDB();
            //закрытие 
            this.Close();


            //
        }

        private void update_LayoutUpdated(object sender, EventArgs e)
        {
            if (Login_textbox.Text != "" && Password_textbox.Text != "" && ProfileName_textbox.Text != "")
            {
                CreateProfile_Btn.IsEnabled = true;
            }
            else CreateProfile_Btn.IsEnabled = false;
        }
    }
}
