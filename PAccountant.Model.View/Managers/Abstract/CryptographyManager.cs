using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Model.View.Managers.Abstract
{
    public abstract class CryptographyManager
    {
        /// <summary>
        /// Encoding string by selected cryptography
        /// </summary>
        /// <param name="EncodingString">string to encode</param>
        /// <returns>encoded byte array</returns>
        public abstract byte[] EncodingString(string EncodingString);

        /// <summary>
        /// Cheking that two bool arrays are equal
        /// </summary>
        /// <param name="byte1"></param>
        /// <param name="byte2"></param>
        /// <returns></returns>
        public virtual bool CheckingEquals(byte[] byte1, byte[] byte2)
        {
            return byte1.SequenceEqual(byte2);
        }
        public virtual bool CheckingEquals(byte[] byte1, string string1)
        {
            byte[] temp = EncodingString(string1);
            return temp.SequenceEqual(byte1);
        }
    }
}
