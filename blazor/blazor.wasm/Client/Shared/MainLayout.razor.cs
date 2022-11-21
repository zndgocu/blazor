using blazor.wasm.Client.Service;
using blazor.wasm.EntityContext.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace blazor.wasm.Client.Shared
{
    public partial class MainLayout
    {

        [Inject]
        public JsProviderService JsProviderService { get; set; }

        [Inject]
        public MenuProviderService MenuProviderService { get; set; }

        [Inject]
        public MatIconProviderService MatIconProviderService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private List<Menu> Menus = new List<Menu>();
        private Dictionary<Menu, string> Svgs = new Dictionary<Menu, string>();


        private AppBar? _appBar;
        private NavMenu? _navMenu;
        private bool _toggle { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsProviderService.ShowLoading();
                await WorkFirstRender();
                await JsProviderService.HideLoading();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task WorkFirstRender()
        {
            var result = await MenuProviderService.InitializeMenus();
            if (result.Result == false)
            {
                ShowSnackBar(result.Message);
            }

            Menus = MenuProviderService.GetMenus();

            foreach(var menu in Menus)
            {
                Svgs.Add(menu, await MatIconProviderService.GetSvgString(menu.Icon));
            }

            _navMenu?.Reload();
        }

        private void OnToggleChanged(bool toggle)
        {
            _toggle = toggle;
        }

        public void ShowSnackBar(string? message, Severity severity = Severity.Normal)
        {
            Snackbar.Add(message, severity);
        }
    }
}
