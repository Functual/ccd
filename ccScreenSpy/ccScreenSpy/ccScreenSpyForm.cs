using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ccScreenSpy
{
    public partial class ccScreenSpyForm : Form
    {
        private static Bitmap _screenshotBitmap = null;
        private static Graphics _screenshotGraphics = null;
        public ccScreenSpyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }
        /// <summary>
        /// Captures the screen into a file
        /// </summary>
        private void CaptureScreen()
        {
            foreach (Screen currentScreen in Screen.AllScreens)
            {
                string fileName = string.Format("{0}.png", DateTime.Now.ToString("yyyy.mm.dd.HH.mm.ss"));
                _screenshotBitmap = new Bitmap(currentScreen.Bounds.Width,currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                _screenshotGraphics = Graphics.FromImage(_screenshotBitmap);
                _screenshotGraphics.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0, 0, currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                _screenshotBitmap.Save(fileName, ImageFormat.Png);
            }            
        }
    }
}
