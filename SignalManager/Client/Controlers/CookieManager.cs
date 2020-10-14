using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using SignalManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SignalManager.Client.Controlers
{
    public class CookieManager
    {
        private static IJSRuntime _IJSRuntime { get; set; }

        [Inject]
        public static User User { get; set; }

        [Inject]
        private static HttpClient _Http { get; set; }

        public CookieManager([FromServices] IJSRuntime IJSRuntime, [FromServices] HttpClient Http)
        {
            _IJSRuntime = IJSRuntime;
            _Http = Http;
            User = new User();
        }

        public async Task<User> GetCurrentUser()
        {
            User.Username = await CookieManager.GetValue("sigmgmt_username");
            User.Password = await CookieManager.GetValue("sigmgmt_password");

            return User;
        }

        public async Task SetCurrentUser(User user)
        {
            await CookieManager.SetValue("sigmgmt_username", user.Username, 365);
            await CookieManager.SetValue("sigmgmt_password", user.Password, 365);
        }

        public static async Task<string> GetValue(string strName)
        {
            try
            {
                if (_IJSRuntime == null)
                {
                    throw new ArgumentNullException(nameof(_IJSRuntime), "is null or empty");
                }

                bool isValidCookie = await _IJSRuntime.InvokeAsync<bool>("checkCookie", new[] { strName });
                if (!isValidCookie)
                {
                    return null;
                }

                return await _IJSRuntime.InvokeAsync<string>("getCookie", new[] { strName });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public static async Task SetValue(string strName, string strValue, decimal decExDays)
        {
            try
            {
                if (_IJSRuntime == null)
                {
                    throw new ArgumentNullException(nameof(_IJSRuntime), "is null or empty");
                }

                if (string.IsNullOrEmpty(strValue) || string.IsNullOrWhiteSpace(strValue))
                {
                    strValue = string.Empty;
                }

                await _IJSRuntime.InvokeVoidAsync("setCookie", new object[] { strName, strValue, decExDays });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
