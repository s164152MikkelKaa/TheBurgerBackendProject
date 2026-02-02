# TheBurgerBackendProject

## Brainstorm på Framework
* EntityFramework
* AspNetCore Identity
* SQL server
* Angular
* API (Restfull?)

## Brainstorm på design Patterns



## Brainstorm på ER implementering
~~~mermaid
erDiagram
  BurgerSpots {
    Id INT PK "IDENTITY(1, 1)"
    SpotName NVARCHAR(200) "NOTNULL"
    SpotAddress NVARCHAR(200) "NOTNULL"
    CoordinateLat DECIMAL(18_14) "NOTNULL"
    CoordinateLon DECIMAL(18_14) "NOTNULL"
    OpenTimes NVARCHAR(500) "NULL"
    LastEditAt DATETIME2 "NOTNULL"
    LastEditBy INT FK "FOREIGNKEY(UserProfile, Id) NULL"
  }
  UserReview {
    Id INT PK "IDENTITY(1, 1)"
    SpotId INT FK "FOREIGNKEY(BurgerSpots, Id) NOTNULL"
    UserId INT FK "FOREIGNKEY(UserProfile, Id) NULL"
    CreatedAt DATETIME2 "NOTNULL"
    LastEditAt DATETIME2 "NOTNULL"
    Score FLOAT(53) "NULL"
    ReviewText NVARCHAR(2000) "NULL"
    PictureLocation NVARCHAR(500) "NULL"
  }
  BurgerSpots ||--o{ UserReview : review_of
  UserProfile {
    Id INT PK "IDENTITY(1, 1)"
  }
  BurgerSpots }o--o| UserProfile : last_edit_by
  UserReview }o--o| UserProfile : owned
~~~

## Noter på tanker/Logbog for tanker
* 02-02-2026
  * Planen er at lave et EntityFramework API med SQL database, indføre Identity for brugerkonti/sikkerhed.
  * Uploadede billeder vil få et unikt navn som gemmes i databasen, billede gemmes i database?
  * Frontend forventes at lave i Angular, da jeg er nogenlunde bekendt med dette.
  * ToDo Undersøg Design Patterns og hvordan man korrekt tilføjer Identity til et projekt.
