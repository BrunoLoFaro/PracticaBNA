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
            try
            {
                entrada = sr.ReadLine();
            }
            //manejo estas excepciones aca porque son referentes al archivo.
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (entrada == null)
                sr.Close();
            return entrada;
        }
    }
}