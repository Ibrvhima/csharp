# CD-Logistics - Solutions Logistiques Complètes

![CD-Logistics Logo](web-version/assets/icons/logo.svg)

**Plateforme web moderne pour CD-Logistics, votre partenaire de confiance en solutions logistiques intégrées en Afrique de l'Ouest.**

---

## 📋 Table des Matières

- [À Propos](#-à-propos)
- [Fonctionnalités](#-fonctionnalités)
- [Technologies](#-technologies)
- [Structure du Projet](#-structure-du-projet)
- [Installation](#-installation)
- [Utilisation](#-utilisation)
- [Déploiement](#-déploiement)
- [Personnalisation](#-personnalisation)
- [Contribution](#-contribution)
- [Licence](#-licence)
- [Contact](#-contact)

---

## 🚀 À Propos

CD-Logistics est une entreprise spécialisée dans les solutions logistiques complètes depuis 2010. Notre plateforme web présente nos services, notre expertise et facilite la communication avec nos clients.

### Notre Mission
Fournir des solutions logistiques fiables, rapides et efficaces qui permettent à nos clients de se concentrer sur leur cœur de métier.

### Nos Valeurs
- **Fiabilité** : Nous tenons nos promesses et livrons toujours à temps
- **Innovation** : Nous adoptons les dernières technologies pour optimiser vos opérations
- **Intégrité** : Nous agissons avec transparence et honnêteté
- **Efficacité** : Nous optimisons chaque processus pour vous faire économiser temps et argent

---

## ✨ Fonctionnalités

### 🌐 Site Web Complet
- **Page d'accueil** moderne avec hero section et statistiques
- **Services détaillés** avec descriptions complètes
- **Présentation de l'entreprise** et de ses valeurs
- **Équipe** avec profils des membres clés
- **Expertise** sectorielle et technologique
- **Formulaire de contact** interactif
- **FAQ** dynamique

### 🎨 Design & UX
- **Design responsive** adapté à tous les appareils
- **Interface moderne** avec animations fluides
- **Navigation intuitive** avec menu actif
- **Icônes SVG** personnalisées et professionnelles
- **Palette de couleurs** cohérente (rouge #B70C15)
- **Typographie** optimisée (Open Sans)

### ⚡ Performances
- **Code optimisé** pour un chargement rapide
- **Images compressées** et icônes SVG légères
- **CSS minifié** et structuré
- **JavaScript** moderne et efficace
- **SEO friendly** avec balises sémantiques

---

## 🛠 Technologies

### Frontend
- **HTML5** - Structure sémantique moderne
- **CSS3** - Design responsive avec Grid/Flexbox
- **JavaScript ES6+** - Interactions et animations
- **SVG** - Icônes vectorielles personnalisées

### Outils & Standards
- **Google Fonts** - Typographie Open Sans
- **Responsive Design** - Mobile-first approach
- **Accessibility** - WCAG 2.1 compatible
- **Cross-browser** - Compatible avec tous les navigateurs modernes

---

## 📁 Structure du Projet

```
CD-Logistics/
├── 📄 README.md                 # Documentation du projet
├── 🌐 web-version/              # Site web complet
│   ├── 📄 index.html           # Page d'accueil
│   ├── 📄 services.html        # Page des services
│   ├── 📄 apropos.html         # Page à propos
│   ├── � equipe.html           # Page équipe
│   ├── 📄 expertise.html       # Page expertise
│   ├── 📄 contact.html         # Page contact
│   ├── 🎨 styles.css           # Feuille de style principale
│   ├── ⚡ script.js            # JavaScript interactif
│   └── 📁 assets/              # Ressources
│       └── 📁 icons/           # Icônes SVG personnalisées
│           ├── 🚢 logo.svg
│           ├── 🚢 ship.svg
│           ├── 🛃 customs.svg
│           ├── 🤝 support.svg
│           └── 🏗️ construction.svg
├── 🔧 Devoir_1/                # Application .NET MAUI (optionnel)
└── 📦 Resources/               # Ressources additionnelles
```

---

## 🚀 Installation

### Prérequis
- Navigateur web moderne (Chrome, Firefox, Safari, Edge)
- Éditeur de code (VS Code, Sublime Text, etc.)

### Installation Locale
1. **Cloner le repository**
   ```bash
   git clone https://github.com/votre-username/CD-Logistics.git
   cd CD-Logistics
   ```

2. **Lancer le site web**
   ```bash
   # Option 1: Ouvrir directement dans le navigateur
   start web-version/index.html
   
   # Option 2: Utiliser un serveur local
   python -m http.server 8000
   # Puis visiter http://localhost:8000/web-version/
   ```

3. **Utiliser Live Server (VS Code)**
   - Installer l'extension "Live Server"
   - Faire clic droit sur `index.html`
   - Sélectionner "Open with Live Server"

---

## 📖 Utilisation

### Navigation du Site
1. **Accueil** - Vue d'ensemble et présentation
2. **Services** - Découvrir nos 4 services principaux
3. **À Propos** - Notre histoire et nos valeurs
4. **Équipe** - Notre équipe et recrutement
5. **Expertise** - Nos compétences sectorielles
6. **Contact** - Nous contacter et FAQ

### Personnalisation Rapide
```html
<!-- Changer les couleurs principales -->
:root {
    --primary-color: #B70C15;    /* Rouge principal */
    --primary-dark: #8A090F;     /* Rouge foncé */
    --primary-light: #E57373;    /* Rouge clair */
}
```

### Modifier le Contenu
1. **Textes** : Éditer les fichiers HTML directement
2. **Styles** : Modifier `styles.css`
3. **Images** : Remplacer les icônes SVG dans `assets/icons/`
4. **Contact** : Mettre à jour les informations dans `contact.html`

---

## 🌍 Déploiement

### Déploiement Statique (Recommandé)
Le site peut être déployé sur n'importe quelle plateforme d'hébergement statique :

#### Netlify
1. Connecter votre repository GitHub
2. Configurer le répertoire de publication : `web-version`
3. Déployer automatiquement

#### Vercel
1. Importer le projet
2. Configurer le répertoire racine : `web-version`
3. Déployer

#### GitHub Pages
1. Activer GitHub Pages dans les settings
2. Sélectionner la branche `main`
3. Configurer le dossier source : `/web-version`

#### Hébergement Traditionnel
1. Uploader le contenu du dossier `web-version/`
2. Assurer la configuration du serveur pour les fichiers statiques

### Configuration du Domaine
```html
<!-- Mettre à jour les URLs dans les fichiers HTML -->
<base href="https://votredomaine.com/">
```

---

## 🎨 Personnalisation

### Marque et Branding
```css
/* Personnaliser les couleurs */
:root {
    --primary-color: #votre-couleur;
    --dark-color: #votre-couleur-foncee;
    --light-color: #votre-couleur-claire;
}

/* Personnaliser les polices */
body {
    font-family: 'Votre-Font', sans-serif;
}
```

### Ajouter de Nouvelles Pages
1. Créer un nouveau fichier HTML dans `web-version/`
2. Copier la structure d'une page existante
3. Mettre à jour la navigation dans tous les fichiers
4. Ajouter les styles spécifiques dans `styles.css`

### Modifier les Icônes
1. Créer de nouveaux SVG dans `assets/icons/`
2. Maintenir la cohérence visuelle (24x24px pour les petites icônes)
3. Optimiser les SVG pour le web

---

## 🤝 Contribution

Nous apprécions les contributions ! Voici comment vous pouvez aider :

### Signaler des Bugs
- Utiliser les [Issues GitHub](https://github.com/votre-username/CD-Logistics/issues)
- Décrire le bug en détail
- Fournir des captures d'écran si possible

### Proposer des Améliorations
- Créer une nouvelle "Issue" avec le tag "enhancement"
- Décrire l'amélioration souhaitée
- Expliquer le bénéfice pour l'utilisateur

### Soumettre du Code
1. Forker le repository
2. Créer une branche (`git checkout -b feature/amélioration`)
3. Commiter les changements (`git commit -am 'Ajouter nouvelle fonctionnalité'`)
4. Pusher la branche (`git push origin feature/amélioration`)
5. Créer une Pull Request

### Standards de Code
- **HTML** : Utiliser la sémantique HTML5
- **CSS** : Suivre les conventions BEM pour les classes
- **JavaScript** : Utiliser ES6+ et commenter le code
- **Accessibilité** : Assurer WCAG 2.1 compliance

---

## 📄 Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

```
MIT License

Copyright (c) 2025 CD-Logistics

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
```

---

## 📞 Contact

### CD-Logistics
- **📍 Adresse** : Conakry, Guinée - Quartier Dixinn
- **📱 Téléphone** : +224 622 70 61 60
- **✉️ Email** : info@asm-cdlogistics.com
- **🌐 Site Web** : https://cdlogistics.com

### Réseau Social
- **LinkedIn** : [CD-Logistics](https://linkedin.com/company/cdlogistics)
- **Facebook** : [@CDLogistics](https://facebook.com/cdlogistics)
- **Twitter** : [@CDLogistics_GN](https://twitter.com/cdlogistics_gn)

### Support Technique
Pour toute question technique sur ce site web :
- **👨‍💻 Développeur** : [Votre Contact]
- **📧 Email Tech** : tech@cdlogistics.com
- **🐛 Issues** : [GitHub Issues](https://github.com/votre-username/CD-Logistics/issues)

---

## 🙏 Remerciements

- **Équipe CD-Logistics** - Pour leur expertise et leur engagement
- **Clients** - Pour leur confiance et leur fidélité
- **Partenaires** - Pour leur collaboration précieuse
- **Community** - Pour les ressources open-source utilisées

---

<div align="center">

**🚢 CD-Logistics - Votre Partenaire Logistique de Confiance**

*Made with ❤️ in Guinea*

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![HTML5](https://img.shields.io/badge/HTML5-E34F26?logo=html5&logoColor=white)](https://html5.org/)
[![CSS3](https://img.shields.io/badge/CSS3-1572B6?logo=css3&logoColor=white)](https://www.w3.org/Style/CSS/)
[![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?logo=javascript&logoColor=black)](https://www.javascript.com/)

</div>
