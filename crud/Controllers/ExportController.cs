using Microsoft.AspNetCore.Mvc;
using CrudMySQL.Classic.Services;
using System.Threading.Tasks;

namespace CrudMySQL.Classic.Controllers
{
    public class ExportController : Controller
    {
        private readonly IExportService _exportService;

        public ExportController(IExportService exportService)
        {
            _exportService = exportService;
        }

        [HttpGet]
        [Route("export/excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            try
            {
                var excelBytes = await _exportService.ExportToExcelAsync();
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "produits.xlsx");
            }
            catch (Exception ex)
            {
                // Log l'erreur
                return BadRequest("Erreur lors de l'export Excel: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("export/pdf")]
        public async Task<IActionResult> ExportToPdf()
        {
            try
            {
                var pdfBytes = await _exportService.ExportToPdfAsync();
                return File(pdfBytes, "application/pdf", "produits.pdf");
            }
            catch (Exception ex)
            {
                // Log l'erreur
                return BadRequest("Erreur lors de l'export PDF: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("export/history")]
        public async Task<IActionResult> GetHistory()
        {
            try
            {
                var history = await _exportService.GetAuditHistoryAsync();
                return Json(history);
            }
            catch (Exception ex)
            {
                // Log l'erreur
                return BadRequest("Erreur lors de la récupération de l'historique: " + ex.Message);
            }
        }
    }
}
