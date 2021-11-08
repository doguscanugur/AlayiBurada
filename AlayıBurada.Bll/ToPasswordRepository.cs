namespace AlayıBurada.Bll
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class ToPasswordRepository
    {
        public static byte[] ConvertItToByte(string value)
        {

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetBytes(value);
            //burada  değişiklik yapıldı
        }

        public static byte[] Byte8(string value)
        {
            char[] arrayChar = value.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
            //deneme dcu2
        }
       
        public string Sha512(string strLogin)
        {
            if (string.IsNullOrEmpty(strLogin))
            {
                throw new ArgumentNullException(@"There is nothing for encryption");
            }
            else
            {
                SHA512Managed password = new SHA512Managed();
                byte[] aryPassword = ConvertItToByte(strLogin);
                byte[] aryHash = password.ComputeHash(aryPassword);
                return BitConverter.ToString(aryHash);
            }
        }
        public string Md5(string strLogin) {
            if (string.IsNullOrEmpty(strLogin)) {
                throw new ArgumentNullException(@"There is nothing for encryption");
            }
            else {
                MD5CryptoServiceProvider password = new MD5CryptoServiceProvider();
                byte[] passwordbytes = password.ComputeHash(Encoding.UTF8.GetBytes(strLogin));
                var sb = new StringBuilder();
                foreach (byte b in passwordbytes) {
                    sb.Append(b.ToString("x2").ToLower());

                }
                return sb.ToString();
            }
        }
    }
}
