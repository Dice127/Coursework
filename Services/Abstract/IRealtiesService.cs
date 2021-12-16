using Domain;

namespace Services.Abstract
{
    public interface IRealtiesService
    {
        void AddOrUpdateRealty(Realty realty);
        Realty GetRealty(string id);
        bool DeleteRealty(string id);
    }
}
