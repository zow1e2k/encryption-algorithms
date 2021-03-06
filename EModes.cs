namespace SymmetricAlgths {
    public enum EModes : uint{
        E_DES_ECB_PKCS7 = 0,
        E_DES_CBC_PKCS7 = 1,
        E_DES_CBC_ZEROS = 2,
        E_DES_CBC_NONE = 3,
        E_DES_ECB_ZEROS = 4,
        E_DES_ECB_NONE = 5,
        E_TRIPLE_DES_ECB_PKCS7 = 0,
        E_TRIPLE_DES_CBC_PKCS7 = 1,
        E_TRIPLE_DES_CBC_ZEROS = 2,
        E_TRIPLE_DES_CBC_NONE = 3,
        E_TRIPLE_DES_ECB_ZEROS = 4,
        E_TRIPLE_DES_ECB_NONE = 5,
        E_RIJNDAEL_ECB_PKCS7 = 0,
        E_RIJNDAEL_ECB_ZEROS = 1,
        E_RIJNDAEL_ECB_NONE = 2,
        E_RIJNDAEL_CBC_PKCS7 = 3,
        E_RIJNDAEL_CBC_ZEROS = 4,
        E_RIJNDAEL_CBC_NONE = 5,
        E_RC_2_ECB_PKCS7 = 0,
        E_RC_2_ECB_ZEROS = 1,
        E_RC_2_ECB_NONE = 2,
        E_RC_2_CBC_PKCS7 = 3,
        E_RC_2_CBC_ZEROS = 4,
        E_RC_2_CBC_NONE = 5,
        E_RC_2_CBF_PKCS7 = 6,
        E_RC_2_CBF_ZEROS = 7,
        E_RC_2_CBF_NONE = 8
    }
}