using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NCrypt
{
    class NCryptServices
    {
        protected RSACryptoServiceProvider RSA;
        protected AesCryptoServiceProvider AES;
        protected FileIO IO = new FileIO();
        protected CspParameters cspp = new CspParameters();
        protected const string KeyContainerName = "Key";

        //custom file extensions
       // public string KeyExtension { get { return ".NKey"; } }
        //public string FileExtension { get { return ".NCrypt"; } }
        
    }
}
