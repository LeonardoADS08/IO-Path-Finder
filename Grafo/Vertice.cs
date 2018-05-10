using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Vertice
    {
        public List<Arista> Aristas { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Vertice()
        {
            Aristas = new List<Arista>();
            Nombre = Constantes.NOMBRE_NODO_PREDETERMINADO;
            Latitud = Constantes.LATITUD_PREDETERMINADA;
            Longitud = Constantes.LONGITUD_PREDETERMINADA;
        }

        public Vertice(string nombre)
        {
            Aristas = new List<Arista>();
            Nombre = nombre;
            Latitud = Constantes.LATITUD_PREDETERMINADA;
            Longitud = Constantes.LONGITUD_PREDETERMINADA;
        }

        public Vertice(string nombre, float latitud, float longitud)
        {
            Aristas = new List<Arista>();
            Nombre = nombre;
            Latitud = latitud;
            Longitud = longitud;
        }

        
    }
}
