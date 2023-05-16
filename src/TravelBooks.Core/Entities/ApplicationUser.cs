using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Interfaces;

namespace Core.Entities
{
    /// <summary>
    /// Model Application User
    /// </summary>
    public class ApplicationUser : BaseEntity, IAggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
       
        /// <summary>
        /// Encrypt Decrypt Password
        /// </summary>
        [NotMapped]
        public string DecryptedPassword
        {
            get { return Decrypt_Password(Password); }
            set { Password = Encrypt_Password(value); }
        }
        private string Decrypt_Password(string encryptpassword)
        {
            string pswstr = string.Empty;
            System.Text.UTF8Encoding encode_psw = new System.Text.UTF8Encoding();
            System.Text.Decoder Decode = encode_psw.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pswstr = new String(decoded_char);
            return pswstr;
        }

        private string Encrypt_Password(string password)
        {
            string pswstr = string.Empty;
            byte[] psw_encode = new byte[password.Length];
            psw_encode = System.Text.Encoding.UTF8.GetBytes(password);
            pswstr = Convert.ToBase64String(psw_encode);
            return pswstr;
        }
    }
}