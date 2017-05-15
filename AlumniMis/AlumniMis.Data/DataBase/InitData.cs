using System;
using System.Data.Entity;
using AlumniMis.Common.Util;
using AlumniMis.Data.DataTable;

namespace AlumniMis.Data.DataBase
{
    public class InitData : CreateDatabaseIfNotExists<InitDbContext>
    {
        /// <summary>
        /// 数据库初始数据
        /// </summary>
        /// <param name="dbContext"></param>
        protected override void Seed(InitDbContext dbContext)
        {
            var numberTemp = DateTime.Now.ToShortDateString();
            for (int i = 0; i < 20; i++)
            {
                dbContext.Users.Add(new User
                {
                    UserName = "test" + i,
                    Password = "abc123".Md5String(),
                    UserType = "Alumni",
                    UserInfoId = i + 1,
                    CreateDate = DateTime.Now.Add(new TimeSpan(1)),
                    IsAvailable = true
                });
                dbContext.Activities.Add(new Activity
                {
                    Anum = "Activity" + numberTemp + i,
                    Aname = "活动" + i,
                    Atag = "演示",
                    Amaster = "周树琴",
                    Atel = "12345678",
                    Apub = DateTime.Now,
                    Astart = DateTime.Now,
                    Apot = "杭电",
                    Aspec = "测试"
                });
            }
        }
    }
}