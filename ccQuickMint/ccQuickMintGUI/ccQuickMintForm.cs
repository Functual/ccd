using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cc.ccQuickMint
{    
    /// <summary>
    /// Author: Timur Kovalev (http://creativecodedesign.com)
    /// Gui to interact with the downloaded MINT data prior to export to QuickBooks format    
    /// </summary>
    public partial class ccQuickMintForm : Form
    {
        ccQuickMint _quickMintInstance = null;
        QuickMintAccount _selectedAccount = null;               // keeps track of the last selected account
        public ccQuickMintForm()
        {
            InitializeComponent();
        }        
        /// <summary>
        /// Called when the user clicks the "Load' button
        /// </summary>
        private void uiLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseDialog = new OpenFileDialog();
            browseDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                uiMintFilePath.Text = browseDialog.FileName;
                _quickMintInstance = new ccQuickMint();
                if (!_quickMintInstance.LoadMintTransactions(uiMintFilePath.Text))
                    MessageBox.Show(string.Format("Unable to load transaction file! {0}", _quickMintInstance.GetLastError()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    PopulateAccounts();
                    MessageBox.Show(string.Format("{0} Loaded Successfully. Please verify all details before performing an IIF export.", uiMintFilePath.Text), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// Populates UI with account data imported from mint
        /// </summary>
        private void PopulateAccounts()
        {
            uiAccountTypeCombo.DataSource = Enum.GetValues(typeof(QuickMintAccount.QuickMintAccountType));
            uiAccountNameCombo.DataSource = _quickMintInstance.TransactionAccounts;
            uiAccountNameCombo_SelectedIndexChanged(null, null);                    // populate account details
        }        
        /// <summary>
        /// Fired when the user changes selected account
        /// </summary>
        private void uiAccountNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAccount = (QuickMintAccount)uiAccountNameCombo.SelectedValue;
            uiAccountTransactions.DataSource = _quickMintInstance.GetQuickMintAccountTransactions(_selectedAccount);
            uiAccountTypeCombo.SelectedItem = _selectedAccount.Type;//.ToString();
            uiAccountDescription.Text = _selectedAccount.Description;
            uiAccountNumber.Text = _selectedAccount.Number;            
        }
        /// <summary>
        /// Called whenver user clicks 'Apply' to modify account info
        /// </summary>
        private void uiApplyButton_Click(object sender, EventArgs e)
        {
            if (_selectedAccount == null)                                                               // this will be true on load of the file
                return;
            QuickMintAccount selectedAccount = (QuickMintAccount)uiAccountNameCombo.SelectedValue;
            if (selectedAccount == null)
                selectedAccount = _selectedAccount;
            selectedAccount.Name = uiAccountNameCombo.Text;                                             // Use current text as the name            
            selectedAccount.Description = uiAccountDescription.Text;
            selectedAccount.Number = uiAccountNumber.Text;
            selectedAccount.Type = (QuickMintAccount.QuickMintAccountType)uiAccountTypeCombo.SelectedItem;
            uiAccountNameCombo.DataSource = _quickMintInstance.TransactionAccounts;
            uiAccountNameCombo.SelectedItem = selectedAccount;
            MessageBox.Show("Account changes applied successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Called when the user clicks "Export To IIF" button. Converts all loaded transactions into IIF format
        /// and asks the user where it should be saved. Subsequently generates and saves the file.
        /// </summary>
        private void uiExportButton_Click(object sender, EventArgs e)
        {               
            string iifOutput = "";
            if (uiExportAccountInfo.Checked == true)                                    // if create accounts is checked, generate account Header and accounts IIF
                iifOutput = _quickMintInstance.GetAccountIIF();
            _quickMintInstance.SetTransactionID(Convert.ToUInt32(uiTransactionStartId.Text));
            iifOutput += _quickMintInstance.GetTransactionIIF(uiIgnoreTransferCheckbox.Checked);                        
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "iif files (*.iif)|*.iif|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveDialog.FileName, iifOutput);
            MessageBox.Show("Transactions saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Called when selected value changes..
        /// </summary>
        private void uiAccountTypeCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            uiApplyButton_Click(null, null);
        }
    }
}
