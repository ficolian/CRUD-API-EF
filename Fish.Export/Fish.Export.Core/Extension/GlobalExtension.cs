using Hangfire;
using Newtonsoft.Json;

namespace Fish.Web.API.Core.Extension
{
    public static class GlobalExtension
    {
        public static void UseMediatR(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}
