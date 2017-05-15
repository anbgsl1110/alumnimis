using System.Collections.Generic;
using System.Linq;
using AlumniMis.Data.DataTable;
using AlumniMis.Data.Provider.IProvider;
using Dapper;

namespace AlumniMis.Data.Provider.Provider
{
    public class UserProvider : IUserProvider
    {
        public List<User> GetUserList()
        {
            using (var dbConnection = DbFactory.GetNewConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM userrepo").ToList();
            }
        }

        public User GetUser(long userId)
        {
            using (var dbConnection = DbFactory.GetNewConnection())
            {
                string sql = string.Format(@"SELECT Id, UserName, Password FROM oemmis_dev.user WHERE Id = {0};"
                    ,userId);
                return dbConnection.Query<User>(sql).SingleOrDefault();
            }
        }
    }
}