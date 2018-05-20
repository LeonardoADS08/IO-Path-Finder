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
using Grafo;

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
            Map1.OnMarkerClick += Map1_OnMarkerClick;
            List<Coordenada> temp = new List<Coordenada>();
            temp.Add(new Coordenada(-17.783, -63.184));
            temp.Add(new Coordenada(-17.786, -63.192));
            temp.Add(new Coordenada(-17.777, -63.197));
            temp.Add(new Coordenada(-17.768, -63.176));
            Map1.Overlays.Add(manager.CoordinateArrayToOverlay(temp));
            manager.Overlay = Map1.Overlays[0];
        }

        private void Map1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            item.ToolTipMode = item.ToolTipMode == MarkerTooltipMode.Always ? MarkerTooltipMode.Never : MarkerTooltipMode.Always;
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
        
        private void button5_Click(object sender, EventArgs e)
        {
            manager.Fflush(Map1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
