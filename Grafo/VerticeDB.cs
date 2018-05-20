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

        public VerticeDB()
        {

        }
        public VerticeDB(string nombre, double latitud, double longitud)
        {
            Nombre = nombre;
            Latitud = latitud;
            Longitud = longitud;
        }

        public static List<Vertice> ConsultarVertices()
        {
            List<Vertice> res = new List<Vertice>();
            var valores = Consulta();

            foreach(var val in valores)
            {
                res.Add(new Vertice(val));
            }
            return res;
        }
    }
}
