namespace ccProjectTracker
{
    partial class InvisibleForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvisibleForm));
            this.uiTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.uiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTrayIcon
            // 
            this.uiTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.uiTrayIcon.BalloonTipText = "Project Tracker";
            this.uiTrayIcon.ContextMenuStrip = this.uiContextMenu;
            this.uiTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("uiTrayIcon.Icon")));
            this.uiTrayIcon.Text = "Project Tracker";
            this.uiTrayIcon.Visible = true;
            this.uiTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.uiTrayIcon_MouseDoubleClick);
            // 
            // uiContextMenu
            // 
            this.uiContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTaskToolStripMenuItem,
            this.endTaskToolStripMenuItem,
            this.closeTaskToolStripMenuItem,
            this.saveStateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.uiContextMenu.Name = "uiContextMenu";
            this.uiContextMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // startTaskToolStripMenuItem
            // 
            this.startTaskToolStripMenuItem.Name = "startTaskToolStripMenuItem";
            this.startTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startTaskToolStripMenuItem.Text = "Start Task";
            this.startTaskToolStripMenuItem.Click += new System.EventHandler(this.startTaskToolStripMenuItem_Click);
            // 
            // endTaskToolStripMenuItem
            // 
            this.endTaskToolStripMenuItem.Enabled = false;
            this.endTaskToolStripMenuItem.Name = "endTaskToolStripMenuItem";
            this.endTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.endTaskToolStripMenuItem.Text = "End Task";
            this.endTaskToolStripMenuItem.Click += new System.EventHandler(this.endTaskToolStripMenuItem_Click);
            // 
            // closeTaskToolStripMenuItem
            // 
            this.closeTaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdToolStripMenuItem});
            this.closeTaskToolStripMenuItem.Name = "closeTaskToolStripMenuItem";
            this.closeTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeTaskToolStripMenuItem.Text = "Close Project";
            this.closeTaskToolStripMenuItem.Click += new System.EventHandler(this.closeTaskToolStripMenuItem_Click);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.asdToolStripMenuItem.Text = "asd";
            // 
            // saveStateToolStripMenuItem
            // 
            this.saveStateToolStripMenuItem.Name = "saveStateToolStripMenuItem";
            this.saveStateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveStateToolStripMenuItem.Text = "Save State";
            this.saveStateToolStripMenuItem.Click += new System.EventHandler(this.saveStateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // InvisibleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(325, 194);
            this.ContextMenuStrip = this.uiContextMenu;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InvisibleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.uiContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon uiTrayIcon;
        private System.Windows.Forms.ContextMenuStrip uiContextMenu;
        private System.Windows.Forms.ToolStripMenuItem startTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
    }
}

