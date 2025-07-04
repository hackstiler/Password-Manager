using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Profile
    {

        Encoder encoder = new Encoder();
        
        public int id { get; set; }
        private string _login, _password, _profileName, _websiteAdress;
        
        private Encoder.EncryptionType _encryption;

        public string login
        {
            set { _login = value; }
            get { return _login; }
        }

        public string password
        {
            set { _password = value; }
            get { return _password; }
        }

        public string profileName
        {
            set { _profileName = value; }
            get { return _profileName; }
        }

        public string websiteAdress
        {
            set { _websiteAdress = value; }
            get { return _websiteAdress; }
        }

        public string encryption
        {
            set { _encryption = Encoder.EncryptionType.encryptionVigenere; }
            get { return _encryption.ToString(); }
        }

        public Profile() { }
        
        public Profile(string login, string password, string profileName, string websiteAdress, string encryption)
        {
            this.login = login;
            this.profileName = profileName;
            this.websiteAdress = websiteAdress;
            this.password = encoder.Encoding(password);

        }


    }
}
