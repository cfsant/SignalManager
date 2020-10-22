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
            if (middleware == null ||
                string.IsNullOrEmpty(middleware.Objs.First().Email) || string.IsNullOrWhiteSpace(middleware.Objs.First().Email) ||
                string.IsNullOrEmpty(middleware.Objs.First().Password) || string.IsNullOrWhiteSpace(middleware.Objs.First().Password)) return null;

            middleware = await this.Http.PostJsonAsync<MiddlewareDomain<UserDomain>>("https://localhost:8080/user/login_async", middleware);

            return middleware;
        }
    }
}