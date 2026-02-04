using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudMySQL.Classic.Data;
using CrudMySQL.Classic.Models;

namespace CrudMySQL.Classic.Pages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Produit Produit { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Produit.DateCreation = DateTime.Now;
        _context.Produits.Add(Produit);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
