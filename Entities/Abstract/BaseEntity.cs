using System;

namespace Entities.Abstract
{
    [Serializable]
    public abstract class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }
        public DateTime dateTime { get; set; }
    }
}
