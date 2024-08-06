using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
