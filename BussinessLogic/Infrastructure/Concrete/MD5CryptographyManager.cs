using PAccountant.BussinessLogic.Managers.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace PAccountant.BussinessLogic.Managers.Concrete
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