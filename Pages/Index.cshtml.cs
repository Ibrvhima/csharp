using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudMySQL.Classic.Data;
using CrudMySQL.Classic.Models;
using Microsoft.EntityFrameworkCore;
using CrudMySQL.Classic.Services;

namespace CrudMySQL.Classic.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILanguageService _languageService;

    public IndexModel(AppDbContext context, ILanguageService languageService)
    {
        _context = context;
        _languageService = languageService;
    }

    public IList<Produit> Produits { get; set; } = default!;
    
    // Pagination
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = 5;
    public int TotalCount { get; set; }
    
    // Recherche et tri
    public string SearchTerm { get; set; } = "";
    public string SortBy { get; set; } = "DateCreation";
    public string SortOrder { get; set; } = "desc";
    
    // Langue
    public string CurrentLanguage { get; set; } = "fr";

    public async Task OnGetAsync(int currentPage = 1, string searchTerm = "", string sortBy = "DateCreation", string sortOrder = "desc", string language = "")
    {
        // Gestion de la langue
        if (!string.IsNullOrEmpty(language))
        {
            _languageService.SetLanguage(language);
        }
        CurrentLanguage = _languageService.GetCurrentLanguage();
        
        CurrentPage = currentPage;
        SearchTerm = searchTerm ?? "";
        SortBy = sortBy ?? "DateCreation";
        SortOrder = sortOrder ?? "desc";
        
        // Construire la requête de base
        var query = _context.Produits.AsQueryable();
        
        // Appliquer le filtre de recherche
        if (!string.IsNullOrEmpty(SearchTerm))
        {
            query = query.Where(p => 
                p.Nom.Contains(SearchTerm) || 
                p.Categorie.Contains(SearchTerm) ||
                (p.Description != null && p.Description.Contains(SearchTerm))
            );
        }
        
        // Appliquer le tri
        query = SortBy.ToLower() switch
        {
            "nom" => SortOrder.ToLower() == "desc" 
                ? query.OrderByDescending(p => p.Nom)
                : query.OrderBy(p => p.Nom),
            "categorie" => SortOrder.ToLower() == "desc" 
                ? query.OrderByDescending(p => p.Categorie)
                : query.OrderBy(p => p.Categorie),
            "prix" => SortOrder.ToLower() == "desc" 
                ? query.OrderByDescending(p => p.Prix)
                : query.OrderBy(p => p.Prix),
            _ => SortOrder.ToLower() == "desc" 
                ? query.OrderByDescending(p => p.DateCreation)
                : query.OrderBy(p => p.DateCreation)
        };
        
        // Calculer le total des produits
        TotalCount = await query.CountAsync();
        TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
        
        // Obtenir les produits pour la page actuelle
        Produits = await query
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }
    
    // Méthode helper pour les traductions
    public string T(string key)
    {
        return _languageService.Get(key);
    }
    
    // Méthode helper pour le titre de l'application
    public string AppName()
    {
        return "CRUDORY";
    }
}
