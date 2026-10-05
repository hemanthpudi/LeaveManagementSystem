namespace LeaveManagementSystem.Models
{
    public class LeaveRequest
    {
        public string LeaveRequestId { get; set; } = string.Empty;
        public Employee Employee { get; set; } = null!;
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; } = null!;
        public int LeaveTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; //Pending,Approved,Rejected
        public DateTime AppliedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public string? Comments { get; set; }
    }

}

