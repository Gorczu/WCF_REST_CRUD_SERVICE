using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SampleRestService
{
    [DataContract]
    public class ClientWrapper
    {
        [DataMember]public string Address { get; internal set; }
        [DataMember]public string Email { get; internal set; }
        [DataMember]public string FirstName { get; internal set; }
        [DataMember]public string LastName { get; internal set; }
        [DataMember]public ICollection<LicenceWrapper> Licence { get; internal set; }
        [DataMember] public DateTime? Registered { get; internal set; }
    }
}