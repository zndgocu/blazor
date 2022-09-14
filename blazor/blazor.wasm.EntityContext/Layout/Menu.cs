using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blazor.wasm.EntityContext.Layout
{
    public class Menu
    {
        public Menu()
        {
        }

        public Menu(string? id, string? treeMenuId, string? name, string? icon)
        {
            Id = id;
            TreeMenuId = treeMenuId;
            Name = name;
            Icon = icon;
        }

        [JsonInclude]
        public string? Id { get; set; }
        [JsonInclude]
        public string? TreeMenuId { get; set; }
        [JsonInclude]
        public string? Name { get; set; }
        [JsonInclude]
        public string? Icon { get; set; }
    }
}
