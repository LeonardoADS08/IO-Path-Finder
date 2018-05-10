using Google.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grafo;

namespace IO_Path_Finder
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyCtcn_dJ3F-DfVCKyaO1-lTBIkoIbyZZYo"));

            Grafo.Grafo G = new Grafo.Grafo();
            G.Insertar("Universidad Privada de Santa Cruz de la Sierra, Bolivia");
            G.Insertar("Estadio Tahuichi Aguilera");
            G.Insertar("Avion Pirata");
            G.Insertar("Plaza 24 de Septiembre");
            G.Insertar("Ventura Mall, Santa Cruz de la Sierra, Bolivia");
            G.Insertar("Universidad Gabriel Rene Moreno, Santa Cruz de la Sierra, Bolivia");
            G.Insertar("Aeropuerto el trompillo");

            G.CompletarGrafo();
            Maps.Utils.GeolocalizarGrafo(G);
            G.Vertices.ForEach(x => Maps.Utils.Calcular(x));
            
            int a = 1;
        }
    }
}
