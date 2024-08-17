using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace practica1
{
    internal class dibujoT
    {
        public float x;
        public float y;
        public float z;
        public Vector3 pos;

        public dibujoT(float x, float y, float z, Vector3 posi)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            pos = posi;
        }

        public void dibujar()
        {
            float ancho = 0.4f;
            float alto = 0.4f;
            float grosor = 0.1f;

            GL.Begin(PrimitiveType.Quads);

            // Parte horizontal de la "T" - Delante
            GL.Color4(Color.White);
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior izquierdo
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior derecho
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior derecho
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior izquierdo

            // Parte vertical de la "T" - Delante
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Superior izquierdo
            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Superior derecho
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior derecho
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior izquierdo

            // Parte horizontal de la "T" - Atrás
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior izquierdo
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior derecho
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior derecho
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior izquierdo

            // Parte vertical de la "T" - Atrás
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Superior izquierdo
            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Superior derecho
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior derecho
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior izquierdo

            GL.End();

            GL.Begin(PrimitiveType.QuadStrip);

            // Uniendo parte delantera con trasera
            // Parte horizontal
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2);
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2);

            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2);
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2);

            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2);
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2);

            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2);
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2);

            // Parte vertical
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2);
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2);

            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2);
            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2);

            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2);
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2);

            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2);
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2);

            GL.End();
        }
    }
}
