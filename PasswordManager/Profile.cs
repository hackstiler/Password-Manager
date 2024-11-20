using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Profile
    {

        public enum EncryptionType { gg,ss,tt} 
        public int id { get; set; }
        private string _login, _password, _profileName, _websiteAdress;
        
        private string _encryption;

        public string login
        {
            set { _login = value; }
            get { return _login; }
        }

        public string password
        {
            set { _password= value; }
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
            set { _encryption = value; }
            get { return _encryption.ToString(); }
        }

        public Profile() { }
        
        public Profile(string login, string password, string profileName, string websiteAdress, string encryption)
        {
            this.login = login;
            this.password = password;
            this.profileName = profileName;
            this.websiteAdress = websiteAdress;
            this.encryption = encryption;

        }


    }
}
