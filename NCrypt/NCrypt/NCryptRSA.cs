using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NCrypt
{ 
    class NCryptRSA: NCryptServices
    {
        public NCryptRSA()
        {
            RSA = new RSACryptoServiceProvider();
        }

        public List<string> ValidKeys()
        {
            List<string> list = new List<string>();
            int Min = RSA.LegalKeySizes[0].MinSize;
            int Max = RSA.LegalKeySizes[0].MaxSize;
            int Skip = RSA.LegalKeySizes[0].SkipSize;

            for (int i = Min; i <= Max; i += Skip )
            {
                list.Add(i.ToString());
            }
            return list;
        }
      
        public void GenerateKey(string FilePath, int Keysize)
        {
            RSA = new RSACryptoServiceProvider(Keysize);
            //write full key
            IO.WriteFileFromString(FilePath + "_PUBLICPRIVATE", RSA.ToXmlString(true));
            //write public key
            IO.WriteFileFromString(FilePath + "_PUBLIC", RSA.ToXmlString(false));
        }

        public void GetKey(string FilePath)
        {
            if (IO.XMLTagExists(FilePath, "RSAKeyValue"))
            {
                //RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(IO.ReadFileString(FilePath));
                Debug.WriteLine(RSA.KeySize);
            }
        }

        public bool CheckKey()
        {
            if (!RSA.PublicOnly)
                return true;
            else
            return false;
        }

        public bool EncryptFile(string FilePath)
        {
            if (RSACheckData(FilePath,true))
            {
                byte[] datatoencrypt = IO.ReadFileBytes(FilePath);
                byte[] encrypteddata = RSAEncrypt(datatoencrypt, RSA.ExportParameters(false), false);
                IO.WriteFileFromBytes(FilePath, encrypteddata);
                //File Encryption completed successfully
                return true;
            }
            return false;
        }

        public bool DecryptFile(string FilePath)
        {
            //make sure we have the full key or else we can decrypt
            if (CheckKey())
            {
                if (RSACheckData(FilePath, false))
                {
                    byte[] datatodecrypt = IO.ReadFileBytes(FilePath);
                    byte[] decrypteddata = RSADecrypt(datatodecrypt, RSA.ExportParameters(true), false);
                    IO.WriteFileFromBytes(FilePath, decrypteddata);
                    //File Decryption completed successfully
                    return true;
                }
            }
            return false;
        }

        public bool RSACheckData(string FilePath, bool Encrypt)
        {// checks to see that data can encrypted / decrypted with selected keysize
            if (Encrypt)
            {
                //Encryption bytes check
                if (IO.CheckFileSize(FilePath) <= ((RSA.KeySize / 8) - 11))
                {
                    return true;
                }
            }
            else
            {
                //Decryption bytes check
                if (IO.CheckFileSize(FilePath) <= ((RSA.KeySize / 8)))
                {
                    return true;
                }

            }
            return false;
        }

        private byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs 
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or 
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs 
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or 
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}
