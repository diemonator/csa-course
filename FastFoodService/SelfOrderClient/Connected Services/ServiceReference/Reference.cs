﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SelfOrderClient.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PriceField;
        
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
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IFastFood")]
    public interface IFastFood {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/GetOrderNr", ReplyAction="http://tempuri.org/IFastFood/GetOrderNrResponse")]
        int GetOrderNr();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/GetOrderNr", ReplyAction="http://tempuri.org/IFastFood/GetOrderNrResponse")]
        System.Threading.Tasks.Task<int> GetOrderNrAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/GetAvailableProducts", ReplyAction="http://tempuri.org/IFastFood/GetAvailableProductsResponse")]
        System.Collections.Generic.List<SelfOrderClient.ServiceReference.Product> GetAvailableProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/GetAvailableProducts", ReplyAction="http://tempuri.org/IFastFood/GetAvailableProductsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SelfOrderClient.ServiceReference.Product>> GetAvailableProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/BuyProducts", ReplyAction="http://tempuri.org/IFastFood/BuyProductsResponse")]
        string BuyProducts(int orderId, System.Collections.Generic.List<string> products);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFastFood/BuyProducts", ReplyAction="http://tempuri.org/IFastFood/BuyProductsResponse")]
        System.Threading.Tasks.Task<string> BuyProductsAsync(int orderId, System.Collections.Generic.List<string> products);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFastFoodChannel : SelfOrderClient.ServiceReference.IFastFood, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FastFoodClient : System.ServiceModel.ClientBase<SelfOrderClient.ServiceReference.IFastFood>, SelfOrderClient.ServiceReference.IFastFood {
        
        public FastFoodClient() {
        }
        
        public FastFoodClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FastFoodClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FastFoodClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FastFoodClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetOrderNr() {
            return base.Channel.GetOrderNr();
        }
        
        public System.Threading.Tasks.Task<int> GetOrderNrAsync() {
            return base.Channel.GetOrderNrAsync();
        }
        
        public System.Collections.Generic.List<SelfOrderClient.ServiceReference.Product> GetAvailableProducts() {
            return base.Channel.GetAvailableProducts();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SelfOrderClient.ServiceReference.Product>> GetAvailableProductsAsync() {
            return base.Channel.GetAvailableProductsAsync();
        }
        
        public string BuyProducts(int orderId, System.Collections.Generic.List<string> products) {
            return base.Channel.BuyProducts(orderId, products);
        }
        
        public System.Threading.Tasks.Task<string> BuyProductsAsync(int orderId, System.Collections.Generic.List<string> products) {
            return base.Channel.BuyProductsAsync(orderId, products);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IAdmin", CallbackContract=typeof(SelfOrderClient.ServiceReference.IAdminCallback))]
    public interface IAdmin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdmin/GetOrders", ReplyAction="http://tempuri.org/IAdmin/GetOrdersResponse")]
        System.Collections.Generic.List<int> GetOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdmin/GetOrders", ReplyAction="http://tempuri.org/IAdmin/GetOrdersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<int>> GetOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/OrderNrReady")]
        void OrderNrReady(int nr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/OrderNrReady")]
        System.Threading.Tasks.Task OrderNrReadyAsync(int nr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/Connect")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/Connect")]
        System.Threading.Tasks.Task ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/Disconnect")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/Disconnect")]
        System.Threading.Tasks.Task DisconnectAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdminCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/NewOrder")]
        void NewOrder(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAdmin/NotifyReadyOrder")]
        void NotifyReadyOrder(int orderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdminChannel : SelfOrderClient.ServiceReference.IAdmin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminClient : System.ServiceModel.DuplexClientBase<SelfOrderClient.ServiceReference.IAdmin>, SelfOrderClient.ServiceReference.IAdmin {
        
        public AdminClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AdminClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AdminClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AdminClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AdminClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<int> GetOrders() {
            return base.Channel.GetOrders();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<int>> GetOrdersAsync() {
            return base.Channel.GetOrdersAsync();
        }
        
        public void OrderNrReady(int nr) {
            base.Channel.OrderNrReady(nr);
        }
        
        public System.Threading.Tasks.Task OrderNrReadyAsync(int nr) {
            return base.Channel.OrderNrReadyAsync(nr);
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
        
        public System.Threading.Tasks.Task DisconnectAsync() {
            return base.Channel.DisconnectAsync();
        }
    }
}
