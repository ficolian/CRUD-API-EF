using Fish.Application.Model;
using Fish.Application.Usecase;
using Fish.Common;
using Fish.Application.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace Fish.Infrastructure.REST
{
    public class CommonClient : ICommonClient, IDisposable
    {
        private readonly RestClient restClient;
        public CommonClient()
        {
            this.restClient = new RestClient(AppConst.AUTH_API_URL);
        }

        public void Dispose()
        {
            restClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        
        public async Task SendLogAPI(LogAPIRequest request)
        {
            var r = new RestRequest("api/log/api/add", Method.Post);
            r.AddJsonBody(request);

            var j = JsonConvert.SerializeObject(request);

            _ = await restClient.PostAsync<Response<object>>(r);
        }

    }
}
