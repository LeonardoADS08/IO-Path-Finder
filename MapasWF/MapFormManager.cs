using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Grafo;
namespace MapasWF
{
    class MapFormManager
    {
        GMarkerGoogle _marker;
        GMapOverlay _overlay;
        GMapControl _main;
        Random rnd = new Random();
        //overlays
        //0->marcadores
        //1->caminos
        public List<double> _temproutes;
        public List<GMapMarker> _marcados;
        public List<GMapMarker> _output;

        public GMarkerGoogle Marker { get => _marker; set => _marker = value; }
        public GMapOverlay Overlay { get => _overlay; set => _overlay = value; }
        public GMapControl Main { get => _main; set => _main = value; }
        /// <summary>
        /// en laza un mapa en el form al manager
        /// </summary>
        /// <param name="x"></param>
        public MapFormManager(GMapControl x)
        {
            _main = x;
            _marker = null;
            _temproutes = new List<double>();
                _overlay = new GMapOverlay("Markadores");
            _marcados = new List<GMapMarker>();
            _output = new List<GMapMarker>();
      

        }
        /// <summary>
        /// marca la posicion (siempre sera verde)
        /// </summary>
        /// <param name="x">puedes usar new PointLatLng( latitud , longitud )</param> pero crea una diferente overlay
        public void AddMarkernShow(PointLatLng x)
        {
  
            _marker = new GMarkerGoogle(x, GMarkerGoogleType.red_small);
            _marker.ToolTipText=("Lat=" + Math.Round(x.Lat, 3) + "\n Long=" + Math.Round(x.Lng, 3));
            _marker.ToolTipMode = MarkerTooltipMode.Always;

            _overlay.Markers.Add(_marker);
            _main.Overlays.Add(_overlay);
            _main.Position = _marker.Position;
        }
        /// <summary>
        /// actualiza los cambios en el mapa(ignoranddo los marcadores)
        /// </summary>
        public void Update()
        {
            _main.Zoom++;
            _main.Zoom--;
        }
        /// <summary>
        /// establece el mapa del form
        /// </summary>
        public void BuildStandart()
        {

            _main.DragButton = MouseButtons.Left;
            _main.CanDragMap = true;
            _main.MapProvider = GMapProviders.GoogleMap;
            _main.Position = new PointLatLng(-17.782788, -63.182387);
            _main.MinZoom = 0;
            _main.MaxZoom = 340;
            _main.Zoom = 14;
            _main.AutoScroll = true;
            _overlay = new GMapOverlay("Camino Optimo");
        }
        /// <summary>
        /// Crea una ruta del punto A al punto B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void CrearRutadinamica(PointLatLng A, PointLatLng B)
        {
            GDirections direcctions = new GDirections();
            DirectionsStatusCode RutasPosibles = GMapProviders.GoogleMap.GetDirections(out direcctions,A, B, false, false, false, false, true);

            //para cuendo no exista alguna ruta existente
            if (RutasPosibles==GMap.NET.DirectionsStatusCode.ZERO_RESULTS)
            {
                MessageBox.Show("No existe camino posible");
                return;
            }

            GMapRoute Obtenida = new GMapRoute(direcctions.Route, "Ruta");
            Obtenida.IsHitTestVisible = true;
           
            Obtenida.Stroke = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 3);
            double aux = Obtenida.Distance;
            _temproutes.Add(aux);

           _main.Overlays[1].Routes.Add(Obtenida);
            
           // _main.Overlays.Add(_overlay);
          

        }
        /// <summary>
        /// genera las rutas del primer marcador al ultimo conforme fueron ingresados al mapa
        /// </summary>
        public void GenerarRutaExistencial()
        {
            _overlay = Main.Overlays[0];
            for (int i = 0; i < _overlay.Markers.Count() - 1; i++)
            {
                

                CrearRutadinamica(new PointLatLng(_overlay.Markers[i].Position.Lat, _overlay.Markers[i].Position.Lng), new PointLatLng(_overlay.Markers[i + 1].Position.Lat, _overlay.Markers[i + 1].Position.Lng));

            }
            CrearRutadinamica(new PointLatLng(_overlay.Markers[_overlay.Markers.Count()-1].Position.Lat, _overlay.Markers[_overlay.Markers.Count() - 1].Position.Lng), new PointLatLng(_overlay.Markers[0].Position.Lat, _overlay.Markers[0].Position.Lng));
          
            this.Update();
        }

        /// <summary>
        /// Reinicio completo del mapa(se pierde todo)
        /// </summary>
        public void Fflush(GMapControl x, string c)
        {
            switch (c)
            {
                case "Todo":
                                        {
                        DialogResult dialogResult = MessageBox.Show("Esta accion es terminal", "Advertencia",
                            MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            while (_main.Overlays.Count != 0)
                            {
                                _main.Overlays.RemoveAt(0);
                               
                            }
                         Main.Overlays.Add(new GMapOverlay("Marcadores"));
                            Main.Overlays.Add(new GMapOverlay("rutas"));
                            _overlay = Main.Overlays[0];
                            this.Update();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do nothing
                            return;
                        }
                        break;
                    }
                case
                    "Solo caminos":

                    {
                        _main.Overlays[1] = new GMapOverlay("Rutas");
                        break;
                }
                case "Restart":
                {
                    while (_main.Overlays.Count != 0)
                    {
                        _main.Overlays.RemoveAt(0);

                    }
                    this.Update();
                        break;
                }
            }



        }

        public void Centrate()
        {
            _main.Position = new PointLatLng(-17.782788, -63.182387);
            _main.Zoom = 14;

        }

        public void ZoomInch(double x)
        {
            _main.Zoom += x;
        }

        public GMapOverlay CoordinateArrayToOverlay(List<Coordenada> x)
        {
            GMarkerGoogle current = null;
            GMapOverlay aux= new GMapOverlay("Marcadores");
            int i = 0;
            foreach (Coordenada u in x)
            {
                if (i == 0)
                {
                    current = new GMarkerGoogle(new PointLatLng(u.Latitud, u.Longitud), GMarkerGoogleType.green_dot);
                }
                else
                {
                    current = new GMarkerGoogle(new PointLatLng(u.Latitud, u.Longitud), GMarkerGoogleType.red_dot);
                }
                current.ToolTipText= "Index ="+i+"\n"+"Lat = "+ Math.Round(u.Latitud, 4)+"\n Long = "+ Math.Round(u.Longitud, 5);

                i++;
                aux.Markers.Add(current);
            }
          

            return aux;
        }

        /// <summary>
        /// Muesra en el mapa(del form) una collecion de coordenadas como una ruta
        /// </summary>
        /// <param name="x"></param>
        private void ShowMapMarkerCollection(List<Coordenada> x)
        {
            if (x.Count <= 1)
            {
                MessageBox.Show("No existen sifuciente Nodos para realizar un camino");
                return;
            }
            else
            {
                PointLatLng prim, sec;
                for (int i = 0; i < x.Count() - 1; i++)
                {
                    prim = new PointLatLng(x[i].Latitud, x[i].Longitud);
                    sec = new PointLatLng(x[i + 1].Latitud, x[i + 1].Longitud);
                    CrearRutadinamica(prim, sec);

                }
            }

        }

        public List<Coordenada> converter(List<GMapMarker> x)
        {
            List<Coordenada> u = new List<Coordenada>();
            foreach (GMapMarker y in x)
            {
                u.Add(new Coordenada(y.Position.Lat, y.Position.Lng));
            }

            return u;
        }

        public void mark(GMapMarker A)
        {
            _marcados.Add(A);
        }

        public bool isMarked(GMapMarker A)
        {
            foreach (GMapMarker x in _marcados)
            {
                if (x.Position.Lat == A.Position.Lat && x.Position.Lng == A.Position.Lng)
                {
                    return true;
                }
            }
            return false;
        }

        private GMapMarker bruteforcestep(GMapMarker A, double  output)
        {
            GDirections direcctions = new GDirections();
            GMapMarker final=null;
            DirectionsStatusCode RutasPosibles;
            this.mark(A);
            double current = 100000000;
            foreach (GMapMarker x in _main.Overlays[0].Markers)
            {

                if (x!=A&&!this.isMarked(x))
                {
                    RutasPosibles= GMapProviders.GoogleMap.GetDirections(out direcctions, A.Position, x.Position, false, false, false, false, true);

                    //para cuendo no exista alguna ruta existente
                    if (RutasPosibles == DirectionsStatusCode.ZERO_RESULTS)
                    {
                        MessageBox.Show("No existe camino posible");
                        output = 0;
                        return null;
                    }

                    GMapRoute Obtenida = new GMapRoute(direcctions.Route, "Ruta");
                    if (Obtenida.Distance < current)
                    {
                        current = Obtenida.Distance;
                        final = x;
                    }
                }
            }
            output = current;
            return final;
        }

        public void BruteForce()
        {
            double temp=0;
            GMapMarker next = null;
            
            next = _main.Overlays[0].Markers[0];
            do
            {
                _output.Add(next);
                next = bruteforcestep(next, temp);
            } while (next != null);

            List<Coordenada> temporal=this.converter(_output);
            this.printfromOverlay(this.CoordinateArrayToOverlay(temporal));

        }

        public double printfromOverlay(GMapOverlay x)
        {
            double current = 0;

            GDirections direcctions;
            GMapRoute Obtenida;
            DirectionsStatusCode RutasPosibles;
            for (int i = 0; i < x.Markers.Count-1; i++)
            {
                
           
                direcctions= new GDirections();
                RutasPosibles = GMapProviders.GoogleMap.GetDirections(out direcctions, x.Markers[i].Position, x.Markers[i+1].Position, false, false, false, false, true);

               Obtenida  = new GMapRoute(direcctions.Route, "Ruta");
                Obtenida.IsHitTestVisible = true;
                Obtenida.Stroke = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 3);
                double aux = Obtenida.Distance;
                current += aux;
                
                _main.Overlays[1].Routes.Add(Obtenida);
            }
              direcctions= new GDirections();
                RutasPosibles = GMapProviders.GoogleMap.GetDirections(out direcctions, x.Markers[x.Markers.Count-2].Position, x.Markers[x.Markers.Count-1].Position, false, false, false, false, true);

               Obtenida = new GMapRoute(direcctions.Route, "Ruta");
                Obtenida.IsHitTestVisible = true;
                Obtenida.Stroke = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 3);
               current+= Obtenida.Distance;
                

                _main.Overlays[1].Routes.Add(Obtenida);


            _output = new List<GMapMarker>();
            _marcados = new List<GMapMarker>();

            return current;

          

           

         
        }



    }
}
