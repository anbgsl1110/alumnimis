using AlumniMis.Data.Provider.Provider;

namespace AlumniMis.Services.Service.Service
{
    /// <summary>
    /// 服务对象基类
    /// </summary>
    public class BaseService
    {
        public UserProvider UserProvider { get; }
        public AdminInfoProvider AdminInfoProvider { get; }
        public AlumniInfoProvider AlumniInfoProvider { get; }
        public ActivityProvider ActivityProvider { get; }
        public AlumniOrganProvider AlumniOrganProvider { get; }
        public DonateProvider DonateProvider { get; }
        public NewReleaseProvider NewReleaseProvider { get; }
        public RequestServiceProvider RequestServiceProvider { get; }

        public BaseService()
        {
            UserProvider = new UserProvider();
            AdminInfoProvider = new AdminInfoProvider();
            AlumniInfoProvider = new AlumniInfoProvider();
            ActivityProvider = new ActivityProvider();
            AlumniOrganProvider = new AlumniOrganProvider();
            DonateProvider = new DonateProvider();
            NewReleaseProvider = new NewReleaseProvider();
            RequestServiceProvider = new RequestServiceProvider();
        }
    }
}