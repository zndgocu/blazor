using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Menu(string? id, string? menuType, string? treeMenuId, string? name, string? icon, bool expanded, string? link)
        {
            Id = id;
            Menu_Type = menuType;
            Tree_Menu_Id = treeMenuId;
            Name = name;
            Icon = icon;
            Expanded = expanded;
            Link = link;
        }

        [JsonInclude]
        [Required]
        [StringLength(36, ErrorMessage = "Name length can't be more than 8.")]
        public string? Id { get; set; }
        [JsonInclude]
        public string? Menu_Type { get; set; }
        [JsonInclude]
        public string? Tree_Menu_Id { get; set; }
        [JsonInclude]
        public string? Name { get; set; }
        [JsonInclude]
        public string? Icon { get; set; }
        [JsonInclude]
        public bool Expanded { get; set; }
        [JsonInclude]
        public string? Link { get; set; }

    }
}
