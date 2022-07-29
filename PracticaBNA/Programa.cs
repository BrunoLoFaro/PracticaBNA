using PracticaBNA.Modelos;
using PracticaBNA.Utils;

namespace PracticaBNA
{
    class Programa
    {
        static void Main(string[] args)
        {
            (string rutaDeArchivo, string formatoDeImpresion) opciones;

            opciones = Utilidades.ProcesarParametros(args);

            List<Registro> registros = Utilidades.ObtenerRegistros(opciones.rutaDeArchivo);

            Utilidades.ImprimirRegistros(AlgoritmosDeOrdenamiento.Ordenar(registros), opciones.formatoDeImpresion);
            Console.ReadKey();
        }
    }
}