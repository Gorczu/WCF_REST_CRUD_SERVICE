using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICEMLicenceService" in both code and config file together.
    [ServiceContract]
    public interface ICEMLicenceService
    {
        [OperationContract]
        [WebInvoke(Method ="GET", UriTemplate = "getallclients", ResponseFormat = WebMessageFormat.Json)]
        List<ClientWrapper> FindAllClients();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getclient/{email}", ResponseFormat = WebMessageFormat.Json)]
        ClientWrapper GetClient(string email);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Create(ClientWrapper client);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Edit(ClientWrapper email);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Delete(string email);
    }
}
