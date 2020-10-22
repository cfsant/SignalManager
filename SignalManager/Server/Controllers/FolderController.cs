using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Base.Middleware;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SignalManager.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("folder")]
    public class FolderController : Controller
    {
        private HttpClient Http
        {
            get;
            set;
        } = new HttpClient();

        [Microsoft.AspNetCore.Mvc.Route("FetchAllAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<FolderDomain>> FetchAllAsync([FromBody] MiddlewareDomain<FolderDomain> middleware)
        {
            if (middleware == null || middleware.Objs.First().UuidUser == null) return null;
            middleware = await this.Http.PostJsonAsync<MiddlewareDomain<FolderDomain>>("https://localhost:8080/folder/fetch_all_async", middleware);

            return middleware;
        }
    }
}