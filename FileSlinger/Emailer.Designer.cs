﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileSlinger {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Emailer : global::System.Configuration.ApplicationSettingsBase {
        
        private static Emailer defaultInstance = ((Emailer)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Emailer())));
        
        public static Emailer Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("server_password")]
        public string smtp_password {
            get {
                return ((string)(this["smtp_password"]));
            }
            set {
                this["smtp_password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("me@server.com")]
        public string email_to_address {
            get {
                return ((string)(this["email_to_address"]));
            }
            set {
                this["email_to_address"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mail.server.com")]
        public string smtp_server {
            get {
                return ((string)(this["smtp_server"]));
            }
            set {
                this["smtp_server"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("user@server.com")]
        public string smtp_user {
            get {
                return ((string)(this["smtp_user"]));
            }
            set {
                this["smtp_user"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("fromme@server.com")]
        public string email_from_address {
            get {
                return ((string)(this["email_from_address"]));
            }
            set {
                this["email_from_address"] = value;
            }
        }
    }
}
