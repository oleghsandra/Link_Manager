using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LinkManager.Common.Entities;
using LinkManager.DAL.Abstraction.Repository;
using LinkManager.DAL.Concrete.Parsers;
using LinkManager.DAL.Concrete.SQL;

namespace LinkManager.DAL.Concrete.Repository
{
    public class LinkRepository : GenericRepository<LinkEntity>, ILinkRepository
    {
        public LinkRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<LinkEntity> GetLinks(int ownewId)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.OwnerId, ownewId)
            };

            return base.ExecuteReader(
                StoredProcedureNames.spGetLinks,
                LinkParser.MakeBuildingResult,
                parameters);
        }

        public void DeleteLink(int linkId)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.LinkId, linkId)
            };

             base.ExecuteReader(StoredProcedureNames.spDeleteLink, null, parameters);
        }

        public void UpdateLink(LinkEntity updateLink)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.LinkId, updateLink.Id),
                new SqlParameter(StoredProcedureParameters.Title, updateLink.Title),
                new SqlParameter(StoredProcedureParameters.Url, updateLink.Url),
                new SqlParameter(StoredProcedureParameters.TypeId, updateLink.Type.Id),
            };

            base.ExecuteReader(StoredProcedureNames.spUpdateLink, null, parameters);
        }

        public void AddLink(LinkEntity newLink)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.Title, newLink.Title),
                new SqlParameter(StoredProcedureParameters.TypeId, newLink.Type.Id),
                new SqlParameter(StoredProcedureParameters.Url, newLink.Url),
                new SqlParameter(StoredProcedureParameters.OwnerId, newLink.OwnerId)
            };

            base.ExecuteReader(StoredProcedureNames.spAddLink, null, parameters);
        }

        public void ChangeLinkFavoriteValue(int linkId, bool value)
        {
            var parameters = new[]
            {
                new SqlParameter(StoredProcedureParameters.LinkId, linkId),
                new SqlParameter(StoredProcedureParameters.NewFavoriteValue, value)
            };

            base.ExecuteReader(StoredProcedureNames.spSetFavoriteLink, null, parameters);
        }
    }
}
