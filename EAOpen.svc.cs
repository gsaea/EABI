using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EABI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EAOpen" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EAOpen.svc or EAOpen.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode= AspNetCompatibilityRequirementsMode.Allowed)]
    public class EAOpen : IEAOpen
    {
        static eCPICWcfService.WcfServiceClient ws;

        // Connect to ecpic web service
        private static void ecpicConnect()
        {
            //  ws = new eCPIC.WebService.ClientProxy.eCPICWebService();
            ws = new eCPICWcfService.WcfServiceClient();
            ws.ClientCredentials.UserName.UserName = "EA Web Services";
            ws.ClientCredentials.UserName.Password = "ForwardGoing007!!";

            System.ServiceModel.EndpointAddress endpoint = new System.ServiceModel.EndpointAddress("https://gsa.ecpic.gov/eCPIC.WcfService/WcfService.svc");
            System.ServiceModel.WSHttpBinding bd = new System.ServiceModel.WSHttpBinding();
            bd.ReaderQuotas.MaxStringContentLength = 2147483647;
            Uri proxyUri = new Uri("http://patchproxyr6.gsa.gov:3128");
            bd.ProxyAddress = proxyUri;
            bd.UseDefaultWebProxy = false;
            bd.Security.Mode = System.ServiceModel.SecurityMode.Transport;
            bd.TextEncoding = System.Text.Encoding.UTF8;
            bd.Name = "TransportSecurity";
            bd.MaxReceivedMessageSize = 2147483647;
            bd.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;

            ws.Endpoint.Binding = bd;
            ws.Endpoint.Name = "TransportSecurity";
            ws.Endpoint.Address = endpoint;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetApplications")]
        public List<Application> GetApplications()
        {
            string id = "";
            string name = "";
            string description = "";
            string sso = "";
            string owner = "";
            string users = "";
            string status = "";
            string system = "";
            string businessPOC = "";
            string technicalPOC = "";
            string technologyPlatform = "";
            string investment = "";
            string statusChangeDate = "";
            string cloud = "";
            string appType = "";
            string alias = "";
            string regionClass = "";

            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_Application].[Identity], [SAODS].[Def_Application].[Name], [SAODS].[Def_Application].[Description], [SAODS].[Def_Application].[SSO], [SAODS].[Def_Application].[Owning Organization (2 letter code)], [SAODS].[Def_Application].[Users], [SAODS].[Def_Application].[Status], [SAODS].[Def_Application].[System], [SAODS].[Def_Application].[Business POC], [SAODS].[Def_Application].[Technical POC], [SAODS].[Def_Application].[Application Platform], [SAODS].[Def_Application].[Investment], [SAODS].[Def_Application].[Status Change Date], [SAODS].[Def_Application].[Cloud], [SAODS].[Def_Application].[Application Type], [SAODS].[Def_Application].[Aliases], [SAODS].[Def_Application].[Region Classification]  FROM [SAODS].[Def_Application]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var apps = new List<Application>();
                while (reader.Read())
                {
                    id = reader.GetValue(0).ToString();
                    name = reader.GetValue(1).ToString();
                    description = reader.GetValue(2).ToString();
                    sso = reader.GetValue(3).ToString();
                    owner = reader.GetValue(4).ToString();
                    users = reader.GetValue(5).ToString();
                    status = reader.GetValue(6).ToString();
                    system = reader.GetValue(7).ToString();
                    businessPOC = reader.GetValue(8).ToString();
                    technicalPOC = reader.GetValue(9).ToString();
                    technologyPlatform = reader.GetValue(10).ToString();
                    investment = reader.GetValue(11).ToString();
                    statusChangeDate = reader.GetValue(12).ToString();
                    cloud = reader.GetValue(13).ToString();
                    appType = reader.GetValue(14).ToString();
                    alias = reader.GetValue(15).ToString();
                    regionClass = reader.GetValue(16).ToString();
                    apps.Add(new Application() { Id = id, Name = name, Description = description, SSO = sso, Owner = owner, Status = status, System = system, BusinessPOC = businessPOC, TechnicalPOC = technicalPOC, TechnologyPlatform = technologyPlatform, Investment = investment, StatusChangeDate = statusChangeDate, Cloud=cloud, ApplicationType=appType, Alias=alias, RegionClassification=regionClass }); 
                }
                conn.Close();
                return apps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetApplicationCosts")]
        public List<ApplicationCost> GetApplicationCosts()
        {
            string appId = "";
            string fiscalYear = "";
            string dme = "";
            string om = "";
            string total = "";
            string source = "";
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_Application Cost].[Application Identity], [SAODS].[Def_Application Cost].[FY], [SAODS].[Def_Application Cost].[DME], [SAODS].[Def_Application Cost].[OM], [SAODS].[Def_Application Cost].[Total], [SAODS].[Def_Application Cost].[Source] FROM [SAODS].[Def_Application Cost]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var appCosts = new List<ApplicationCost>();
                while (reader.Read())
                {
                    appId = reader.GetValue(0).ToString();
                    fiscalYear = reader.GetValue(1).ToString();
                    dme = reader.GetValue(2).ToString();
                    om = reader.GetValue(3).ToString();
                    total = reader.GetValue(4).ToString();
                    source = reader.GetValue(5).ToString();
                    appCosts.Add(new ApplicationCost() { AppId = appId, FiscalYear = fiscalYear, DME = dme, OM = om, Total = total, Source = source });
                }
                conn.Close();
                return appCosts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetITStandards/{requestType}")]
        public List<Standard> GetITStandards(string requestType)
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                var stands = new List<Standard>();
                if (requestType == "All")
                {
                    cmd.CommandText = "SELECT [SAODS].[Def_Technology].[Identity], [SAODS].[Def_Technology].[Name], [SAODS].[Def_Technology].[Description], [SAODS].[Def_Technology].[Standard Type], [SAODS].[Def_Technology].[Standard Category], [SAODS].[Def_Technology].[Technology Status]  FROM [SAODS].[Def_Technology]";
                    da.SelectCommand = cmd;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string description = reader.GetValue(2).ToString();
                        string type = reader.GetValue(3).ToString();
                        string category = reader.GetValue(4).ToString();
                        string status = reader.GetValue(5).ToString();
                        stands.Add(new Standard() { Id = id, Name = name, Description = description, Type = type, Category = category, Status = status });
                    }
                    conn.Close();
                    return stands;
                }
                else if (requestType == "ByCategory")
                {
                    cmd.CommandText = "SELECT TECH.[Identity], TECH.[Name] as 'Standard Name', TECH.[Technology Status], CATEGORIES.[Name] as 'Category', CATEGORIES.[Parent Category] FROM [SAODS].[Def_Standards Category] CATEGORIES INNER JOIN [SAODS].[LK_Def_Standards Category_Parent Category] PARENTS ON CATEGORIES.[Identity] = PARENTS.[Standards Category Identity] LEFT OUTER JOIN.[SAODS].[LK_Def_Technology_Standard Category] TECH_TO_CAT ON CATEGORIES.[Identity] = TECH_TO_CAT.[Referred Standards Category Identity] RIGHT OUTER JOIN.[SAODS].[Def_Technology] TECH ON TECH.[Identity] = TECH_TO_CAT.[Technology Identity] ORDER BY [Standard Name]";
                    da.SelectCommand = cmd;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string status = reader.GetValue(2).ToString();
                        string category = reader.GetValue(3).ToString();
                        string parentCategory = reader.GetValue(4).ToString();
                        stands.Add(new Standard() { Id = id, Name = name, Status = status, Category = category, ParentCategory = parentCategory });
                    }
                    conn.Close();
                    return stands;
                }
                else
                    return stands;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetGoals")]
        public List<Goal> GetGoals()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_Business Goal].[ID], [SAODS].[Def_Business Goal].[Name], [SAODS].[Def_Business Goal].[Description], [SAODS].[Def_Business Goal].[Target Date], [SAODS].[Def_Business Goal].[Owner], [SAODS].[Def_Business Goal].[Identity] FROM [SAODS].[Def_Business Goal]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var goals = new List<Goal>();
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string description = reader.GetValue(2).ToString();
                    string targetdate = reader.GetValue(3).ToString();
                    string owner = reader.GetValue(4).ToString();
                    string id2 = reader.GetValue(5).ToString();
                    goals.Add(new Goal() { ID = id, Name = name, Description = description, TargetDate = targetdate, Owner = owner, Id = id2});
                }
                conn.Close();
                return goals;
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetBusinessFunctions")]
        public List<BusinessFunction> GetBusinessFunctions()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Identity], [Name], [Description], [BRM Parent] as [Parent Function], null as BRM_Mapping, [Elem Bus Process], [Data], [Element Type], [Fct ID], [Organizations] FROM [SAODS].[Def_BRM Element]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var func = new List<BusinessFunction>();
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string description = reader.GetValue(2).ToString();
                    string parentfunction = reader.GetValue(3).ToString();
                    string brmmapping = reader.GetValue(4).ToString();
                    string elemBusProcess = reader.GetValue(5).ToString();
                    string data = reader.GetValue(6).ToString();
                    string elementType = reader.GetValue(7).ToString();
                    string fctID = reader.GetValue(8).ToString();
                    string organizations = reader.GetValue(9).ToString();
                    func.Add(new BusinessFunction() { Id = id, Name = name, Description = description, ParentFunction = parentfunction, BRMMapping = brmmapping, ElemBusProcess = elemBusProcess, Data = data, ElementType = elementType, FctID = fctID, Organizations = organizations });
                }
                conn.Close();
                return func;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetApplicationTIME")]
        public List<ApplicationTIME> GetApplicationTIME()
        {
            string fy = "";
            string application = "";
            string quad = "";
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SSO], [Name], [Owning Organization (2 letter code)] ,[Status] " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2014' and [Application Identity]=A.[Identity]) FY14_TQ " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2015' and [Application Identity]=A.[Identity]) FY15_TQ " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2016' and [Application Identity]=A.[Identity]) FY16_TQ " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2017' and [Application Identity]=A.[Identity]) FY17_TQ " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2018' and [Application Identity]=A.[Identity]) FY18_TQ " +
                                  " ,(select max([TIME Quadrant]) FROM [SAODS].[Def_Application TIME] WHERE [YEAR] ='2019' and [Application Identity]=A.[Identity]) FY19_TQ " +
                                  "   FROM [SAODS].[Def_Application] A " +
                                  "   WHERE EXISTS (select 1 FROM [SAODS].[Def_Application TIME] AT WHERE AT.[Application Identity]=A.[Identity]) " +
                                  " ORDER BY 1,2"; 
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var appTIMEList = new List<ApplicationTIME>();
                while (reader.Read())
                {
                    string sso = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string owner = reader.GetValue(2).ToString();
                    string status = reader.GetValue(3).ToString();
                    string fy14 = reader.GetValue(4).ToString();
                    string fy15 = reader.GetValue(5).ToString();
                    string fy16 = reader.GetValue(6).ToString();
                    string fy17 = reader.GetValue(7).ToString();
                    string fy18 = reader.GetValue(8).ToString();
                    string fy19 = reader.GetValue(9).ToString();
                    appTIMEList.Add(new ApplicationTIME() { SSO = sso, Name = name, Owner = owner, Status = status, FY14 = fy14, FY15 = fy15, FY16 = fy16, FY17 = fy17, FY18 = fy18, FY19 = fy19 });
                }
                conn.Close();
                return appTIMEList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetFISMASystems/{requestType}")]
        public List<FISMASystem> GetFISMASystems(string requestType)
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                var fs = new List<FISMASystem>();
                if (requestType == "ALL")
                {
                    cmd.CommandText = "SELECT F.[Name], F.[Description], F.[Responsible SSO], F.[FIPS 199 Impact Level], F.[ATO Date], F.[ATO Renewal Date], F.[Federal or Contractor Located?], F.[Continuous Monitoring Transition Date], F.[Complete FISMA Assessment for Current FY?], F.[Related Artifacts], F.[Reference Documents] " +
                                      "FROM [SAODS].[Def_FISMA System] F WHERE F.[Inactive Date] is null ORDER BY 1";
                    da.SelectCommand = cmd;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetValue(0).ToString();
                        string description = reader.GetValue(1).ToString();
                        string respsso = reader.GetValue(2).ToString();
                        string fips199 = reader.GetValue(3).ToString();
                        string atodate = reader.GetValue(4).ToString();
                        string renewaldate = reader.GetValue(5).ToString();
                        string fedContractorLoc = reader.GetValue(6).ToString();
                        string contMonitorDate = reader.GetValue(7).ToString();
                        string complFISMA = reader.GetValue(8).ToString();
                        string relatedArtName = reader.GetValue(9).ToString();
                        string relatedArtURL = reader.GetValue(10).ToString();
                        fs.Add(new FISMASystem() { Name = name, Description = description, RespSSO = respsso, FIPS199 = fips199, ATODate = atodate, RenewalDate = renewaldate, FedContractorLoc = fedContractorLoc, ContMonitorDate = contMonitorDate, ComplFISMA = complFISMA, RelatedArtName = relatedArtName, RelatedArtURL = relatedArtURL });
                    }
                    conn.Close();
                    return fs;
                }
                else if (requestType == "POC")
                {
                    cmd.CommandText = "SELECT F.[Responsible SSO], F.[Name], F.[FIPS 199 Impact Level] " +
                                      "  ,P1.[Name] AO_Name,P1.[Phone Number] AO_Phone,P1.[Email] AO_Email " +
                                      "  ,P2.[Name] PM_Name,P2.[Phone Number] PM_Phone,P2.[Email] PM_Email " +
                                      "  ,P3.[Name] ISSO_Name,P3.[Phone Number] ISSO_Phone,P3.[Email] ISSO_Email " +
                                      "  ,P4.[Name] ISSM_Name,P4.[Phone Number] ISSM_Phone,P4.[Email] ISSM_Email " +
                                      " FROM [SAODS].[Def_FISMA System] F " +
                                      " LEFT OUTER JOIN " +
                                      "   (SELECT  [FISMA System Identity], [Name],[Phone Number],[Email] FROM   [SAODS].[LK_Def_FISMA System_Authorizing Official] A	JOIN [SAODS].[Def_POC] P	ON A.[Referred POC Identity] = P.[Identity]) P1 " +
                                      " ON F.[Identity] = P1.[FISMA System Identity] " +
                                      " LEFT OUTER JOIN " +
                                      "   (SELECT  [FISMA System Identity], [Name],[Phone Number],[Email] FROM   [SAODS].[LK_Def_FISMA System_Program Manager] PM	JOIN [SAODS].[Def_POC] P ON PM.[Referred POC Identity] = P.[Identity]) P2 " +
                                      " ON F.[Identity] = P2.[FISMA System Identity] " +
                                      " LEFT OUTER JOIN " +
                                      "   (SELECT  [FISMA System Identity], [Name],[Phone Number],[Email] FROM   [SAODS].[LK_Def_FISMA System_ISSO] O  JOIN [SAODS].[Def_POC] P ON O.[Referred POC Identity] = P.[Identity]) P3 " +
                                      " ON F.[Identity] = P3.[FISMA System Identity] " +
                                      " LEFT OUTER JOIN " +
                                      "   (SELECT [FISMA System Identity], [Name],[Phone Number],[Email]  FROM   [SAODS].[LK_Def_FISMA System_ISSM] M	JOIN [SAODS].[Def_POC] P ON M.[Referred POC Identity] = P.[Identity]) P4 " +
                                      " ON F.[Identity] = P4.[FISMA System Identity] WHERE F.[Inactive Date] is null order by 1,2";
                    da.SelectCommand = cmd;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string respSSO = reader.GetValue(0).ToString();
                        string name = reader.GetValue(1).ToString();
                        string fips199 = reader.GetValue(2).ToString();
                        string aoName = reader.GetValue(3).ToString();
                        string aoPhone = reader.GetValue(4).ToString();
                        string aoEmail = reader.GetValue(5).ToString();
                        string pmName = reader.GetValue(6).ToString();
                        string pmPhone = reader.GetValue(7).ToString();
                        string pmEmail = reader.GetValue(8).ToString();
                        string issoName = reader.GetValue(9).ToString();
                        string issoPhone = reader.GetValue(10).ToString();
                        string issoEmail = reader.GetValue(11).ToString();
                        string issmName = reader.GetValue(12).ToString();
                        string issmPhone = reader.GetValue(13).ToString();
                        string issmEmail = reader.GetValue(14).ToString();
                        fs.Add(new FISMASystem() { RespSSO = respSSO, Name = name, FIPS199 = fips199, AOName = aoName, AOPhone = aoPhone, AOEmail = aoEmail, PMName = pmName, PMPhone = pmPhone, PMEmail = pmEmail, ISSOName = issoName, ISSOPhone = issoPhone, ISSOEmail = issoEmail, ISSMName = issmName, ISSMPhone = issmPhone, ISSMEmail = issmEmail });
                    }
                    conn.Close();
                    return fs;
                }
                else
                    return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOrganizations")]
        public List<Organization> GetOrganizations()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_Organization Unit].[Name], [SAODS].[Def_Organization Unit].[Description], [SAODS].[Def_Organization Unit].[Parent], [SAODS].[Def_Organization Unit].[Identity] FROM [SAODS].[Def_Organization Unit]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var org = new List<Organization>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string description = reader.GetValue(1).ToString();
                    string parent = reader.GetValue(2).ToString();
                    string id = reader.GetValue(3).ToString();
                    org.Add(new Organization() { Name = name, Description = description, Parent = parent, Id = id });
                }
                conn.Close();
                return org;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetDatasets")]
        public List<Dataset> GetDatasets()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_Dataset].[Name], [SAODS].[Def_Dataset].[Description], [SAODS].[Def_Dataset].[Keyword*], [SAODS].[Def_Dataset].[Organization] FROM [SAODS].[Def_Dataset]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<Dataset>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string description = reader.GetValue(1).ToString();
                    string keyword = reader.GetValue(2).ToString();
                    string organization = reader.GetValue(3).ToString();
                    fs.Add(new Dataset() { Name = name, Description = description, Keyword = keyword, Organization = organization });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOpenDatasets")]
        public GSADataset GetOpenDatasets()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlDataAdapter da1 = new SqlDataAdapter();
                SqlDataAdapter da2 = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmdPOC = conn.CreateCommand();
                SqlCommand cmdDist = conn.CreateCommand();
                cmd.CommandText = "SELECT [Name], [Identity], [Description], [Publisher*] " +
                            //    ",'[\"'+ REPLACE(REPLACE([Keyword*], '\"', ''), ',', '\",\"') +'\"]' as KEY_WORDS " +
                                ", REPLACE([Keyword*], '\"', '') as KEY_WORDS " +
                                 ",case([Public Access Level*]) when 'undefined' then 'non-public' else [Public Access Level*] end AS DATASET_ACCESS_LEVEL " +
                                 ",SUBSTRING([Bureau Code*],CHARINDEX('-',[Bureau Code*])+1, 7) AS DATASET_BUREAU_CODE " +
                                ",CASE WHEN (LEN([Program Code*]) > 8) THEN SUBSTRING([Program Code*], LEN([Program Code*]) - CHARINDEX('-', REVERSE([Program Code*])) + 2, LEN([Program Code*])) ELSE [Program Code*] END AS DATASET_PROGRAM_CODE " +
                                ",[License] license, isNull([Rights],'N/A') as rights, [Mission Area*] AS theme, [Spatial], [Accrual Periodicity] " +
                                ",case UPPER([DATA QUALITY]) when 'T' then 'true' when 'F' then 'false' else 'true' end AS DATASET_DATA_QUALITY " +
                                ",ISNULL([IDENTIFIER], 'GSA - ' + CONVERT(VARCHAR(10), [Identity]) ) AS DATASET_IDENTIFIER " +
                                ",CONVERT(VARCHAR(10),CONVERT(DATE,[ISSUED DATE]), 126) AS DATASET_ISSUED " +
                                ",LEFT([LANGUAGE], ISNULL(NULLIF(CHARINDEX(':', [LANGUAGE]) - 1, -1), LEN([LANGUAGE]))) AS DATASET_LANGUAGE " +
                                ",CONVERT(VARCHAR(10),CONVERT(DATE,[Dataset Last Modified Date*]), 126) AS DATASET_MODIFIED " +
                                ",[Data Dictionary], [Access URL Text], [Access URL] " +
                                "FROM [SAODS].[Def_Dataset]";
                da.SelectCommand = cmd;
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new GSADataset();
                var fsDS = new List<OpenDataset>();
                List<string> fsDist = new List<string>();
                while (reader.Read())
                {
                 //   var fsDist = new List<DatasetDistribution>();
                    var fsPOC = new DatasetContactPoint();
                    var fsPub = new DatasetPublisher();

                    string name = reader.GetValue(0).ToString();
                    string identity = reader.GetValue(1).ToString();
                    string description = reader.GetValue(2).ToString();
                //    List<string> publisher = new List<string> {reader.GetValue(3).ToString()};
                   // List<string> keyword = new List<string> { reader.GetValue(4).ToString().Split(',').ToList<string>() };
                    List<string> keyword =  reader.GetValue(4).ToString().Split(',').ToList<string>() ;
                    string accessLevel = reader.GetValue(5).ToString();
                    List<string> bureauCode = new List<string> {reader.GetValue(6).ToString()};
                    List<string> programCode = new List<string> {reader.GetValue(7).ToString()};
                    string license = reader.GetValue(8).ToString();
                    string rights = reader.GetValue(9).ToString();
                    List<string> theme = new List<string> {reader.GetValue(10).ToString()};
                    string spatial = reader.GetValue(11).ToString();
                    string periodicity = reader.GetValue(12).ToString();
                    bool dataQuality = Convert.ToBoolean(reader.GetValue(13));
                    string identifier = reader.GetValue(14).ToString();
                    string issued = reader.GetValue(15).ToString();
                    List<string> language = new List<string> {reader.GetValue(16).ToString().Trim()};
                    string modified = reader.GetValue(17).ToString();
                    string dataDictURL = reader.GetValue(18).ToString();
                    string transPeriodicity = periodicity;

                    if (String.IsNullOrEmpty(license)) { license = null; }
                    if (String.IsNullOrEmpty(issued)) { issued = null; }
                    if (String.IsNullOrEmpty(spatial)) { spatial = null; }
                    if (String.IsNullOrEmpty(dataDictURL)) { dataDictURL = null; }

                    switch (periodicity) {
                        case "Annual" :
                            transPeriodicity = "R/P1Y";
                            break;
                        case "Monthly":
                            transPeriodicity = "R/P1M";
                            break;
                        case "Weekly":
                            transPeriodicity = "R/P1W";
                            break;
                        case "Quarterly":
                            transPeriodicity = "R/P3M";
                            break;
                        case "Semimonthly":
                            transPeriodicity = "R/P0.5M";
                            break;
                        case "Daily":
                            transPeriodicity = "R/P1D";
                            break;
                        case "Bimonthly":
                            transPeriodicity = "R/P2M";
                            break;
                        case "Biweekly":
                            transPeriodicity = "R/P2W";
                            break;
                        case "Continuously updated":
                        case "Completely irregular":
                            transPeriodicity = "R/PT1S";
                            break;

                        case "Semiannual":
                            transPeriodicity = "R/P6M";
                            break;
                        case "":
                            transPeriodicity = null;
                            break;
                        default:
                            break;
                    }
                    cmdDist.CommandText ="SELECT [Access URL], [Download URL], REPLACE(REPLACE(ISNULL(SUBSTRING([Media Type],CHARINDEX(' ',[Media Type])+1,100), [Media Type]),'[',''),']','') AS [Media Type] " +
                                        "FROM [SAODS].[Def_Dataset Distribution] WHERE [Dataset Identity]  = " + identity;
                    da1.SelectCommand = cmdDist;
                    SqlDataReader readerDist = cmdDist.ExecuteReader();
                    
                    while (readerDist.Read())
                    {
                        string accessURL = readerDist.GetValue(0).ToString();
                        string downloadURL = readerDist.GetValue(1).ToString();
                        string mediaType = readerDist.GetValue(2).ToString();
                        if (String.IsNullOrEmpty(accessURL)) { accessURL = null; }
                        if (String.IsNullOrEmpty(downloadURL)) { downloadURL = null; }
                        if (downloadURL == "null" || downloadURL == "" || String.IsNullOrEmpty(downloadURL) || downloadURL == null)
                        {
                            fsDist.Add(accessURL.ToString());
                            fsDist.Add(mediaType.ToString());
                        }
                        else
                        {
                            fsDist.Add(accessURL.ToString());
                            fsDist.Add(mediaType.ToString());
                            fsDist.Add(downloadURL.ToString());

                        }
                    }
                    readerDist.Close();
                    cmdPOC.CommandText ="SELECT P.Name, P.Email  FROM [SAODS].[LK_Def_Dataset_Contact*] DP " +
                                        "  LEFT OUTER JOIN [SAODS].[Def_POC] P  ON DP.[Referred POC Identity] = P.[Identity] " +
                                        "  WHERE DP.[Dataset Identity] = " + identity;
                    da2.SelectCommand = cmdPOC;
                    SqlDataReader readerPOC = cmdPOC.ExecuteReader();
                    while (readerPOC.Read())
                    {
                        string pocName = readerPOC.GetValue(0).ToString();
                        string pocEmail = readerPOC.GetValue(1).ToString();
                        fsPOC = new DatasetContactPoint() {fn = pocName, hasEmail = "mailto:" + pocEmail} ;
                    }
                    readerPOC.Close();
                    fsPub = new DatasetPublisher() { name = reader.GetValue(3).ToString() };

                    fsDS.Add(new OpenDataset() { title = name, description = description, accessLevel = accessLevel, accrualPeriodicity = transPeriodicity, bureauCode = bureauCode, programCode = programCode, dataQuality = dataQuality, identifier = identifier, issued = issued, modified = modified, keyword = keyword, language = language, spatial = spatial, license = license, rights = rights, theme = theme, describedBy = dataDictURL, publisher = fsPub, distribution = fsDist, contactPoint = fsPOC });
                    fsDist = null;
                    fsPub = null;
                    fsPOC = null;
                }
                fs = new GSADataset() { conformsTo = "https://project-open-data.cio.gov/v1.1/schema", describedBy = "https://project-open-data.cio.gov/v1.1/schema/catalog.json", dataset = fsDS };
                reader.Close();
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetEcpicInvestments")]
        public List<EcpicInvestment> GetEcpicInvestments()
        {
            ecpicConnect();
            try
            {
                string[] invst = null;
                char[] chr = { '"', ' ' };

                invst = ws.Get_InitiativeList_CSV("2BB8204592B2408EB7C9F3F014ED4C2E");
                var fs = new List<EcpicInvestment>();

                foreach (string row in invst.Skip(1))
                {
                    string[] split = new string[10];
                    int i = 0;
                    Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                    foreach (Match match in csvSplit.Matches(row))
                    {
                        split[i++] = match.Value.TrimStart(',');
                    }

                    if (!split[3].Replace("'", " ").Replace("\"", "").Trim().StartsWith("z") && !split[3].Trim().ToUpper().Contains("(TEST)"))
                    {
                        string initiativeID = split[0].ToString();
                        string title = split[3].Replace("'", " ").Replace("\"", "");
                        string initiativeRevision = split[4].ToString();
                        string initiativeClass = split[5].ToString();
                        string initiativeType = split[6].Replace("'", " ").Replace("\"", "");
                        string contact = split[7].Replace("'", " ").Replace("\"", "");
                        fs.Add(new EcpicInvestment() { InitiativeID = initiativeID, Title = title, InitiativeRevision = initiativeRevision, InitiativeClass = initiativeClass, InitiativeType = initiativeType, Contact=contact });
                    }
                }
                //string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv);
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetEcpicPortfolios")]
        public List<EcpicPortfolio> GetEcpicPortfolios()
        {
            ecpicConnect();
            try
            {
                string[] invst = null;
                char[] chr = { '"', ' ' };

                invst = ws.Get_PortfolioList_CSV("2BB8204592B2408EB7C9F3F014ED4C2E");
                var fs = new List<EcpicPortfolio>();

                foreach (string row in invst.Skip(1))
                {
                    string[] split = new string[10];
                    int i = 0;
                    Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                    foreach (Match match in csvSplit.Matches(row))
                    {
                        split[i++] = match.Value.TrimStart(',');
                    }

                    if (!split[3].Replace("'", " ").Replace("\"", "").Trim().StartsWith("z") && !split[3].Trim().ToUpper().Contains("(TEST)"))
                    {
                        string portfolioId = split[0].ToString();
                        string name = split[1].Replace("'", " ").Replace("\"", "");
                        string description = split[2].ToString();
                        string scope = split[3].ToString();
                        string phase = split[4].Replace("'", " ").Replace("\"", "");
                        string poc = split[5].Replace("'", " ").Replace("\"", "");
                        string template = split[6].Replace("'", " ").Replace("\"", "");
                        string BY = split[7].Replace("'", " ").Replace("\"", "");
                        fs.Add(new EcpicPortfolio() { PortfolioHistoryID = portfolioId, PortfolioName = name, PortfolioDescription = description, SCOPE = scope, PHASE = phase, POC = poc, TEMPLATENAME = template, BUDGETYEAR = BY});
                    }
                }
                //string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv);
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetEcpicInitiativeByPortfolio/{portId}")]
        public List<ECPICInitiativeByPortfolio> GetEcpicInitiativeByPortfolio(string portId)
        {
            ecpicConnect();
            try
            {
                string[] invst = null;
                char[] chr = { '"', ' ' };
                invst = ws.Get_InitiativeListInPortfolio_CSV(portId, "2BB8204592B2408EB7C9F3F014ED4C2E");
                var fs = new List<ECPICInitiativeByPortfolio>();

                foreach (string row in invst.Skip(1))
                {
                    string[] split = new string[10];
                    int i = 0;
                    Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                    foreach (Match match in csvSplit.Matches(row))
                    {
                        split[i++] = match.Value.TrimStart(',');
                    }

                    if (!split[3].Replace("'", " ").Replace("\"", "").Trim().StartsWith("z") && !split[3].Trim().ToUpper().Contains("(TEST)"))
                    {
                        string initiativeId = split[0].ToString();
                        string portname = split[1].Replace("'", " ").Replace("\"", "");
                        string tempid = split[2].ToString();
                        string tempname = split[3].ToString();
                        string title = split[4].Replace("'", " ").Replace("\"", "");
                        string initrev = split[5].Replace("'", " ").Replace("\"", "");
                        string cls = split[6].Replace("'", " ").Replace("\"", "");
                        string type = split[7].Replace("'", " ").Replace("\"", "");
                        string contact = split[8].Replace("'", " ").Replace("\"", "");
                        string lastupdate = split[9].Replace("'", " ").Replace("\"", "");
                        fs.Add(new ECPICInitiativeByPortfolio() { InitiativeHistoryID = initiativeId, PORTFOLIONAME = portname, TEMPLATEID = tempid, TEMPLATENAME = tempname, TITLE = title, INITIATIVEREVISION = initrev, CLASS = cls, TYPE = type, CONTACT = contact, LASTUPDATED = lastupdate });
                    }
                }
                //string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(csv);
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetEcpic300Data/{initId}")]
        public List<OMB300> GetEcpic300Data(string initId)
        {
            ecpicConnect();
            try
            {
                ecpicConnect();
                XmlDocument invst = new XmlDocument();
             //   string[] invest = null;
                string e300 = "";
                initId = "0EBE8BB023E03D61E053144A16ACFD41";
                char[] chr = { '"', ' ' };
                e300 = ws.Get_FullExport_XML(initId, "2BB8204592B2408EB7C9F3F014ED4C2E");
                //  DataSet ds = new DataSet();
                var fs = new List<OMB300>();
                try
                {
                    XmlReader rdr = XmlReader.Create(new System.IO.StringReader(e300));
                    string majmissionarea = "";
                    string shortdescription = "";
                    string budget = "";
                    while (rdr.Read())
                    {                      
                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            string element = rdr.LocalName;
                            if (element == "MajorMissionArea")
                            {
                                majmissionarea = rdr.ReadInnerXml();
                            }
                            else if (element == "OMBShortDescription")
                            {
                                shortdescription = rdr.ReadInnerXml();
                            }
                            else if (element == "omb:locationInBudget")
                            {
                                budget = rdr.ReadInnerXml();
                            }         
                        }                     
                    }
                    fs.Add(new OMB300() { MajorMissionArea = majmissionarea, ShortDescription = shortdescription, Budget = budget });
                    return fs;
                }
                catch (Exception ex)
                {
                    throw;
                }     
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetMissionSectors")]
        public List<BRMMissionSector> GetMissionSectors()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_FEAF2 BRM Mission Sector].[Name], [SAODS].[Def_FEAF2 BRM Mission Sector].[Code] FROM [SAODS].[Def_FEAF2 BRM Mission Sector]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<BRMMissionSector>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string code = reader.GetValue(1).ToString();
                    fs.Add(new BRMMissionSector() { Name = name, Code = code });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetBRMBusinessFunctions")]
        public List<BRMBusinessFunction> GetBRMBusinessFunctions()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_FEAF2 BRM Business Function].[Name], [SAODS].[Def_FEAF2 BRM Business Function].[Code], [SAODS].[Def_FEAF2 BRM Business Function].[BRM Mission Sector] FROM [SAODS].[Def_FEAF2 BRM Business Function]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<BRMBusinessFunction>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string code = reader.GetValue(1).ToString();
                    string ms = reader.GetValue(2).ToString();
                    fs.Add(new BRMBusinessFunction() { Name = name, Code = code, MissionSector = ms });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetServices")]
        public List<BRMService> GetServices()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[Def_FEAF2 BRM Service].[Name], [SAODS].[Def_FEAF2 BRM Service].[Definition], [SAODS].[Def_FEAF2 BRM Service].[Code], [SAODS].[Def_FEAF2 BRM Service].[BRM Business Function] FROM [SAODS].[Def_FEAF2 BRM Service]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<BRMService>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string definition = reader.GetValue(1).ToString();
                    string code = reader.GetValue(2).ToString();
                    string ms = reader.GetValue(3).ToString();
                    fs.Add(new BRMService() { Name = name, Code = code, Definition = definition, BusinessFunction = ms });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetGSASystems")]
        public List<GSASystem> GetGSASystems()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Name], [Description], [SSO], [Identity] FROM [SAODS].[Def_System]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<GSASystem>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string description = reader.GetValue(1).ToString();
                    string sso = reader.GetValue(2).ToString();
                    string id = reader.GetValue(3).ToString();
                    fs.Add(new GSASystem() { Name = name, Description = description, SSO = sso, Id = id });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetBenchmarks")]
        public List<Benchmark> GetBenchmarks()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Name], [Description], [Format of Data Point], [GSA FY13 Performance], [Govt Medium FY13 Performance (est.)], [Source of FY13 Data], [GSA FY14 Performance], [Govt Medium FY14 Performance (est.)], [Source of FY14 Data]  FROM [SAODS].[Def_Benchmark]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var bench = new List<Benchmark>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string description = reader.GetValue(1).ToString();
                    string format = reader.GetValue(2).ToString();
                    string fy13perf = reader.GetValue(3).ToString();
                    string fy13med = reader.GetValue(4).ToString();
                    string fy13source = reader.GetValue(5).ToString();
                    string fy14perf = reader.GetValue(6).ToString();
                    string fy14med = reader.GetValue(7).ToString();
                    string fy14source = reader.GetValue(8).ToString();

                    bench.Add(new Benchmark() { Name = name, Description = description, Format = format, FY13Perf = fy13perf, FY13GovtMed = fy13med, FY13Source = fy13source, FY14Perf = fy14perf, FY14GovtMed = fy14med, FY14Source = fy14source });
                }
                conn.Close();
                return bench;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetBRMElement")]
        public List<BRMElement> GetBRMElement()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Name], [Identity], [Description], [Reference Number], [BRM Parent]  FROM [SAODS].[Def_BRM Element]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var BRME = new List<BRMElement>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string id = reader.GetValue(1).ToString();
                    string description = reader.GetValue(2).ToString();
                    string refnum = reader.GetValue(3).ToString();
                    string brmp = reader.GetValue(4).ToString();

                    BRME.Add(new BRMElement() { Name = name, Id = id, Description = description, ReferenceNum = refnum, BRMParent = brmp });
                }
                conn.Close();
                return BRME;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetRISSOPocs")]
        public List<POC> GetRISSOPocs()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT[IDENTITY], [Name],[Phone Number],[Email],[Organization],[Region],[RISSO Title] ,[Security Role],[Training]  FROM [SAODS].[Def_POC]  where [Security Role] in ('Authorizing Official','ISSM','ISSO','Program Manager','RISSO') ORDER BY [Name]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<POC>();
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string phoneNumber = reader.GetValue(2).ToString();
                    string email = reader.GetValue(3).ToString();
                    string organization = reader.GetValue(4).ToString();
                    string region = reader.GetValue(5).ToString();
                    string rissoTitle = reader.GetValue(6).ToString();
                    string securityRole = reader.GetValue(7).ToString();
                    string training = reader.GetValue(8).ToString();
                    fs.Add(new POC() { Id = id, Name = name, PhoneNumber = phoneNumber, Email = email, Organization = organization, Region = region, RISSOTitle = rissoTitle, SecurityRole = securityRole, Training = training });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetInvestments")]
        public List<Investment> GetInvestments()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT[Name], [Description],[Investment Type],[Budget Year],[Primary Service Area],[Secondary Service Area #1]  FROM [SAODS].[Def_Investment]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var inv = new List<Investment>();
                while (reader.Read())
                {
                    string name = reader.GetValue(0).ToString();
                    string desc = reader.GetValue(1).ToString();
                    string invtype = reader.GetValue(2).ToString();
                    string by = reader.GetValue(3).ToString();
                    string psa = reader.GetValue(4).ToString();
                    string ssa = reader.GetValue(5).ToString();
                    inv.Add(new Investment() { Name = name, Description = desc, Type = invtype, BY = by, PrimarySA = psa, SecondarySA = ssa });
                }
                conn.Close();
                return inv;
            }
            catch (Exception)
            {
                throw;
            }
        }






        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetFuncAppMap")]
        public List<FuncAppMap> GetFuncAppMap()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Referred BRM Element Identity], [Application Identity] FROM [SAODS].[LK_Def_Application_Functional Support]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<FuncAppMap>();
                while (reader.Read())
                {
                    string funcid = reader.GetValue(0).ToString();
                    string appid = reader.GetValue(1).ToString();
                    fs.Add(new FuncAppMap() { Funcid = funcid, Appid = appid });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOrgGoalMap")]
        public List<OrgGoalMap> GetOrgGoalMap()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Referred Organization Unit Identity], [Business Goal Identity] FROM [SAODS].[LK_Def_Business Goal_Owner]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var og = new List<OrgGoalMap>();
                while (reader.Read())
                {
                    string orgid = reader.GetValue(0).ToString();
                    string goalid = reader.GetValue(1).ToString();
                    og.Add(new OrgGoalMap() { Orgid = orgid, Goalid = goalid });
                }
                conn.Close();
                return og;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOrgAppMap")]
        public List<OrgAppMap> GetOrgAppMap()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Referred Organization Unit Identity], [Application Identity] FROM [SAODS].[LK_Def_Application_Owning Organization (2 letter code)]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var oa = new List<OrgAppMap>();
                while (reader.Read())
                {
                    string orgid = reader.GetValue(0).ToString();
                    string appid = reader.GetValue(1).ToString();
                    oa.Add(new OrgAppMap() { Orgid = orgid, Appid = appid });
                }
                conn.Close();
                return oa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOrgSysMap")]
        public List<OrgSysMap> GetOrgSysMap()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Referred Organization Unit Identity], [System Identity] FROM [SAODS].[LK_Def_System_SSO]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var os = new List<OrgSysMap>();
                while (reader.Read())
                {
                    string orgid = reader.GetValue(0).ToString();
                    string sysid = reader.GetValue(1).ToString();
                    os.Add(new OrgSysMap() { Orgid = orgid, Sysid = sysid });
                }
                conn.Close();
                return os;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetInterfaces")]
        public List<Interface> GetInterfaces()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Application Identity], [Referred Application Identity] FROM [SAODS].[LK_Def_Application_Application Interface]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var interf = new List<Interface>();
                while (reader.Read())
                {
                    string appid = reader.GetValue(0).ToString();
                    string refappid = reader.GetValue(1).ToString();
                    interf.Add(new Interface() { Appid = appid, RefAppid = refappid });
                }
                conn.Close();
                return interf;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAppTechMap")]
        public List<AppTechMap> GetAppTechMap()
        {
            try
            {
                string dbconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(dbconn);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [SAODS].[LK_Def_Application_Technologies].[Referred Technology Identity], [SAODS].[LK_Def_Application_Technologies].[Application Identity] FROM [SAODS].[LK_Def_Application_Technologies]";
                da.SelectCommand = cmd;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                var fs = new List<AppTechMap>();
                while (reader.Read())
                {
                    string funcid = reader.GetValue(0).ToString();
                    string appid = reader.GetValue(1).ToString();
                    fs.Add(new AppTechMap() { Techid = funcid, Appid = appid });
                }
                conn.Close();
                return fs;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
