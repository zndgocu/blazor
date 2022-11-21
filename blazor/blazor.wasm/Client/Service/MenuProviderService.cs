using blazor.wasm.EntityContext.Layout;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ramfree.customDataType.Results;
using ramfree.Extensions.Web;

namespace blazor.wasm.Client.Service
{
    public class MenuProviderService
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public MenuProviderService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public List<Menu> __DEFAULT_MENUS = new List<Menu> { new Menu(Guid.NewGuid().ToString(), "", "", "About", "Info", false, "/about") };

        public List<Menu> Menus { get; set; }
        public async Task<MessageResult> InitializeMenus()
        {
            try
            {
                var result = await HttpClient.GetAsync("menu/get");
                string message = "";
                if (result.IsOk(out message) == false)
                {
                    return new MessageResult(false, message);
                }

                var menus = await result.Content.GetContent<List<Menu>>();
                if (menus == null) throw new Exception("menu is null");
                if (menus.Count < 1) throw new Exception("menu is zero");

                Menus = menus;
            }
            catch (Exception exception)
            {
                return new MessageResult(false, exception.Message);
            }
            return new MessageResult(true);
        }

        public List<Menu> GetMenus()
        {
            if(Menus == null || Menus.Count < 1)
            {
                return __DEFAULT_MENUS;
            }

            return Menus;
        }


    }
}
