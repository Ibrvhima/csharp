using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudMySQL.Classic.Data;
using CrudMySQL.Classic.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMySQL.Classic.Pages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Produit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProduitExists(Produit.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ProduitExists(int id)
    {
        return _context.Produits.Any(e => e.Id == id);
    }
}
