using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv3Models;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv2Models;

namespace IdSrv3DataMigrationTool.Migrations.Classes
{
    public abstract class Migrate
    {
        protected IdSrv3Entities idSrv3Entities = new IdSrv3Entities();
        protected IdSrv2Entities idSrv2Entities = new IdSrv2Entities();
    }
}
