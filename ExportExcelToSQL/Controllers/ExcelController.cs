using ExportExcelToSQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;

namespace ExportExcelToSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly AppDbContext context;

        public ExcelController(AppDbContext context)
        {
            this.context = context;
        }

        //public async Task<List<AirportDTO>> Import(IFormFile file)
        //{
        //    var list = new List<AirportDTO>();
        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        using (var package = new ExcelPackage(stream))
        //        {

        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowcount = worksheet.Dimension.Rows;
        //            var colcount = worksheet.Dimension.Columns;

        //            for (int row = 2; row < rowcount; row++)
        //            {
        //                list.Add(new AirportDTO
        //                {
        //                    AirportName = worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                    CountryName = worksheet.Cells[row, 2].Value.ToString().Trim(),
        //                    THLCode= worksheet.Cells[row, 3].Value.ToString().Trim()                           
        //                });
        //            }
        //        }
        //    }
        //    //SaveDataToDb(list);
        //    context.Airports.AddRange((IEnumerable<Airport>)list);
        //    await context.SaveChangesAsync();

        //    return list;


        //}
        [HttpPost("importOrderData")]
        public async Task<IActionResult> ImportOrderData(IFormFile file)
        {
            var listobj = new List<AirportDTO>();
            var savedIds = new List<int>();

            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }
            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // select the first worksheet
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // process each row in the worksheet
                for (int row = 2; row <= rowCount; row++)
                {
                    // process each column in the row
                    var ineobj = new AirportDTO();

                    // access the cell value using worksheet.Cells[row, col].Value
                    ineobj.AirportName = (worksheet.Cells[row, 2].Value?.ToString());
                    ineobj.CountryName = (worksheet.Cells[row, 3].Value?.ToString());
                    ineobj.THLCode = (worksheet.Cells[row, 4].Value?.ToString());
                    listobj.Add(ineobj);

                }
                var airportEntities = listobj.Select(dto => new Airport
                {
                    AirportName = dto.AirportName,
                    CountryName = dto.CountryName,
                    THLCode = dto.THLCode,
                    IsDeleted=dto.IsDeleted,
                    CreatedOn=dto.CreatedOn,
                    ModifyOn=dto.ModifyOn
                }).ToList();

                context.Airports.AddRange(airportEntities);
                await context.SaveChangesAsync();

            }

            return Ok(listobj);
        }

    }
}
