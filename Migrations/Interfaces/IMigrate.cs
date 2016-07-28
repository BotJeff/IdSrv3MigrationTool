namespace IdSrv3DataMigrationTool.Migrations.Interfaces
{
    internal interface IMigrate : IMigrateUsers, IMigrateClaims
    {
        new void MapUsers();
        new void MapClaims();
    }
}