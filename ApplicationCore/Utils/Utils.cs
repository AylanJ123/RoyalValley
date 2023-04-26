using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ApplicationCore.Utils
{
    namespace Enums
    {
        public enum EstadoConstruccion : byte
        {
            [Description("Lote Baldío")]
            Lote = 0,
            [Description("En Construcción")]
            Obra = 1,
            [Description("Construido")]
            Construido = 2,
        }
    }

    namespace Extensions
    {
        public static class Extensions
        {
            public static string GetDescription<T>(this T value) where T : Enum
            {
                Type type = typeof(T);
                string name = Enum.GetName(type, value);
                if (name != null)
                {
                    FieldInfo field = type.GetField(name);
                    if (field != null)
                        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                            return attr.Description;
                }
                return null;
            }
        }
    }

    namespace Crypto
    {
        public class Cryptography
        {
            const string KEY = "~!@#$%^&*()_+{}:>?<`1234567890-=[]\'.,/|";
            /// <summary>
            /// http://www.aspsnippets.com/Articles/AES-Encryption-Decryption-Cryptography-Tutorialwith-example-in-ASPNet-using-C-and-VBNet.aspx
            /// </summary>
            /// <param name="pCadena"></param>
            /// <returns></returns>
            static public byte[] EncrypthAES(string pCadena)
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(pCadena);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                       CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        return ms.ToArray();
                    }
                }
            }
            static public string DecrypthAES(byte[] pass)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                       CryptoStreamMode.Write))
                        {
                            cs.Write(pass, 0, pass.Length);
                            cs.Close();
                        }
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
        }
    }

}
