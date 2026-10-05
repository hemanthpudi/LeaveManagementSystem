namespace LeaveManagementSystem.DTOs.LeaveType
{
    public class CreateLeaveTypeDto
    {
        public string LeaveTypeName { get; set; } = string.Empty;

        public int MaximumDays { get; set; }
    }
}
