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
        }
       
        public string Sha512(string strLogin)
        {
            if (string.IsNullOrEmpty(strLogin))
            {
                throw new ArgumentNullException(@"There is nothing for encryption");
            }
            else
            {
                SHA512Managed sifre = new SHA512Managed();
                byte[] arySifre = ConvertItToByte(strLogin);
                byte[] aryHash = sifre.ComputeHash(arySifre);
                return BitConverter.ToString(aryHash);
            }
        }
    }
}
