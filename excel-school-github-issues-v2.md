# 📋 Excel School App — GitHub Issues (Product Owner)

---

## 🏷️ Labels à créer dans GitHub
- `database` 🗄️ (orange)
- `backend` ⚙️ (vert)
- `frontend` 🎨 (bleu)
- `auth` 🔐 (rouge)
- `setup` 🔧 (gris)
- `feature` ✨ (violet)
- `bug` 🐛 (rouge vif)
- `priority-high` 🔴
- `priority-medium` 🟡
- `priority-low` 🟢

---

## 📅 Milestones
- **Milestone 1** — Semaine 1 (10-14 Mar) : Setup + Auth Backend
- **Milestone 2** — Semaine 2 (17-21 Mar) : Backend CRUD complet
- **Milestone 3** — Semaine 3 (24-28 Mar) : Frontend Auth + Dashboard
- **Milestone 4** — Semaine 4 (31 Mar - 4 Avr) : Frontend Notes + Absences + Élèves
- **Milestone 5** — Semaine 5 (7-11 Avr) : Messagerie + Emploi du temps + Finitions

---

---
# 🗄️ DATABASE
---

## [DB-01] Conception et création du schéma de base de données

**Labels :** `database` `setup` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 3h | 3 points

### User Story
> En tant qu'Admin, je veux que l'application dispose d'une base de données structurée afin de pouvoir stocker et gérer toutes les données de l'établissement scolaire.

### Critères d'acceptation
- [ ] La base de données PostgreSQL est créée et accessible
- [ ] Toutes les tables sont créées avec leurs colonnes et types corrects
- [ ] Toutes les clés étrangères sont définies et fonctionnelles
- [ ] Les relations entre tables sont correctement implémentées
- [ ] La connexion depuis .NET est opérationnelle

### Tâches techniques
- [ ] Créer la base de données PostgreSQL `excel_school_db`
- [ ] Configurer la connection string dans `appsettings.json`
- [ ] Installer les packages NuGet : `Npgsql.EntityFrameworkCore.PostgreSQL`, `Microsoft.EntityFrameworkCore.Tools`
- [ ] Créer `AppDbContext` avec tous les DbSets
- [ ] Définir les relations dans `OnModelCreating`
- [ ] Générer la migration initiale : `dotnet ef migrations add InitialCreate`
- [ ] Appliquer la migration : `dotnet ef database update`
- [ ] Vérifier les tables créées dans pgAdmin ou DBeaver

---

## [DB-02] Création du modèle User et gestion des rôles

**Labels :** `database` `auth` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 2h | 2 points

### User Story
> En tant qu'Admin, je veux gérer les utilisateurs avec des rôles distincts (Admin, Professeur, Élève, Parent) afin de contrôler l'accès aux différentes fonctionnalités de l'application.

### Critères d'acceptation
- [ ] L'entité `User` est créée avec toutes les propriétés nécessaires
- [ ] L'enum `Role` contient les 4 valeurs : Admin, Professeur, Eleve, Parent
- [ ] Le mot de passe est hashé avec BCrypt avant stockage
- [ ] Un utilisateur Admin par défaut est créé au démarrage (seed)

### Tâches techniques
- [ ] Créer l'enum `Role` : `Admin`, `Professeur`, `Eleve`, `Parent`
- [ ] Créer l'entité `User` : `Id`, `FirstName`, `LastName`, `Email`, `Password` (hashé), `Role`, `CreatedAt`
- [ ] Configurer la contrainte d'unicité sur `Email` dans `OnModelCreating`
- [ ] Créer un seed de données avec un compte Admin par défaut
- [ ] Générer et appliquer la migration

---

## [DB-03] Création du modèle Eleve

**Labels :** `database` `feature` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 1h | 1 point

### User Story
> En tant qu'Admin, je veux stocker les informations des élèves afin de pouvoir les gérer et les associer à leurs notes, absences et parents.

### Critères d'acceptation
- [ ] L'entité `Eleve` est créée avec toutes ses propriétés
- [ ] La relation avec `User` est configurée (1 élève = 1 compte utilisateur)
- [ ] La relation avec `Classe` est configurée (1 élève appartient à 1 classe)
- [ ] La relation avec `Parent` est configurée (1 élève peut avoir 1 parent)

### Tâches techniques
- [ ] Créer l'entité `Eleve` : `Id`, `UserId`, `ClasseId`, `ParentId`, `DateOfBirth`, `StudentNumber`
- [ ] Configurer les clés étrangères dans `OnModelCreating`
- [ ] Créer l'entité `Classe` : `Id`, `Name` (ex: 3ème A), `Level`
- [ ] Générer et appliquer la migration

---

## [DB-04] Création du modèle Note

**Labels :** `database` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 1h | 1 point

### User Story
> En tant que Professeur, je veux stocker les notes des élèves avec leur matière et appréciation afin de suivre les résultats scolaires.

### Critères d'acceptation
- [ ] L'entité `Note` est créée avec toutes ses propriétés
- [ ] La relation avec `Eleve` est configurée (1 note appartient à 1 élève)
- [ ] La relation avec `User` (Professeur) est configurée
- [ ] La valeur de la note est contrainte entre 0 et 20

### Tâches techniques
- [ ] Créer l'entité `Note` : `Id`, `EleveId`, `ProfesseurId`, `Matiere`, `Valeur` (decimal), `Appreciation`, `DateNote`, `Trimestre`
- [ ] Créer l'enum `Matiere` : `Mathematiques`, `Francais`, `Sciences`, `HistoireGeo`, `Anglais`, `EPS`, `Arts`
- [ ] Créer l'enum `Trimestre` : `T1`, `T2`, `T3`
- [ ] Configurer la contrainte `CHECK (Valeur >= 0 AND Valeur <= 20)` dans `OnModelCreating`
- [ ] Générer et appliquer la migration

---

## [DB-05] Création du modèle Absence

**Labels :** `database` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 1h | 1 point

### User Story
> En tant qu'Admin, je veux stocker les absences des élèves avec leur statut de justification afin de suivre l'assiduité et alerter les parents.

### Critères d'acceptation
- [ ] L'entité `Absence` est créée avec toutes ses propriétés
- [ ] L'enum `StatutAbsence` contient les 3 valeurs : EnAttente, Justifie, NonJustifie
- [ ] La relation avec `Eleve` est configurée
- [ ] La date et les heures sont stockées correctement

### Tâches techniques
- [ ] Créer l'enum `StatutAbsence` : `EnAttente`, `Justifie`, `NonJustifie`
- [ ] Créer l'entité `Absence` : `Id`, `EleveId`, `Date`, `HeureDebut`, `HeureFin`, `Motif`, `Statut`, `IsJourneeComplete`, `CreatedAt`
- [ ] Configurer la clé étrangère vers `Eleve`
- [ ] Générer et appliquer la migration

---

## [DB-06] Création du modèle Message

**Labels :** `database` `feature` `priority-medium`
**Milestone :** Milestone 2
**Estimation :** 1h | 1 point

### User Story
> En tant qu'Admin/Professeur/Parent, je veux pouvoir envoyer et recevoir des messages afin de communiquer efficacement avec tous les acteurs de l'établissement.

### Critères d'acceptation
- [ ] L'entité `Message` est créée avec toutes ses propriétés
- [ ] Les relations Expediteur et Destinataire vers `User` sont configurées
- [ ] Le champ `Lu` permet de tracker les messages non lus

### Tâches techniques
- [ ] Créer l'entité `Message` : `Id`, `ExpediteurId`, `DestinataireId`, `Contenu`, `DateEnvoi`, `Lu`, `LuAt`
- [ ] Configurer les deux clés étrangères vers `User` avec nommage explicite dans `OnModelCreating`
- [ ] Générer et appliquer la migration

---

## [DB-07] Création du modèle Cours (Emploi du temps)

**Labels :** `database` `feature` `priority-medium`
**Milestone :** Milestone 2
**Estimation :** 1h | 2 points

### User Story
> En tant qu'Admin, je veux stocker l'emploi du temps de chaque classe afin de planifier et afficher les cours de la semaine.

### Critères d'acceptation
- [ ] L'entité `Cours` est créée avec toutes ses propriétés
- [ ] Les conflits d'horaires peuvent être détectés via les données stockées
- [ ] Les relations avec `Classe` et `User` (Professeur) sont configurées

### Tâches techniques
- [ ] Créer l'enum `JourSemaine` : `Lundi`, `Mardi`, `Mercredi`, `Jeudi`, `Vendredi`
- [ ] Créer l'entité `Cours` : `Id`, `ClasseId`, `ProfesseurId`, `Matiere`, `Salle`, `JourSemaine`, `HeureDebut`, `HeureFin`
- [ ] Configurer les clés étrangères
- [ ] Générer et appliquer la migration finale

---
---
# 🔐 AUTH
---

## [AUTH-01] Implémentation de l'authentification JWT Backend

**Labels :** `backend` `auth` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 4h | 5 points

### User Story
> En tant qu'utilisateur (Admin, Professeur, Élève, Parent), je veux pouvoir me connecter avec mon email et mot de passe afin d'accéder à mon espace personnel sécurisé.

### Critères d'acceptation
- [ ] L'endpoint `POST /api/auth/register` crée un nouvel utilisateur avec mot de passe hashé
- [ ] L'endpoint `POST /api/auth/login` retourne un token JWT valide
- [ ] Le token contient les claims : Email, FullName, Role
- [ ] Le token expire après 24h
- [ ] Un mauvais mot de passe retourne une erreur 401
- [ ] Un email déjà utilisé retourne une erreur 400

### Tâches techniques
- [ ] Créer `LoginDto` : `Email`, `Password`
- [ ] Créer `RegisterDto` : `FirstName`, `LastName`, `Email`, `Password`, `Role`
- [ ] Créer `AuthResponseDto` : `Id`, `FirstName`, `LastName`, `Email`, `Role`, `Token`
- [ ] Créer `IAuthService` avec signatures `Register` et `Login`
- [ ] Implémenter `AuthService` : BCrypt.HashPassword (register) + BCrypt.Verify (login)
- [ ] Implémenter `GenerateToken` (private) avec claims Email, Name, Role
- [ ] Configurer JWT dans `Program.cs` : `AddAuthentication`, `AddJwtBearer`
- [ ] Créer `AuthController` avec `[AllowAnonymous]` sur les deux endpoints
- [ ] Configurer les politiques d'autorisation par rôle : `[Authorize(Roles = "Admin")]`

---

## [AUTH-02] Gestion de l'authentification Angular

**Labels :** `frontend` `auth` `priority-high`
**Milestone :** Milestone 3
**Estimation :** 3h | 3 points

### User Story
> En tant qu'utilisateur, je veux que mon token JWT soit automatiquement envoyé avec chaque requête HTTP afin d'accéder aux ressources protégées sans me reconnecter à chaque fois.

### Critères d'acceptation
- [ ] Le token est stocké dans le `localStorage` après connexion
- [ ] L'interceptor ajoute automatiquement le header `Authorization: Bearer <token>`
- [ ] Les routes protégées redirigent vers `/login` si non authentifié
- [ ] Les routes sont protégées par rôle (ex: Admin ne voit pas les routes Élève)
- [ ] La déconnexion supprime le token et redirige vers `/login`

### Tâches techniques
- [ ] Créer l'interface `LoginResponse` : `id`, `firstName`, `lastName`, `email`, `role`, `token`
- [ ] Créer `AuthService` : `login()`, `register()`, `logout()`, `getToken()`, `isAuthenticated()`, `getUserRole()`
- [ ] Créer `authTokenInterceptor` (HttpInterceptorFn) qui injecte le token dans les headers
- [ ] Créer `authGuard` (CanActivateFn) qui vérifie `isAuthenticated()`
- [ ] Créer `roleGuard` (CanActivateFn) qui vérifie le rôle via `getUserRole()`
- [ ] Enregistrer l'interceptor dans `app.config.ts` via `withInterceptors`
- [ ] Configurer toutes les routes avec les guards appropriés dans `app.routes.ts`

---

## [AUTH-03] Page Login

**Labels :** `frontend` `auth` `priority-high`
**Milestone :** Milestone 3
**Estimation :** 3h | 3 points

### User Story
> En tant qu'utilisateur, je veux accéder à une page de connexion claire avec un sélecteur de rôle afin de me connecter rapidement à mon espace personnel.

### Critères d'acceptation
- [ ] Le formulaire contient les champs Email et Mot de passe avec validation
- [ ] Un sélecteur permet de choisir son rôle (Admin, Professeur, Élève, Parent)
- [ ] Un message d'erreur s'affiche si les identifiants sont incorrects
- [ ] Après connexion réussie, l'utilisateur est redirigé vers le Dashboard
- [ ] Si déjà connecté, l'utilisateur est redirigé automatiquement vers le Dashboard
- [ ] Un lien vers la page Register est disponible

### Tâches techniques
- [ ] Créer `LoginComponent` avec `ReactiveFormsModule`
- [ ] Créer le `FormGroup` avec validators : `Validators.required`, `Validators.email`
- [ ] Implémenter le sélecteur de rôle (4 cards cliquables)
- [ ] Implémenter `login()` : appel `authService.login()` → `subscribe` → `navigate('/dashboard')`
- [ ] Implémenter la redirection dans `ngOnInit` si déjà authentifié
- [ ] Afficher les erreurs via `MatSnackBar`
- [ ] Appliquer le design de la maquette (panneau gauche bleu + panneau droit formulaire)

---

## [AUTH-04] Page Register

**Labels :** `frontend` `auth` `priority-medium`
**Milestone :** Milestone 3
**Estimation :** 2h | 2 points

### User Story
> En tant que nouvel utilisateur, je veux pouvoir créer un compte avec mes informations personnelles afin d'accéder à l'application.

### Critères d'acceptation
- [ ] Le formulaire contient : FirstName, LastName, Email, Password, Role
- [ ] Tous les champs sont validés (required, email format, password min 6 chars)
- [ ] Un message de succès s'affiche après inscription
- [ ] L'utilisateur est redirigé vers `/login` après inscription réussie
- [ ] Les erreurs API sont affichées clairement

### Tâches techniques
- [ ] Créer `RegisterComponent` avec `ReactiveFormsModule`
- [ ] Créer le `FormGroup` avec tous les validators
- [ ] Implémenter `register()` : appel `authService.register()` → `subscribe` → `navigate('/login')`
- [ ] Afficher les erreurs via `MatSnackBar`

---
---
# ⚙️ BACKEND
---

## [BACK-01] Setup du projet .NET et configuration

**Labels :** `backend` `setup` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 2h | 2 points

### User Story
> En tant que développeur, je veux un projet .NET correctement structuré afin de développer l'API de manière organisée et maintenable.

### Critères d'acceptation
- [ ] Le projet ASP.NET Core Web API est créé
- [ ] La structure en couches est en place (Controllers, Services, Repositories, Models, DTOs, Data)
- [ ] CORS est configuré pour accepter les requêtes depuis Angular (localhost:4200)
- [ ] Swagger est accessible en développement
- [ ] Tous les packages NuGet nécessaires sont installés

### Tâches techniques
- [ ] Créer le projet : `dotnet new webapi -n ExcelSchoolApi`
- [ ] Créer les dossiers : `Models/`, `DTOs/`, `Services/`, `Repositories/`, `Controllers/`, `Data/`
- [ ] Installer les packages : `BCrypt.Net-Next`, `Microsoft.AspNetCore.Authentication.JwtBearer`, `Npgsql.EntityFrameworkCore.PostgreSQL`
- [ ] Configurer CORS dans `Program.cs`
- [ ] Configurer Swagger avec support JWT
- [ ] Enregistrer les services dans le conteneur DI (`AddScoped`)

---

## [BACK-02] CRUD Élèves — Backend

**Labels :** `backend` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 4h | 3 points

### User Story
> En tant qu'Admin, je veux pouvoir créer, lire, modifier et supprimer des élèves via l'API afin de gérer les inscriptions de l'établissement.

### Critères d'acceptation
- [ ] `GET /api/eleves` retourne la liste de tous les élèves (Admin uniquement)
- [ ] `GET /api/eleves/{id}` retourne un élève par son ID
- [ ] `POST /api/eleves` crée un nouvel élève
- [ ] `PUT /api/eleves/{id}` modifie un élève existant
- [ ] `DELETE /api/eleves/{id}` supprime un élève
- [ ] Toutes les routes sont protégées avec `[Authorize]`
- [ ] Les réponses utilisent des DTOs (pas les entités directement)

### Tâches techniques
- [ ] Créer `EleveDto`, `CreateEleveDto`, `UpdateEleveDto`
- [ ] Créer `IEleveRepository` avec signatures CRUD
- [ ] Implémenter `EleveRepository` avec Entity Framework
- [ ] Créer `IEleveService` avec signatures CRUD
- [ ] Implémenter `EleveService` avec mapping DTO ↔ Entity
- [ ] Créer `EleveController` avec les 5 endpoints
- [ ] Enregistrer dans DI dans `Program.cs`

---

## [BACK-03] CRUD Notes — Backend

**Labels :** `backend` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 4h | 3 points

### User Story
> En tant que Professeur, je veux pouvoir saisir, modifier et supprimer des notes via l'API afin de gérer les résultats scolaires de mes élèves.

### Critères d'acceptation
- [ ] `GET /api/notes` retourne toutes les notes (filtrable par élève, matière, trimestre)
- [ ] `GET /api/notes/eleve/{eleveId}` retourne les notes d'un élève
- [ ] `GET /api/notes/eleve/{eleveId}/moyenne` retourne la moyenne générale et par matière
- [ ] `POST /api/notes` crée une nouvelle note (Professeur + Admin)
- [ ] `PUT /api/notes/{id}` modifie une note
- [ ] `DELETE /api/notes/{id}` supprime une note

### Tâches techniques
- [ ] Créer `NoteDto`, `CreateNoteDto`, `UpdateNoteDto`, `MoyenneDto`
- [ ] Créer `INoteRepository` et `NoteRepository`
- [ ] Créer `INoteService` et `NoteService` avec calcul de moyennes
- [ ] Créer `NoteController` avec tous les endpoints et autorisation par rôle
- [ ] Enregistrer dans DI

---

## [BACK-04] CRUD Absences — Backend

**Labels :** `backend` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 3h | 3 points

### User Story
> En tant qu'Admin, je veux pouvoir enregistrer et gérer les absences des élèves afin de suivre leur assiduité et d'alerter les parents si nécessaire.

### Critères d'acceptation
- [ ] `GET /api/absences` retourne toutes les absences (filtrable par date, élève, statut)
- [ ] `POST /api/absences` crée une nouvelle absence
- [ ] `PUT /api/absences/{id}/justifier` justifie une absence
- [ ] `DELETE /api/absences/{id}` supprime une absence
- [ ] Un élève avec plus de 3 absences non justifiées déclenche une alerte

### Tâches techniques
- [ ] Créer `AbsenceDto`, `CreateAbsenceDto`, `JustifierAbsenceDto`
- [ ] Créer `IAbsenceRepository` et `AbsenceRepository`
- [ ] Créer `IAbsenceService` et `AbsenceService` avec logique d'alerte
- [ ] Créer `AbsenceController`
- [ ] Enregistrer dans DI

---

## [BACK-05] Messagerie — Backend

**Labels :** `backend` `feature` `priority-medium`
**Milestone :** Milestone 2
**Estimation :** 3h | 3 points

### User Story
> En tant qu'Admin ou Professeur, je veux pouvoir envoyer et recevoir des messages via l'API afin de communiquer avec les parents et collègues.

### Critères d'acceptation
- [ ] `GET /api/messages/conversations` retourne la liste des conversations de l'utilisateur connecté
- [ ] `GET /api/messages/conversation/{userId}` retourne les messages avec un utilisateur
- [ ] `POST /api/messages` envoie un nouveau message
- [ ] `PUT /api/messages/{id}/lu` marque un message comme lu
- [ ] Le nombre de messages non lus est retourné

### Tâches techniques
- [ ] Créer `MessageDto`, `CreateMessageDto`, `ConversationDto`
- [ ] Créer `IMessageRepository` et `MessageRepository`
- [ ] Créer `IMessageService` et `MessageService`
- [ ] Créer `MessageController`
- [ ] Enregistrer dans DI

---

## [BACK-06] Emploi du temps — Backend

**Labels :** `backend` `feature` `priority-medium`
**Milestone :** Milestone 2
**Estimation :** 3h | 3 points

### User Story
> En tant qu'Admin, je veux gérer l'emploi du temps des classes via l'API afin de planifier et afficher les cours de la semaine.

### Critères d'acceptation
- [ ] `GET /api/cours/classe/{classeId}` retourne l'emploi du temps d'une classe
- [ ] `GET /api/cours/professeur/{profId}` retourne l'emploi du temps d'un professeur
- [ ] `POST /api/cours` crée un nouveau cours (avec détection de conflit)
- [ ] `PUT /api/cours/{id}` modifie un cours
- [ ] `DELETE /api/cours/{id}` supprime un cours
- [ ] La création d'un cours en conflit d'horaire retourne une erreur 409

### Tâches techniques
- [ ] Créer `CoursDto`, `CreateCoursDto`
- [ ] Créer `ICoursRepository` et `CoursRepository`
- [ ] Créer `ICoursService` et `CoursService` avec détection des conflits
- [ ] Créer `CoursController`
- [ ] Enregistrer dans DI

---

## [BACK-07] Dashboard Statistiques — Backend

**Labels :** `backend` `feature` `priority-high`
**Milestone :** Milestone 2
**Estimation :** 2h | 2 points

### User Story
> En tant qu'Admin, je veux accéder à des statistiques globales de l'établissement via l'API afin d'avoir une vue d'ensemble sur le tableau de bord.

### Critères d'acceptation
- [ ] `GET /api/dashboard/stats` retourne : nb élèves, nb profs, absences du jour, moyenne générale
- [ ] `GET /api/dashboard/activites-recentes` retourne les 5 dernières activités
- [ ] Les stats sont filtrées selon le rôle de l'utilisateur connecté

### Tâches techniques
- [ ] Créer `DashboardStatsDto` avec toutes les statistiques
- [ ] Créer `IDashboardService` et `DashboardService`
- [ ] Créer `DashboardController` avec autorisation par rôle
- [ ] Optimiser les requêtes EF Core avec `Include` et `Select`

---
---
# 🎨 FRONTEND
---

## [FRONT-01] Setup du projet Angular et configuration

**Labels :** `frontend` `setup` `priority-high`
**Milestone :** Milestone 1
**Estimation :** 2h | 2 points

### User Story
> En tant que développeur, je veux un projet Angular correctement structuré afin de développer l'interface de manière organisée et maintenable.

### Critères d'acceptation
- [ ] Le projet Angular est créé avec Angular CLI
- [ ] La structure des dossiers est en place
- [ ] Angular Material est installé et configuré
- [ ] Les environnements (dev/prod) sont configurés
- [ ] Le routing est configuré avec lazy loading

### Tâches techniques
- [ ] Créer le projet : `ng new excel-school-front --routing --style=scss`
- [ ] Créer la structure : `pages/`, `shared/`, `services/`, `interfaces/`, `guards/`, `interceptors/`
- [ ] Installer Angular Material : `ng add @angular/material`
- [ ] Configurer `environment.ts` avec `APIBASEURL` et `AUTH`
- [ ] Configurer `app.config.ts` avec `provideHttpClient(withInterceptors([]))`, `provideRouter(routes)`, `provideAnimations()`
- [ ] Créer `NavbarComponent` dans `shared/`

---

## [FRONT-02] NavbarComponent et layout principal

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 3
**Estimation :** 2h | 2 points

### User Story
> En tant qu'utilisateur connecté, je veux voir une barre de navigation adaptée à mon rôle afin d'accéder rapidement aux différentes sections de l'application.

### Critères d'acceptation
- [ ] La navbar affiche les liens adaptés au rôle de l'utilisateur connecté
- [ ] Le bouton Logout est visible et fonctionnel
- [ ] La navbar est masquée sur les pages Login et Register
- [ ] Les badges de notifications s'affichent (absences, messages)

### Tâches techniques
- [ ] Créer `NavbarComponent` avec `MatToolbarModule`, `MatButtonModule`, `RouterModule`
- [ ] Injecter `AuthService` pour récupérer le rôle et afficher les bons liens
- [ ] Implémenter `logout()` : `authService.logout()` + `navigate('/login')`
- [ ] Utiliser `@if (isAuthenticated())` pour conditionner l'affichage
- [ ] Configurer `app.component.html` avec `<app-navbar>` + `<router-outlet>`

---

## [FRONT-03] Dashboard Admin

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 3
**Estimation :** 4h | 5 points

### User Story
> En tant qu'Admin, je veux voir un tableau de bord complet avec les statistiques de l'établissement afin d'avoir une vue d'ensemble en temps réel.

### Critères d'acceptation
- [ ] Les 4 cards de statistiques (Élèves, Profs, Absences, Moyenne) s'affichent
- [ ] Le tableau des dernières activités s'affiche avec les 5 dernières entrées
- [ ] L'emploi du temps du jour s'affiche dans la colonne droite
- [ ] La messagerie récente s'affiche avec le nombre de messages non lus
- [ ] Les données sont chargées depuis l'API backend
- [ ] Un loader s'affiche pendant le chargement

### Tâches techniques
- [ ] Créer `DashboardComponent` avec injection `DashboardService`
- [ ] Créer `DashboardService` avec `getStats()` et `getActivitesRecentes()`
- [ ] Implémenter les 4 vues : Admin, Professeur, Élève, Parent (avec `@switch` sur le rôle)
- [ ] Utiliser `async pipe` avec `BehaviorSubject` pour la réactivité
- [ ] Implémenter le squelette de chargement (skeleton loader)
- [ ] Appliquer le design de la maquette HTML fournie

---

## [FRONT-04] Page Gestion des Élèves

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 4
**Estimation :** 4h | 3 points

### User Story
> En tant qu'Admin, je veux voir et gérer la liste des élèves en cartes visuelles afin d'avoir une vue rapide sur chaque élève avec ses statistiques clés.

### Critères d'acceptation
- [ ] La liste des élèves s'affiche en cartes avec avatar, nom, classe, moyenne, absences
- [ ] Un champ de recherche filtre les élèves en temps réel
- [ ] Des filtres par classe et statut (présent/absent) sont disponibles
- [ ] La pagination affiche 8 élèves par page
- [ ] Un bouton "Ajouter un élève" ouvre un formulaire
- [ ] Les boutons Profil et Notes redirigent vers les pages correspondantes

### Tâches techniques
- [ ] Créer l'interface `Eleve` TypeScript correspondant au DTO backend
- [ ] Créer `EleveService` avec `getAll()`, `getById()`, `create()`, `update()`, `delete()` + `BehaviorSubject`
- [ ] Créer `ElevesListComponent` avec cards et filtres
- [ ] Implémenter la recherche avec `debounceTime` et `switchMap` (RxJS)
- [ ] Implémenter la pagination avec `MatPaginatorModule`
- [ ] Créer `EleveProfilComponent` pour la page détail
- [ ] Ajouter les notifications `MatSnackBar` pour les actions CRUD

---

## [FRONT-05] Page Notes

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 4
**Estimation :** 4h | 3 points

### User Story
> En tant que Professeur, je veux saisir et visualiser les notes des élèves avec leur distribution afin de suivre facilement les résultats de ma classe.

### Critères d'acceptation
- [ ] Le tableau des notes s'affiche avec les barres de progression visuelles
- [ ] Les filtres par classe, matière et trimestre fonctionnent
- [ ] Le graphique de distribution des notes s'affiche dans la colonne droite
- [ ] Le formulaire de saisie rapide permet d'ajouter une note en 3 clics
- [ ] Les statistiques (moyenne, max, min) se mettent à jour en temps réel
- [ ] Les actions modifier/supprimer fonctionnent avec confirmation

### Tâches techniques
- [ ] Créer l'interface `Note` TypeScript
- [ ] Créer `NoteService` avec `getAll()`, `getByEleve()`, `getMoyenne()`, `create()`, `update()`, `delete()` + `BehaviorSubject`
- [ ] Créer `NotesComponent` avec tableau et filtres
- [ ] Implémenter le formulaire de saisie rapide avec `ReactiveFormsModule`
- [ ] Implémenter le calcul de distribution (excellent/bien/passable/insuffisant)
- [ ] Ajouter les notifications `MatSnackBar`

---

## [FRONT-06] Page Absences

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 4
**Estimation :** 4h | 3 points

### User Story
> En tant qu'Admin, je veux gérer les absences des élèves avec un calendrier visuel afin d'identifier rapidement les élèves à risque et contacter leurs parents.

### Critères d'acceptation
- [ ] Le tableau des absences s'affiche avec les statuts colorés
- [ ] Le calendrier mensuel met en évidence les jours avec absences
- [ ] Les alertes pour les élèves dépassant le seuil d'absences s'affichent
- [ ] Les actions Justifier/Refuser fonctionnent directement depuis le tableau
- [ ] Le formulaire de signalement permet de créer une absence rapidement

### Tâches techniques
- [ ] Créer l'interface `Absence` TypeScript
- [ ] Créer `AbsenceService` avec toutes les méthodes CRUD + `justifier()` + `BehaviorSubject`
- [ ] Créer `AbsencesComponent` avec tableau, calendrier et alertes
- [ ] Implémenter le mini-calendrier avec mise en évidence des jours d'absence
- [ ] Implémenter la logique d'alerte (> 3 absences non justifiées)
- [ ] Ajouter les notifications `MatSnackBar`

---

## [FRONT-07] Page Messagerie

**Labels :** `frontend` `feature` `priority-medium`
**Milestone :** Milestone 5
**Estimation :** 5h | 5 points

### User Story
> En tant qu'Admin ou Professeur, je veux envoyer et recevoir des messages dans une interface de chat moderne afin de communiquer efficacement avec les parents et collègues.

### Critères d'acceptation
- [ ] La liste des conversations s'affiche à gauche avec les messages non lus
- [ ] Le chat s'affiche au centre avec les bulles de messages
- [ ] L'envoi d'un message fonctionne avec Enter ou le bouton Envoyer
- [ ] Les messages non lus sont marqués comme lus à l'ouverture
- [ ] Un bouton "Nouveau message" permet de démarrer une conversation

### Tâches techniques
- [ ] Créer les interfaces `Message` et `Conversation` TypeScript
- [ ] Créer `MessageService` avec `getConversations()`, `getMessages()`, `sendMessage()`, `markAsRead()` + `BehaviorSubject`
- [ ] Créer `MessagerieComponent` avec layout 3 colonnes (liste / chat / vide)
- [ ] Implémenter le scroll automatique vers le dernier message
- [ ] Implémenter l'envoi avec `(keydown.enter)` et bouton
- [ ] Ajouter le badge de messages non lus dans la navbar

---

## [FRONT-08] Page Emploi du temps

**Labels :** `frontend` `feature` `priority-medium`
**Milestone :** Milestone 5
**Estimation :** 5h | 5 points

### User Story
> En tant qu'Admin, je veux visualiser et gérer l'emploi du temps hebdomadaire par classe afin de planifier les cours et détecter les conflits d'horaires.

### Critères d'acceptation
- [ ] La grille hebdomadaire s'affiche avec les créneaux de 8h à 17h
- [ ] Les cours sont colorés par matière
- [ ] Les filtres par classe et professeur fonctionnent
- [ ] La navigation par semaine (précédente/suivante) fonctionne
- [ ] Un clic sur un cours affiche ses détails
- [ ] L'ajout d'un cours vérifie les conflits avant de sauvegarder

### Tâches techniques
- [ ] Créer l'interface `Cours` TypeScript
- [ ] Créer `CoursService` avec `getBySemaine()`, `getByClasse()`, `create()`, `update()`, `delete()` + `BehaviorSubject`
- [ ] Créer `EmploiDuTempsComponent` avec la grille CSS Grid
- [ ] Implémenter le positionnement des cours sur la grille par heure
- [ ] Implémenter la navigation par semaine avec calcul des dates
- [ ] Implémenter la détection de conflit côté frontend (affichage d'une alerte)

---

## [FRONT-09] Gestion de l'état global et notifications

**Labels :** `frontend` `feature` `priority-high`
**Milestone :** Milestone 3
**Estimation :** 2h | 2 points

### User Story
> En tant qu'utilisateur, je veux voir des notifications visuelles pour chaque action (succès, erreur) afin d'être informé du résultat de mes actions en temps réel.

### Critères d'acceptation
- [ ] Un `MatSnackBar` vert s'affiche pour chaque action réussie
- [ ] Un `MatSnackBar` rouge s'affiche pour chaque erreur
- [ ] Un loader s'affiche pendant les requêtes HTTP
- [ ] L'interface `RequestState` est utilisée dans tous les services

### Tâches techniques
- [ ] Créer l'interface `RequestState` : `isLoading`, `errorMessage`, `successMessage`
- [ ] Implémenter `BehaviorSubject<RequestState>` dans chaque service
- [ ] Configurer les styles `MatSnackBar` dans `styles.scss` : `.success` (vert) et `.error` (rouge)
- [ ] Créer un `LoadingComponent` réutilisable avec spinner Material
- [ ] Utiliser `tap({ next, error })` dans tous les services pour mettre à jour le state

---

*Total estimé : ~60h | ~65 points de complexité*
*Deadline : Mi-avril 2026 (5 semaines × 4h/jour × 5 jours = 100h disponibles)*
