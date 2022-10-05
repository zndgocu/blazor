using blazor.wasm.EntityContext.Layout;

namespace blazor.wasm.Client.Service
{
    public class MenuProviderService
    {
        private List<Menu> _menus_default = new List<Menu>() { new Menu(Guid.NewGuid().ToString(), "", "About", "Info") };
        private List<Menu>? _menus;


        public void SetMenus(List<Menu>? menus)
        {
            _menus = menus;
        }
        public List<IGrouping<string?, Menu>>? GetMenus()
        {
            if (_menus == null) return _menus_default?.GroupBy(x => x.TreeMenuId).ToList();
            return _menus?.GroupBy(x => x.TreeMenuId).ToList();
        }
    }
}
