using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    [System.Serializable]
    public class Key
    {
        public Dictionary<byte, byte> ByteDictionary;
        public Key()
        {
            ByteDictionary = new Dictionary<byte, byte>();
            List<byte> availableBytes = new List<byte>();
            for (int i = 0; i < 256; i++)
            {
                availableBytes.Add((byte)i);
            }
            Random random = new Random();
            for (int i = 0; i < 256; i++)
            {
                var index = random.Next(0, availableBytes.Count);
                ByteDictionary.Add((byte)i, availableBytes[index]);
                availableBytes.Remove(availableBytes[index]);
            }
        }
        public string ShowKey()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in ByteDictionary)
            {
                result.Append($"{item.Key}: {item.Value}\n");
            }
            return result.ToString();
        }
        public byte[] Encrypt(byte[] list_to_encrypt)
        {
            var res = new byte[list_to_encrypt.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = ByteDictionary[list_to_encrypt[i]];
            }
            return res;
        }
    }
}
