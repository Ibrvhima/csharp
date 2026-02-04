namespace CrudMySQL.Classic.Services
{
    public interface ILanguageService
    {
        string Get(string key);
        string Get(string key, string culture);
        void SetLanguage(string culture);
        string GetCurrentLanguage();
    }

    public class LanguageService : ILanguageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Dictionary<string, Dictionary<string, string>> _translations;

        public LanguageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _translations = InitializeTranslations();
        }

        public string Get(string key)
        {
            var culture = GetCurrentLanguage();
            return Get(key, culture);
        }

        public string Get(string key, string culture)
        {
            if (_translations.TryGetValue(culture, out var translations) &&
                translations.TryGetValue(key, out var value))
            {
                return value;
            }

            // Fallback to French
            if (_translations.TryGetValue("fr", out var frTranslations) &&
                frTranslations.TryGetValue(key, out var frValue))
            {
                return frValue;
            }

            return key; // Return key if no translation found
        }

        public void SetLanguage(string culture)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Response.Cookies.Append("language", culture, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                });
            }
        }

        public string GetCurrentLanguage()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var cookie = httpContext.Request.Cookies["language"];
                if (!string.IsNullOrEmpty(cookie))
                {
                    return cookie;
                }

                // Try to get from Accept-Language header
                var acceptLanguage = httpContext.Request.Headers["Accept-Language"].FirstOrDefault();
                if (!string.IsNullOrEmpty(acceptLanguage))
                {
                    if (acceptLanguage.StartsWith("en")) return "en";
                    if (acceptLanguage.StartsWith("fr")) return "fr";
                }
            }

            return "fr"; // Default language
        }

        private Dictionary<string, Dictionary<string, string>> InitializeTranslations()
        {
            return new Dictionary<string, Dictionary<string, string>>
            {
                ["fr"] = new Dictionary<string, string>
                {
                    ["Title"] = "Gestion des Produits",
                    ["AddProduct"] = "Ajouter un produit",
                    ["Search"] = "Recherche",
                    ["SearchPlaceholder"] = "Rechercher par nom, catégorie ou description...",
                    ["SortBy"] = "Trier par",
                    ["Order"] = "Ordre",
                    ["Apply"] = "Appliquer",
                    ["TotalProducts"] = "Total Produits",
                    ["TotalValue"] = "Valeur Totale",
                    ["Categories"] = "Catégories",
                    ["ProductsList"] = "Liste des produits",
                    ["Total"] = "produit(s) au total",
                    ["NoProductsFound"] = "Aucun produit trouvé",
                    ["NoProductsFoundFor"] = "Aucun produit trouvé pour",
                    ["ClickToAdd"] = "Cliquez sur \"Ajouter un produit\" pour commencer.",
                    ["ID"] = "ID",
                    ["Name"] = "Nom",
                    ["Category"] = "Catégorie",
                    ["Price"] = "Prix",
                    ["Description"] = "Description",
                    ["Date"] = "Date",
                    ["Actions"] = "Actions",
                    ["Edit"] = "Modifier",
                    ["Delete"] = "Supprimer",
                    ["Previous"] = "Précédent",
                    ["Next"] = "Suivant",
                    ["PageOf"] = "Page {0} sur {1}",
                    ["Results"] = "résultat(s)",
                    ["SearchFor"] = "Recherche:",
                    ["CreationDate"] = "Date de création",
                    ["Ascending"] = "Croissant",
                    ["Descending"] = "Décroissant",
                    ["ConfirmDelete"] = "Confirmation de suppression",
                    ["ConfirmDeleteMessage"] = "Êtes-vous sûr de vouloir supprimer ce produit ?",
                    ["ProductToDelete"] = "Produit à supprimer:",
                    ["Irreversible"] = "Cette action est irréversible.",
                    ["Cancel"] = "Annuler",
                    ["Export"] = "Exporter",
                    ["ExportExcel"] = "Exporter en Excel",
                    ["ExportPDF"] = "Exporter en PDF",
                    ["History"] = "Historique",
                    ["DarkMode"] = "Mode sombre",
                    ["LightMode"] = "Mode clair",
                    ["Language"] = "Langue"
                },
                ["en"] = new Dictionary<string, string>
                {
                    ["Title"] = "Product Management",
                    ["AddProduct"] = "Add product",
                    ["Search"] = "Search",
                    ["SearchPlaceholder"] = "Search by name, category or description...",
                    ["SortBy"] = "Sort by",
                    ["Order"] = "Order",
                    ["Apply"] = "Apply",
                    ["TotalProducts"] = "Total Products",
                    ["TotalValue"] = "Total Value",
                    ["Categories"] = "Categories",
                    ["ProductsList"] = "Products list",
                    ["Total"] = "product(s) in total",
                    ["NoProductsFound"] = "No products found",
                    ["NoProductsFoundFor"] = "No products found for",
                    ["ClickToAdd"] = "Click \"Add product\" to start.",
                    ["ID"] = "ID",
                    ["Name"] = "Name",
                    ["Category"] = "Category",
                    ["Price"] = "Price",
                    ["Description"] = "Description",
                    ["Date"] = "Date",
                    ["Actions"] = "Actions",
                    ["Edit"] = "Edit",
                    ["Delete"] = "Delete",
                    ["Previous"] = "Previous",
                    ["Next"] = "Next",
                    ["PageOf"] = "Page {0} of {1}",
                    ["Results"] = "result(s)",
                    ["SearchFor"] = "Search for:",
                    ["CreationDate"] = "Creation date",
                    ["Ascending"] = "Ascending",
                    ["Descending"] = "Descending",
                    ["ConfirmDelete"] = "Delete Confirmation",
                    ["ConfirmDeleteMessage"] = "Are you sure you want to delete this product?",
                    ["ProductToDelete"] = "Product to delete:",
                    ["Irreversible"] = "This action is irreversible.",
                    ["Cancel"] = "Cancel",
                    ["Export"] = "Export",
                    ["ExportExcel"] = "Export to Excel",
                    ["ExportPDF"] = "Export to PDF",
                    ["History"] = "History",
                    ["DarkMode"] = "Dark mode",
                    ["LightMode"] = "Light mode",
                    ["Language"] = "Language"
                }
            };
        }
    }
}
