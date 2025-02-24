using System.Security.Cryptography;
using System.Text;

namespace MvcNetCoreUtilidades.Helpers
{
    public class HelperCryptography
    {

        public static string EncriptarTextoBasico(string contenido)
        {
            byte[] entrada;
            byte[] salida;

            UnicodeEncoding encoding = new UnicodeEncoding();
            SHA1 managed = SHA1.Create();
            entrada = encoding.GetBytes(contenido);
            salida = managed.ComputeHash(entrada);
            string resultado = encoding.GetString(salida);
            return resultado;
        }
    }
}
