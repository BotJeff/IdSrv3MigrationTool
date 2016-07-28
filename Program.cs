<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdSrv3DataMigrationTool;
using IdSrv3DataMigrationTool.Migrations;
using IdSrv3DataMigrationTool.Migrations.Classes;
using IdSrv3DataMigrationTool.Crypto.Classes;

namespace IdSrv3DataMigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var migrateUsers = new MigrateUsers();
            migrateUsers.MapUsers();

            var migrateClaims = new MigrateClaims();
            migrateClaims.MapClaims();

            var migrateGroups = new MigrateGroups();
            migrateGroups.MapGroups();

            var passwordUpdate = new PasswordFormat();
            passwordUpdate.UpdateUserAccountPasswordFormat();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdSrv3DataMigrationTool;
using IdSrv3DataMigrationTool.Migrations;
using IdSrv3DataMigrationTool.Migrations.Classes;
using IdSrv3DataMigrationTool.Crypto.Classes;

namespace IdSrv3DataMigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var migrateUsers = new MigrateUsers();
            migrateUsers.MapUsers();

            var migrateClaims = new MigrateClaims();
            migrateClaims.MapClaims();

            var migrateGroups = new MigrateGroups();
            migrateGroups.MapGroups();

            var passwordUpdate = new PasswordFormat();
            passwordUpdate.UpdateUserAccountPasswordFormat();
        }
    }
}
>>>>>>> 6984fb790f5598ba0e2af99b0681236b2876e077
