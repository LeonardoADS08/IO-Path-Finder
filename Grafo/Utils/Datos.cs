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
               // datos.Add(new VerticeDB("Plaza 24 de Septiembre"));
              //  datos.Add(new VerticeDB("Colegio La Salle, Bolivia , Santa Cruz"));
                //datos.Add(new VerticeDB("Universidad Franz Tamayo, Bolivia , Santa Cruz"));
                //datos.Add(new VerticeDB("Mall Las Brisas, Bolivia , Santa Cruz"));
                //datos.Add(new VerticeDB("Cine center, Bolivia, Santa Cruz"));
                //datos.Add(new VerticeDB("La casa del Camboa, Bolivia , Santa Cruz"));


                VerticeDB.Eliminar();
                VerticeDB.Insertar(datos);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public static List<String> standarts()
        {
            List<String> x = new List<String>();
            x.Add("Universidad Privada de Santa Cruz de la Sierra, Bolivia");
            x.Add("Estadio Tahuichi Aguilera");
            x.Add("Avion Pirata");
            return x;
        }

        public static void VerificarDatos(List<String> d)
        {
            try
            {
                List<VerticeDB> datos = new List<VerticeDB>();
                foreach (String x in d)
                {
                    datos.Add(new VerticeDB(x));
                }
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
