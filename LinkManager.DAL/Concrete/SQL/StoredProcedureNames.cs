namespace LinkManager.DAL.Concrete.SQL
{
    public static class StoredProcedureNames
    {
        //Users SP
        public const string spAddUser = "[dbo].[spUsers_Add]";

        //Link Types SP
        public const string spAddLinkType = "[dbo].[spLinkType_Add]";
        public const string spGetAllLinkTypes = "[dbo].[spLinkTypes_GetAll]";

        //Link SP
        public const string spAddLink = "[dbo].[spLink_AddNew]";
        public const string spGetLinks = "[dbo].[spLinks_Get]";
        public const string spUpdateLink = "[dbo].[spLink_Update]";
        public const string spDeleteLink = "[dbo].[spLink_Delete]";
        public const string spSetFavoriteLink = "[dbo].[spLink_SetFavorite]";
    }
}
