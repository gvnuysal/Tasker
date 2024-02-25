using TodoApp.Core.Enums;
using TodoApp.Core.Models.Common;

namespace TodoApp.Core.Models
{
    public class SettingsModel:BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public AppTheme Theme { get; set; }
    }
}
