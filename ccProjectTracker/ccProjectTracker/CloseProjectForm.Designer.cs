namespace ccProjectTracker
{
    partial class CloseProjectForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiProjectTasksDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiExportButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTotalDurationTextBox = new System.Windows.Forms.TextBox();
            this.uiCloseProjectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProjectTasksDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiProjectTasksDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(703, 262);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 0;
            // 
            // uiProjectTasksDataGridView
            // 
            this.uiProjectTasksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiProjectTasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiProjectTasksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiProjectTasksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uiProjectTasksDataGridView.Name = "uiProjectTasksDataGridView";
            this.uiProjectTasksDataGridView.Size = new System.Drawing.Size(703, 201);
            this.uiProjectTasksDataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiCloseProjectButton);
            this.groupBox1.Controls.Add(this.uiTotalDurationTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.uiCancelButton);
            this.groupBox1.Controls.Add(this.uiExportButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // uiExportButton
            // 
            this.uiExportButton.Location = new System.Drawing.Point(12, 19);
            this.uiExportButton.Name = "uiExportButton";
            this.uiExportButton.Size = new System.Drawing.Size(118, 23);
            this.uiExportButton.TabIndex = 0;
            this.uiExportButton.Text = "Export to CSV";
            this.uiExportButton.UseVisualStyleBackColor = true;
            this.uiExportButton.Click += new System.EventHandler(this.uiExportButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(260, 19);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(118, 23);
            this.uiCancelButton.TabIndex = 1;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Duration (minutes): ";
            // 
            // uiTotalDurationTextBox
            // 
            this.uiTotalDurationTextBox.Location = new System.Drawing.Point(641, 21);
            this.uiTotalDurationTextBox.Name = "uiTotalDurationTextBox";
            this.uiTotalDurationTextBox.Size = new System.Drawing.Size(56, 20);
            this.uiTotalDurationTextBox.TabIndex = 3;
            // 
            // uiCloseProjectButton
            // 
            this.uiCloseProjectButton.Location = new System.Drawing.Point(136, 19);
            this.uiCloseProjectButton.Name = "uiCloseProjectButton";
            this.uiCloseProjectButton.Size = new System.Drawing.Size(118, 23);
            this.uiCloseProjectButton.TabIndex = 4;
            this.uiCloseProjectButton.Text = "Close Project";
            this.uiCloseProjectButton.UseVisualStyleBackColor = true;
            this.uiCloseProjectButton.Click += new System.EventHandler(this.uiCloseProjectButton_Click);
            // 
            // CloseProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CloseProjectForm";
            this.Text = "Close Project";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiProjectTasksDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView uiProjectTasksDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.Button uiExportButton;
        private System.Windows.Forms.TextBox uiTotalDurationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiCloseProjectButton;
    }
}