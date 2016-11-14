using System.Collections.Generic;
using LinkManager.Common.Entities;

namespace LinkManager.DAL.Abstraction.Repository
{
    public interface ILinkRepository : IGenericRepository<LinkEntity>
    {
        IEnumerable<LinkEntity> GetLinks(int ownewId);

        void DeleteLink(int linkId);

        void UpdateLink(LinkEntity updateLink);

        void AddLink(LinkEntity newLink);

        void ChangeLinkFavoriteValue(int linkId, bool value);
    }
}
