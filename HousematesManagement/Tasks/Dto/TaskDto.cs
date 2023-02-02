namespace HousemateManagement.Tasks.Dto
{
    public sealed class TaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; }
    }
}
