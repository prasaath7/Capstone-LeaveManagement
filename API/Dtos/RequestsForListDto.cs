using System;
using API.Models;

namespace API.Dtos
{
    public class RequestsForListDto
    {
        public int Id { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public UserForListDto User  { get; set;}
        public bool LeaveApproved { get; set; }
    }
}