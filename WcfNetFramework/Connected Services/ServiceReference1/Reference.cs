﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfNetFramework.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/somme", ReplyAction="http://tempuri.org/IService1/sommeResponse")]
        string somme(int value1, int value2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/somme", ReplyAction="http://tempuri.org/IService1/sommeResponse")]
        System.Threading.Tasks.Task<string> sommeAsync(int value1, int value2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/create", ReplyAction="http://tempuri.org/IService1/createResponse")]
        void create(string clef, string contenu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/create", ReplyAction="http://tempuri.org/IService1/createResponse")]
        System.Threading.Tasks.Task createAsync(string clef, string contenu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/read", ReplyAction="http://tempuri.org/IService1/readResponse")]
        string read(string clef);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/read", ReplyAction="http://tempuri.org/IService1/readResponse")]
        System.Threading.Tasks.Task<string> readAsync(string clef);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/remove", ReplyAction="http://tempuri.org/IService1/removeResponse")]
        void remove(string clef);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/remove", ReplyAction="http://tempuri.org/IService1/removeResponse")]
        System.Threading.Tasks.Task removeAsync(string clef);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WcfNetFramework.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WcfNetFramework.ServiceReference1.IService1>, WcfNetFramework.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string somme(int value1, int value2) {
            return base.Channel.somme(value1, value2);
        }
        
        public System.Threading.Tasks.Task<string> sommeAsync(int value1, int value2) {
            return base.Channel.sommeAsync(value1, value2);
        }
        
        public void create(string clef, string contenu) {
            base.Channel.create(clef, contenu);
        }
        
        public System.Threading.Tasks.Task createAsync(string clef, string contenu) {
            return base.Channel.createAsync(clef, contenu);
        }
        
        public string read(string clef) {
            return base.Channel.read(clef);
        }
        
        public System.Threading.Tasks.Task<string> readAsync(string clef) {
            return base.Channel.readAsync(clef);
        }
        
        public void remove(string clef) {
            base.Channel.remove(clef);
        }
        
        public System.Threading.Tasks.Task removeAsync(string clef) {
            return base.Channel.removeAsync(clef);
        }
    }
}
