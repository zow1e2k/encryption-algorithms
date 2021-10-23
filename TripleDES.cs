using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SymmetricAlgths {
    public class TripleDES : Algorithm, ISymmetricAlgorithm  {
        public SymmetricAlgorithm symmAlgth;

        private byte[]
            key,
            initVector;
        
        private CipherMode cipherMode;
        private PaddingMode paddingMode;
        
        public TripleDES(CipherMode cipherMode, PaddingMode paddingMode) {
            this.symmAlgth = System
                        .Security
                        .Cryptography
                        .TripleDES
                        .Create();
            
            symmAlgth.GenerateKey();
            this.key = symmAlgth.Key;
            
            symmAlgth.GenerateIV();
            this.initVector = symmAlgth.IV;
            
            this.symmAlgth.Mode = cipherMode;
            this.cipherMode = this.symmAlgth.Mode;
            
            this.symmAlgth.Padding = paddingMode;
            this.paddingMode = this.symmAlgth.Padding;

            //Console.WriteLine(" Symmetric algorithm TripleDES has been created");
            
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
            FileStream fs;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            byte[] encryptedText = this.encrypt(this.symmAlgth, str);

            try {
                fs = new FileStream("out/encryptedText_3DES.txt", FileMode.OpenOrCreate);
                fs.Write(encryptedText);
                fs.Close();
            } catch (FileLoadException e) {
                Console.WriteLine(e.Message);
            }

            byte[] decryptedText = this.decrypt(this.symmAlgth, encryptedText);

            try {
                fs = new FileStream("out/decryptedText_3DES.txt", FileMode.OpenOrCreate);
                fs.Write(decryptedText);
                fs.Close();
            } catch (FileLoadException e) {
                Console.WriteLine(e.Message);
            }
            
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts.Milliseconds;
        }
    }
}