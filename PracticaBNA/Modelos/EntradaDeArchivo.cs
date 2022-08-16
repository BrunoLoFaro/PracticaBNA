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
            try
            {
                string entrada;
                entrada = sr.ReadLine();
                if (entrada == null)
                    sr.Close();
                return entrada;
            }
            catch (OutOfMemoryException ex)
            {
                throw new OutOfMemoryException(ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
        }
    }
}