using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Maps
{
    public class Utils
    {
        public static bool Cargado = false;
        static Utils()
        {
            // GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyCtcn_dJ3F-DfVCKyaO1-lTBIkoIbyZZYo"));
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyCcGVtsZ0A0QHv8Kq04Uh6fCke2ajKLbvQ"));
              //GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyDG4k1RT9mdKFtSlUC5D0K04_IXCtyb2po"));
            

            Cargado = true;
        }

        public static void GeolocalizarGrafo(Grafo.Grafo G)
        {
            foreach (var val in G.Vertices)
            {
                var geoRequest = new GeocodingRequest();
                geoRequest.Address = val.Nombre;
                var geoResponse = new GeocodingService().GetResponse(geoRequest);

                if (geoResponse.Status == ServiceResponseStatus.Ok && geoResponse.Results.Count() > 0)
                {
                    var result = geoResponse.Results.First();

                    val.Alias = result.FormattedAddress;
                    val.Latitud = result.Geometry.Location.Latitude;
                    val.Longitud = result.Geometry.Location.Longitude;
                }
                else
                {
                    Debug.WriteLine("No fue posible geolocalizar la posicion :c");
                }
            }
        }


        public static void Calcular(Grafo.Vertice V)
        {
            
            foreach (var val in V.Aristas)
            {
                Google.Maps.DistanceMatrix.DistanceMatrixRequest distanceRequest = new Google.Maps.DistanceMatrix.DistanceMatrixRequest()
                {
                    WaypointsOrigin = new List<Google.Maps.Location> { new Google.Maps.LatLng(V.Latitud, V.Longitud) },
                    WaypointsDestination = new List<Google.Maps.Location> { new Google.Maps.LatLng(val.Fin.Latitud, val.Fin.Longitud) },
                    Mode = TravelMode.driving,
                    Units = Units.metric
                };

                try
                {
                    var response = new Google.Maps.DistanceMatrix.DistanceMatrixService().GetResponse(distanceRequest);
                    val.Costo = Convert.ToDouble(response.Rows.First().Elements.First().distance.Value);
                    val.Tiempo = Convert.ToDouble(response.Rows.First().Elements.First().duration.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("No fue posible hallar la distancia :c");
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public static Grafo.Grafo SolicitarDatos(bool calcularDistancias = false)
        {
            Grafo.Grafo res = new Grafo.Grafo();
            res.CargarGrafo();
            GeolocalizarGrafo(res);
            if (calcularDistancias)
            {
                foreach (var val in res.Vertices)
                {
                    Calcular(val);
                }
            }
            return res;
        }
    }
}
