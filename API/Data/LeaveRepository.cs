using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly DataContext _context;

        public LeaveRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<LeaveRequest> Request(LeaveRequest leaveRequest)
        {
            var LeaveDays = (leaveRequest.EndDate.Date - leaveRequest.StartDate.Date).Days;
            if(leaveRequest.LeaveType == "paid")
            {
                var user = await _context.Users.FindAsync(leaveRequest.UserId);
                if(user.PaidLeave < LeaveDays) return null;
            }

            if(leaveRequest.LeaveType == "unpaid")
            {
                var user = await _context.Users.FindAsync(leaveRequest.UserId);
                if(user.UnpaidLeave < LeaveDays) return null;
            }

            await _context.LeaveRequests.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}