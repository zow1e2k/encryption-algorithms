using System;
using System.IO;
using System.Security.Cryptography;

namespace SymmetricAlgths {
    public class Program {
        private const String WELCOME_TEXT = "\t0. Method: DES, Cipher: ECB, Padding: PKCS7\n" +
                                           "\t1. Method: DES, Cipher: CBC, Padding: PKCS7\n" +
                                           "\t2. Method: DES, Cipher: CBC, Padding: Zeros\n" +
                                           "\t3. Method: DES, Cipher: ECB, Padding: Zeros\n" +
                                           "\t4. Method: 3DES, Cipher: ECB, Padding: PKCS7\n" +
                                           "\t5. Method: 3DES, Cipher: CBC, Padding: PKCS7\n" +
                                           "\t6. Method: 3DES, Cipher: CBC, Padding: Zeros\n" +
                                           "\t7. Method: Rijndael, Cipher: ECB, Padding: Zeros\n" +
                                           "\t8. Method: Rijndael, Cipher: ECB, Padding: PKCS7\n" +
                                           "\t9. Method: Rijndael, Cipher: ECB, Padding: Zeros\n" +
                                           "\t10. Method: Rijndael, Cipher: CBC, Padding: PKCS7\n" +
                                           "\t11. Method: Rijndael, Cipher: CBC, Padding: Zeros\n" +
                                           "\t12. Method: RC2, Cipher: ECB, Padding: PKCS7\n" +
                                           "\t13. Method: RC2, Cipher: ECB, Padding: Zeros\n" +
                                           "\t14. Method: RC2, Cipher: CBC, Padding: PKCS7\n" +
                                           "\t15. Method: RC2, Cipher: CBC, Padding: Zeros\n" +
                                           "\t16. Method: RC2, Cipher: CFB, Padding: PKCS7\n" +
                                           "\t17. Method: RC2, Cipher: ECB, Padding: Zeros\n" +
                                           "\t18. Method: RC2, Cipher: CFB, Padding: Zeros";

        private const String FILE_INPUT_TEXT_PATH = "input.txt";
        
        private const uint
            MAX_DES_MODES = 6,
            MAX_TRIPLE_DES_MODES = 6,
            MAX_RIJNDAEL_MODES = 6,
            MAX_RC2_MODES = 9;
        
        private static DES[] desMode = new DES[MAX_DES_MODES];
        private static TripleDES[] tripleDesMode = new TripleDES[MAX_TRIPLE_DES_MODES];
        private static Rijndael[] rijndaleMode = new Rijndael[MAX_RIJNDAEL_MODES];
        private static RC2[] rc2Mode = new RC2[MAX_RC2_MODES];

        static void Main(string[] args) {
            fillModeArrays();
            String text = File.ReadAllText(FILE_INPUT_TEXT_PATH);

            while (true) {
                Console.WriteLine("What kind of encrypt mode do u want?\nType in \"exit\" to kill the process");
                Console.WriteLine(WELCOME_TEXT);
                
                String number = Console.In.ReadLine();

                switch (number) {
                    case "exit": {
                        Console.WriteLine(" Process has been finished");
                        return;
                    }
                    
                    case "comparison": {
                        comparison(text);
                        continue;
                    }
                    
                    case "0": {
                        desMode[(int) EModes.E_DES_ECB_PKCS7] ??= new DES(CipherMode.ECB, PaddingMode.PKCS7);
                        int time = desMode[(int) EModes.E_DES_ECB_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "1": {
                        desMode[(int) EModes.E_DES_CBC_PKCS7] ??= new DES(CipherMode.CBC, PaddingMode.PKCS7);
                        int time = desMode[(int) EModes.E_DES_CBC_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "2": {
                        desMode[(int) EModes.E_DES_CBC_ZEROS] ??= new DES(CipherMode.CBC, PaddingMode.Zeros);
                        int time = desMode[(int) EModes.E_DES_CBC_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "3": {
                        desMode[(int) EModes.E_DES_ECB_ZEROS] ??= new DES(CipherMode.ECB, PaddingMode.Zeros);
                        int time = desMode[(int) EModes.E_DES_ECB_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "4": {
                        tripleDesMode[(int) EModes.E_TRIPLE_DES_ECB_PKCS7] ??= new TripleDES(CipherMode.ECB, PaddingMode.PKCS7);
                        int time = tripleDesMode[(int) EModes.E_TRIPLE_DES_ECB_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "5": {
                        tripleDesMode[(int) EModes.E_TRIPLE_DES_CBC_PKCS7] ??= new TripleDES(CipherMode.CBC, PaddingMode.PKCS7);
                        int time = tripleDesMode[(int) EModes.E_TRIPLE_DES_CBC_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "6": {
                        tripleDesMode[(int) EModes.E_TRIPLE_DES_CBC_ZEROS] ??= new TripleDES(CipherMode.CBC, PaddingMode.Zeros);
                        int time = tripleDesMode[(int) EModes.E_TRIPLE_DES_CBC_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "7": {
                        tripleDesMode[(int) EModes.E_TRIPLE_DES_ECB_ZEROS] ??= new TripleDES(CipherMode.ECB, PaddingMode.Zeros);
                        int time = tripleDesMode[(int) EModes.E_TRIPLE_DES_ECB_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "8": {
                        rijndaleMode[(int) EModes.E_RIJNDAEL_ECB_PKCS7] ??= new Rijndael(CipherMode.ECB, PaddingMode.PKCS7);
                        int time = rijndaleMode[(int) EModes.E_RIJNDAEL_ECB_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "9": {
                        rijndaleMode[(int) EModes.E_RIJNDAEL_ECB_ZEROS] ??= new Rijndael(CipherMode.ECB, PaddingMode.Zeros);
                        int time = rijndaleMode[(int) EModes.E_RIJNDAEL_ECB_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "10": {
                        rijndaleMode[(int) EModes.E_RIJNDAEL_CBC_PKCS7] ??= new Rijndael(CipherMode.CBC, PaddingMode.PKCS7);
                        int time = rijndaleMode[(int) EModes.E_RIJNDAEL_CBC_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "11": {
                        rijndaleMode[(int) EModes.E_RIJNDAEL_CBC_ZEROS] ??= new Rijndael(CipherMode.CBC, PaddingMode.Zeros);
                        int time = rijndaleMode[(int) EModes.E_RIJNDAEL_CBC_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "12": {
                        rc2Mode[(int) EModes.E_RC_2_ECB_PKCS7] ??= new RC2(CipherMode.ECB, PaddingMode.PKCS7);
                        int time = rc2Mode[(int) EModes.E_RC_2_ECB_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "13": {
                        rc2Mode[(int) EModes.E_RC_2_ECB_ZEROS] ??= new RC2(CipherMode.ECB, PaddingMode.Zeros);
                        int time = rc2Mode[(int) EModes.E_RC_2_ECB_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "14": {
                        rc2Mode[(int) EModes.E_RC_2_CBC_PKCS7] ??= new RC2(CipherMode.CBC, PaddingMode.PKCS7);
                        int time = rc2Mode[(int) EModes.E_RC_2_CBC_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "15": {
                        rc2Mode[(int) EModes.E_RC_2_CBC_ZEROS] ??= new RC2(CipherMode.CBC, PaddingMode.Zeros);
                        int time = rc2Mode[(int) EModes.E_RC_2_CBC_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    case "16": {
                        rc2Mode[(int) EModes.E_RC_2_CBF_PKCS7] ??= new RC2(CipherMode.CFB, PaddingMode.PKCS7);
                        int time = rc2Mode[(int) EModes.E_RC_2_CBF_PKCS7].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }
                    
                    case "17": {
                        rc2Mode[(int) EModes.E_RC_2_CBF_ZEROS] ??= new RC2(CipherMode.CFB, PaddingMode.Zeros);
                        int time = rc2Mode[(int) EModes.E_RC_2_CBF_ZEROS].runSymmAlg(text);
                        Console.WriteLine("\nRuntime: " + time + "ms");
                        continue;
                    }

                    default: {
                        continue;
                    }
                }
            }
        }
        
        private static void comparison(String text) {
            Console.WriteLine("Mode\t\t Cipher\t\t Padding\t\t Runtime");
            //Console.WriteLine("----\t---------\t----------\t----------");
            for (int modeID = 0, cipherID = 1, paddingID = 2; modeID < MAX_DES_MODES; modeID++) {
                desMode[modeID] ??= new DES((CipherMode)cipherID, (PaddingMode)paddingID);

                int time = desMode[modeID].runSymmAlg(text);

                Console.WriteLine(
                    "DES\t\t | "
                    + desMode[modeID].getCipherMode()
                    + "\t\t | "
                    + desMode[modeID].getPaddingMode()
                    + "\t\t | "
                    + time
                    + "ms"
                );
                
                cipherID++;
                
                if (cipherID <= 2) {
                    continue;
                }
                
                paddingID++;
                cipherID = 1;
            }
            
            for (int modeID = 0, cipherID = 1, paddingID = 2; modeID < MAX_TRIPLE_DES_MODES; modeID++) {
                tripleDesMode[modeID] ??= new TripleDES((CipherMode)cipherID, (PaddingMode)paddingID);

                int time = tripleDesMode[modeID].runSymmAlg(text);

                Console.WriteLine(
                    "TripleDES\t | "
                    + tripleDesMode[modeID].getCipherMode()
                    + "\t\t | "
                    + tripleDesMode[modeID].getPaddingMode()
                    + "\t\t | "
                    + time
                    + "ms"
                );
                
                cipherID++;
                
                if (cipherID <= 2) {
                    continue;
                }
                
                paddingID++;
                cipherID = 1;
            }
            
            for (int modeID = 0, cipherID = 1, paddingID = 2; modeID < MAX_RIJNDAEL_MODES; modeID++) {
                rijndaleMode[modeID] ??= new Rijndael((CipherMode)cipherID, (PaddingMode)paddingID);

                int time = rijndaleMode[modeID].runSymmAlg(text);

                Console.WriteLine(
                    "Rijndael\t | "
                    + rijndaleMode[modeID].getCipherMode()
                    + "\t\t | "
                    + rijndaleMode[modeID].getPaddingMode()
                    + "\t\t | "
                    + time
                    + "ms"
                );
                
                cipherID++;
                
                if (cipherID <= 2) {
                    continue;
                }
                
                paddingID++;
                cipherID = 1;
            }
            
            for (int modeID = 0, cipherID = 1, paddingID = 2; modeID < MAX_RC2_MODES; modeID++) {
                rc2Mode[modeID] ??= new RC2((CipherMode)cipherID, (PaddingMode)paddingID);

                int time = rc2Mode[modeID].runSymmAlg(text);

                Console.WriteLine(
                    "RC2\t\t | "
                    + rc2Mode[modeID].getCipherMode()
                    + "\t\t | "
                    + rc2Mode[modeID].getPaddingMode()
                    + "\t\t | "
                    + time
                    + "ms"
                );

                paddingID++;

                if (paddingID >= 6) {
                    paddingID = 2;
                    cipherID++;
                    continue;
                }
                
                cipherID++;
                
                if (cipherID == 3) {
                    cipherID++;
                }
                
                if (cipherID == 5) {
                    paddingID = 2;
                    cipherID = 1;
                }
            }

            return;
        }
        
        private static void fillModeArrays() {
            for (uint i = 0; i < MAX_DES_MODES; i++) {
                desMode[i] = null;
            }
            
            for (uint i = 0; i < MAX_TRIPLE_DES_MODES; i++) {
                tripleDesMode[i] = null;
            }
            
            for (uint i = 0; i < MAX_RIJNDAEL_MODES; i++) {
                rijndaleMode[i] = null;
            }
            
            for (uint i = 0; i < MAX_RC2_MODES; i++) {
                rc2Mode[i] = null;
            }
            
            return;
        }
    }
}