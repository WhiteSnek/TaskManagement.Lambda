using TaskManagement.Lambda.Enums;

namespace TaskManagement.Lambda.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid CategoryId { get; set; }
        public required Guid CollectionId { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskTypeEnum TaskType { get; set; } = TaskTypeEnum.ONE_TIME;
        public StatusEnum Status { get; set; } = StatusEnum.TODO;
        public PriorityEnum Priority { get; set; } = PriorityEnum.LOW;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
