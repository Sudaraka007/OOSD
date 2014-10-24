namespace SalesLeadsManagementSystem.Security
{
    public enum Permissions : byte
    {
        NoPermissions = 0,
        Engineer = 1,
        AccountManager = 2,
        Manager = 3,
        DeputyGeneralManager = 4,
        GeneralManager = 5
    }
}