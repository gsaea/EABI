﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EABI.eCPICWcfService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="eCPICWcfService.IWcfService")]
    public interface IWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeList_DataSetResponse")]
        System.Data.DataSet Get_InitiativeList_DataSet(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeList_DataSetResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_InitiativeList_DataSetAsync(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeList_CSVResponse")]
        string[] Get_InitiativeList_CSV(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeList_CSVResponse")]
        System.Threading.Tasks.Task<string[]> Get_InitiativeList_CSVAsync(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_PortfolioList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_PortfolioList_DataSetResponse")]
        System.Data.DataSet Get_PortfolioList_DataSet(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_PortfolioList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_PortfolioList_DataSetResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_PortfolioList_DataSetAsync(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_PortfolioList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_PortfolioList_CSVResponse")]
        string[] Get_PortfolioList_CSV(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_PortfolioList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_PortfolioList_CSVResponse")]
        System.Threading.Tasks.Task<string[]> Get_PortfolioList_CSVAsync(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_DataSetResponse")]
        System.Data.DataSet Get_InitiativeListInPortfolio_DataSet(string portfolioID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_DataSetResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_InitiativeListInPortfolio_DataSetAsync(string portfolioID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_CSVResponse")]
        string[] Get_InitiativeListInPortfolio_CSV(string portfolioID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeListInPortfolio_CSVResponse")]
        System.Threading.Tasks.Task<string[]> Get_InitiativeListInPortfolio_CSVAsync(string portfolioID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_FieldList_DataSetResponse")]
        System.Data.DataSet Get_FieldList_DataSet(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldList_DataSet", ReplyAction="http://tempuri.org/IWcfService/Get_FieldList_DataSetResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_FieldList_DataSetAsync(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_FieldList_CSVResponse")]
        string[] Get_FieldList_CSV(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldList_CSV", ReplyAction="http://tempuri.org/IWcfService/Get_FieldList_CSVResponse")]
        System.Threading.Tasks.Task<string[]> Get_FieldList_CSVAsync(string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldByFieldID_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FieldByFieldID_XMLResponse")]
        string Get_FieldByFieldID_XML(string initiativeID, string fieldID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldByFieldID_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FieldByFieldID_XMLResponse")]
        System.Threading.Tasks.Task<string> Get_FieldByFieldID_XMLAsync(string initiativeID, string fieldID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldByFieldXMLTag_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FieldByFieldXMLTag_XMLResponse")]
        string Get_FieldByFieldXMLTag_XML(string initiativeID, string fieldXMLTag, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FieldByFieldXMLTag_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FieldByFieldXMLTag_XMLResponse")]
        System.Threading.Tasks.Task<string> Get_FieldByFieldXMLTag_XMLAsync(string initiativeID, string fieldXMLTag, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FullExport_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FullExport_XMLResponse")]
        string Get_FullExport_XML(string initiativeID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_FullExport_XML", ReplyAction="http://tempuri.org/IWcfService/Get_FullExport_XMLResponse")]
        System.Threading.Tasks.Task<string> Get_FullExport_XMLAsync(string initiativeID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_Exhibit300Export_XML", ReplyAction="http://tempuri.org/IWcfService/Get_Exhibit300Export_XMLResponse")]
        string Get_Exhibit300Export_XML(string initiativeID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_Exhibit300Export_XML", ReplyAction="http://tempuri.org/IWcfService/Get_Exhibit300Export_XMLResponse")]
        System.Threading.Tasks.Task<string> Get_Exhibit300Export_XMLAsync(string initiativeID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Import_Exhibit300_XML", ReplyAction="http://tempuri.org/IWcfService/Import_Exhibit300_XMLResponse")]
        string[] Import_Exhibit300_XML(string XML_300, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Import_Exhibit300_XML", ReplyAction="http://tempuri.org/IWcfService/Import_Exhibit300_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Import_Exhibit300_XMLAsync(string XML_300, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Import_FullXML_XML", ReplyAction="http://tempuri.org/IWcfService/Import_FullXML_XMLResponse")]
        string[] Import_FullXML_XML(string XML_Full, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Import_FullXML_XML", ReplyAction="http://tempuri.org/IWcfService/Import_FullXML_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Import_FullXML_XMLAsync(string XML_Full, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_Exhibit300_XML", ReplyAction="http://tempuri.org/IWcfService/Update_Exhibit300_XMLResponse")]
        string[] Update_Exhibit300_XML(string initiativeID, string XML_300, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_Exhibit300_XML", ReplyAction="http://tempuri.org/IWcfService/Update_Exhibit300_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Update_Exhibit300_XMLAsync(string initiativeID, string XML_300, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_FullXML_XML", ReplyAction="http://tempuri.org/IWcfService/Update_FullXML_XMLResponse")]
        string[] Update_FullXML_XML(string initiativeID, string XML_Full, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_FullXML_XML", ReplyAction="http://tempuri.org/IWcfService/Update_FullXML_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Update_FullXML_XMLAsync(string initiativeID, string XML_Full, int budgetYear, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_SaveField_XML", ReplyAction="http://tempuri.org/IWcfService/Update_SaveField_XMLResponse")]
        string[] Update_SaveField_XML(string xml, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_SaveField_XML", ReplyAction="http://tempuri.org/IWcfService/Update_SaveField_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Update_SaveField_XMLAsync(string xml, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_SaveMultipleFields_XML", ReplyAction="http://tempuri.org/IWcfService/Update_SaveMultipleFields_XMLResponse")]
        string[] Update_SaveMultipleFields_XML(string xml, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Update_SaveMultipleFields_XML", ReplyAction="http://tempuri.org/IWcfService/Update_SaveMultipleFields_XMLResponse")]
        System.Threading.Tasks.Task<string[]> Update_SaveMultipleFields_XMLAsync(string xml, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeTemplate", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeTemplateResponse")]
        int Get_InitiativeTemplate(string initiativeID, string userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Get_InitiativeTemplate", ReplyAction="http://tempuri.org/IWcfService/Get_InitiativeTemplateResponse")]
        System.Threading.Tasks.Task<int> Get_InitiativeTemplateAsync(string initiativeID, string userID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfServiceChannel : EABI.eCPICWcfService.IWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfServiceClient : System.ServiceModel.ClientBase<EABI.eCPICWcfService.IWcfService>, EABI.eCPICWcfService.IWcfService {
        
        public WcfServiceClient() {
        }
        
        public WcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Get_InitiativeList_DataSet(string UserID) {
            return base.Channel.Get_InitiativeList_DataSet(UserID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_InitiativeList_DataSetAsync(string UserID) {
            return base.Channel.Get_InitiativeList_DataSetAsync(UserID);
        }
        
        public string[] Get_InitiativeList_CSV(string userID) {
            return base.Channel.Get_InitiativeList_CSV(userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Get_InitiativeList_CSVAsync(string userID) {
            return base.Channel.Get_InitiativeList_CSVAsync(userID);
        }
        
        public System.Data.DataSet Get_PortfolioList_DataSet(string userID) {
            return base.Channel.Get_PortfolioList_DataSet(userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_PortfolioList_DataSetAsync(string userID) {
            return base.Channel.Get_PortfolioList_DataSetAsync(userID);
        }
        
        public string[] Get_PortfolioList_CSV(string userID) {
            return base.Channel.Get_PortfolioList_CSV(userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Get_PortfolioList_CSVAsync(string userID) {
            return base.Channel.Get_PortfolioList_CSVAsync(userID);
        }
        
        public System.Data.DataSet Get_InitiativeListInPortfolio_DataSet(string portfolioID, string userID) {
            return base.Channel.Get_InitiativeListInPortfolio_DataSet(portfolioID, userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_InitiativeListInPortfolio_DataSetAsync(string portfolioID, string userID) {
            return base.Channel.Get_InitiativeListInPortfolio_DataSetAsync(portfolioID, userID);
        }
        
        public string[] Get_InitiativeListInPortfolio_CSV(string portfolioID, string userID) {
            return base.Channel.Get_InitiativeListInPortfolio_CSV(portfolioID, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Get_InitiativeListInPortfolio_CSVAsync(string portfolioID, string userID) {
            return base.Channel.Get_InitiativeListInPortfolio_CSVAsync(portfolioID, userID);
        }
        
        public System.Data.DataSet Get_FieldList_DataSet(string userID) {
            return base.Channel.Get_FieldList_DataSet(userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_FieldList_DataSetAsync(string userID) {
            return base.Channel.Get_FieldList_DataSetAsync(userID);
        }
        
        public string[] Get_FieldList_CSV(string userID) {
            return base.Channel.Get_FieldList_CSV(userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Get_FieldList_CSVAsync(string userID) {
            return base.Channel.Get_FieldList_CSVAsync(userID);
        }
        
        public string Get_FieldByFieldID_XML(string initiativeID, string fieldID, string userID) {
            return base.Channel.Get_FieldByFieldID_XML(initiativeID, fieldID, userID);
        }
        
        public System.Threading.Tasks.Task<string> Get_FieldByFieldID_XMLAsync(string initiativeID, string fieldID, string userID) {
            return base.Channel.Get_FieldByFieldID_XMLAsync(initiativeID, fieldID, userID);
        }
        
        public string Get_FieldByFieldXMLTag_XML(string initiativeID, string fieldXMLTag, string userID) {
            return base.Channel.Get_FieldByFieldXMLTag_XML(initiativeID, fieldXMLTag, userID);
        }
        
        public System.Threading.Tasks.Task<string> Get_FieldByFieldXMLTag_XMLAsync(string initiativeID, string fieldXMLTag, string userID) {
            return base.Channel.Get_FieldByFieldXMLTag_XMLAsync(initiativeID, fieldXMLTag, userID);
        }
        
        public string Get_FullExport_XML(string initiativeID, string userID) {
            return base.Channel.Get_FullExport_XML(initiativeID, userID);
        }
        
        public System.Threading.Tasks.Task<string> Get_FullExport_XMLAsync(string initiativeID, string userID) {
            return base.Channel.Get_FullExport_XMLAsync(initiativeID, userID);
        }
        
        public string Get_Exhibit300Export_XML(string initiativeID, string userID) {
            return base.Channel.Get_Exhibit300Export_XML(initiativeID, userID);
        }
        
        public System.Threading.Tasks.Task<string> Get_Exhibit300Export_XMLAsync(string initiativeID, string userID) {
            return base.Channel.Get_Exhibit300Export_XMLAsync(initiativeID, userID);
        }
        
        public string[] Import_Exhibit300_XML(string XML_300, int budgetYear, string userID) {
            return base.Channel.Import_Exhibit300_XML(XML_300, budgetYear, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Import_Exhibit300_XMLAsync(string XML_300, int budgetYear, string userID) {
            return base.Channel.Import_Exhibit300_XMLAsync(XML_300, budgetYear, userID);
        }
        
        public string[] Import_FullXML_XML(string XML_Full, int budgetYear, string userID) {
            return base.Channel.Import_FullXML_XML(XML_Full, budgetYear, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Import_FullXML_XMLAsync(string XML_Full, int budgetYear, string userID) {
            return base.Channel.Import_FullXML_XMLAsync(XML_Full, budgetYear, userID);
        }
        
        public string[] Update_Exhibit300_XML(string initiativeID, string XML_300, int budgetYear, string userID) {
            return base.Channel.Update_Exhibit300_XML(initiativeID, XML_300, budgetYear, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Update_Exhibit300_XMLAsync(string initiativeID, string XML_300, int budgetYear, string userID) {
            return base.Channel.Update_Exhibit300_XMLAsync(initiativeID, XML_300, budgetYear, userID);
        }
        
        public string[] Update_FullXML_XML(string initiativeID, string XML_Full, int budgetYear, string userID) {
            return base.Channel.Update_FullXML_XML(initiativeID, XML_Full, budgetYear, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Update_FullXML_XMLAsync(string initiativeID, string XML_Full, int budgetYear, string userID) {
            return base.Channel.Update_FullXML_XMLAsync(initiativeID, XML_Full, budgetYear, userID);
        }
        
        public string[] Update_SaveField_XML(string xml, string userID) {
            return base.Channel.Update_SaveField_XML(xml, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Update_SaveField_XMLAsync(string xml, string userID) {
            return base.Channel.Update_SaveField_XMLAsync(xml, userID);
        }
        
        public string[] Update_SaveMultipleFields_XML(string xml, string userID) {
            return base.Channel.Update_SaveMultipleFields_XML(xml, userID);
        }
        
        public System.Threading.Tasks.Task<string[]> Update_SaveMultipleFields_XMLAsync(string xml, string userID) {
            return base.Channel.Update_SaveMultipleFields_XMLAsync(xml, userID);
        }
        
        public int Get_InitiativeTemplate(string initiativeID, string userID) {
            return base.Channel.Get_InitiativeTemplate(initiativeID, userID);
        }
        
        public System.Threading.Tasks.Task<int> Get_InitiativeTemplateAsync(string initiativeID, string userID) {
            return base.Channel.Get_InitiativeTemplateAsync(initiativeID, userID);
        }
    }
}
