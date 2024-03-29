﻿using System;
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

        public Ruta RutaOptima(Vertice Inicio)
        {
            List<Ruta> rutas = new List<Ruta>();
            Ruta ruta = new Ruta(), mejorRuta = new Ruta() { Distancia = float.MaxValue, Tiempo = float.MaxValue, Rutas = new List<Arista>() };
            Caminos(Inicio, Inicio, new Estados(this), ruta, ref mejorRuta, true);
            return mejorRuta;
        }

        private void Caminos(Vertice P, Vertice A, Estados estado, Ruta actual, ref Ruta mejorRuta, bool Primero = false)
        {
            if (!Primero) estado[P.Nombre] = true;

            // Son las mismas ciudades
            if (!Primero && P.Nombre == A.Nombre)
            {
                if (actual.Rutas.Count == Vertices.Count && actual.Distancia < mejorRuta.Distancia) mejorRuta = new Ruta(actual);
                estado[P.Nombre] = false;
                return;
            }

            foreach (var x in P.Aristas)
            {
                if (!estado[BuscarVertice(x.Fin.Nombre).Nombre])
                {
                    actual.Rutas.Add(x);
                    actual.Distancia += x.Costo;
                    actual.Tiempo += x.Tiempo;
                    Caminos(BuscarVertice(x.Fin.Nombre), A, estado, actual, ref mejorRuta);
                    actual.Distancia -= x.Costo;
                    actual.Tiempo -= x.Tiempo;
                    actual.Rutas.RemoveAt(actual.Rutas.Count - 1);
                }
            };

            estado[P.Nombre] = false;
        }

        public Ruta TSP() => RutaOptima(Vertices[0]);

    }
}
