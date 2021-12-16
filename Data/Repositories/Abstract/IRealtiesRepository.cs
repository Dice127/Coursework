using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IRealtiesRepository
    {
        void AddRealty(RealtyEntity realty);
        void UpdateRealty(RealtyEntity realty);
        List<RealtyEntity> GetRealties();
        void DeleteRealty(RealtyEntity realty);
    }
}
