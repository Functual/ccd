namespace ccProjectTracker
{
    partial class StartTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiStartTaskButton = new System.Windows.Forms.Button();
            this.uiExistingProjectsComboBox = new System.Windows.Forms.ComboBox();
            this.uiStartTaskCancelButton = new System.Windows.Forms.Button();
            this.uiTaskDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiNewProjectNameTextBox = new System.Windows.Forms.TextBox();
            this.uiNewProjectRadioButton = new System.Windows.Forms.RadioButton();
            this.uiExistingProjectRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.uiToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiStartTaskButton
            // 
            this.uiStartTaskButton.Location = new System.Drawing.Point(142, 142);
            this.uiStartTaskButton.Name = "uiStartTaskButton";
            this.uiStartTaskButton.Size = new System.Drawing.Size(89, 23);
            this.uiStartTaskButton.TabIndex = 5;
            this.uiStartTaskButton.Text = "Go!";
            this.uiStartTaskButton.UseVisualStyleBackColor = true;
            this.uiStartTaskButton.Click += new System.EventHandler(this.uiStartTaskButton_Click);
            // 
            // uiExistingProjectsComboBox
            // 
            this.uiExistingProjectsComboBox.FormattingEnabled = true;
            this.uiExistingProjectsComboBox.Location = new System.Drawing.Point(114, 19);
            this.uiExistingProjectsComboBox.Name = "uiExistingProjectsComboBox";
            this.uiExistingProjectsComboBox.Size = new System.Drawing.Size(192, 21);
            this.uiExistingProjectsComboBox.TabIndex = 1;
            this.uiExistingProjectsComboBox.Enter += new System.EventHandler(this.uiExistingProjectsComboBox_Enter);
            // 
            // uiStartTaskCancelButton
            // 
            this.uiStartTaskCancelButton.Location = new System.Drawing.Point(237, 142);
            this.uiStartTaskCancelButton.Name = "uiStartTaskCancelButton";
            this.uiStartTaskCancelButton.Size = new System.Drawing.Size(89, 23);
            this.uiStartTaskCancelButton.TabIndex = 6;
            this.uiStartTaskCancelButton.Text = "Cancel";
            this.uiStartTaskCancelButton.UseVisualStyleBackColor = true;
            this.uiStartTaskCancelButton.Click += new System.EventHandler(this.uiStartTaskCancelButton_Click);
            // 
            // uiTaskDescription
            // 
            this.uiTaskDescription.Location = new System.Drawing.Point(6, 19);
            this.uiTaskDescription.Name = "uiTaskDescription";
            this.uiTaskDescription.Size = new System.Drawing.Size(288, 20);
            this.uiTaskDescription.TabIndex = 4;
            this.uiTaskDescription.Text = "General Task";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiExistingProjectsComboBox);
            this.groupBox1.Controls.Add(this.uiNewProjectNameTextBox);
            this.groupBox1.Controls.Add(this.uiNewProjectRadioButton);
            this.groupBox1.Controls.Add(this.uiExistingProjectRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 75);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which Project is this task for?";
            // 
            // uiNewProjectNameTextBox
            // 
            this.uiNewProjectNameTextBox.Location = new System.Drawing.Point(114, 46);
            this.uiNewProjectNameTextBox.Name = "uiNewProjectNameTextBox";
            this.uiNewProjectNameTextBox.Size = new System.Drawing.Size(192, 20);
            this.uiNewProjectNameTextBox.TabIndex = 3;
            this.uiNewProjectNameTextBox.Enter += new System.EventHandler(this.uiNewProjectNameTextBox_Enter);
            // 
            // uiNewProjectRadioButton
            // 
            this.uiNewProjectRadioButton.AutoSize = true;
            this.uiNewProjectRadioButton.Location = new System.Drawing.Point(6, 47);
            this.uiNewProjectRadioButton.Name = "uiNewProjectRadioButton";
            this.uiNewProjectRadioButton.Size = new System.Drawing.Size(67, 17);
            this.uiNewProjectRadioButton.TabIndex = 2;
            this.uiNewProjectRadioButton.Text = "New Project";
            this.uiNewProjectRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiExistingProjectRadioButton
            // 
            this.uiExistingProjectRadioButton.AutoSize = true;
            this.uiExistingProjectRadioButton.Checked = true;
            this.uiExistingProjectRadioButton.Location = new System.Drawing.Point(6, 20);
            this.uiExistingProjectRadioButton.Name = "uiExistingProjectRadioButton";
            this.uiExistingProjectRadioButton.Size = new System.Drawing.Size(81, 17);
            this.uiExistingProjectRadioButton.TabIndex = 0;
            this.uiExistingProjectRadioButton.TabStop = true;
            this.uiExistingProjectRadioButton.Text = "Existing Project";
            this.uiExistingProjectRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiTaskDescription);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 49);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task Description (Optional): ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 201);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(334, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // uiToolStripStatusLabel
            // 
            this.uiToolStripStatusLabel.Name = "uiToolStripStatusLabel";
            this.uiToolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.uiToolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.uiToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // StartTaskForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(334, 223);
            this.ControlBox = false;
            this.Controls.Add(this.uiStartTaskButton);
            this.Controls.Add(this.uiStartTaskCancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Start a New Task";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiStartTaskButton;
        private System.Windows.Forms.ComboBox uiExistingProjectsComboBox;
        private System.Windows.Forms.Button uiStartTaskCancelButton;
        private System.Windows.Forms.TextBox uiTaskDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox uiNewProjectNameTextBox;
        private System.Windows.Forms.RadioButton uiNewProjectRadioButton;
        private System.Windows.Forms.RadioButton uiExistingProjectRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel uiToolStripStatusLabel;
    }
}