using System;
using System.Collections.Generic;
using System.Linq;
using IdSrv3DataMigrationTool.Crypto.Interfaces;
using IdSrv3DataMigrationTool.Migrations.Classes;
using IdSrv3DataMigrationTool.Crypto.IdSrv3Crypto;
using IdSrv3DataMigrationTool.EntityFrameworkModels.IdSrv2Models;

namespace IdSrv3DataMigrationTool.Crypto.Classes
{
    public class PasswordFormat : Migrate, IPasswordFormat
    {
        public virtual void UpdatePasswordFormat()
        {
            var memberships = idSrv2Entities.Memberships.ToDictionary(key => key.UserId);
            foreach (var user in idSrv3Entities.UserAccounts)                     
            {
                var pwDate = new DateTime(2016, 7, 21);

                if (user.Created < pwDate && memberships.ContainsKey(user.ID))
                {
                    string oldHash = memberships[user.ID].Password;
                    string oldSalt = memberships[user.ID].PasswordSalt;
                    int year       = memberships[user.ID].LastPasswordChangedDate.Year;

                    user.HashedPassword = GetNewPasswordFormat(oldHash, oldSalt, year);          
                }
            }
            idSrv3Entities.SaveChanges();
        }

        /* NOTE:
         *   Will only work if original encryption used is the ICrypto. If a different
         *   encrption method was used, end users will need to reset passwords.
         */

        public string GetNewPasswordFormat(string pw, string salt, int year)
        {
            var crypto = new DefaultCrypto();
            int iterations = crypto.GetIterationsFromYear(year);          
            string hex = crypto.EncodeIterations(iterations);

            return hex + "." + pw + salt;     
        }
    }
}
