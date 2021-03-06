﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        private void thisFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this)).Show();
        }

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.scene)).Show();
        }

        private void gLCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.glCanvas1)).Show();
        }

        private void cameraManipulaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.cameraManipulater)).Show();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dlgSaveFile.FileName;
                Save2PictureHelper.Save2Picture(0, 0, glCanvas1.Width, glCanvas1.Height, filename);
                Process.Start("explorer", "/select, " + filename);
            }
        }

        private void startStopTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
        }

        private void sceneObjectsMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormSceneObjectListMonitor(this.scene)).Show();
        }

    }
}
