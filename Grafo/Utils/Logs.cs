using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Grafo.DB
{
    /// <summary>
    /// Clase estática para guardar logs.
    /// </summary>
    public static class Logs
    {

        /// <summary>
        /// Guarda un mensaje en el log con un formato dado, estos logs se guardan por fecha.
        /// </summary>
        /// <param name="Mensaje">Mensaje a guardar en el log.</param>
        /// <param name="Direccion">Especificar donde ha ocurrido el error.</param>
        /// <param name="Cronologia">Si es true, en el log se escribira el momento que ha sido creado.</param>
        public static void GuardarLog(string Mensaje, string Direccion, bool Cronologia = true)
        {
            try
            {
                // Dirección donde se guardará el archivo.
                // Dirección del programa + "Runtime_Log " + Fecha + ".log"
                string logfile = AppDomain.CurrentDomain.BaseDirectory + "Runtime_Log " + DateTime.Today.ToString("dd-MM-yyyy") + ".log";

                // El mensaje que será guardado en el Log
                string final = "";
                if (Cronologia) final = DateTime.Now.ToString("hh:mm:ss") + ": " + Direccion + " - " + Mensaje + "\r\n";
                else final = Direccion + " - " + Mensaje + "\r\n";

                // Se guarda en el archivo
                File.AppendAllText(logfile, final);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Obtiene el nombre de la funcion de la cual se esta llamando.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ObtenerDireccion()
        {
            try
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);
                return sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name;
            }
            catch
            {
                return "No es posible obtener la dirección.";
            }
        }
    }
}