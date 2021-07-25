using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ccProjectTracker
{
    public partial class InvisibleForm : Form
    {
        private ProjectTrackerState _instanceState = ProjectTrackerState.LoadFromFile("ccProjectTracker.xml");
        private int _notifyPositionX = 0;
        private int _notifyPositionY = 0;
        public InvisibleForm()
        {
            InitializeComponent();            
            GenerateProjectMenu();
            //uiTrayIcon.ShowBalloonTip(1000, "Still There?", "Click here if still working..", ToolTipIcon.Info);
            /*
            Thread workerThread = new Thread(() =>
            {
                MessageBox.Show("Still Working on stuffs?", "Hey there!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);                
            });
            workerThread.Start();
            Thread.Sleep(1000);
            if (workerThread.IsAlive)
                workerThread.Abort();
             */
            //System.Threading.Timer taksTimer = new System.Threading.Timer(TimerCallback, null, 1000, 1000); 
        }
        /// <summary>
        /// Fires whenever the timer gets to the next roudning period
        /// </summary>
        /// <param name="state">null</param>
        public void TimerCallback(object state)
        {
            Thread workerThread = new Thread(() =>
            {
                MessageBox.Show("Still Working on stuffs?", "Hey there!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            });
            workerThread.Start();
            Thread.Sleep(1000);
            if (workerThread.IsAlive)
                workerThread.Abort();
        }

        private void GenerateProjectMenu()
        {            
            closeTaskToolStripMenuItem.DropDownItems.Clear();
            foreach (Project currentProject in _instanceState.Projects)
            {
                ToolStripMenuItem currentItem = new ToolStripMenuItem();
                currentItem.Text = currentProject.Name;
                currentItem.Click += new EventHandler(CloseProjectClickEventHandler);
                closeTaskToolStripMenuItem.DropDownItems.Add(currentItem);
            }
        }

        /// <summary>
        /// Is called when the user selects a project to close out
        /// </summary>
        private void CloseProjectClickEventHandler(object sender, EventArgs e)
        {            
            closeTaskToolStripMenuItem.Enabled = false;                     // Disable the menu
            startTaskToolStripMenuItem.Enabled = false;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            Project selectedProject = _instanceState.GetProject(clickedItem.Text);
            CloseProjectForm closeProjectForm = new CloseProjectForm(selectedProject);
            closeProjectForm.ShowDialog();
            if (!closeProjectForm.Cancelled)
            {
                if (selectedProject.Tasks.Contains(_instanceState.CurrentTask))
                    endTaskToolStripMenuItem_Click(null, null);                     // this terminates the current task!
                _instanceState.RemoveProject(selectedProject);
                _instanceState.SaveState();
                GenerateProjectMenu();
            }            
            closeTaskToolStripMenuItem.Enabled = true;
            startTaskToolStripMenuItem.Enabled = true;

        }
        /// <summary>
        /// Handles the tray icon double click. If task in progress, confirm and stop, if 
        /// no task in progress, bring up start task dialog
        /// </summary>
        private void uiTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _notifyPositionX = Cursor.Position.X;
            _notifyPositionY = Cursor.Position.Y;
            startTaskToolStripMenuItem_Click(sender, e);            
        }
        /// <summary>
        /// Terminates the currently running task (if any) and exits the application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Brings up the start new task dialog
        /// </summary>
        private void startTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.startTaskToolStripMenuItem.Enabled)                           // in case user double-clicks notify icon
                return;
            ToggleInput(false);                                                     // disable menu intput
            StartTaskForm startTaskForm = new StartTaskForm(_instanceState);
            startTaskForm.ShowDialog();
            ToggleInput(true);
            if (!startTaskForm.Cancelled)
            {
                GenerateProjectMenu();
                this.uiTrayIcon.Text = string.Format("Project Tracker: Working on project '{0}'", _instanceState.LastKnownProject);
            }
            ToggleEndTaskMenu();            // make sure the end task menu is ok 
        }
        /// <summary>
        /// Disables all menu items that allow us to bring up a dialog of any kind
        /// </summary>
        public void ToggleInput(bool enabledState)
        {
            this.startTaskToolStripMenuItem.Enabled = enabledState;
            this.endTaskToolStripMenuItem.Enabled = enabledState;
            this.closeTaskToolStripMenuItem.Enabled = enabledState;
        }
        /// <summary>
        /// Disables or enables the End Task menu depending on whether there is a task currently open
        /// (this is a solution for if a user want to start a new task while doing another task, but then cancels out of the box..
        /// </summary>
        public void ToggleEndTaskMenu()
        {
            if (_instanceState.CurrentTask == null)
                this.endTaskToolStripMenuItem.Enabled = false;
            else
                this.endTaskToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// Terminates the current task, and save current state
        /// </summary>
        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _instanceState.EndCurrentProjectTask();
            this.uiTrayIcon.Text = "Project Tracker - Idle";
            ToggleEndTaskMenu();
        }
        /// <summary>
        /// Closes the task - tallies up all the recorded task periods and generates a csv
        /// This will actually have no click, but the existing task menu will be generated dynamically
        /// </summary>
        private void closeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // #TODO#
        }
        /// <summary>
        /// Saves the current state and current timing values
        /// </summary>
        private void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _instanceState.SaveState();
        }                
    }
}
