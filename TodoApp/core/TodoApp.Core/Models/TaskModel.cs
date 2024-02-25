using System.Text.Json.Serialization;
using TodoApp.Core.Enums;
using TodoApp.Core.Models.Common;

namespace TodoApp.Core.Models
{
    public class TaskModel:BaseModel
    {
        /// <summary>
        /// Başlık bilgisi yer alacak
        /// </summary>
        /// 
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Yapılacak işin detayını tutacak
        /// </summary>
        /// 
        [JsonPropertyName("content")]
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [JsonPropertyName("taskDate")]
        public DateTime TaskDate { get; set; }
        [JsonPropertyName("isFavourite")]
        public bool IsFavourite { get; set; }
        [JsonPropertyName("status")]
        public TaskStatu Status { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
