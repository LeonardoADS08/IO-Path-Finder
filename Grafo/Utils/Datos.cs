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
                datos.Add(new VerticeDB("Universidad Privada de Santa Cruz de la Sierra, Bolivia"));
                datos.Add(new VerticeDB("Estadio Tahuichi Aguilera"));
                datos.Add(new VerticeDB("Avion Pirata"));
                datos.Add(new VerticeDB("Plaza 24 de Septiembre"));
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
