using System.Collections.Generic;
using OpenTK;

namespace LetraT3D.Tarea3
{
    internal class Parte
    {
        public Dictionary<string, Poligono> poligonos;
        private Vector3 origen;

        public Parte(float originX, float originY, float originZ)
        {
            origen = new Vector3(originX, originY, originZ);
            poligonos = new Dictionary<string, Poligono>();
        }

        public void AgregarPoligono(string nombre, Poligono poligono)
        {
            poligonos.Add(nombre, poligono);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Trasladar(x, y, z);
            }
        }

        public void Rotar(string eje, float angulo)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Rotar(eje, angulo);
            }
        }

        public void Escalar(float factor)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Escalar(factor);
            }
        }

        public void Dibujar(float offsetX, float offsetY, float offsetZ)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Dibujar(origen.X + offsetX, origen.Y + offsetY, origen.Z + offsetZ);
            }
        }
    }
}
