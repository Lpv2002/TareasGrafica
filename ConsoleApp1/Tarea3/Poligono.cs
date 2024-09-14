using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LetraT3D
{
    // La clase Poligono representa una cara de un objeto tridimensional.
    public class Poligono
    {
        // Lista de vértices que forman el polígono.
        public List<Vertice> Vertices { get; set; }

        // Matriz de transformación para aplicar rotaciones, traslaciones y escalas.
        private Matrix4 MatrizTransformacion = Matrix4.Identity;

        // Constructor de la clase Poligono.
        public Poligono()
        {
            // Inicializa la lista de vértices.
            Vertices = new List<Vertice>();
        }

        // Método para trasladar el polígono.
        public void Trasladar(float x, float y, float z)
        {
            MatrizTransformacion = Matrix4.Mult(MatrizTransformacion, Matrix4.CreateTranslation(x, y, z));
        }

        // Método para escalar el polígono.
        public void Escalar(float factor)
        {
            MatrizTransformacion = Matrix4.Mult(MatrizTransformacion, Matrix4.CreateScale(factor));
        }

        // Método para rotar el polígono alrededor de un eje.
        public void Rotar(string eje, float angulo)
        {
            float radianes = MathHelper.DegreesToRadians(angulo);
            if (eje == "x")
                MatrizTransformacion = Matrix4.Mult(MatrizTransformacion, Matrix4.CreateRotationX(radianes));
            else if (eje == "y")
                MatrizTransformacion = Matrix4.Mult(MatrizTransformacion, Matrix4.CreateRotationY(radianes));
            else if (eje == "z")
                MatrizTransformacion = Matrix4.Mult(MatrizTransformacion, Matrix4.CreateRotationZ(radianes));
        }

        // Método para dibujar el polígono.
        public void Dibujar(float offsetX, float offsetY, float offsetZ)
        {
            // Comienza el dibujo del polígono.
            GL.Begin(PrimitiveType.Polygon);

            // Establece el color del polígono.
            SetColor();

            // Itera sobre los vértices y los dibuja aplicando la matriz de transformación.
            foreach (Vertice vertex in Vertices)
            {
                // Aplica la transformación al vértice.
                Vector4 vertexTransformado = Vector4.Transform(new Vector4((float)vertex.X, (float)vertex.Y, (float)vertex.Z, 1), MatrizTransformacion);
                GL.Vertex3(vertexTransformado.X + offsetX, vertexTransformado.Y + offsetY, vertexTransformado.Z + offsetZ);
            }

            // Finaliza el dibujo del polígono.
            GL.End();

            // Reinicia la matriz de transformación.
            MatrizTransformacion = Matrix4.Identity;
        }

        // Método para establecer el color del polígono.
        private void SetColor()
        {
            // Aquí se establecería el color utilizando OpenGL.
            // En este ejemplo, asumimos que el color es negro.
            GL.Color3(0.0f, 0.0f, 0.0f);
        }

        // Método para cargar los vértices en el polígono.
        public void LoadVertices(Vertice[] vertices)
        {
            // Agrega cada vértice a la lista de vértices del polígono.
            foreach (Vertice vertex in vertices)
            {
                Vertices.Add(vertex);
            }
        }
    }
}
