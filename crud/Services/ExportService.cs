using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.EntityFrameworkCore;
using CrudMySQL.Classic.Data;
using CrudMySQL.Classic.Models;
using System.Data;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CrudMySQL.Classic.Services
{
    public interface IExportService
    {
        Task<byte[]> ExportToExcelAsync();
        Task<byte[]> ExportToPdfAsync();
        Task<List<AuditLog>> GetAuditHistoryAsync();
    }

    public class ExportService : IExportService
    {
        private readonly AppDbContext _context;

        public ExportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]> ExportToExcelAsync()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Produits");

            // En-têtes
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nom";
            worksheet.Cell(1, 3).Value = "Catégorie";
            worksheet.Cell(1, 4).Value = "Prix";
            worksheet.Cell(1, 5).Value = "Description";
            worksheet.Cell(1, 6).Value = "Date création";

            // Style des en-têtes
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 1).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(1, 2).Style.Font.Bold = true;
            worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 2).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(1, 3).Style.Font.Bold = true;
            worksheet.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 3).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(1, 4).Style.Font.Bold = true;
            worksheet.Cell(1, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 4).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(1, 5).Style.Font.Bold = true;
            worksheet.Cell(1, 5).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 5).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(1, 6).Style.Font.Bold = true;
            worksheet.Cell(1, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            worksheet.Cell(1, 6).Style.Font.FontColor = XLColor.White;

            // Données
            var produits = await _context.Produits
                .OrderByDescending(p => p.DateCreation)
                .ToListAsync();

            int row = 2;
            foreach (var produit in produits)
            {
                worksheet.Cell(row, 1).Value = produit.Id;
                worksheet.Cell(row, 2).Value = produit.Nom;
                worksheet.Cell(row, 3).Value = produit.Categorie;
                worksheet.Cell(row, 4).Value = produit.Prix;
                worksheet.Cell(row, 5).Value = produit.Description ?? "";
                worksheet.Cell(row, 6).Value = produit.DateCreation.ToString("dd/MM/yyyy HH:mm");
                
                row++;
            }

            // Ajuster la largeur des colonnes
            worksheet.Column(1).Width = 8;
            worksheet.Column(2).Width = 30;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 15;
            worksheet.Column(5).Width = 40;
            worksheet.Column(6).Width = 20;

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> ExportToPdfAsync()
        {
            var produits = await _context.Produits
                .OrderByDescending(p => p.DateCreation)
                .ToListAsync();

            using var memoryStream = new MemoryStream();
            using var document = new Document(PageSize.A4, 10, 10, 10, 10);
            using var writer = PdfWriter.GetInstance(document, memoryStream);
            
            document.Open();

            // Titre
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
            var title = new Paragraph("Liste des Produits", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            
            // Date de génération
            var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
            var date = new Paragraph($"Généré le {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont);
            date.Alignment = Element.ALIGN_CENTER;
            document.Add(date);
            
            document.Add(new Paragraph(" "));

            // Tableau
            var table = new PdfPTable(6);
            table.WidthPercentage = 100;
            
            // En-têtes
            var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
            var headerColor = new BaseColor(68, 114, 196); // #4472C4
            
            table.AddCell(new Phrase("ID", headerFont));
            table.AddCell(new Phrase("Nom", headerFont));
            table.AddCell(new Phrase("Catégorie", headerFont));
            table.AddCell(new Phrase("Prix", headerFont));
            table.AddCell(new Phrase("Description", headerFont));
            table.AddCell(new Phrase("Date création", headerFont));
            
            // Appliquer le style aux en-têtes
            for (int i = 0; i < 6; i++)
            {
                var cell = table.GetRow(0).GetCells()[i];
                cell.BackgroundColor = headerColor;
            }
            
            // Données
            var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
            
            foreach (var produit in produits)
            {
                table.AddCell(new Phrase(produit.Id.ToString(), dataFont));
                table.AddCell(new Phrase(produit.Nom, dataFont));
                table.AddCell(new Phrase(produit.Categorie, dataFont));
                table.AddCell(new Phrase(produit.Prix.ToString("C"), dataFont));
                table.AddCell(new Phrase(produit.Description ?? "", dataFont));
                table.AddCell(new Phrase(produit.DateCreation.ToString("dd/MM/yyyy HH:mm"), dataFont));
            }
            
            document.Add(table);
            
            // Footer
            var footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.ITALIC, BaseColor.GRAY);
            var footer = new Paragraph($"Total: {produits.Count()} produits", footerFont);
            footer.Alignment = Element.ALIGN_RIGHT;
            document.Add(footer);
            
            document.Close();
            
            return memoryStream.ToArray();
        }

        public async Task<List<AuditLog>> GetAuditHistoryAsync()
        {
            // Pour l'historique, nous allons créer des logs de base pour l'instant
            // Pour l'instant, retournons une liste vide
            return new List<AuditLog>();
        }
    }

    // Classe pour l'historique des modifications
    public class AuditLog
    {
        public int Id { get; set; }
        public string? Action { get; set; }
        public string? EntityName { get; set; }
        public string? EntityId { get; set; }
        public string? AncienneValeur { get; set; }
        public string? NouvelleValeur { get; set; }
        public string? Utilisateur { get; set; }
        public DateTime DateModification { get; set; }
    }
}
