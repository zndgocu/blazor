using blazor.wasm.Client.Service;
using blazor.wasm.Client.Shared;
using blazor.wasm.EntityContext.Layout;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ramfree.Extensions.Class;

namespace blazor.wasm.Client.Pages.SetPage
{
    public partial class SettingMenus
    {

        [CascadingParameter]
        protected JsProviderService? JsProviderService { get; set; }

        [CascadingParameter]
        protected MatIconProviderService? MatIconProviderService { get; set; }

        [CascadingParameter]
        protected ISnackbar? Snackbar { get; set; }


        [Inject]
        public MenuProviderService? MenuProviderService { get; set; }

        private List<Menu>? _menus;
        private Dictionary<Menu, string>? _svgs;
        private List<string>? _svgIcons;

        private NavMenu? _navMenu;

        private Menu? _selectedMenu;


        public void OnSelectedMenu(Menu menu)
        {
            _selectedMenu = menu;
        }

        protected override Task OnInitializedAsync()
        {
            _menus = new List<Menu>();
            _svgs = new Dictionary<Menu, string>();
            _svgIcons = new List<string>();
            return base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (JsProviderService != null)
                {
                    await JsProviderService.ShowLoading();
                    await WorkFirstRender();
                    await JsProviderService.HideLoading();
                }
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task WorkFirstRender()
        {
            if (MenuProviderService is not null)
            {
                var result = await MenuProviderService.InitializeMenus();
                if (result.Result == false)
                {
                    ShowSnackBar(result.Message);
                }

                var menus = MenuProviderService.GetMenus();
                var svgs = new Dictionary<Menu, string>();
                List<string> svgIcons = new List<string>();
                foreach (var menu in menus)
                {
                    if (MatIconProviderService != null)
                    {
                        svgs.Add(menu, await MatIconProviderService.GetSvgString(menu.Icon));
                    }
                }

                if (MatIconProviderService != null)
                {
                    var icons = await MatIconProviderService.GetDefaultIconsString();
                    svgIcons.AddRange(icons);
                }


                if (_menus is not null)
                {
                    _menus.Clear();
                    _menus.AddRange(menus);
                } 
                if (_svgs is not null)
                {
                    _svgs.Clear();
                    _svgs.AddRange(svgs);
                } 
                if (_svgIcons is not null)
                {
                    _svgIcons.Clear();
                    _svgIcons.AddRange(svgIcons);
                }
                _navMenu?.Reload();
            }
        }



        public void ShowSnackBar(string? message, Severity severity = Severity.Normal)
        {
            if (Snackbar != null)
            {
                Snackbar.Add(message, severity);
            }
        }
    }
}
