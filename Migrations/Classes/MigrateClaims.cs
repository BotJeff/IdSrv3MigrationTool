using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdSrv3DataMigrationTool.Migrations.Interfaces;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv3Models;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv2Models;

namespace IdSrv3DataMigrationTool.Migrations.Classes
{
    class MigrateClaims : Migrate, IMigrateClaims
    {
        /*
         * Roles in Identity Server 2 two need to become claims for Identity Server 3.
         * 
         */
        public void MapClaims()
        {
            Dictionary<Guid, Role> roles = idSrv2Entities.Roles.ToDictionary(k => k.RoleId);

            Dictionary<Guid, UserAccount> userAccount;
            userAccount = idSrv3Entities.UserAccounts.ToDictionary(key => key.ID);

            foreach (var role in idSrv2Entities.UsersInRoles)
            {
                idSrv3Entities.UserClaims.Add(new UserClaim
                {
                    ParentKey = userAccount[role.UserId].Key,
                    Type = "Role",
                    Value = roles[role.RoleId].RoleName,
                });
            }           
            idSrv3Entities.SaveChanges();
        }
    }
}
