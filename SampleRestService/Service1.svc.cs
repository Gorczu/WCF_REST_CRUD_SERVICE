using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ClientService : ICEMLicenceService
    {
        public bool Create(ClientWrapper client)
        {
            using (LicenceAndClientsServiseEntities entities = new LicenceAndClientsServiseEntities())
            {
                try
                {
                    var clientEnt = new Client()
                    {
                        Adress = client.Address,
                        Email = client.Email,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Licence = client.Licence.Select(o =>
                        new Licence
                                    {
                                     Client = o.Client,
                                     ExpirationDate = o.ExpirationDate,
                                     Since = o.Since,
                                     UserId = o.UserId,   
                                    }).ToList(),
                        Registered = client.Registered

                    };
                    entities.Client.Add(clientEnt);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(string email)
        {
            using (LicenceAndClientsServiseEntities entities = new LicenceAndClientsServiseEntities())
            {
                var clientToRemove = entities.Client.FirstOrDefault(t => t.Email == email);
                if (clientToRemove != null)
                {
                    entities.Client.Remove(clientToRemove);
                    entities.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public bool Edit(ClientWrapper client)
        {
            using (LicenceAndClientsServiseEntities entities = new LicenceAndClientsServiseEntities())
            {
                var clientToEdit = entities.Client.FirstOrDefault(t => t.Email == client.Email);
                if (clientToEdit != null)
                {
                    clientToEdit.Adress = client.Address;
                    clientToEdit.FirstName = client.FirstName;
                    clientToEdit.LastName = client.LastName;
                    clientToEdit.Licence = client.Licence.Select(p => new Licence()
                                                                        {
                                                                            Client = p.Client,
                                                                            ExpirationDate = p.ExpirationDate,
                                                                            Since = p.Since,
                                                                            UserId = p.UserId
                                                                        }).ToList();
                    clientToEdit.Registered = client.Registered;
                    return true;
                }
                else
                    return false;
            }
        }

        public List<ClientWrapper> FindAllClients()
        {
            using (LicenceAndClientsServiseEntities entities = new LicenceAndClientsServiseEntities())
            {
                return entities.Client
                        .Select(t =>
                         new ClientWrapper()
                        {
                            Address = t.Adress,
                            Email = t.Email,
                            FirstName = t.FirstName,
                            LastName = t.LastName,
                            Licence = t.Licence.Select(y => new LicenceWrapper()
                                                            { 
                                                               Client = y.Client,
                                                               ExpirationDate = y.ExpirationDate,
                                                               Since = y.Since,
                                                               UserId = y.UserId   
                                                            }).ToList(),
                            Registered = t.Registered
                        })
                        .ToList();
            }
        }

        public ClientWrapper GetClient(string email)
        {
            using (LicenceAndClientsServiseEntities entities = new LicenceAndClientsServiseEntities())
            {
                var itemDb = entities.Client.FirstOrDefault(o => o.Email == email);
                return new ClientWrapper()
                {
                    Address = itemDb.Adress,
                    Email = itemDb.Email,
                    FirstName = itemDb.FirstName,
                    LastName = itemDb.LastName,
                    Licence = itemDb.Licence.Select(o =>
                                                    new LicenceWrapper()
                                                    {
                                                        Client = o.Client,
                                                        Since = o.Since,
                                                        ExpirationDate = o.ExpirationDate,
                                                        UserId = o.UserId
                                                    })
                                            .ToList(),

                    Registered = itemDb.Registered
                };
                                      
            }
        }
    }
}
