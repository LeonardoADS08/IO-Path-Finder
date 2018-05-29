using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Ruta
    {
        public List<Arista> Rutas = new List<Arista>();
        public double Distancia = 0d;
        public double Tiempo = 0d;
        public Ruta()
        {

        }

        public Ruta(Ruta nuevo)
        {
            nuevo.Rutas.ForEach(x => Rutas.Add(x));
            Distancia = nuevo.Distancia;
            Tiempo = nuevo.Tiempo;
        }

        public List<Coordenada> Coordenadas()
        {
            List<Coordenada> res = new List<Coordenada>();
            foreach (var val in Rutas)
            {
                res.Add(new Coordenada(val.Inicio.Latitud, val.Inicio.Longitud));
            }
            return res;
        }
    }
}
