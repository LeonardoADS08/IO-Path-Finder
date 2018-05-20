using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo.DB;
using LiteDB;

namespace Grafo
{
    public class VerticeDB : uDB.CRUD<VerticeDB>
    {
         [BsonId]
        public int _id { get; set; }
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
