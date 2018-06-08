using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Grafo;
using Grafo.Utils;

namespace MapasWF
{
    public partial class Form1 : Form
    {
        GMarkerGoogle _marker;
        GMapOverlay _overlay;
        PointLatLng inicio;
        PointLatLng final;
         Ruta teesepesango;
        MapFormManager manager;
        public List<String> DBNAMES;
        Grafo.Grafo Datos;
        Thread _thread;
        public Form1()
        {
            InitializeComponent();
            manager = new MapFormManager(Map1);
            Map1.OnMapDrag += Map1_OnMapDrag;
            Map1.OnMarkerClick += Map1_OnMarkerClick;
            Map1.OnRouteClick += Map1_OnRouteClick;
            Map1.OnMarkerDoubleClick += Map1_OnMarkerDoubleClick;
            teesepesango = null;
            ComboFflush.SelectedIndex = 0;
            DBNAMES = new List<string>();
            // Grafo
            _thread = new Thread(() => CargarDatos());
            _thread.Start();
            Actualizar();
        }

        private void Map1_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
            MessageBox.Show(manager.isMarked(item).ToString());
        }

        private void Map1_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            MessageBox.Show("Distancia =" + item.Distance.ToString());
        }

    

        private async void Actualizar()
        {
            while (Datos == null)
            {
               

                // QUE HACER CUANDO SE TIENEN LOS DATOS;
                await Task.Delay(250);
            }
            _thread.Abort();

            Grafo.Utils.Datos.VerificarDatos();
           teesepesango = Datos.TSP();

            manager.Main.Overlays.Add(manager.CoordinateArrayToOverlay(teesepesango.Coordenadas()));
            manager.Update();
            MessageBox.Show("terminado");


        }

        private async void Actualizar(List<String> x)
        {

            while (Datos == null)
            {


                // QUE HACER CUANDO SE TIENEN LOS DATOS;
                await Task.Delay(250);
            }
            _thread.Abort();

            Grafo.Utils.Datos.VerificarDatos(x);
            teesepesango = Datos.TSP();

            manager.Main.Overlays.Add(manager.CoordinateArrayToOverlay(teesepesango.Coordenadas()));
            manager.Update();
            MessageBox.Show("terminado");

        


        }


        /// <summary>
        /// verifica datos osea nel pastel
        /// </summary>
        private void CargarDatos()
        {
            Grafo.Utils.Datos.VerificarDatos();
            Datos = Maps.Utils.SolicitarDatos(true);
        }

        private void CargarDatos(List<String> x)
        {
            Grafo.Utils.Datos.VerificarDatos(x);
            Datos = Maps.Utils.SolicitarDatos(true);
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
            //_marker = new GMarkerGoogle(new PointLatLng(double.Parse(Tlatitud.Text), double.Parse(Tlongitud.Text)), GMarkerGoogleType.green_dot);
            //_marker.ToolTipMode = MarkerTooltipMode.Always;
            //_marker.ToolTipText = string.Format("\n Lat: {0} \n Long:{1}", double.Parse(Tlatitud.Text), double.Parse(Tlongitud.Text));
            //_overlay.Markers.Add(_marker);
            //Map1.Overlays.Add(_overlay);
            //Map1.Position = _marker.Position;
            // Datos.Insertar(Tdireccionbusqueda.Text);
            string reginaltext = Tdireccionbusqueda.Text + " , Bolivia , Santa Cruz";
            Datos = null;
            manager.Fflush(Map1, "Restart");
            if (DBNAMES.Count == 0)
            {
                List<String> temp = Grafo.Utils.Datos.standarts();

                temp.Add(reginaltext);
                DBNAMES = temp;
                _thread = new Thread(() => CargarDatos(temp));
                _thread.Start();
                Actualizar(temp);
            }
            else
            {
                DBNAMES.Add(reginaltext);
                _thread = new Thread(() => CargarDatos(DBNAMES));
                _thread.Start();
                Actualizar(DBNAMES);
            }






        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            manager.BuildStandart();
        }

       

        private void Map1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = Map1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = Map1.FromLocalToLatLng(e.X, e.Y).Lng;
            Tlatitud.Text = lat.ToString();
            Tlongitud.Text = lng.ToString();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            if (manager.Main.Overlays.Count == 1)
            {
                manager.Main.Overlays.Add(new GMapOverlay());
            }

            manager.GenerarRutaExistencial();
            Tdistanciatotal.Text = (teesepesango.Distancia/1000).ToString()+" Km";
            double van = teesepesango.Tiempo;
            Ttempototal.Text = Timespliter(van);


        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            manager.Fflush(Map1,(ComboFflush.Text));
        }

        private void Baddposittion_Click(object sender, EventArgs e)
        {
            GMarkerGoogle aux = new GMarkerGoogle(new PointLatLng(Map1.Position.Lat, Map1.Position.Lng),
                GMarkerGoogleType.red_dot);
            aux.ToolTipText = "Index =" + (Map1.Overlays[0].Markers.Count + 1) + "\n" + "Lat = " + Math.Round(aux.Position.Lat, 5) + "\n Long = " + Math.Round(aux.Position.Lng, 5);
            Map1.Overlays[0].Markers.Add(aux);
            Map1.Update();
        }

        private void Bbruteforce_Click(object sender, EventArgs e)
        {
            manager.BruteForce();
        }

        private void Bbruteforce_Click_1(object sender, EventArgs e)
        {
            manager.Centrate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manager.ZoomInch(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manager.ZoomInch(-1);
        }

        public string Timespliter(double segundos)
        {
            TimeSpan aux=TimeSpan.FromSeconds(segundos);
            String final="H= "+aux.Hours.ToString()+" ,Min= "+aux.Minutes.ToString() + " ,Seg= " + aux.Seconds.ToString();

            return final;
        }
    }
}
