﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ccProjectTracker {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class ccProjectTracker : global::System.Configuration.ApplicationSettingsBase {
        
        private static ccProjectTracker defaultInstance = ((ccProjectTracker)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ccProjectTracker())));
        
        public static ccProjectTracker Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int CheckIn_Interval {
            get {
                return ((int)(this["CheckIn_Interval"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("General task")]
        public string DefaultTaskDescription {
            get {
                return ((string)(this["DefaultTaskDescription"]));
            }
            set {
                this["DefaultTaskDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int RoundupMinutes {
            get {
                return ((int)(this["RoundupMinutes"]));
            }
            set {
                this["RoundupMinutes"] = value;
            }
        }
    }
}