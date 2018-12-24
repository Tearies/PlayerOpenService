using System;

namespace WebApi
{
    [Api("/Time")]
    public class TimeTicks
    {
        [Api(ApiVersions.V1, "/Ticks", HttpMethods.GET,"获取当前时间的Ticks")]
        public long Ticks()
        {
            return DateTime.Now.Ticks;
        }

        [Api(ApiVersions.V2, "/Ticks", HttpMethods.GET, "获取当前时间")]
        public string TicksV1()
        {
            return DateTime.Now.ToString();
        }

        [Api(ApiVersions.V2, "/Ticks", HttpMethods.POST,"根据传入的format格式输出格式化当前时间")]
        public string Ticks(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}