using System;
using System.Collections.Generic;
using LinkManager.Common.Entities;
using LinkManager.DAL.Abstraction.Repository;
using LinkManager.DAL.Concrete.Parsers;
using LinkManager.DAL.Concrete.SQL;

namespace LinkManager.DAL.Concrete.Repository
{
    public class LinkTypeRepository : GenericRepository<LinkTypeEntity>, ILinkTypeRepository
    {
        public LinkTypeRepository(string connection) 
            : base(connection)
        {
            
        }

        public IEnumerable<LinkTypeEntity> GetAllLinkTypes()
        {
            return base.ExecuteReader(StoredProcedureNames.spGetAllLinkTypes, LinkTypesParser.MakeBuildingResult);
        }
    }
}
