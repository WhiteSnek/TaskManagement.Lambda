namespace TaskManagement.Lambda.Enums
{
    public enum TaskTypeEnum
    {
        ONE_TIME = 0,
        RECURRING = 1
    }

    public enum StatusEnum
    {
        TODO = 0,
        IN_PROGRESS = 1,
        DONE = 2,
        DROPPED = 3,
    }

    public enum PriorityEnum
    {
        LOW = 0,
        MEDIUM = 1,
        HIGH = 2,
        CRITICAL = 3
    }
}
