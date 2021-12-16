using System;

namespace Entities.Abstract
{
    public interface IBaseEntity
    {
        int ID { get; set; }
        DateTime dateTime { get; set; }
    }
}
