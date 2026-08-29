using System.Data.Entity;
using System.Linq;
using AlumniMis.Data.DataBase;
using MySql.Data.Entity;
using Xunit;

namespace AlumniMis.Test.DataBase
{
    /// <summary>
    /// 初始化数据库相关单元测试
    /// </summary>
    public class DbInitializerTest
    {
        /// <summary>
        /// 删除并创建数据库
        /// </summary>
        [Fact]
        public void DropAndCreateDatabase()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration()); //修正创建数据库时出错的问题
            InitDbContext dbContext = new InitDbContext();
            using (dbContext)
            {
                dbContext.Database.Delete();
                var count = dbContext.Users.Count();
                Assert.True(count > 0);
                var isExist = dbContext.Database.Exists();
                Assert.True(isExist);
            }
        }
    }
}