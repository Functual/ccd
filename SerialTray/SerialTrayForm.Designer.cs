namespace SerialTray
{
    partial class SerialTrayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialTrayForm));
            this.m_uiSystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_uiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // m_uiSystemTrayIcon
            // 
            this.m_uiSystemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_uiSystemTrayIcon.Icon")));
            this.m_uiSystemTrayIcon.Text = "Right-Click to View Ports";
            this.m_uiSystemTrayIcon.Visible = true;
            // 
            // m_uiContextMenu
            // 
            this.m_uiContextMenu.Name = "m_uiContextMenu";
            this.m_uiContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // SerialTrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ContextMenuStrip = this.m_uiContextMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialTrayForm";
            this.ShowInTaskbar = false;
            this.Text = "SerialTray Window";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon m_uiSystemTrayIcon;
        private System.Windows.Forms.ContextMenuStrip m_uiContextMenu;
    }
}

