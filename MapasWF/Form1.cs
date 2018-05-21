﻿using System;
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

        MapFormManager manager;

        Grafo.Grafo Datos;
        Thread _thread;
        public Form1()
        {
            InitializeComponent();
            manager = new MapFormManager(Map1);
            Map1.OnMapDrag += Map1_OnMapDrag;
            Map1.OnMarkerClick += Map1_OnMarkerClick;
            Map1.OnRouteClick += Map1_OnRouteClick;

            ComboFflush.SelectedIndex = 0;
           


            // Grafo
            _thread = new Thread(() => CargarDatos());
            _thread.Start();
            Actualizar();
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
            manager.Main.Overlays.Add(manager.CoordinateArrayToOverlay(Datos.Coordenadas()));
            manager.Update();

        }

        private void CargarDatos()
        {
            Grafo.Utils.Datos.VerificarDatos();
            Datos = Maps.Utils.SolicitarDatos();
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
            Map1.SetPositionByKeywords(Tdireccionbusqueda.Text);
            Map1.Overlays[0].Markers.Add(new GMarkerGoogle(new PointLatLng(Map1.Position.Lat, Map1.Position.Lng),
                GMarkerGoogleType.red_dot));
            Map1.Update();



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


        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            manager.Fflush(Map1,(ComboFflush.Text));
        }

      
    }
}
