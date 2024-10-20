using BGCL.Reporting;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.NETCore;
using Rms.Api.Common;
using Rms.BLL.Abstraction.Operation;
using Rms.Database.Database;
using Rms.Models.DbModels.SP;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Setup;
using System.Data;

namespace Rms.Api.Controllers.Report
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillReportController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BillReportController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ElectricBill(int customerId, string month)
        {

            try
            {
                DateTime parsedMonth = DateTime.ParseExact(month, "yyyy-MM", null);
                int year = parsedMonth.Year;
                int monthNumber = parsedMonth.Month;

                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var dataset = _dbContext.Database.SqlQueryRaw<ElectricBillReportModel>("EXEC SP_ElectricBill @CustomerId, @Year, @Month",
                 new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@Year", year),
                new SqlParameter("@Month", monthNumber)
                ).AsQueryable();

                Dictionary<string, DataTable> data = new();
                var dfdf = dataset.ToList();

                if (dataset != null)
                {
                    DataTable dt = Extensions.ConvertListToDataTable(await dataset.ToListAsync());
                    data.Add("ds", dt);
                }

                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\" + "ElectricBillReport" + ".rdlc";

                if (!System.IO.File.Exists(path))
                {
                    return NotFound("Report file not found at " + path);
                }

                ReportDomain reportDomain = new("PDF", data, path, null);
                var reportContent = new ReportApplication().Load(reportDomain);

                return File(reportContent, reportDomain.mimeType, $"{Guid.NewGuid()}.pdf");
            }
            catch (Exception ex)
            {
                // Log the exception for diagnostics
                Console.WriteLine($"Error in ElectricBill generation: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RentAndUtilityBill(int customerId, string month)
        {
            try
            {
                DateTime parsedMonth = DateTime.ParseExact(month, "yyyy-MM", null);
                int year = parsedMonth.Year;
                int monthNumber = parsedMonth.Month;

                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var dataset = _dbContext.Database.SqlQueryRaw<RentAndUtilityBillReportModel>("EXEC SP_RentAndUtilityBill @CustomerId, @Year, @Month",
                 new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@Year", year),
                new SqlParameter("@Month", monthNumber)
                ).AsQueryable();

                var fddf = await dataset.ToListAsync();

                Dictionary<string, DataTable> data = new();

                if (dataset != null)
                {
                    DataTable dt = Extensions.ConvertListToDataTable(await dataset.ToListAsync());
                    data.Add("ds", dt);
                }

                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\" + "RentAndUtilityBillReport" + ".rdlc";

                if (!System.IO.File.Exists(path))
                {
                    return NotFound("Report file not found at " + path);
                }

                ReportDomain reportDomain = new("PDF", data, path, null);
                var reportContent = new ReportApplication().Load(reportDomain);

                return File(reportContent, reportDomain.mimeType, $"{Guid.NewGuid()}.pdf");
            }
            catch (Exception ex)
            {
                // Log the exception for diagnostics
                Console.WriteLine($"Error in ElectricBill generation: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> UtilityBill(int customerId, string month)
        {
            try
            {
                DateTime parsedMonth = DateTime.ParseExact(month, "yyyy-MM", null);
                int year = parsedMonth.Year;
                int monthNumber = parsedMonth.Month;

                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var dataset = _dbContext.Database.SqlQueryRaw<UtilityBillReportModel>("EXEC SP_UtilityBill @CustomerId, @Year, @Month",
                 new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@Year", year),
                new SqlParameter("@Month", monthNumber)
                ).AsQueryable();

                var fddf = await dataset.ToListAsync();

                Dictionary<string, DataTable> data = new();

                if (dataset != null)
                {
                    DataTable dt = Extensions.ConvertListToDataTable(await dataset.ToListAsync());
                    data.Add("ds", dt);
                }

                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\" + "UtilityBillReport" + ".rdlc";

                if (!System.IO.File.Exists(path))
                {
                    return NotFound("Report file not found at " + path);
                }

                ReportDomain reportDomain = new("PDF", data, path, null);
                var reportContent = new ReportApplication().Load(reportDomain);

                return File(reportContent, reportDomain.mimeType, $"{Guid.NewGuid()}.pdf");
            }
            catch (Exception ex)
            {
                // Log the exception for diagnostics
                Console.WriteLine($"Error in ElectricBill generation: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
