using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdSrv3DataMigrationTool.Crypto.Interfaces;
using IdSrv3DataMigrationTool.Migrations.Classes;
using IdSrv3DataMigrationTool.Crypto.IdSrv3Crypto;

namespace IdSrv3DataMigrationTool.Crypto.Classes
{
    public class PasswordFormat : Migrate, IPasswordFormat
    {
        public virtual void UpdateUserAccountPasswordFormat()
        {
            var membershipDict = idSrv2Entities.Memberships.ToDictionary(key => key.UserId);
            foreach (var userAccount in idSrv3Entities.UserAccounts)
            {
                var newPasswordDate = new DateTime(2016, 7, 21);

                if (userAccount.Created < newPasswordDate && membershipDict.ContainsKey(userAccount.ID))
                {
                    string oldHashedPassword    = membershipDict[userAccount.ID].Password;
                    string passwordSalt         = membershipDict[userAccount.ID].PasswordSalt;
                    int year                    = membershipDict[userAccount.ID].LastPasswordChangedDate.Year;

                    userAccount.HashedPassword = GetNewPasswordFormat(oldHashedPassword, passwordSalt, year);
                }
            }
            idSrv3Entities.SaveChanges();
        }
        private string GetNewPasswordFormat(string password, string salt, int year)
        {
            DefaultCrypto crypto = new DefaultCrypto();
            int iterations = crypto.GetIterationsFromYear(year);          
            string hex = crypto.EncodeIterations(iterations);

            return hex + "." + password + salt;
        }
    }
}
