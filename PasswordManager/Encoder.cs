using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    /**
     *Методы хранения кодового слова для Шифра вижнера
    1. Использование мастер-пароля

    Как работает:
    Кодовое слово шифруется с использованием мастер-пароля, который пользователь вводит при входе в приложение.
        Мастер-пароль используется для генерации ключа через алгоритм PBKDF2 или Argon2.
        Полученный ключ шифрует и расшифровывает кодовое слово с использованием AES.
    Плюсы: Кодовое слово хранится зашифрованным. Без мастер-пароля его нельзя использовать.
    Минусы: Требуется ввод мастер-пароля при каждом запуске.

    2. Хранение в защищенном системном хранилище

    Для Windows: Data Protection API (DPAPI).
        Кодовое слово шифруется средствами операционной системы, а ключ доступа хранится в профиле пользователя.
        Библиотека: System.Security.Cryptography.ProtectedData.

    Для macOS и Linux: Keychain (macOS) или Secret Service API (Linux).
        Эти системы предоставляют безопасное место для хранения секретов.

    Плюсы:
        Пользователь не вводит пароль.
        Защита встроена в ОС, что усложняет компрометацию.

    Минусы: Работает только на том же устройстве и для того же пользователя. 
     * 
     **/



    internal class Encoder
    {
        private const string Alphabetical = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Alphanumerical = "0123456789";
        private const string Symbols = @"#¤%&/\()=?@£$€{[]}:;^´`½§_,.!*+-";


        public enum EncryptionType
        {
            encryptionVigenere,
            encryptionCaesar,
            RCA,
            None
        };


        static public EncryptionType StringToEncryptionType(string str)
        {
            switch (str)
            {
                case "encryptionCaesar":
                    return EncryptionType.encryptionCaesar;
                    break;
                case "encryptionVigenere":
                    return EncryptionType.encryptionVigenere;
                    break;
                case "RCA":
                    break;
            }
            return EncryptionType.None;

        }

        //шифрование
        public string Encoding(string password, EncryptionType encryptionType)
        {
            string finalPassword = "";

            switch (encryptionType)
            {
                //Шифр Виженера
                case EncryptionType.encryptionVigenere:
                    finalPassword = TextToVigenereEncryption(password,"1eM0n!e");
                    break;
                //Шифр Цезаря
                case EncryptionType.encryptionCaesar:
                    finalPassword = TextToCaesarEncryption(password,2);
                    break;
            }



            return finalPassword;
        }

        //рассшифровка
        public string Decoding(string password, EncryptionType encryptionType)
        {
            string finalPassword = "";

            switch (encryptionType)
            {
                //Шифр Виженера
                case EncryptionType.encryptionVigenere:
                    finalPassword = VigenereEncryptionTextToText(password, "1eM0n!e");
                    break;
                //Шифр Цезаря
                case EncryptionType.encryptionCaesar:
                    finalPassword = CaesarEncryptionToText(password,2);
                    break;
            }



            return finalPassword;
        }

        //текст в шифрования виженера
        private string TextToVigenereEncryption(string originalPassword, string originalKeyWord)
        {
            //начальные переменные
            char[] originalPasswordChars = originalPassword.ToCharArray();
            char[] KeyWordChars = new char[originalPasswordChars.Length];
            string EncryptionPassword = "";
            char[] allChars = (Alphabetical + Alphanumerical + Symbols).ToCharArray();
            string allCharsStr = Alphabetical + Alphanumerical + Symbols;

            //подготовка ключ-слова
            int tempValue = 0;
            for (int i = 0; i < KeyWordChars.Length; i++)
            {
                if (tempValue >= originalKeyWord.Length)
                {
                    tempValue = 0;
                }
                KeyWordChars[i] = originalKeyWord[tempValue];
                tempValue++;

            }

            //реализация шифрования Виженера
            for (int i = 0; i < originalPassword.Length; i++)
            {
                char passwordChar = originalPasswordChars[i];
                char keywordChar = KeyWordChars[i];

                int indexPasswordChar = allCharsStr.IndexOf(passwordChar);
                int indexKeyWordChar = allCharsStr.IndexOf(keywordChar);

                int indexEncryptionChar;
                if (indexPasswordChar + indexKeyWordChar > allChars.Length - 1)
                {
                    indexEncryptionChar = indexPasswordChar + indexKeyWordChar - allChars.Length;
                }
                else indexEncryptionChar = indexPasswordChar + indexKeyWordChar;

                Console.WriteLine($"I - {i}, index - {indexEncryptionChar}, lenght - {allChars.Length-1}");

                EncryptionPassword += allChars[indexEncryptionChar];
            }


            return EncryptionPassword;

        }

        //зашифрованииное слово кодом виженера в расшифрованный текст
        private string VigenereEncryptionTextToText(string encryptionPassword, string originalKeyWord)
        {
            //начальные переменные
            char[] encryptionPasswordChars = encryptionPassword.ToCharArray();
            char[] KeyWordChars = new char[encryptionPasswordChars.Length];
            string originalPassword = "";
            char[] allChars = (Alphabetical + Alphanumerical + Symbols).ToCharArray();
            string allCharsStr = Alphabetical + Alphanumerical + Symbols;

            //подготовка ключ-слова
            int tempValue = 0;
            for (int i = 0; i < KeyWordChars.Length; i++)
            {
                if (tempValue >= originalKeyWord.Length)
                {
                    tempValue = 0;
                }
                KeyWordChars[i] = originalKeyWord[tempValue];
                tempValue++;

            }

            //реализация шифрования Виженера
            for (int i = 0; i < encryptionPassword.Length; i++)
            {
                char passwordChar = encryptionPasswordChars[i];
                char keyWordChar = KeyWordChars[i];

                int indexPasswordChar = allCharsStr.IndexOf(passwordChar);
                int indexKeyWordChar = allCharsStr.IndexOf(keyWordChar);

                int indexEncryptionChar;
                if (indexPasswordChar - indexKeyWordChar < 0)
                {
                    indexEncryptionChar = allChars.Length  + indexPasswordChar - indexKeyWordChar;
                }
                else indexEncryptionChar = indexPasswordChar - indexKeyWordChar;
                originalPassword += allChars[indexEncryptionChar];
            }


            return originalPassword;
        }

        private string TextToCaesarEncryption(string originalPassword, int offsetStep)
        {
            //начальные переменные
            char[] originalPasswordChars = originalPassword.ToCharArray();
            string EncryptionPassword = "";
            char[] allChars = (Alphabetical + Alphanumerical + Symbols).ToCharArray();
            string allCharsStr = Alphabetical + Alphanumerical + Symbols;

            //реализация шифрования 
            for (int i = 0; i < originalPassword.Length; i++)
            {
                char passwordChar = originalPasswordChars[i];

                int indexPasswordChar = allCharsStr.IndexOf(passwordChar);

                int indexEncryptionChar;
                if (indexPasswordChar + offsetStep > allChars.Length - 1)
                {
                    indexEncryptionChar = indexPasswordChar + offsetStep - allChars.Length - 1;
                }
                else indexEncryptionChar = indexPasswordChar + offsetStep;

                EncryptionPassword += allChars[indexEncryptionChar];
            }

            return EncryptionPassword;
        }


        private string CaesarEncryptionToText(string encryptionPassword, int offsetStep)
        {
            //начальные переменные
            char[] encryptionPasswordChars = encryptionPassword.ToCharArray();
            string originalPassword = "";
            char[] allChars = (Alphabetical + Alphanumerical + Symbols).ToCharArray();
            string allCharsStr = Alphabetical + Alphanumerical + Symbols;

            Console.WriteLine(encryptionPassword + "--------------------------------------------------------------------------------------------------------------");

            //реализация шифрования 
            for (int i = 0; i < encryptionPassword.Length; i++)
            {
                char passwordChar = encryptionPasswordChars[i];

                int indexPasswordChar = allCharsStr.IndexOf(passwordChar);

                int indexEncryptionChar;
                if (indexPasswordChar - offsetStep < 0)
                {
                    indexEncryptionChar = allChars.Length  + indexPasswordChar - offsetStep;
                }
                else indexEncryptionChar = indexPasswordChar - offsetStep;
                originalPassword += allChars[indexEncryptionChar];
            }


            return originalPassword;
        }
    }
}
