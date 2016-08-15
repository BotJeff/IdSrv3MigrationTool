using System;
using System.Collections.Generic;
using System.Linq;
using IdSrv3DataMigrationTool.Migrations.Interfaces;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv3Models;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv2Models;

namespace IdSrv3DataMigrationTool.Migrations.Classes
{
    class MigrateClaims : Migrate, IMigrateClaims
    {
        /*
         * Roles in Identity Server 2 two need to become claims for Identity Server 3.
         */
        public void MapClaims()
        {
            var roles = idSrv2Entities.Roles.ToDictionary(k => k.RoleId);
            var users = idSrv3Entities.UserAccounts.ToDictionary(key => key.ID);       

            foreach (var role in idSrv2Entities.UsersInRoles)
            {
                idSrv3Entities.UserClaims.Add(new UserClaim
                {
                    ParentKey = users[role.UserId].Key,
                    Type = "Role",
                    Value = roles[role.RoleId].RoleName,
                });
            }           
            idSrv3Entities.SaveChanges();
        }
    }
}
