using System.Text.Json.Serialization;
using TodoApp.Core.Enums;
using TodoApp.Core.Models.Common;

namespace TodoApp.Core.Models
{
    public class SettingsModel:BaseModel
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("theme")]
        public TaskTheme Theme { get; set; }
    }
}
