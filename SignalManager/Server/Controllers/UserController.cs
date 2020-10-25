using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Base.Middleware;
using System.Net.Http;
using System.Threading.Tasks;

namespace SignalManager.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("user")]
    public class UserController : Controller
    {
        private HttpClient Http
        {
            get;
            set;
        } = new HttpClient();

        [Microsoft.AspNetCore.Mvc.Route("LoginAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<UserDomain>> LoginAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            return await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/login_async", middleware);
        }

        [Microsoft.AspNetCore.Mvc.Route("FetchAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<UserDomain>> FetchAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            return await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/fetch_async", middleware);
        }

        [Microsoft.AspNetCore.Mvc.Route("RemoveBondAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<UserDomain>> RemoveBondAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            return await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/remove_bond_async", middleware);
        }

        [Microsoft.AspNetCore.Mvc.Route("UpdateOrInsertAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<UserDomain>> UpdateOrInsertAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            return await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/update_or_insert_async", middleware);
        }

        [Microsoft.AspNetCore.Mvc.Route("LoginWithTokenAsync")]
        [HttpPost]
        public async Task<MiddlewareDomain<UserDomain>> LoginWithTokenAsync([FromBody] MiddlewareDomain<UserDomain> middleware)
        {
            return await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/login_with_token_async", middleware);
        }
    }
}