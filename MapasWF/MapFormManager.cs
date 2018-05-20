using System;
using System.Collections.Generic;
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
        public List<double> _temproutes;

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
         
                _overlay = new GMapOverlay("Markadores");
         

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
            DirectionsStatusCode RutasPosibles = GMapProviders.GoogleMap.GetDirections(out direcctions,A, B, false, false, false, false, false);

            //para cuendo no exista alguna ruta existente
            if (RutasPosibles==GMap.NET.DirectionsStatusCode.ZERO_RESULTS)
            {
                MessageBox.Show("No existe camino posible");
                return;
            }

            GMapRoute Obtenida = new GMapRoute(direcctions.Route, "Ruta");
            double aux = Obtenida.Distance;
            //_temproutes.Add(aux);
            //_overlay.Routes.Add(Obtenida);
            
           // _main.Overlays.Add(_overlay);
            this.Update();

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
           // UpdateDistancesPerMarkers();
        }
        /// <summary>
        /// Reinicio completo del mapa(se pierde todo)
        /// </summary>
        public void Fflush(GMapControl x)
        {
            DialogResult dialogResult = MessageBox.Show("Esta accion es terminal", "Advertencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                while (_main.Overlays.Count != 0)
                {
                    _main.Overlays.RemoveAt(0);
                    _overlay = new GMapOverlay("Marcadores");
                    this.Update();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
                return;
            }


           
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
                    current = new GMarkerGoogle(new PointLatLng(u.Latitud, u.Longitud), GMarkerGoogleType.red_big_stop);
                }

                i++;
                
                current.ToolTipText= "Lat="+ Math.Round(u.Latitud, 4)+"\n Long"+ Math.Round(u.Longitud, 4);
               

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

        public void UpdateDistancesPerMarkers()
        {
            int i = 0;
            foreach (GMapMarker x in _main.Overlays[0].Markers)
            {
                if (i != 0)
                {
                    x.ToolTipText += "\n Distance" + _temproutes[i - 1].ToString();
                }
            }
        }



    }
}
