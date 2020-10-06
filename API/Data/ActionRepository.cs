using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ActionRepository : IActionRepository
    {
        private readonly DataContext _context;

        public ActionRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<int> GetDays()
        {
            int mainid = 1;
            var days = await _context.LeaveDays.FindAsync(mainid);
            int TotalDays = days.TotalLeave;
            return TotalDays;
        }

        public async Task<IEnumerable<LeaveRequest>> GetRequests()
        {
           //var requests = await _context.LeaveRequests.Include(p => p.User).ToListAsync();
           var requests = await _context.LeaveRequests.Include(p => p.User).Where(r => r.isVisited == false).ToListAsync();
           
           return requests;
        }

        public async Task<LeaveRequest> LeaveAction(ResponseDto responseDto)
        {
            var entity = await _context.LeaveRequests.FindAsync(responseDto.Id);

            if(responseDto.LeaveApproved)
            {
                var LeaveDays = (entity.EndDate.Date - entity.StartDate.Date).Days;
                if(entity.LeaveType == "paid")
                {
                    var user = await _context.Users.FindAsync(entity.UserId);
                    if(user.PaidLeave < LeaveDays) return null;
                    user.PaidLeave = user.PaidLeave-LeaveDays;
                }

                if(entity.LeaveType == "unpaid")
                {
                    var user = await _context.Users.FindAsync(entity.UserId);
                    if(user.UnpaidLeave < LeaveDays) return null;
                    user.UnpaidLeave = user.UnpaidLeave-LeaveDays;
                }
            }
            entity.LeaveApproved = responseDto.LeaveApproved;
            entity.isVisited = true;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LeaveDays> Setdays(int NewDays)
        {
            int mainid = 1;
            var days = await _context.LeaveDays.FindAsync(mainid);
            int OldDays = days.TotalLeave;
            days.TotalLeave = NewDays;
            int dayDiff = NewDays - OldDays;

            foreach(var user in _context.Users)
            {
                if(user.PaidLeave < NewDays) { user.PaidLeave += dayDiff; }
                else { user.PaidLeave = NewDays; }

                if(user.UnpaidLeave < NewDays) { user.UnpaidLeave += dayDiff; }
                else { user.UnpaidLeave = NewDays; }

            }
            await _context.SaveChangesAsync();
            return days;
        }
    }
}