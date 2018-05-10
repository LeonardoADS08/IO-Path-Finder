using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Coordenada
    {
        public double Latitud;
        public double Longitud;

        public Coordenada()
        {
            Latitud = -17.783427;
            Longitud = -63.182073;
        }

        public Coordenada(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
