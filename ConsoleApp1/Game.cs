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
using System.IO;

namespace LetraT3D
{
    public class Game : GameWindow
    {
        private Escenario escenario;
        private Objeto objetoT;
        private Objeto objetoT2;
        private Parte parteHorizontal;

        private float rotationAngle = 0.0f;

        public Game() : base(800, 600) // Constructor que define el tamaño de la ventana
        {
            escenario = new Escenario(0.0f, 0.0f, 0.0f);

            //Leer el JSON desde el archivo
            string json = File.ReadAllText(@"C:\Users\hp\Downloads\ProgramGrafica-Tarea3\ProgramGrafica-Tarea3\serializado.txt");
            objetoT = JsonConvert.DeserializeObject<Objeto>(json);
            escenario.AgregarObjeto("LetraT", objetoT);

            //objetoT2 = JsonConvert.DeserializeObject<Objeto>(json);
            //escenario.AgregarObjeto("LetraT2", objetoT2);

            // Aquí obtenemos la parte  del objeto para aplicar las transformaciones
            if (objetoT.partes.ContainsKey("horizontal"))
            {
                parteHorizontal = objetoT.partes["horizontal"];
            }

            /*
            // Partes de la T
            Parte horizontal = new Parte();
            Parte vertical = new Parte();

            // Caras
            Poligono caradelanteraH = new Poligono();
            Poligono caratraseraH = new Poligono();
            Poligono caraderechaH = new Poligono();
            Poligono caraizquierdaH = new Poligono();
            Poligono carainferiorH = new Poligono();
            Poligono carasuperiorH = new Poligono();

            Poligono caradelanteraV = new Poligono();
            Poligono caratraseraV = new Poligono();
            Poligono caraderechaV = new Poligono();
            Poligono caraizquierdaV = new Poligono();
            Poligono carainferiorV = new Poligono();
            Poligono carasuperiorV = new Poligono();

            // Armar el escenario
            escenario.AgregarObjeto("ObjetoT", objetoT);

            // Ensamblar T
            objetoT.AgregarParte("horizontal", horizontal);
            objetoT.AgregarParte("vertical", vertical);

            // Ensamblar partes
            horizontal.AgregarPoligono("caradelanteraH", caradelanteraH);
            horizontal.AgregarPoligono("caratraseraH", caratraseraH);
            horizontal.AgregarPoligono("caraderechaH", caraderechaH);
            horizontal.AgregarPoligono("caraizquierdaH", caraizquierdaH);
            horizontal.AgregarPoligono("carainferiorH", carainferiorH);
            horizontal.AgregarPoligono("carasuperiorH", carasuperiorH);


            vertical.AgregarPoligono("caradelanteraV", caradelanteraV);
            vertical.AgregarPoligono("caratraseraV", caratraseraV);
            vertical.AgregarPoligono("caraderechaV", caraderechaV);
            vertical.AgregarPoligono("caraizquierdaV", caraizquierdaV);
            vertical.AgregarPoligono("carainferiorV", carainferiorV);
            vertical.AgregarPoligono("carasuperiorV", carasuperiorV);


            // Vértices para la parte horizontal de la T
            Vertice[] punto1 = {

                //Cara delantera T

                new Vertice(-5, 4.5, 2.5), // Esquina superior izquierda
                new Vertice(5, 4.5, 2.5),  // Esquina superior derecha
                new Vertice(5, -2, 2.5),   // Esquina inferior derecha
                new Vertice(-5, -2, 2.5),  // Esquina inferior izquierda
            };
            caradelanteraH.LoadVertices(punto1);

            Vertice[] punto2 = {

                //Cara trasera T

                new Vertice(-5, 4.5, -2.5), // Esquina superior izquierda
                new Vertice(5, 4.5, -2.5),  // Esquina superior derecha
                new Vertice(5, -2, -2.5),   // Esquina inferior derecha
                new Vertice(-5, -2, -2.5),  // Esquina inferior izquierda
            };
            caratraseraH.LoadVertices(punto2);

            Vertice[] punto3 = {

                // Cara lateral derecha T

                new Vertice(5, 4.5, 2.5),
                new Vertice(5, 4.5, -2.5),
                new Vertice(5, -2, -2.5),
                new Vertice(5, -2, 2.5),

            };
            caraderechaH.LoadVertices(punto3);

            Vertice[] punto4 = {

                // Cara lateral izquierda T

                new Vertice(-5, 4.5, 2.5),
                new Vertice(-5, 4.5, -2.5),
                new Vertice(-5, -2, -2.5),
                new Vertice(-5, -2, 2.5),

            };
            caraizquierdaH.LoadVertices(punto4);

            Vertice[] punto5 = {

                // Cara inferior

                new Vertice(-5, -2, 2.5),
                new Vertice(-5, -2, -2.5),
                new Vertice(5, -2, -2.5),
                new Vertice(5, -2, 2.5),

            };
            carainferiorH.LoadVertices(punto5);

            Vertice[] punto6 = {

                // Cara superior

                new Vertice(-5, 4.5, 2.5),  
                new Vertice(-5, 4.5, -2.5), 
                new Vertice(5, 4.5, -2.5),   
                new Vertice(5, 4.5, 2.5),   

            };
            carasuperiorH.LoadVertices(punto6);


            // Vértices para la parte vertical de la T
            Vertice[] punto7 = {

                //cara delantera

                new Vertice(-2.5, 4.5, 2.5), // Esquina superior izquierda 
                new Vertice(2.5, 4.5, 2.5),  // Esquina superior derecha 
                new Vertice(2.5, -20, 2.5),   // Esquina inferior derecha 
                new Vertice(-2.5, -20, 2.5),  // Esquina inferior izquierda 

            };
            caradelanteraV.LoadVertices(punto7);

            Vertice[] punto8 = {

                //cara trasera
                
                new Vertice(-2.5, 4.5, -2.5),
                new Vertice(2.5, 4.5, -2.5),
                new Vertice(2.5, -20, -2.5),
                new Vertice(-2.5, -20, -2.5),

            };
            caratraseraV.LoadVertices(punto8);

            Vertice[] punto9 = {    

                //cara lado derecho

                new Vertice(2.5, 4.5, 2.5), // Esquina inferior izquierda 
                new Vertice(2.5, 4.5, -2.5),  // Esquina inferior derecha 
                new Vertice(2.5, -20, -2.5),   // Esquina superior derecha 
                new Vertice(2.5, -20, 2.5),  // Esquina superior izquierda 

            };
            caraderechaV.LoadVertices(punto9);

            Vertice[] punto10 = {

                // Cara lateral izquierda

                new Vertice(-2.5, 4.5, 2.5),
                new Vertice(-2.5, 4.5, -2.5),
                new Vertice(-2.5, -20, -2.5),
                new Vertice(-2.5, -20, 2.5),

            };
            caraizquierdaV.LoadVertices(punto10);

            Vertice[] punto11 = {

                // Cara superior

                new Vertice(-2.5, 4.5, 2.5),
                new Vertice(-2.5, 4.5, -2.5),
                new Vertice(2.5, 4.5, -2.5),
                new Vertice(2.5, 4.5, 2.5),

            };
            carasuperiorV.LoadVertices(punto11);

            Vertice[] punto12 = {

                // Cara inferior

                new Vertice(-2.5, -20, 2.5),   
                new Vertice(-2.5, -20, 2.5),
                new Vertice(2.5, -20, 2.5),
                new Vertice(2.5, -20, 2.5),
            };
            carainferiorV.LoadVertices(punto12);
            */

            //Serializa el objeto
            //SerializarObjeto(objetoT,@"C:\Users\hp\Downloads\ProgramGrafica-Tarea3\ProgramGrafica-Tarea3\serializado.txt");

        }


        private void SerializarObjeto(Objeto objeto, string filePath)
        {
            try
            {
                // Serializar el objeto a formato JSON
                string json = JsonConvert.SerializeObject(objeto, Formatting.Indented);

                // Guardar el JSON en un archivo .txt
                File.WriteAllText(filePath, json);

                Console.WriteLine("Serialización exitosa en: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de serialización: " + ex.Message);
            }
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

            // Aquí puedes mover, rotar o escalar tu escenario, objetos o partes
            objetoT.Trasladar(1.0f, 0.0f, 0.0f); 
            objetoT.Rotar("x", rotationAngle);  
            escenario.Escalar(0.0f);

            //if (parteHorizontal != null)
            //{
            //    parteHorizontal.Trasladar(1.0f, 0.0f, 0.0f);
            //    parteHorizontal.Rotar("z", rotationAngle);
            //    parteHorizontal.Escalar(1.0f);
            //}

            escenario.Dibujar();

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