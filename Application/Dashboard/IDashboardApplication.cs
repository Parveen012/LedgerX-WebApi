using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dashboard
{
    public interface IDashboardApplication
    {
        public Task<DashboardDto> GetDashboard();
    }
}
