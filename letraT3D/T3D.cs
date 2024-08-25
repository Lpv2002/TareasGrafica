using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica1
{
   public class T3D: GameWindow

    {
        private practica1.dibujoT T;
        public T3D(int WIDTH , int HEIGHT, string mititulo): base(WIDTH, HEIGHT, GraphicsMode.Default, mititulo)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

       
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.ClearColor(Color4.Gray);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            T = new practica1.dibujoT(0,0,0,new Vector3(0.0f,0.0f,0.0f));
            T.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.Rotate(1.0f, 0.0f, 0.1f, 0.0f);
            base.OnUpdateFrame(e);
        }


    }
}
