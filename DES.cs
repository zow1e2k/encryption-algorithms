using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace SymmetricAlgths {
    public class DES : Algorithm, ISymmetricAlgorithm {
        public SymmetricAlgorithm symmAlgth;

        private byte[]
            key,
            initVector;
        
        private CipherMode cipherMode;
        private PaddingMode paddingMode;

        public DES(CipherMode cipherMode, PaddingMode paddingMode) {
            
            this.symmAlgth = System
                        .Security
                        .Cryptography
                        .DES
                        .Create();

            symmAlgth.GenerateKey();
            this.key = symmAlgth.Key;
            
            symmAlgth.GenerateIV();
            this.initVector = symmAlgth.IV;
            
            this.symmAlgth.Mode = cipherMode;
            this.cipherMode = this.symmAlgth.Mode;
            
            this.symmAlgth.Padding = paddingMode;
            this.paddingMode = this.symmAlgth.Padding;

            //Console.WriteLine(" Symmetric algorithm DES has been created");

            return;
        }

        public byte[] getKey() {
            return this.key;
        }

        public byte[] getInitVector() {
            return this.initVector;
        }

        public PaddingMode getPaddingMode() {
            return this.paddingMode;
        }
        
        public CipherMode getCipherMode() {
            return this.cipherMode;
        }

        public int runSymmAlg(String str) {
            //Console.Write("che eto? " + typeof(DES) + " a eto? " + obj.GetType().FullName + "\n");
            // obj.GetType().Assembly.GetName().Name = SymmetricAlgths
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            /*Console.WriteLine(
                " Start text string: "
                + str
                +
                " ("
                + Encoding.UTF8.GetBytes(str).Length
                + " bytes)"
                + "\n"
            );*/

            byte[] encryptedText = this.encrypt(this.symmAlgth, str);
            /*Console.WriteLine(
                " Encrypted text: "
                +
                Encoding.UTF8.GetString(encryptedText)
                +
                " ("
                + encryptedText.Length
                + " bytes)"
                + "\n"
            );*/
            FileStream fs;
            
            try {
                fs = new FileStream("out/encryptedText_DES.txt", FileMode.OpenOrCreate);
                fs.Write(encryptedText);
                fs.Close();
            } catch (FileLoadException e) {
                Console.WriteLine(e.Message);
            }

            byte[] decryptedText = this.decrypt(this.symmAlgth, encryptedText);
            /*Console.WriteLine(
                " Decrypted text: "
                +
                Encoding.UTF8.GetString(decryptedText)
                + " ("
                + decryptedText.Length
                + " bytes)"
                + "\n"
            );*/
            
            try {
                fs = new FileStream("out/decryptedText_DES.txt", FileMode.OpenOrCreate);
                fs.Write(decryptedText);
                fs.Close();
            } catch (FileLoadException e) {
                Console.WriteLine(e.Message);
            }
            
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            
            //String elapsedTime = String.Format("{0:00}", ts.Milliseconds);
            //Console.WriteLine("RunTime: " + elapsedTime + "ms");
            return ts.Milliseconds;
        }
    }
}