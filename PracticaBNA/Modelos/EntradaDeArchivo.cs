using System.IO;

namespace PracticaBNA.Modelos
{
    internal class FileInput : IEntrada
    {
        StreamReader sr;
        public FileInput(string fileDir)
        {
            if (!File.Exists(fileDir))
                throw new FileNotFoundException("Invalid file.");
            sr = new StreamReader(fileDir);
        }

        public string ObtenerLinea()
        {
            string input;
            input = sr.ReadLine();
            if (input == null)
                sr.Close();
            return input;
        }
    }
}