using blazor.wasm.Client.JsInterop.Base;
using Microsoft.JSInterop;

namespace blazor.wasm.Client.JsInterop
{
    public class IndexJs : JsInteropWrapper
    {
        public const string JsId = "IndexJs";
        public const string JsPath = "~/js_interop/index_js/index.js"; 
        public IndexJs(string? id, IJSObjectReference? jsObject) : base(JsId, jsObject)
        {
        }
    }
}
