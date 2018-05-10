using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapasWF
{
    class Coordenada
    {
        private double _longitud;
        private double _latitud;
        public double Longitud { get => _longitud; set => _longitud = value; }
        public double Latitud { get => _latitud; set => _latitud = value; }

        public Coordenada()
        {
            _latitud = 0;
            _longitud = 0;
        }
        
    }
}
