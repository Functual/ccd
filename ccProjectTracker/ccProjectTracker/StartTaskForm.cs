using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccProjectTracker
{
    public partial class StartTaskForm : Form
    {
        public bool Cancelled = true;
        private int _notifyPositionX = 0;
        private int _notifyPositionY = 0;
        ProjectTrackerState _instanceState = null;
        public StartTaskForm(ProjectTrackerState instanceState)
        {
            InitializeComponent();
            _instanceState = instanceState;
            uiExistingProjectsComboBox.DataSource = _instanceState.Projects;
            this.uiTaskDescription.Text = ccProjectTracker.Default.DefaultTaskDescription;
            if (_instanceState.CurrentTask == null)
                this.uiToolStripStatusLabel.Text = "";
            else
                this.uiToolStripStatusLabel.Text = "NOTE: Current Task will be terminated!";
            if (_notifyPositionX == 0 && _notifyPositionY == 0)
            {
                _notifyPositionX = Cursor.Position.X;
                _notifyPositionY = Cursor.Position.Y;
            }
            this.Left = _notifyPositionX - this.Width;
            this.Top = _notifyPositionY - this.Height - 50;            
        }
        /// <summary>
        /// Called when the user clicks "Go" to start a new task
        /// Preforms basic validation, and initiates a task upon success
        /// </summary>
        private void uiStartTaskButton_Click(object sender, EventArgs e)
        {
            string newProjectName = null;
            if (uiExistingProjectRadioButton.Checked)
            {
                newProjectName = uiExistingProjectsComboBox.Text;
                _instanceState.StartNewProjectTask(uiExistingProjectsComboBox.Text, uiTaskDescription.Text);

            }
            else if (uiNewProjectRadioButton.Checked)
            {
                // check if the project with specified name already exists, if not, create one and add a new current task
                newProjectName = uiNewProjectNameTextBox.Text;
                if (_instanceState.HasProject(newProjectName))
                {
                    MessageBox.Show(string.Format("Project '{0}' already exists. Please either use existing, or chose a different name!", newProjectName), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _instanceState.StartNewProjectTask(newProjectName, uiTaskDescription.Text);                
            }
            this.Cancelled = false;
            this.Close();
        }        

        private void uiNewProjectNameTextBox_Enter(object sender, EventArgs e)
        {
            uiNewProjectRadioButton.Checked = true;
        }

        private void uiExistingProjectsComboBox_Enter(object sender, EventArgs e)
        {
            uiExistingProjectRadioButton.Checked = true;
        }

        private void uiStartTaskCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
