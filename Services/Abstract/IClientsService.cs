using Domain;

namespace Services.Abstract
{
    public interface IClientsService
    {
        void AddOrUpdateClient(Client client);
        Client GetClient(string id);
        bool DeleteClient(string id);
    }
}
