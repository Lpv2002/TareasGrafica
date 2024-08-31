using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraT3D.Tarea3
{
    internal class Parte
    {
        public Dictionary<string, Poligono> poligonos;

        public Parte()
        {
            poligonos = new Dictionary<string, Poligono>();
        }

        public void AgregarPoligono(string nombre, Poligono poligono1)
        {
            poligonos.Add(nombre, poligono1);
        }

        public void Dibujar(float offsetX, float offsetY, float offsetZ)
        {
            foreach (Poligono poligonos in poligonos.Values)
            {
                poligonos.Draw(offsetX, offsetY, offsetZ);
            }
        }
    }
}
