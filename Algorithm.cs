using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SymmetricAlgths {
    public class Algorithm {
        protected byte[] encrypt(SymmetricAlgorithm alg, String str) {
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(
                memStream,
                alg.CreateEncryptor(),
                CryptoStreamMode.Write
            );
            
            byte[] byteText = Encoding.UTF8.GetBytes(str);
            cryptStream.Write(byteText, 0, byteText.Length);
            cryptStream.Close();

            byte[] cipherBytes = memStream.ToArray();
            memStream.Close();
            
            return cipherBytes;
        }
        
        protected byte[] decrypt(SymmetricAlgorithm alg, byte[] encryptedStr) {

            MemoryStream memStream = new MemoryStream(encryptedStr);
            CryptoStream cryptStream = new CryptoStream(
                memStream,
                alg.CreateDecryptor(),
                CryptoStreamMode.Read);
        
            byte[] byteText = new byte[encryptedStr.Length];
            cryptStream.Read(byteText, 0, encryptedStr.Length);

            cryptStream.Close();
            memStream.Close();

            return byteText;
        }
    }
}