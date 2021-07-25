using System;
using System.IO;


namespace cc
{
    /// <summary>
    /// Timur Kovalev (http://www.creativecodedesign.com): This class watches the specified directory for new (previosuly unprocessed) files and 
    /// when a new file is discovered, it calls the specified delegate
    /// </summary>
    public class DirectoryWatcher : IDisposable
    {
        /// <summary>
        /// Defintion for a callback that will get called when a new file is found
        /// </summary>
        /// <param name="strFilePath">path to the new file</param>
        public delegate void NewFileCallback(string strFilePath);
        FileSystemWatcher m_oFSWatcher = null;                          // The object that will monitor for new files
        NewFileCallback m_oCallback = null;                             // A callback that will be fired when a new file is detected
        /// <summary>
        /// Instantiates a directory watcher for the specified directory and issues a callback when new files are discovered
        /// </summary>
        /// <param name="strDirectory">Directory that should be watched - note, the directory should already exist (or an exception will be thrown)</param>
        /// <param name="oCallback">a callback function that should be called when a new file is discovered</param>
        public DirectoryWatcher(string strDirectory, NewFileCallback oCallback)
        {
            m_oCallback = oCallback;                                                                // store the callback
            m_oFSWatcher = new FileSystemWatcher(strDirectory);
            m_oFSWatcher.Created += new FileSystemEventHandler(FileSystemObjectCreated);            // set up the callback when new objects are created            
            m_oFSWatcher.IncludeSubdirectories = false;                                             // don't look at subdirectories (change as needed)            
            m_oFSWatcher.EnableRaisingEvents = true;                                                // start the monitoring
        }
        /// <summary>
        /// Called by FileSystemWatcher object when a new file is found in the target directory
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event Data</param>
        private void FileSystemObjectCreated(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("Found File {0}", e.FullPath);
            FileInfo oFileInfo = new FileInfo(e.FullPath);                                          // get the file info
            while (true)                                                                            // a little hackery here.. :-/
            {
                try
                {
                    using(FileStream oStream = oFileInfo.OpenWrite());                              // try to open a file for write
                    break;                                                                          // 'using' will close the stream, so break
                }
                catch (IOException)                                                                 // and exception will occur if it is still being written to
                {
                    //Console.WriteLine("waiting for write completion...");
                    System.Threading.Thread.Sleep(1000);                                            // wait a seconds
                    continue;                                                                       // and try again...        
                }
            }            
            m_oCallback(e.FullPath);
        }
        /// <summary>
        /// Cleans up after the instance explicitly
        /// </summary>
        public void Dispose()
        {
            if (m_oFSWatcher != null)
            {
                m_oFSWatcher.EnableRaisingEvents = false;
                m_oFSWatcher.Dispose();
            }
        }
    }
}
