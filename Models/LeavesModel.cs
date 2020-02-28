using System;

namespace project_bazi.Models
{
    public class LeavesModel
    {
        public int LeaveId { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveStatus { get; set; }
        public string EmpEmbg { get; set; }
        public string EmpName { get; set; }
    }
}