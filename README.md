# Catalogue API (.NET / Dapper / Clean Architecture)

API REST performante et légère développée en .NET Core, structurée selon une **Clean Architecture en 3 couches**, utilisant **Dapper** comme micro-ORM pour un accès direct et optimisé à la base de données SQL Server.

---

## Structure de la Solution

La solution est strictement découplée pour garantir la maintenabilité, l'évolutivité et la testabilité :

```text
Catalogue.sln
├── Catalogue.Api              # Couche de Présentation (Controllers, Middleware, Configuration DI)
├── Catalogue.Core             # Cœur Applicatif & Domaine (Entités, DTOs, Interfaces, Services, Mappings)
├── Catalogue.Infrastructure   # Couche d'Accès aux Données (Repositories Dapper, SQL, ConnectionFactory)
└── CatalogueDB                # Gestion du schéma et scripts de base de données
---

## Documentation & Tests avec Swagger

L'API intègre **Swagger UI** (OpenAPI) pour explorer et tester les endpoints directement depuis le navigateur.

### 1. Accéder à Swagger UI

1. Lancez le projet API :
   ```bash
   dotnet run --project Catalogue.Api
