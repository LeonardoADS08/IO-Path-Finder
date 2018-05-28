using System;
using System.Collections.Generic;
using System.Text;

namespace Grafo
{
    public class Estados : Dictionary<string, bool>
    {
        public Estados(Grafo G) => G.Vertices.ForEach(x => this.Add(x.Nombre, false));
    }
}
