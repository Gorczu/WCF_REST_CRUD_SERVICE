using System;
using System.Runtime.Serialization;

namespace SampleRestService
{
    [DataContract]
    public class LicenceWrapper
    {
        [DataMember]public Client Client { get; internal set; }
        [DataMember]public DateTime ExpirationDate { get; internal set; }
        [DataMember]public DateTime Since { get; internal set; }
        [DataMember]public string UserId { get; internal set; }
    }
}