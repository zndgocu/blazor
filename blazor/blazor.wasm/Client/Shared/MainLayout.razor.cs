namespace blazor.wasm.Client.Shared
{
    public partial class MainLayout
    {
        private AppBar _appBar;
        private bool _toggle { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        private void OnToggleChanged(bool toggle)
        {
            _toggle = toggle;
        }
    }
}
