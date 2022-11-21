using blazor.wasm.Client.Service;
using blazor.wasm.EntityContext.Layout;
using Microsoft.AspNetCore.Components;

namespace blazor.wasm.Client.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public bool? Editable { get; set; } = false;

        [Parameter]
        public EventCallback<Menu> OnSelectedMenu { get; set; }

        private bool IsEditMode()
        {
            if (Editable is null) return false;
            return Editable.Value;
        }

        [CascadingParameter]
        protected List<Menu>? Menus { get; set; }

        [CascadingParameter]
        protected Dictionary<Menu, string>? Svgs { get; set; }



        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        public void Reload()
        {
            StateHasChanged();
        }

        public List<Menu> GetNonTreeMenu()
        {
            if (Menus == null) return new List<Menu>();
            return Menus.Where(x => string.IsNullOrEmpty(x.Tree_Menu_Id)).ToList();
        }

        public List<Menu> GetTreeMenu(string id)
        {
            if (Menus == null) return new List<Menu>();
            if (string.IsNullOrEmpty(id)) return new List<Menu>();
            return Menus.Where(x => x.Tree_Menu_Id == id).ToList();
        }

        public string? GetIcon(Menu menu)
        {
            string? result = "";
            Svgs?.TryGetValue(menu, out result);
            return string.IsNullOrEmpty(result) ? menu.Icon : result;
        }

        private void OnClickMenu(Menu menu)
        {
            OnSelectedMenu.InvokeAsync(menu);
        }
    }
}
