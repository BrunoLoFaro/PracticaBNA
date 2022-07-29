using PracticaBNA.Modelos;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticaBNA.Utils
{
    public abstract class Utilidades
    {
        internal static List<Registro> ObtenerRegistros(string rutaDeArchivo)
        {
            string linea;
            IEntrada entradaDeArchivo = new EntradaDeArchivo(rutaDeArchivo);
            List<Registro> registros = new List<Registro>();

            while ((linea = entradaDeArchivo.ObtenerLinea()) != null)
            {
                if(linea.Length==25)
                registros.Add(new Registro(linea));
            }

            return registros;
        }

        public enum FormatoDeImpresion { ShortFormat, LongFormat }

        internal static (string rutaDeArchivo, string formatoDeImpresion)  ProcesarParametros(string[] parametros)
        {
            (string? rutaDeArchivo, string formatoDeImpresion) parametrosValido = (null, FormatoDeImpresion.LongFormat.ToString()); ;

            if (parametros.Length < 1 || parametros.Length > 2)
                throw new ArgumentException("2 arguments required.");

            else
            {
                if (parametros.Length > 1)
                {
                    if (!EsFormatoDeImpresionValido(parametros[1]))
                        throw new ArgumentException("Invalid specified format.");
                    parametrosValido.formatoDeImpresion = parametros[1];
                }
                if (!File.Exists(parametros[0]))
                    throw new ArgumentException("File not found.");
                parametrosValido.rutaDeArchivo = parametros[0];
            }

            return parametrosValido;
        }

        internal static bool EsFormatoDeImpresionValido(string format)
        {
            bool isValid = false;
            string[] names = Enum.GetNames(typeof(FormatoDeImpresion));
            for (int i = 0; i < names.Length; i++)
            {
                if (format.ToLower().Equals(names[i].ToLower()))
                    isValid = true;
            }
            return isValid;
        }

        internal static void ImprimirRegistros(List<Registro> registros, string formato)
        {
            foreach (Registro registro in registros)
            {
                registro.Imprimir(formato);
            }
        }
    }

}