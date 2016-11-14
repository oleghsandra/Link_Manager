using System.Collections.Generic;
using LinkManager.Common.Entities;

namespace LinkManager.DAL.Abstraction.Repository
{
    public interface ILinkTypeRepository : IGenericRepository<LinkTypeEntity>
    {
        IEnumerable<LinkTypeEntity> GetAllLinkTypes();
    }
}
