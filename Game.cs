using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using LetraT3D.Tarea3;
using Newtonsoft.Json;

namespace LetraT3D
{
    public class Game : GameWindow
    {
        private Escenario Escenario1;
        private float rotationAngle = 0.0f;

        public Game() : base(800, 600) // Constructor que define el tamaño de la ventana
        {
            Escenario1 = new Escenario(0.0f, 0.0f, 0.0f);
            Objeto objetoT = new Objeto(0.0f, 0.0f, 0.0f);

            // Partes de la T
            Parte horizontal = new Parte();
            Parte vertical = new Parte();

            // Caras
            Poligono horizontalT = new Poligono();
            Poligono verticalT = new Poligono();

            // Armar el escenario
            Escenario1.AgregarObjeto("ObjetoT", objetoT);

            // Ensamblar T
            objetoT.AgregarParte("horizontal", horizontal);
            objetoT.AgregarParte("vertical", vertical);

            // Ensamblar partes
            horizontal.AgregarPoligono("horizontal", horizontalT);
            vertical.AgregarPoligono("vertical", verticalT);

            // Vértices para la parte horizontal de la T
            Vertice[] v1 = {

                //Cara delantera T

                new Vertice(-5, 4.5, 2.5), // Esquina superior izquierda
                new Vertice(5, 4.5, 2.5),  // Esquina superior derecha
                new Vertice(5, -2, 2.5),   // Esquina inferior derecha
                new Vertice(-5, -2, 2.5),  // Esquina inferior izquierda

                //Cara trasera T

                new Vertice(-5, 4.5, -2.5), // Esquina superior izquierda
                new Vertice(5, 4.5, -2.5),  // Esquina superior derecha
                new Vertice(5, -2, -2.5),   // Esquina inferior derecha
                new Vertice(-5, -2, -2.5),  // Esquina inferior izquierda

                // Cara lateral derecha T

                new Vertice(5, 4.5, 2.5),   
                new Vertice(5, 4.5, -2.5),
                new Vertice(5, -2, -2.5),
                new Vertice(5, -2, 2.5),

                // Cara lateral izquierda T

                new Vertice(-5, 4.5, 2.5),
                new Vertice(-5, 4.5, -2.5),
                new Vertice(-5, -2, -2.5),
                new Vertice(-5, -2, 2.5),

                // Cara inferior

                new Vertice(-5, -2, 2.5),                
                new Vertice(-5, -2, -2.5),  
                new Vertice(5, -2, -2.5),  
                new Vertice(5, -2, 2.5),   

                // Cara superior

                new Vertice(-5, 2, 2.5),  
                new Vertice(-5, 2, -2.5), 
                new Vertice(5, 2, -2.5),   
                new Vertice(5, 2, 2.5),   

            };
            horizontalT.LoadVertices(v1);

            // Vértices para la parte vertical de la T
            Vertice[] v2 = {

                //cara delantera

                new Vertice(-2.5, 3.5, 2.5), // Esquina superior izquierda 
                new Vertice(2.5, 3.5, 2.5),  // Esquina superior derecha 
                new Vertice(2.5, -20, 2.5),   // Esquina inferior derecha 
                new Vertice(-2.5, -20, 2.5),  // Esquina inferior izquierda 

                //cara trasera
                
                new Vertice(-2.5, 3.5, -2.5),  
                new Vertice(2.5, 3.5, -2.5),
                new Vertice(2.5, -20, -2.5),
                new Vertice(-2.5, -20, -2.5),

                //cara lado derecho

                new Vertice(2.5, 4.5, 2.5), // Esquina inferior izquierda 
                new Vertice(2.5, 4.5, -2.5),  // Esquina inferior derecha 
                new Vertice(2.5, -20, -2.5),   // Esquina superior derecha 
                new Vertice(2.5, -20, 2.5),  // Esquina superior izquierda 

                

                new Vertice(-2.5, 4.5, 2.5),   // Cara lateral derecha
                new Vertice(-2.5, 4.5, -2.5),
                new Vertice(-2.5, -20, -2.5),
                new Vertice(-2.5, -20, 2.5),

                new Vertice(-2.5, 4.5, 2.5),    // Cara superior
                new Vertice(-2.5, 4.5, -2.5),
                new Vertice(2.5, 4.5, -2.5),
                new Vertice(2.5, 4.5, 2.5),

                new Vertice(-2.5, -20, 2.5),   // Cara lateral izquierda
                new Vertice(-2.5, -20, 2.5),
                new Vertice(2.5, -20, 2.5),
                new Vertice(2.5, -20, 2.5),
            };
            verticalT.LoadVertices(v2);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.FromArgb(135, 206, 235));
            GL.Enable(EnableCap.DepthTest); // Profundidad
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            rotationAngle += 60.5f * (float)e.Time; // Rotación
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Frustum(-1.0, 1.0, -1.0, 1.0, 1.0, 100.0); // Proyección perspectiva
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Posiciona y orienta la cámara
            GL.Translate(0.0f, 0.0f, -30.0f); // Mueve la cámara más hacia atrás
            GL.Rotate(20.0f, 1.0f, 0.0f, 0.0f); // Inclina la vista hacia abajo
            GL.Rotate(40.0f + rotationAngle, 0.0f, 1.0f, 0.0f); // Rota la vista hacia un ángulo lateral

            Escenario1.Dibujar();

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Ajustar la vista en caso de que se redimensione la ventana
            GL.Viewport(0, 0, Width, Height);
        }
    }
}
