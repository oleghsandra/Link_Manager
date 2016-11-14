namespace LinkManager.DAL.Concrete.SQL
{
    public static class StoredProcedureParameters
    {
        public const string LinkId = ColumnNames.LinkId;
        public const string OwnerId = "OwnerId";
        public const string Title = ColumnNames.Title;
        public const string TypeId = ColumnNames.TypeId;
        public const string Url = ColumnNames.Url;
        public const string LinkTypeName = ColumnNames.LinkTypeName;
        public const string LinkCount = "LinkCount";
        public const string PageNumber = "PageNumber";
        public const string FilterLinkTypeId = "FilterLinkTypeId";
        public const string OnlyFavorite = "OnlyFavorite";
        public const string SortOrder = "SortOrder";
        public const string NewFavoriteValue = "NewFavoriteValue";
    }
}
