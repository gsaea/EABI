using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;


namespace EABI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEAOpen" in both code and config file together.
    [ServiceContract(Namespace = "http://icoh2m-qaapp01/EAWeb/EAOpen/EAOpen.svc")]
    public interface IEAOpen
    {

        [OperationContract]
        List<Application> GetApplications();

        [OperationContract]
        List<ApplicationTIME> GetApplicationTIME();

        [OperationContract]
        List<ApplicationCost> GetApplicationCosts();

        [OperationContract]
        List<FISMASystem> GetFISMASystems(string requestType);

        [OperationContract]
        List<BusinessFunction> GetBusinessFunctions();

        [OperationContract]
        List<Standard> GetITStandards(string requestType);

        [OperationContract]
        List<Goal> GetGoals();

        [OperationContract]
        List<Dataset> GetDatasets();

        [OperationContract]
        GSADataset GetOpenDatasets();

        [OperationContract]
        List<Organization> GetOrganizations();

        [OperationContract]
        List<BRMMissionSector> GetMissionSectors();

        [OperationContract]
        List<BRMBusinessFunction> GetBRMBusinessFunctions();

        [OperationContract]
        List<BRMService> GetServices();

        [OperationContract]
        List<Interface> GetInterfaces();

        [OperationContract]
        List<FuncAppMap> GetFuncAppMap();

        [OperationContract]
        List<AppTechMap> GetAppTechMap();

        [OperationContract]
        List<OrgGoalMap> GetOrgGoalMap();

        [OperationContract]
        List<OrgAppMap> GetOrgAppMap();

        [OperationContract]
        List<OrgSysMap> GetOrgSysMap();

        [OperationContract]
        List<EcpicInvestment> GetEcpicInvestments();

        [OperationContract]
        List<EcpicPortfolio> GetEcpicPortfolios();

        [OperationContract]
        List<ECPICInitiativeByPortfolio> GetEcpicInitiativeByPortfolio(string portId);

        [OperationContract]
        List<OMB300> GetEcpic300Data(string initId);

        [OperationContract]
        List<GSASystem> GetGSASystems();

        [OperationContract]
        List<POC> GetRISSOPocs();

        [OperationContract]
        List<Benchmark> GetBenchmarks();

        [OperationContract]
        List<BRMElement> GetBRMElement();

        [OperationContract]
        List<Investment> GetInvestments();

    }
}
