using System.IO;

namespace PracticaBNA.Modelos
{
    public class EntradaDeArchivo : IEntrada
    {
        StreamReader sr;
        public EntradaDeArchivo(string rutaDeArchivo)
        {
            if (!File.Exists(rutaDeArchivo))
                throw new FileNotFoundException("Archivo Invalido");
            sr = new StreamReader(rutaDeArchivo);
        }

        public string ObtenerLinea()
        {
            string entrada;
            entrada = sr.ReadLine();
            if (entrada == null)
                sr.Close();
            return entrada;
        }
    }
}