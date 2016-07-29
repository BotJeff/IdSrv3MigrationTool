using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv3Models;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv2Models;
using IdSrv3DataMigrationTool.Migrations.Interfaces;

namespace IdSrv3DataMigrationTool.Migrations.Classes
{
    class MigrateGroups : Migrate, IMigrateGroups
    {
        public void MapGroups()
        {
            foreach (Role role in idSrv2Entities.Roles)
            {
                idSrv3Entities.Groups.Add(new Group
                {
                    ID          = role.RoleId,
                    Tenant      = "default",
                    Name        = role.RoleName,
                    Description = role.Description,
                    Created     = DateTime.Now,
                    LastUpdated = DateTime.Now
                });
            }
            idSrv3Entities.SaveChanges();
        }
    }
}
