using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class Grafo
    {
        public List<Vertice> Vertices { get; set; }

        public Grafo()
        {
            Vertices = new List<Vertice>();
        }

        public Vertice BuscarVertice(string Nombre) => Vertices.Find(x => x.Nombre == Nombre);
        
        public bool Insertar(string Nombre)
        {
            if (BuscarVertice(Nombre) != null) return false;
            Vertices.Add(new Vertice(Nombre));
            return true;
        }
        
        public void CompletarGrafo()
        {
            for (int i = 0; i < Vertices.Count; ++i)
            {
                for (int j = 0; j < Vertices.Count; ++j)
                {
                    if (i == j) continue;

                    if (!Vertices[i].Aristas.Exists(x => x.Fin == Vertices[j]))
                    {
                        Vertices[i].Aristas.Add(new Arista(Vertices[i], Vertices[j]));
                    }
                }
            }
        }
        

        public bool ExisteCamino(string A, string B)
        {
            var vertA = BuscarVertice(A);
            var vertB = BuscarVertice(B);
            if (vertA == null || vertB == null) return false;

            return ExisteCamino(vertA, vertB, new Estados(this));
        }

        private bool ExisteCamino(Vertice A, Vertice B, Estados Estados)
        {
            if (A == B) return true;
            Estados[A.Nombre] = true;

            foreach (var val in A.Aristas)
            {
                if (!Estados[val.Fin.Nombre])
                {
                    if (ExisteCamino(val.Fin, B, Estados)) return true;
                }
            }

            return false;
        }

        public List<Coordenada> Coordenadas()
        {
            List<Coordenada> res = new List<Coordenada>();
            foreach(var val in Vertices)
            {
                res.Add(new Coordenada(val.Latitud, val.Longitud));
            }
            return res;
        }

        public bool CargarGrafo()
        {
            try
            {
                Vertices = VerticeDB.ConsultarVertices();
                CompletarGrafo();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }


        public List<Ruta> Caminos(Vertice Inicio)
        {
            List<Ruta> rutas = new List<Ruta>(), resultado = new List<Ruta>();
            Ruta ruta = new Ruta(); 

            Caminos(Inicio, Inicio, new Estados(this) ,ref rutas, ruta, true);
            return rutas;
        }

        private void Caminos(Vertice P, Vertice A, Estados estado, ref List<Ruta> Rutas, Ruta actual, bool Primero = false)
        {
            if (!Primero) estado[P.Nombre] = true;

            // Son las mismas ciudades
            if (!Primero && P.Nombre == A.Nombre)
            {
                if (actual.Rutas.Count == Vertices.Count) Rutas.Add(new Ruta(actual));
                estado[P.Nombre] = false;
                return;
            }

            foreach (var x in P.Aristas)
            {
                if (!estado[BuscarVertice(x.Fin.Nombre).Nombre])
                {
                    actual.Rutas.Add(x);
                    actual.Distancia += x.Costo;
                    Caminos(BuscarVertice(x.Fin.Nombre), A, estado, ref Rutas, actual);
                    actual.Distancia -= x.Costo;
                    actual.Rutas.RemoveAt(actual.Rutas.Count - 1);
                }
            };

            estado[P.Nombre] = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Coordenada> TSP()
        {
            var rutas = Caminos(Vertices[0]);
            Ruta mejorRuta = new Ruta() { Distancia = double.MaxValue };
            rutas.ForEach(x =>
            {
                if (x.Distancia < mejorRuta.Distancia) mejorRuta = x;
            });
            List<Coordenada> res = new List<Coordenada>();

            foreach (var val in mejorRuta.Rutas)
            {
                res.Add(new Coordenada(val.Inicio.Latitud, val.Inicio.Longitud));
            }
            return res;
        }
    }
}
