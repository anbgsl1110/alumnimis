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
                    Atel = "18294567867",
                    Apub = DateTime.Now,
                    Astart = DateTime.Now,
                    Apot = "杭电",
                    Aspec = "测试"
                });
                dbContext.AdminInfos.Add(new AdminInfo
                {
                    Name = "管理员" + i,
                    Phone = "18294567867"
                });
                dbContext.AlumniInfos.Add(new AlumniInfo
                {
                    Anum = "AlumniInfo" + numberTemp + i,
                    Aname =  "校友" + 1,
                    Asex = "女",
                    Atel = "18294567867",
                    Aclass = "三二班",
                    Acoll = "管理学院",
                    Aenter = DateTime.Now.AddDays(-1110),
                    Aleave = DateTime.Now.AddDays(-520),
                    Addres = "浙江杭州",
                    Acompany = "杭电有限公司",
                    Ajob = "CTO"
                });
                dbContext.AlumniOrgans.Add(new AlumniOrgan
                {
                    Gnum = "AlumniOrgan" + numberTemp + i,
                    Gname = "组织" + i,
                    Gtag = "教育",
                    GMaster = "master",
                    Gtel = "18294567867"
                });
                dbContext.Donates.Add(new Donate
                {
                    Dnum = "Donate" + numberTemp + i,
                    Dname = "捐赠" + i,
                    Dtag = "hhh",
                    Dpub = DateTime.Now,
                    Dpuber = "发起人",
                    Dres = "负责人",
                    Dtel = "18294567867",
                    Dstatus = 0,
                    Dremarks = "捐赠备注"
                });
                dbContext.NewReleases.Add(new NewRelease
                {
                    Nnum = "NewRelease" + numberTemp + i,
                    Ntit = "新闻" + i,
                    Nauthor = "作者",
                    Ntime = DateTime.Now,
                    Ntag = "通知",
                    Ntype = "母校新闻",
                    Ncontent = "怎么过一天，就怎么过一生"
                });
                dbContext.RequestServices.Add(new RequestService
                {
                    Snum = "RequestService" + numberTemp + i,
                    Sname = "服务"+ i,
                    Sres = "负责人",
                    Stel = "18294567867",
                    Status = false
                });
            }
        }
    }
}