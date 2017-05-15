using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AlumniMis.Data.DataTable;

namespace AlumniMis.Data.DataBase
{
    public class InitDbContext : DbContext
    {
        static InitDbContext()
        {
            Database.SetInitializer(new InitData());
        }

        public InitDbContext() : base("alumnimis")
        {
        }

        /// <summary>
        /// 重写数据库表格模型
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //移除复数表名

            //User
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.UserName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.Password).HasMaxLength(50);

        }

        #region 组织结构属性

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 活动
        /// </summary>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// 管理员信息
        /// </summary>
        public DbSet<AdminInfo> AdminInfos { get; set; }

        /// <summary>
        /// 校友信息
        /// </summary>
        public DbSet<AlumniInfo> AlumniInfos { get; set; }

        /// <summary>
        /// 校友组织
        /// </summary>
        public DbSet<AlumniOrgan> AlumniOrgans { get; set; }

        /// <summary>
        /// 捐赠
        /// </summary>
        public DbSet<Donate> Donates { get; set; }

        /// <summary>
        /// 新闻发布
        /// </summary>
        public DbSet<NewRelease> NewReleases { get; set; }

        /// <summary>
        /// 请求服务
        /// </summary>
        public DbSet<RequestService> RequestServices { get; set; }

        #endregion
    }
}