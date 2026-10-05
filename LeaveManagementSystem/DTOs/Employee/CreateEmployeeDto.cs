namespace LeaveManagementSystem.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string EmployeeCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }

    }
}
