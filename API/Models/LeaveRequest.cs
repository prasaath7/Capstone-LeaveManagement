using System;


namespace API.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public User User  { get; set;}
        public int UserId { get; set; }
        public bool LeaveApproved { get; set; }
        public bool isVisited { get; set; }
    }
}