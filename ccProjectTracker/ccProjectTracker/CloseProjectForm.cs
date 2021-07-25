using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ccProjectTracker
{
    public partial class CloseProjectForm : Form
    {
        Project _project = null;
        public bool Cancelled = true;
        public CloseProjectForm(Project project)
        {
            InitializeComponent();
            _project = project;
            this.Text = string.Format("Close Project: {0}", _project.Name);
            uiProjectTasksDataGridView.DataSource = _project.Tasks;
            // Set the duration textbox
            var durationSum = (from currentTask in _project.Tasks select currentTask.Duration).Sum();
            uiTotalDurationTextBox.Text = durationSum.ToString();
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void uiCloseProjectButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this project? The project and its tasks will be permanently removed from Project Tracker!", 
                "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cancelled = false;
                this.Close();
            }
        }

        private void uiExportButton_Click(object sender, EventArgs e)
        {
            StringBuilder csvText = new StringBuilder("Description,Start Time,End Time,Duration in Minutes\r\n");
            foreach (ProjectTask currentTask in _project.Tasks)
                csvText.Append(string.Format("{0},{1},{2},{3}\r\n", currentTask.Description, currentTask.StartTime, currentTask.EndTime, currentTask.Duration));            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveDialog.FileName, csvText.ToString());
            MessageBox.Show("Project tasks exported successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
