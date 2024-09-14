using System.Collections.Generic;
using OpenTK;

namespace LetraT3D.Tarea3
{
    internal class Objeto
    {
        public Dictionary<string, Parte> partes;
        private Vector3 origen;

        public Objeto(float originX, float originY, float originZ)
        {
            origen = new Vector3(originX, originY, originZ);
            partes = new Dictionary<string, Parte>();
        }

        public void AgregarParte(string nombre, Parte parte)
        {
            partes.Add(nombre, parte);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Trasladar(x, y, z);
            }
        }

        public void Rotar(string eje, float angulo)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Rotar(eje, angulo);
            }
        }

        public void Escalar(float factor)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Escalar(factor);
            }
        }

        public void Dibujar(float offsetX, float offsetY, float offsetZ)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Dibujar(origen.X + offsetX, origen.Y + offsetY, origen.Z + offsetZ);
            }
        }
    }
}
