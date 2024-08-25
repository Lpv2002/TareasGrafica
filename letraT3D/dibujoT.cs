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
            float ancho = 0.5f;
            float alto = 0.5f;
            float grosor = 0.2f;

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

            GL.Begin(PrimitiveType.Quads);

            // Uniendo parte delantera con trasera
            // Parte horizontal arriba

            GL.Color4(Color.Red);
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior izquierdo - delante
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior izquierdo - atrás
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior derecho - atrás
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior derecho - delante

            //parte horizontal abajo

            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior izquierdo - delante
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior izquierdo - atrás
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior derecho - atrás
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior derecho - delante

            //parte horizontal derecha

            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior derecho - delante
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior derecho - atrás
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior derecho - atrás 
            GL.Vertex3(pos.X + ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior derecho - delante 

            //parte horizontal izquierda

            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z + grosor / 2); // Superior izquierda - delante 
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2, pos.Z - grosor / 2); // Superior izquierda - atrás 
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Inferior izquierda - atrás 
            GL.Vertex3(pos.X - ancho / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Inferior izquierda - delante 


            // Parte vertical derecha
            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Superior derecha - delante
            GL.Vertex3(pos.X + grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Superior derecha - atrás
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior derecha - atrás
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior derecha - delante

            // Parte vertical izquierda
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z + grosor / 2); // Superior izquierda - delante
            GL.Vertex3(pos.X - grosor / 2, pos.Y + alto / 2 - grosor, pos.Z - grosor / 2); // Superior izquierda - atrás
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior izquierda - atrás
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior izquierda - delante

            //parte vertical inferior 
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior derecha - delante
            GL.Vertex3(pos.X - grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior derecha - atrás
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z - grosor / 2); // Inferior izquierda - atrás
            GL.Vertex3(pos.X + grosor / 2, pos.Y - alto / 2, pos.Z + grosor / 2); // Inferior izquierda - delante

            GL.End();
        }
    }
}
