using TodoApp.Core.Enums;
using TodoApp.Core.Models.Common;

namespace TodoApp.Core.Models
{
    public class TaskModel:BaseModel
    {
        /// <summary>
        /// Başlık bilgisi yer alacak
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Yapılacak işin detayını tutacak
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TaskDate { get; set; }
        public bool IsFavourite { get; set; }
        public TaskStatu Status { get; set; }
        public string Color { get; set; }
    }
}
