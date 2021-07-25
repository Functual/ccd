namespace cc.ccQuickMint
{
    partial class ccQuickMintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ccQuickMintForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiLoadButton = new System.Windows.Forms.Button();
            this.uiMintFilePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiApplyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uiAccountNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiAccountDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiAccountTypeCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiAccountNameCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiAccountTransactions = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.uiIgnoreTransferCheckbox = new System.Windows.Forms.CheckBox();
            this.uiTransactionStartId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiExportButton = new System.Windows.Forms.Button();
            this.uiExportAccountInfo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAccountTransactions)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiLoadButton);
            this.groupBox1.Controls.Add(this.uiMintFilePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load MINT Transaction File: ";
            // 
            // uiLoadButton
            // 
            this.uiLoadButton.Location = new System.Drawing.Point(896, 17);
            this.uiLoadButton.Name = "uiLoadButton";
            this.uiLoadButton.Size = new System.Drawing.Size(75, 23);
            this.uiLoadButton.TabIndex = 2;
            this.uiLoadButton.Text = "Load";
            this.uiLoadButton.UseVisualStyleBackColor = true;
            this.uiLoadButton.Click += new System.EventHandler(this.uiLoadButton_Click);
            // 
            // uiMintFilePath
            // 
            this.uiMintFilePath.Location = new System.Drawing.Point(6, 19);
            this.uiMintFilePath.Name = "uiMintFilePath";
            this.uiMintFilePath.Size = new System.Drawing.Size(884, 20);
            this.uiMintFilePath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiApplyButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.uiAccountNumber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.uiAccountDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.uiAccountTypeCombo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.uiAccountNameCombo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.uiAccountTransactions);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(977, 325);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imported Account Details: ";
            // 
            // uiApplyButton
            // 
            this.uiApplyButton.Location = new System.Drawing.Point(896, 30);
            this.uiApplyButton.Name = "uiApplyButton";
            this.uiApplyButton.Size = new System.Drawing.Size(75, 23);
            this.uiApplyButton.TabIndex = 10;
            this.uiApplyButton.Text = "Apply";
            this.uiApplyButton.UseVisualStyleBackColor = true;
            this.uiApplyButton.Click += new System.EventHandler(this.uiApplyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(761, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Account Number: ";
            // 
            // uiAccountNumber
            // 
            this.uiAccountNumber.Location = new System.Drawing.Point(764, 32);
            this.uiAccountNumber.Name = "uiAccountNumber";
            this.uiAccountNumber.Size = new System.Drawing.Size(126, 20);
            this.uiAccountNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Account Description: ";
            // 
            // uiAccountDescription
            // 
            this.uiAccountDescription.Location = new System.Drawing.Point(443, 32);
            this.uiAccountDescription.Name = "uiAccountDescription";
            this.uiAccountDescription.Size = new System.Drawing.Size(315, 20);
            this.uiAccountDescription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account Type: ";
            // 
            // uiAccountTypeCombo
            // 
            this.uiAccountTypeCombo.FormattingEnabled = true;
            this.uiAccountTypeCombo.Location = new System.Drawing.Point(316, 32);
            this.uiAccountTypeCombo.Name = "uiAccountTypeCombo";
            this.uiAccountTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.uiAccountTypeCombo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Name: ";
            // 
            // uiAccountNameCombo
            // 
            this.uiAccountNameCombo.FormattingEnabled = true;
            this.uiAccountNameCombo.Location = new System.Drawing.Point(6, 32);
            this.uiAccountNameCombo.Name = "uiAccountNameCombo";
            this.uiAccountNameCombo.Size = new System.Drawing.Size(304, 21);
            this.uiAccountNameCombo.TabIndex = 2;
            this.uiAccountNameCombo.SelectedIndexChanged += new System.EventHandler(this.uiAccountNameCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Transactions: ";
            // 
            // uiAccountTransactions
            // 
            this.uiAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiAccountTransactions.Location = new System.Drawing.Point(6, 72);
            this.uiAccountTransactions.Name = "uiAccountTransactions";
            this.uiAccountTransactions.Size = new System.Drawing.Size(965, 247);
            this.uiAccountTransactions.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.uiIgnoreTransferCheckbox);
            this.groupBox3.Controls.Add(this.uiTransactionStartId);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.uiExportButton);
            this.groupBox3.Controls.Add(this.uiExportAccountInfo);
            this.groupBox3.Location = new System.Drawing.Point(12, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(977, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transaction Export: ";
            // 
            // uiIgnoreTransferCheckbox
            // 
            this.uiIgnoreTransferCheckbox.AutoSize = true;
            this.uiIgnoreTransferCheckbox.Location = new System.Drawing.Point(316, 38);
            this.uiIgnoreTransferCheckbox.Name = "uiIgnoreTransferCheckbox";
            this.uiIgnoreTransferCheckbox.Size = new System.Drawing.Size(219, 17);
            this.uiIgnoreTransferCheckbox.TabIndex = 4;
            this.uiIgnoreTransferCheckbox.Text = "Ignore Credit Card Payment Transactions";
            this.uiIgnoreTransferCheckbox.UseVisualStyleBackColor = true;
            // 
            // uiTransactionStartId
            // 
            this.uiTransactionStartId.Location = new System.Drawing.Point(9, 36);
            this.uiTransactionStartId.Name = "uiTransactionStartId";
            this.uiTransactionStartId.Size = new System.Drawing.Size(171, 20);
            this.uiTransactionStartId.TabIndex = 3;
            this.uiTransactionStartId.Text = "0";
            this.uiTransactionStartId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Transactions Start Id:";
            // 
            // uiExportButton
            // 
            this.uiExportButton.Location = new System.Drawing.Point(541, 34);
            this.uiExportButton.Name = "uiExportButton";
            this.uiExportButton.Size = new System.Drawing.Size(75, 23);
            this.uiExportButton.TabIndex = 1;
            this.uiExportButton.Text = "Export to IIF";
            this.uiExportButton.UseVisualStyleBackColor = true;
            this.uiExportButton.Click += new System.EventHandler(this.uiExportButton_Click);
            // 
            // uiExportAccountInfo
            // 
            this.uiExportAccountInfo.AutoSize = true;
            this.uiExportAccountInfo.Checked = true;
            this.uiExportAccountInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiExportAccountInfo.Location = new System.Drawing.Point(190, 38);
            this.uiExportAccountInfo.Name = "uiExportAccountInfo";
            this.uiExportAccountInfo.Size = new System.Drawing.Size(120, 17);
            this.uiExportAccountInfo.TabIndex = 0;
            this.uiExportAccountInfo.Text = "Export Account Info";
            this.uiExportAccountInfo.UseVisualStyleBackColor = true;
            // 
            // ccQuickMintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 482);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ccQuickMintForm";
            this.Text = "ccQuickMint - Mint CSV to Quickbooks IIF Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAccountTransactions)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiLoadButton;
        private System.Windows.Forms.TextBox uiMintFilePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiAccountNameCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiAccountTransactions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiAccountDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox uiAccountTypeCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiAccountNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button uiExportButton;
        private System.Windows.Forms.CheckBox uiExportAccountInfo;
        private System.Windows.Forms.Button uiApplyButton;
        private System.Windows.Forms.TextBox uiTransactionStartId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox uiIgnoreTransferCheckbox;
    }
}

