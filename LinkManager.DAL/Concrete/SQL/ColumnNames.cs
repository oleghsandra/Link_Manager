namespace LinkManager.DAL.Concrete.SQL
{
    /// <summary>
    /// Class that contains all names of all 
    /// tables in Data Base
    /// </summary>
    public static class ColumnNames
    {
        //Link table
        public const string LinkId = "LinkId";
        public const string Title = "Title";
        public const string IsFavorite = "IsFavorite";
        public const string TypeId = "TypeId";
        public const string Url = "Url";
        public const string CreationDate = "CreationDate";

        //LinkTypes table
        public const string LinkTypeId = "LinkTypeId";
        public const string LinkTypeName = "LinkTypeName";
    }
}