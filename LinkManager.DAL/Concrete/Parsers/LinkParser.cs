using System;
using System.Data.SqlClient;
using LinkManager.Common.Entities;
using LinkManager.DAL.Concrete.SQL;

namespace LinkManager.DAL.Concrete.Parsers
{
    public static class LinkParser
    {
        public static LinkEntity MakeBuildingResult(SqlDataReader reader)
        {
            return new LinkEntity
            {
                Type = LinkTypesParser.MakeBuildingResult(reader),
                Id = reader.Get<int>(ColumnNames.LinkId),
                Title = reader.Get<string>(ColumnNames.Title),
                IsFavorite = reader.Get<bool>(ColumnNames.IsFavorite),
                Url = reader.Get<string>(ColumnNames.Url),
                CreationDate = reader.Get<DateTime?>(ColumnNames.CreationDate)
            };
        }
    }
}
