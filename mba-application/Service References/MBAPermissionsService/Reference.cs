﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mba_application.MBAPermissionsService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Permission", Namespace="http://schemas.datacontract.org/2004/07/mba_model")]
    [System.SerializableAttribute()]
    public partial class Permission : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommandParamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ParentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.Role[] RolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ScreenNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TooltipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.User[] UsersField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommandParam {
            get {
                return this.CommandParamField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandParamField, value) != true)) {
                    this.CommandParamField = value;
                    this.RaisePropertyChanged("CommandParam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ParentId {
            get {
                return this.ParentIdField;
            }
            set {
                if ((this.ParentIdField.Equals(value) != true)) {
                    this.ParentIdField = value;
                    this.RaisePropertyChanged("ParentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.Role[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ScreenName {
            get {
                return this.ScreenNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ScreenNameField, value) != true)) {
                    this.ScreenNameField = value;
                    this.RaisePropertyChanged("ScreenName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tooltip {
            get {
                return this.TooltipField;
            }
            set {
                if ((object.ReferenceEquals(this.TooltipField, value) != true)) {
                    this.TooltipField = value;
                    this.RaisePropertyChanged("Tooltip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.User[] Users {
            get {
                return this.UsersField;
            }
            set {
                if ((object.ReferenceEquals(this.UsersField, value) != true)) {
                    this.UsersField = value;
                    this.RaisePropertyChanged("Users");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Role", Namespace="http://schemas.datacontract.org/2004/07/mba_model")]
    [System.SerializableAttribute()]
    public partial class Role : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.Permission[] PermissionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ScreenNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.User[] UsersField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.Permission[] Permissions {
            get {
                return this.PermissionsField;
            }
            set {
                if ((object.ReferenceEquals(this.PermissionsField, value) != true)) {
                    this.PermissionsField = value;
                    this.RaisePropertyChanged("Permissions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ScreenName {
            get {
                return this.ScreenNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ScreenNameField, value) != true)) {
                    this.ScreenNameField = value;
                    this.RaisePropertyChanged("ScreenName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.User[] Users {
            get {
                return this.UsersField;
            }
            set {
                if ((object.ReferenceEquals(this.UsersField, value) != true)) {
                    this.UsersField = value;
                    this.RaisePropertyChanged("Users");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/mba_model")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FreezedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiddleNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.Permission[] PermissionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private mba_application.MBAPermissionsService.Role[] RolesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Freezed {
            get {
                return this.FreezedField;
            }
            set {
                if ((this.FreezedField.Equals(value) != true)) {
                    this.FreezedField = value;
                    this.RaisePropertyChanged("Freezed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName {
            get {
                return this.MiddleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MiddleNameField, value) != true)) {
                    this.MiddleNameField = value;
                    this.RaisePropertyChanged("MiddleName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.Permission[] Permissions {
            get {
                return this.PermissionsField;
            }
            set {
                if ((object.ReferenceEquals(this.PermissionsField, value) != true)) {
                    this.PermissionsField = value;
                    this.RaisePropertyChanged("Permissions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Photo {
            get {
                return this.PhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoField, value) != true)) {
                    this.PhotoField = value;
                    this.RaisePropertyChanged("Photo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public mba_application.MBAPermissionsService.Role[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MBAPermissionsService.IPermissionsService")]
    public interface IPermissionsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionsService/Permissions", ReplyAction="http://tempuri.org/IPermissionsService/PermissionsResponse")]
        mba_application.MBAPermissionsService.Permission[] Permissions();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPermissionsService/Permissions", ReplyAction="http://tempuri.org/IPermissionsService/PermissionsResponse")]
        System.IAsyncResult BeginPermissions(System.AsyncCallback callback, object asyncState);
        
        mba_application.MBAPermissionsService.Permission[] EndPermissions(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPermissionsServiceChannel : mba_application.MBAPermissionsService.IPermissionsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PermissionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PermissionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public mba_application.MBAPermissionsService.Permission[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((mba_application.MBAPermissionsService.Permission[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PermissionsServiceClient : System.ServiceModel.ClientBase<mba_application.MBAPermissionsService.IPermissionsService>, mba_application.MBAPermissionsService.IPermissionsService {
        
        private BeginOperationDelegate onBeginPermissionsDelegate;
        
        private EndOperationDelegate onEndPermissionsDelegate;
        
        private System.Threading.SendOrPostCallback onPermissionsCompletedDelegate;
        
        public PermissionsServiceClient() {
        }
        
        public PermissionsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PermissionsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PermissionsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PermissionsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<PermissionsCompletedEventArgs> PermissionsCompleted;
        
        public mba_application.MBAPermissionsService.Permission[] Permissions() {
            return base.Channel.Permissions();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPermissions(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginPermissions(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public mba_application.MBAPermissionsService.Permission[] EndPermissions(System.IAsyncResult result) {
            return base.Channel.EndPermissions(result);
        }
        
        private System.IAsyncResult OnBeginPermissions(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginPermissions(callback, asyncState);
        }
        
        private object[] OnEndPermissions(System.IAsyncResult result) {
            mba_application.MBAPermissionsService.Permission[] retVal = this.EndPermissions(result);
            return new object[] {
                    retVal};
        }
        
        private void OnPermissionsCompleted(object state) {
            if ((this.PermissionsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PermissionsCompleted(this, new PermissionsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void PermissionsAsync() {
            this.PermissionsAsync(null);
        }
        
        public void PermissionsAsync(object userState) {
            if ((this.onBeginPermissionsDelegate == null)) {
                this.onBeginPermissionsDelegate = new BeginOperationDelegate(this.OnBeginPermissions);
            }
            if ((this.onEndPermissionsDelegate == null)) {
                this.onEndPermissionsDelegate = new EndOperationDelegate(this.OnEndPermissions);
            }
            if ((this.onPermissionsCompletedDelegate == null)) {
                this.onPermissionsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPermissionsCompleted);
            }
            base.InvokeAsync(this.onBeginPermissionsDelegate, null, this.onEndPermissionsDelegate, this.onPermissionsCompletedDelegate, userState);
        }
    }
}
