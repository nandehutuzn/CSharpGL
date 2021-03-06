﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form10RaycastVolumeRenderer : Form
    {

        private Camera camera;
        private SatelliteManipulater rotator;
        private RaycastVolumeRenderer renderer;


        public Form10RaycastVolumeRenderer()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            RenderEventArg arg = new RenderEventArg(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);
            RaycastVolumeRenderer renderer = this.renderer;
            if (renderer != null)
            {
                mat4 mvp = arg.Camera.GetProjectionMat4() * arg.Camera.GetViewMat4();
                renderer.SetMVP(mvp);

                renderer.Render(arg);
            }

            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(mousePosition.X - offset.X,
                this.glCanvas1.Height - (mousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }

        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);

        //void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    ICamera camera = this.camera;
        //    if (camera != null)
        //    {
        //        camera.MouseWheel(e.Delta);
        //    }
        //}

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }

    }

}
