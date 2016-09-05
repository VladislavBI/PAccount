using PAccountant.Model.View.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PAccountant.Model.View.Managers.Concrete
{
    public class MD5CryptographyManager : CryptographyManager
    {
        public override byte[] EncodingString(string encodeString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(encodeString));
            return checkSum;
        }
    }
}