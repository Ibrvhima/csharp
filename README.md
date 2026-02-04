# C# Projects

Bienvenue dans mon repository de projets C# ! Ce repository contient différents projets développés avec C# et .NET.

## 📁 Structure des Projets

```
csharp/
├── 📁 crud/                    # CRUD MySQL - Gestion de Produits
├── 📁 CD-Logistics/            # Site Web - Entreprise Logistique
└── 📄 README.md                # Ce fichier
```

---

## 🗄️ CRUD MySQL - Gestion de Produits

Une application CRUD (Create, Read, Update, Delete) moderne et professionnelle pour la gestion de produits avec ASP.NET Core Razor Pages et MySQL.

### 🚀 Fonctionnalités

#### 📊 Gestion des Données
- **CRUD Complet** : Création, lecture, mise à jour et suppression des produits
- **Base de données MySQL** avec Entity Framework Core
- **Pagination** pour les grandes listes de données
- **Recherche avancée** par nom, catégorie et description
- **Tri** par nom, catégorie, prix et date de création

#### 🌍 Multilingue
- **Français 🇫🇷** et **Anglais 🇬🇧** supportés
- Changement de langue instantané
- Sauvegarde automatique de la langue préférée

#### 🎨 Interface Utilisateur
- **Mode Sombre/Clair** avec sauvegarde automatique

### 📂 Accès au Projet
- **Dossier** : [`crud/`](./crud/)
- **Lancement** : `cd crud && dotnet run`

---

## 🚢 CD-Logistics - Site Web Logistique

Site web moderne et professionnel pour CD-Logistics, entreprise spécialisée en solutions logistiques complètes en Afrique de l'Ouest.

### ✨ Fonctionnalités

#### 🌐 Site Web Complet
- **6 pages** : Accueil, Services, À Propos, Équipe, Expertise, Contact
- **Design responsive** adapté à tous les appareils
- **Navigation intuitive** avec menu actif
- **Formulaire de contact** interactif
- **FAQ** dynamique

#### 🎨 Design & UX
- **Interface moderne** avec animations fluides
- **Icônes SVG** personnalisées et professionnelles
- **Palette de couleurs** cohérente (rouge #B70C15)
- **Typographie** optimisée (Open Sans)

#### ⚡ Performances
- **Code optimisé** pour un chargement rapide
- **SEO friendly** avec balises sémantiques
- **Cross-browser** compatible

### 📂 Accès au Projet
- **Dossier** : [`CD-Logistics/`](./CD-Logistics/)
- **Site web** : Ouvrir `CD-Logistics/web-version/index.html`

---

## 🛠 Technologies Utilisées

### Projet CRUD
- **C#** avec ASP.NET Core Razor Pages
- **MySQL** avec Entity Framework Core
- **Bootstrap** pour le design responsive
- **jQuery** pour les interactions

### Projet CD-Logistics
- **HTML5** - Structure sémantique moderne
- **CSS3** - Design responsive avec Grid/Flexbox
- **JavaScript ES6+** - Interactions et animations
- **SVG** - Icônes vectorielles personnalisées

---

## 🚀 Démarrage Rapide

### Pour le projet CRUD
```bash
cd crud
dotnet run
```

### Pour le site CD-Logistics
```bash
cd CD-Logistics/web-version
# Ouvrir index.html dans votre navigateur
```

---

## 📞 Contact

-**Nom** : IBRAHIMA DIALLO
-**Matricul** : B1323 27GI
-**Licence** : 4
- **GitHub** : [@Ibrvhima](https://github.com/Ibrvhima)
- **Repository** : https://github.com/Ibrvhima/csharp

---

<div align="center">

**🎯 Merci de visiter mes projets !**

[![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/fr-fr/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)
[![HTML5](https://img.shields.io/badge/HTML5-E34F26?logo=html5&logoColor=white)](https://html5.org/)

</div>
- **Design Responsive** optimisé pour mobile et desktop
- **Interface Professionnelle** avec Bootstrap 5
- **Animations fluides** et transitions élégantes

### 📤 Export de Données
- **Export Excel** avec formatage professionnel
- **Export PDF** avec mise en page soignée
- **Historique des modifications** (préparé pour audit)

### 🔍 Fonctionnalités Avancées
- **Modal de confirmation** pour les suppressions
- **Tableaux scrollables** sur mobile
- **Statistiques en temps réel** (total produits, valeur totale, catégories)
- **Filtres et tri** dynamiques

## 🛠️ Technologies Utilisées

### Backend
- **ASP.NET Core 10.0** - Framework web
- **Razor Pages** - Framework de pages
- **Entity Framework Core 8.0** - ORM
- **Pomelo.EntityFrameworkCore.MySql** - Provider MySQL
- **iTextSharp** - Génération PDF
- **ClosedXML** - Génération Excel

### Frontend
- **Bootstrap 5** - Framework CSS
- **Font Awesome 6** - Icônes
- **JavaScript Vanilla** - Interactivité
- **CSS3** - Animations et thèmes

### Base de Données
- **MySQL 8.0+** - SGBD relationnel
- **Migration automatique** au démarrage

## 📋 Prérequis

- **.NET 10.0 SDK** ou supérieur
- **MySQL Server** 8.0 ou supérieur
- **Visual Studio 2022** ou VS Code
- **Git** (optionnel)

## 🚀 Installation

### 1. Cloner le projet
```bash
git clone <repository-url>
cd CrudMySQL.Classic
```

### 2. Configurer la base de données
Modifier le fichier `appsettings.json` avec vos informations MySQL :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=crudory_db;Uid=root;Pwd=votre_mot_de_passe;"
  }
}
```

### 3. Restaurer les packages
```bash
dotnet restore
```

### 4. Lancer l'application
```bash
dotnet run
```

L'application sera disponible sur `https://localhost:5000`

## 📁 Structure du Projet

```
CrudMySQL.Classic/
├── Controllers/
│   └── ExportController.cs          # Contrôleur pour les exports
├── Data/
│   └── AppDbContext.cs              # Contexte Entity Framework
├── Models/
│   └── Produit.cs                    # Modèle de données
├── Pages/
│   ├── Index.cshtml                 # Page principale avec liste
│   ├── Create.cshtml                # Page de création
│   ├── Edit.cshtml                  # Page de modification
│   ├── Delete.cshtml                # Page de suppression
│   └── Shared/
│       └── _Layout.cshtml           # Layout principal
├── Services/
│   ├── ExportService.cs            # Service d'export
│   └── LanguageService.cs          # Service de traduction
├── wwwroot/
│   └── css/
│       ├── custom.css               # Styles personnalisés
│       └── theme.css                # Styles pour le thème
├── CrudMySQL.Classic.csproj          # Fichier projet
├── Program.cs                       # Point d'entrée
└── README.md                        # Ce fichier
```

## 🎯 Utilisation

### Navigation
- **Accueil** : Liste des produits avec recherche et filtres
- **Ajouter** : Formulaire de création de nouveau produit
- **Modifier** : Mise à jour des produits existants
- **Supprimer** : Suppression avec confirmation

### Fonctionnalités dans le Header
- **🌐 Langue** : Changer entre Français et Anglais
- **📥 Exporter** : Exporter en Excel ou PDF
- **📊 Historique** : Voir l'historique des modifications
- **🌙 Thème** : Basculer entre mode clair et sombre

### Recherche et Tri
- **Recherche** : Par nom, catégorie ou description
- **Tri** : Par nom, catégorie, prix ou date
- **Ordre** : Croissant ou décroissant
- **Pagination** : Navigation entre les pages de résultats

## 🔧 Configuration

### Base de données
La base de données est créée automatiquement au premier lancement avec la table `Produits` :

```sql
CREATE TABLE Produits (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(255) NOT NULL,
    Prix DECIMAL(18,2) NOT NULL,
    Description TEXT,
    Categorie VARCHAR(100) NOT NULL,
    DateCreation DATETIME NOT NULL
);
```

### Variables d'environnement
- `ASPNETCORE_ENVIRONMENT` : Development/Production
- `ConnectionStrings__DefaultConnection` : Chaîne de connexion MySQL

## 🎨 Personnalisation

### Thème
Le thème est géré via CSS variables dans `wwwroot/css/theme.css` :
- Mode clair : Fond blanc, textes sombres
- Mode sombre : Fond sombre, textes claires
- Sauvegarde automatique dans `localStorage`

### Traductions
Les traductions sont dans `Services/LanguageService.cs` :
- Support facile de nouvelles langues
- Clés de traduction organisées par fonctionnalité
- Fallback automatique vers le français

### Styles
Les styles personnalisés sont dans `wwwroot/css/custom.css` :
- Design responsive mobile-first
- Animations et transitions
- Variables CSS pour la maintenance

## 📊 Export

### Excel
- Format `.xlsx` compatible Microsoft Excel
- Mise en forme professionnelle avec en-têtes colorés
- Largeurs de colonnes automatiques

### PDF
- Format `.pdf` universel
- Mise en page professionnelle avec iTextSharp
- Tableaux formatés et statistiques

## 🔄 Déploiement

### Production
1. Compiler en mode Release :
```bash
dotnet publish -c Release
```

2. Configurer le `appsettings.Production.json` avec les vraies informations de base de données

3. Déployer sur IIS, Azure ou autre plateforme d'hébergement

### Docker
Un `Dockerfile` peut être ajouté pour le déploiement conteneurisé.

## 🐛 API Endpoints

### Export
- `GET /export/excel` : Exporter en Excel
- `GET /export/pdf` : Exporter en PDF
- `GET /export/history` : Obtenir l'historique

### Pages Razor
- `/` : Page d'accueil (Index)
- `/Create` : Création de produit
- `/Edit/{id}` : Modification de produit
- `/Delete/{id}` : Suppression de produit

## 🔒 Sécurité

- **Validation des entrées** avec Data Annotations
- **Protection CSRF** automatique
- **SQL Injection** protégé par Entity Framework
- **XSS Protection** avec Razor Pages

## 🧪 Tests

### Tests manuels
1. Créer un produit
2. Modifier un produit existant
3. Rechercher des produits
4. Tester les exports
5. Changer de langue
6. Tester le mode sombre/clair

### Tests de charge
Utiliser des outils comme Apache JMeter ou k6 pour tester les performances.

## 📝 Journal des Modifications

### Version 1.0.0
- ✅ CRUD complet
- ✅ Interface responsive
- ✅ Mode sombre/clair
- ✅ Support multilingue
- ✅ Export Excel/PDF
- ✅ Recherche et tri
- ✅ Pagination
- ✅ Design professionnel

## 🤝 Contribution

1. Forker le projet
2. Créer une branche (`git checkout -b feature/AmazingFeature`)
3. Committer les changements (`git commit -m 'Add some AmazingFeature'`)
4. Pusher la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

## 📄 Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de détails.

## 📞 Support

Pour toute question ou suggestion :
- Créer une issue sur GitHub
- Contacter l'équipe de développement

## 🙏 Remerciements

- Microsoft pour ASP.NET Core
- Équipe Entity Framework Core
- Bootstrap pour le framework CSS
- Font Awesome pour les icônes
- Communauté open source

---

**CRUDORY** - Fait avec ❤️ en ASP.NET Core
