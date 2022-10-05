using blazor.wasm.Client.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace blazor.wasm.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public JsProviderService JsProviderService { get; set; }

        [Inject]
        public MenuProviderService MenuProviderService { get; set; }


        private AppBar? _appBar;
        private bool _toggle { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender == true)
            {
                await JsProviderService.ShowLoading();
                await WorkFirstRender();
                await JsProviderService.HideLoading();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task WorkFirstRender()
        {

        }

        private void OnToggleChanged(bool toggle)
        {
            _toggle = toggle;
        }
    }
}
