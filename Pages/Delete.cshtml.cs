using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudMySQL.Classic.Data;
using CrudMySQL.Classic.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMySQL.Classic.Pages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Produit Produit { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produit = await _context.Produits.FirstOrDefaultAsync(m => m.Id == id);
        if (produit == null)
        {
            return NotFound();
        }
        Produit = produit;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produit = await _context.Produits.FindAsync(id);
        if (produit != null)
        {
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
