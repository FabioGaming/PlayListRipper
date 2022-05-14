using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ListRipper
{
    class Crypt
    {
        public enum EncryptType
        {
            Base64,
            MD5,
            SHA256
        }
        private static string md5key { get; set; } = "FoxFamilyEncryptKeySecret:99789978-5537";

        public static string Encrypt(string text, EncryptType type = EncryptType.Base64)
        {
            string retun = text;
            if (type == EncryptType.MD5)
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(md5key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateEncryptor())
                        {
                            byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                            byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                            retun = Convert.ToBase64String(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
            if (type == EncryptType.Base64)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
                retun = System.Convert.ToBase64String(plainTextBytes);
            }
            if (type == EncryptType.SHA256)
            {
                SHA256CryptoServiceProvider x1 = new SHA256CryptoServiceProvider();

                byte[] bs1 = System.Text.Encoding.UTF8.GetBytes(text);
                bs1 = x1.ComputeHash(bs1);
                System.Text.StringBuilder s1 = new System.Text.StringBuilder();

                foreach (byte b in bs1)
                {
                    s1.Append(b.ToString("x2").ToLower());
                }
                retun = s1.ToString();
            }

            return retun;
        }

        public static string Decrypt(string cipher, EncryptType type = EncryptType.Base64)
        {
            if (type == EncryptType.MD5)
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(md5key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateDecryptor())
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipher);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            return UTF8Encoding.UTF8.GetString(bytes);
                        }
                    }
                }
            }
            if (type == EncryptType.Base64)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(cipher);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            return "";
        }

        public static string MultiEncrypt(string text, List<EncryptType> types)
        {
            string res = "";
            foreach(EncryptType type in types)
            {
                if (res == "")
                {
                    res = Encrypt(text, type);
                }
                else
                {
                    res = Encrypt(res, type);
                }
            }
            return res;
        }
        public static string MultiDecrypt(string text, List<EncryptType> types)
        {
            string res = "";
            foreach (EncryptType type in types)
            {
                if (res == "")
                {
                    res = Decrypt(text, type);
                }
                else
                {
                    res = Decrypt(res, type);
                }
            }
            return res;
        }
    }
}
