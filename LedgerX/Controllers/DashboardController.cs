using Application.Dashboard;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardApplication _dashboardApplication;

        public DashboardController(IDashboardApplication dashboardApplication)
        {
            _dashboardApplication = dashboardApplication;
        }

        [HttpGet]
        public async Task<DashboardDto> GetDashboard()
        {
            return await _dashboardApplication.GetDashboard();

        }
    }
}
