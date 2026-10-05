namespace LeaveManagementSystem.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto
    {
        public string LeaveTypeName { get; set; } = string.Empty;

        public int MaximumDays { get; set; }
    }
}
