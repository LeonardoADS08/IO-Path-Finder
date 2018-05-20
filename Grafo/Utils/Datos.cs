using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo.Utils
{
    public static class Datos
    {
        public static void VerificarDatos()
        {
            try
            {
                List<VerticeDB> datos = new List<VerticeDB>();
                // datos.Add(new VerticeDB("NOMBRE", -11.1111, -11.11111));


                VerticeDB.Eliminar();
                VerticeDB.Insertar(datos);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
