using System.Collections.Generic;
using OpenTK;

namespace LetraT3D.Tarea3
{
    internal class Escenario
    {
        public Dictionary<string, Objeto> objetos;
        private Vector3 origen;

        public Escenario(float originX, float originY, float originZ)
        {
            origen = new Vector3(originX, originY, originZ);
            objetos = new Dictionary<string, Objeto>();
        }

        public void AgregarObjeto(string nombre, Objeto objeto)
        {
            objetos.Add(nombre, objeto);
        }

        public void DeleteObjeto(string nombre)
        {
            objetos.Remove(nombre);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Trasladar(x, y, z);
            }
        }

        public void Rotar(string eje, float angulo)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Rotar(eje, angulo);
            }
        }

        public void Escalar(float factor)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Escalar(factor);
            }
        }

        public void Dibujar()
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Dibujar(origen.X, origen.Y, origen.Z);
            }
        }
    }
}
