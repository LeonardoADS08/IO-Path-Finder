using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Arista
    {
        public Vertice Inicio { get; set; }
        public Vertice Fin { get; set; }
        public double Costo { get; set; }
        public double Tiempo { get; set; }

        public Arista()
        {
            Costo = Constantes.COSTO_PREDETERMINADO;
            Tiempo = Constantes.TIEMPO_PREDETERMINADO;
        }
        public Arista(Vertice inicio, Vertice fin)
        {
            Inicio = inicio;
            Fin = fin;
        }
        public Arista(Vertice inicio, Vertice fin, float costo, float tiempo)
        {
            Inicio = inicio;
            Fin = fin;
            Costo = costo;
            Tiempo = tiempo;
        }

        
    }
}
