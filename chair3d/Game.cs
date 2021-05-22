using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace chair3d
{
    class Game
    {
        double theta = 0.0;
        GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }

        void Start()
        {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }

        void resize(object obj, EventArgs args)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
            Matrix4 matrix = Matrix4.Perspective(45.0f, window.Width / window.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void renderF(object obj, EventArgs args)
        {

            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Figura 1

            GL.PushMatrix();

            GL.Translate(0.0, 0.0, -50.0);
            GL.Rotate(theta, 0.0, 1.0, 0.0);
            //GL.Rotate(theta, 1.0, 0.0, 1.0);

            GL.Scale(0.7, 0.7, 0.7);

            //llamar a la figura

            silla();

            GL.PopMatrix();
            //Fin Figura 1

            window.SwapBuffers();
            theta += 1.0;

            if (theta > 360)
                theta -= 360;

        }

        void loaded(object obj, EventArgs args)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }

        void silla()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(80/255d, 55/255d, 22/255d);
            //GL.Color3(40/255d, 27/255d, 11/255d);

            //Bottom Asiento
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            //Left  Espalda
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            //Right Pata Delantera 1
            GL.Vertex3(10.0, -30.0, -10.0);
            GL.Vertex3(10.0, -30.0, -5.0);
            GL.Vertex3(10.0, -10.0, -5.0);
            GL.Vertex3(10.0, -10.0, -10.0);

            //Right Pata Delantera 2
            GL.Vertex3(10.0, -30.0, 10.0);
            GL.Vertex3(10.0, -30.0, 5.0);
            GL.Vertex3(10.0, -10.0, 5.0);
            GL.Vertex3(10.0, -10.0, 10.0);

            //Left Pata Trasera 1 
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -5.0);
            GL.Vertex3(-10.0, -30.0, -5.0);
            GL.Vertex3(-10.0, -30.0, -10.0);

            //Left Pata Trasera 2
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 5.0);
            GL.Vertex3(-10.0, -30.0, 5.0);
            GL.Vertex3(-10.0, -30.0, 10.0);

            GL.End();
        }

    }
}
