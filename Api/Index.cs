namespace WebApi
{
    [Api("/Index")]
    public class Index
    {
        [Api(ApiVersions.V1,"/Help",HttpMethods.VIEW,"查看当前API中所有公开的接口")]
        public string Help()
        {
            var @interface = ApiFactory.Factory.GetInterFace();
            return @interface;
        }
    }
}