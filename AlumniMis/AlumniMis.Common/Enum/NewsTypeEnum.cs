using System.ComponentModel;

namespace AlumniMis.Common.Enum
{
    public enum NewsTypeEnum
    {
        [Description("校内新闻")]
        SchoolNews = 1,

        [Description("校友新闻")]
        AlumniNews = 2
    }
}