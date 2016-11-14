using System.Data.SqlClient;
using LinkManager.Common.Entities;
using LinkManager.DAL.Concrete.SQL;

namespace LinkManager.DAL.Concrete.Parsers
{
    public static class LinkTypesParser
    {
        public static LinkTypeEntity MakeBuildingResult(SqlDataReader reader)
        {
            return new LinkTypeEntity
            {
                Id = reader.Get<int>(ColumnNames.LinkTypeId),
                Name = reader.Get<string>(ColumnNames.LinkTypeName)
            };
        }
    }
}
