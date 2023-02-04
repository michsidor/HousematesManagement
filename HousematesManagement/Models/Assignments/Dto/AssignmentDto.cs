namespace HousemateManagement.Models.Assignments.Dto
{
    public sealed class AssignmentDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; }
    }
}
