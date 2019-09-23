using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;


namespace SafTRDPClient
{

    public class PublicFunctions
    {
        public byte[] GenerateKey(string pass)
        {
            SymmetricAlgorithm algo = new RijndaelManaged();
            byte[] stat_adding = Environment.UserName as byte[];
            PasswordDeriveBytes key = new PasswordDeriveBytes(pass, stat_adding, "SHA256", 3);
            algo.Key = key.GetBytes(algo.KeySize / 8);
            algo.IV = key.GetBytes(algo.BlockSize / 8);
            byte[] done_key = null;
            done_key[0] = algo.Key;
            done_key[1] = algo.IV;
            return done_key;
        }

        public string Encrypt(string pass)
        {
            SymmetricAlgorithm algo = new RijndaelManaged();
            byte[] key = GenerateKey(pass);
            ICryptoTransform encryptor = algo.CreateEncryptor(key[0],key[1]);
            Stream password = pass;
            CryptoStream encryptorstream = new CryptoStream(password,encryptor,CryptoStreamMode.Write);
        }


    }
}
 
         
         
       