# PasswordManager
## Description
Ce projet vise à développer une solution Blazor pour un gestionnaire de mots de passe, destiné aux étudiants en enseignement supérieur. Il permettra aux utilisateurs de stocker, gérer et accéder à leurs mots de passe en toute sécurité grâce à une interface conviviale.

## Fonctionnalités principales
- **Authentification (3pts)** : Inscription🆗, connexion🆗.
- **Gestion des mots de passe (2pts)** : Ajouter, modifier et supprimer des mots de passe🆗.
- **Catégorisation (2pts)** : Organiser les mots de passe par catégorie.
- **Recherche rapide (2pts)** : Trouver facilement des mots de passe via une barre de recherche🆗.
- **Chiffrement (3pts)** : Sécuriser les données avec des algorithmes de chiffrement robustes.
- **Mode hors ligne (2pts)** : Accès local sécurisé sans dépendance réseau.
- **Sécurité (3pts)** : Utilisation d’un mot de passe principal pour la décryptage, verrouillage après tentatives échouées.
- **Générateur de mots de passe (2pts)** : Génération de mots de passe complexes et sécurisés avec critères personnalisables.🆗
- **Sauvegarde (5pts)** : sur une base de données SQLite.🆗
- **Interface utilisateur (4pts)** : Simple, intuitive, et responsive avec recherche et filtrage des mots de passe.🆗
- **Points bonus (5pts)**: Tests unitaires, et Application mobile

## Technologies utilisées
- **Framework front-end (5pts)** : [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)🆗
- **Backend (2pts)** : ASP.NET Core Web API🆗
- **Base de données** : SQLite🆗
- **Autres (5pts)** : Entity Framework Core, Dependency Injection, etc.🆗

## Librairies utilisées
- **Refit**: Générateur de client Rest avec des décorateurs
- **Blazored.Toast**: Composant de Toasts pour Blazor
- **Microsoft QuickGrid**: Composant d'affichage avec pagination et lazy loading

## Implémentations Perso
- **OneOf**: Implémentation Inspirée de [OneOf de mcintyre321](https://github.com/mcintyre321/OneOf), pour faire des unions discriminatoires. Pattern consistant à fortement typer les retours de méthodes dans le cas de plusieurs possibilités.