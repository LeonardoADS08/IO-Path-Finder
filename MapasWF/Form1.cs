using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
namespace MapasWF
{
    public partial class Form1 : Form
    {
        GMarkerGoogle _marker;
        GMapOverlay _overlay;
        PointLatLng inicio;
        PointLatLng final;

        MapFormManager manager;
        public Form1()
        {
            InitializeComponent();
            manager = new MapFormManager(Map1);
            Map1.OnMapDrag += Map1_OnMapDrag;
        }

        private void Map1_OnMapDrag()
        {
            Tlatitud.Text = Map1.Position.Lat.ToString();
            Tlongitud.Text = Map1.Position.Lng.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _marker = new GMarkerGoogle(new PointLatLng(double.Parse(Tlatitud.Text), double.Parse(Tlongitud.Text)), GMarkerGoogleType.green_dot);
            _marker.ToolTipMode = MarkerTooltipMode.Always;
            _marker.ToolTipText = string.Format("\n Lat: {0} \n Long:{1}", double.Parse(Tlatitud.Text), double.Parse(Tlongitud.Text));
            _overlay.Markers.Add(_marker);
            Map1.Overlays.Add(_overlay);
            Map1.Position = _marker.Position;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager.BuildStandart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.AddMarkernShow(Map1.Position);
        }

        private void Map1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = Map1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = Map1.FromLocalToLatLng(e.X, e.Y).Lng;
            Tlatitud.Text = lat.ToString();
            Tlongitud.Text = lng.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<PointLatLng> poligono = new List<PointLatLng>();
            double lng,lat;
            foreach (GMapMarker x in _overlay.Markers)
            {
                poligono.Add(new PointLatLng(x.Position.Lat, x.Position.Lng));
            }
            GMapRoute ruta = new GMapRoute(poligono,"Rutas");
            _overlay.Routes.Add(ruta);
            Map1.Overlays.Add(_overlay);
            Map1.Zoom = Map1.Zoom + 1;
            Map1.Zoom = Map1.Zoom - 1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            manager.GenerarRutaExistencial();


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
                PointLatLng prim, sec ;
                for (int i = 0; i < x.Count()-1; i++)
                {
                    prim = new PointLatLng(x[i].Latitud, x[i].Longitud);
                    sec = new PointLatLng(x[i+1].Latitud, x[i+1].Longitud);
                    manager.CrearRutadinamica(prim, sec);

                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            manager.Fflush(Map1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
