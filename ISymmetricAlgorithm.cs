using System;
using System.Security.Cryptography;

namespace SymmetricAlgths {
    public interface ISymmetricAlgorithm {
        public byte[] getKey();
        public byte[] getInitVector();
        
        public CipherMode getCipherMode();
        
        public PaddingMode getPaddingMode();
        
        public int runSymmAlg(String str);
    }
}