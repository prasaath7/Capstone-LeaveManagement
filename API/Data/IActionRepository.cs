using API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Dtos;

namespace API.Data
{
    public interface IActionRepository
    {
         Task<IEnumerable<LeaveRequest>> GetRequests();
         Task<LeaveRequest> LeaveAction(ResponseDto responseDto);
         Task<LeaveDays> Setdays (int TotalDays);
         Task<int> GetDays();
    }
}