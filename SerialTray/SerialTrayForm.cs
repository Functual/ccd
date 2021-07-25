using System;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Management;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace SerialTray
{
    public partial class SerialTrayForm : Form
    {
        string m_strCustomPortCommand = "";
        string m_strCustomCommandArguments = "";
        Hashtable m_oFriendlyNameMap;
        /// <summary>
        /// Initializes the form and does some custom manipulations for how the context menu displayed
        /// </summary>
        public SerialTrayForm()
        {
            if (ConfigurationManager.AppSettings["CustomPortCommand"] == null)
            {
                MessageBox.Show("No command is specified for Port 'Connect' action! Please check SerialTray.exe.config", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            m_strCustomPortCommand = ConfigurationManager.AppSettings["CustomPortCommand"];
            m_strCustomCommandArguments = (ConfigurationManager.AppSettings["CustomCommandArguments"] != null) ? ConfigurationManager.AppSettings["CustomCommandArguments"] : "";
            InitializeComponent();
            InitializeContextMenu();
            m_uiSystemTrayIcon.ContextMenuStrip = this.m_uiContextMenu;     // transfer our context menu to system tray icon and edit window            
        }

        /// <summary>
        /// This function adds all the required handlers to the menu
        /// </summary>
        void InitializeContextMenu()
        {            
            m_oFriendlyNameMap = BuildPortNameHash(System.IO.Ports.SerialPort.GetPortNames());
            this.m_uiContextMenu.Items.Add("Launch Application for:");
            foreach (string strSerialPortName in m_oFriendlyNameMap.Keys)                
                this.m_uiContextMenu.Items.Add(new ToolStripMenuItem(strSerialPortName, SerialTrayResource.serial_port.ToBitmap(), new EventHandler(ExecuteCustomCommandForPort)));            
            this.m_uiContextMenu.Items.Add("-");            // add separator
            this.m_uiContextMenu.Items.Add(new ToolStripMenuItem("Creative Code Design...", SerialTrayResource.web.ToBitmap(), new EventHandler(LaunchCCDSite)));
            this.m_uiContextMenu.Items.Add(new ToolStripMenuItem("About SerialTray...", SerialTrayResource.info.ToBitmap(), new EventHandler(ShowAboutBoxClick)));
            this.m_uiContextMenu.Items.Add("-");
            this.m_uiContextMenu.Items.Add(new ToolStripMenuItem("Exit", SerialTrayResource.exit.ToBitmap(), new EventHandler(ExitProgramClick)));
        }        
        /// <summary>
        /// Begins recursive registry enumeration
        /// </summary>
        /// <param name="oPortsToMap">array of port names (i.e. COM1, COM2, etc)</param>
        /// <returns>a hashtable mapping Friendly names to non-friendly port values</returns>
        Hashtable BuildPortNameHash(string [] oPortsToMap)
        {
            Hashtable oReturnTable = new Hashtable();
            MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum", oReturnTable, oPortsToMap);
            return oReturnTable;
        }
        /// <summary>
        /// Recursively enumerates registry subkeys starting with strStartKey looking for "Device Parameters" subkey. If key
        /// is present, friendly port name is extracted.
        /// </summary>
        /// <param name="strStartKey">the start key from which to begin the enumeration</param>
        /// <param name="oTargetMap">hashtable that will get populated with friendly-to-nonfriendly port names</param>
        /// <param name="oPortNamesToMatch">array of port names (i.e. COM1, COM2, etc)</param>
        void MineRegistryForPortName(string strStartKey, Hashtable oTargetMap, string [] oPortNamesToMatch)
        {
            if (oTargetMap.Count >= oPortNamesToMatch.Length)                 // avoid unnecessary processing
                return;
            RegistryKey oCurrentKey = Registry.LocalMachine;
            try
            {
                oCurrentKey = oCurrentKey.OpenSubKey(strStartKey);
            }
            catch (Exception)                                               // some keys will not allow access even if admin (i.e. FixedButton\Properties - WTF)
            {
                return;
            }
            string[] oSubKeyNames = oCurrentKey.GetSubKeyNames();
            if (oSubKeyNames.Contains("Device Parameters") && strStartKey != "SYSTEM\\CurrentControlSet\\Enum")   // this is true on some machines..
            {
                object oPortNameValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + strStartKey + "\\Device Parameters", "PortName", null);
                if (oPortNameValue == null || oPortNamesToMatch.Contains(oPortNameValue.ToString()) == false)               // if no value, or not in out list
                    return;                                                                                                 // uncurse
                object oFriendlyName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + strStartKey, "FriendlyName", null);
                string strFriendlyName = "N/A";
                if (oFriendlyName != null)
                    strFriendlyName = oFriendlyName.ToString();
                if (strFriendlyName.Contains(oPortNameValue.ToString()) == false)
                    strFriendlyName = string.Format("{0} ({1})", strFriendlyName, oPortNameValue);
                oTargetMap[strFriendlyName] = oPortNameValue;                                                               // add the vlaue to the hash
            }
            else
            {
                foreach (string strSubKey in oSubKeyNames)
                    MineRegistryForPortName(strStartKey + "\\" + strSubKey, oTargetMap, oPortNamesToMatch);                 // recurse - wouldn't have to recurse if cursed right the first time
            }
        }
        /// <summary>
        /// Executes the custom command specified in the configuration
        /// </summary>
        /// <param name="oSender">the menu item that triggered this function call</param>
        /// <param name="oArgs"></param>
        void ExecuteCustomCommandForPort(object oSender, EventArgs oArgs)
        {
            ToolStripMenuItem oSenderItem = (ToolStripMenuItem)oSender;
            string strPortName = oSenderItem.ToString();
            if (m_oFriendlyNameMap.ContainsKey(strPortName) == false)
            {
                MessageBox.Show("No Mapping for port exists", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strPortNum = m_oFriendlyNameMap[strPortName].ToString().Replace("COM", "");                              // strip the "COM" part
            string strCommand = m_strCustomPortCommand.Replace("%PortNumber%", strPortNum);
            string strArguments = m_strCustomCommandArguments.Replace("%PortNumber%", strPortNum);
            try
            {
                Process.Start(strCommand, strArguments);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Unable to execute command: '{0}' with argument '{1}'", strCommand, strArguments), 
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }
        /// <summary>
        /// Launches the Creative Code Design website
        /// </summary>
        /// <param name="oSender"></param>
        /// <param name="oArgs"></param>
        void LaunchCCDSite(object oSender, EventArgs oArgs)
        {
            Process.Start("http://www.creativecodedesign.com");
        }
        /// <summary>
        /// Displays an about box
        /// </summary>
        /// <param name="oSender"></param>
        /// <param name="oArgs"></param>
        void ShowAboutBoxClick(object oSender, EventArgs oArgs)
        {
            MessageBox.Show("Written by Timur at Creative Code Design", "About SerialTray", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="oSender"></param>
        /// <param name="oArgs"></param>
        void ExitProgramClick(object oSender, EventArgs oArgs)
        {
            Application.Exit();
        }

        /// <summary>
        /// Uses WMI to retrieve available serial ports, and builds a mapping of Friendly Names to Device IDs (port numbers)
        /// THIS METHOD IS OBSOLETE
        /// </summary>
        /// <returns></returns>
        List<string> GetFriendlyPortNames()
        {
            List<string> oReturnList = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from WIN32_PnPEntity");
            foreach (ManagementObject Port in searcher.Get())
            {
                string strFriendlyName = (string)Port.GetPropertyValue("Name");
                string strDeviceName = (string)Port.GetPropertyValue("DeviceID");
                string strCaption = (string)Port.GetPropertyValue("Caption");

                if (strFriendlyName.ToLower().Contains("com") == false)
                    continue;
                foreach (PropertyData oProp in Port.Properties)
                {
                    string strProperty = oProp.ToString();
                }
                /*if (m_oFriendlyNameMap.ContainsKey(strFriendlyName))
                {
                    MessageBox.Show(string.Format("Specified port {0} was already added to list", strFriendlyName), 
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }*/
                oReturnList.Add(strFriendlyName);
                //m_oFriendlyNameMap[strFriendlyName] = string.Join(null, Regex.Split(strDeviceName, "[^\\d]"));         // get the port number from the ID
            }
            oReturnList.Sort();
            return oReturnList;
        }
    }
}
