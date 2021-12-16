using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IClientsRepository
    {
        void AddClient(ClientEntity client);
        void UpdateClient(ClientEntity client);
        List<ClientEntity> GetClients();
        void DeleteClient(ClientEntity client);
    }
}
