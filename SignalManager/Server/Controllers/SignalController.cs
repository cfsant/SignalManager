using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Base.Middleware;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SignalManager.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("Signal")]
    public class SignalController
    {
        private HttpClient Http
        {
            get;
            set;
        } = new HttpClient();

        [Microsoft.AspNetCore.Mvc.Route("FetchAllAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<IqOptionAdminSignalDomain>> FetchAllAsync([FromBody] MiddlewareDomain<IqOptionAdminSignalDomain> middleware)
        {
            if (middleware == null || middleware.Objs.First().UuidUser == null) return null;
            middleware = await this.Http.PostJsonAsync<MiddlewareDomain<IqOptionAdminSignalDomain>>("https://localhost:8080/iqoptionadminsignal/fetch_all_async", middleware);

            return middleware;
        }

        [Microsoft.AspNetCore.Mvc.Route("UpdateOrInsertInto")]
        [HttpPost]
        public async Task<MiddlewareDomain<IqOptionAdminSignalDomain>> UpdateOrInsertInto([FromBody] MiddlewareDomain<IqOptionAdminSignalDomain> middleware)
        {
            if (middleware == null || middleware.Objs.First().UuidUser == null) return null;
            middleware = await this.Http.PostJsonAsync<MiddlewareDomain<IqOptionAdminSignalDomain>>("https://localhost:8080/iqoptionadminsignal/update_or_insert_async", middleware);

            return middleware;
        }

    }
}
