# QuestLog

A personal video game backlog and milestone tracker built with **ASP.NET Core MVC** and **Entity Framework Core**.

## Features
- **Game Backlog Management (Full CRUD):** Add, view, edit, and delete video games with platform, release year, studio, and completion status tracking.
- **Play Milestones:** Log and deletes individual play milestones, completion dates, and hours invested for each video game.
- **Game Studios Catalog:** Create and browse game development studios and their countries.
- **Client & Server-Side Validation:** Form inputs are validated using Data Annotations (`[Required]`, `[StringLength]`, `[Range]`) and jQuery Unobtrusive Validation.

## Database Schema
- **Studio** (`Id`, `Name`, `Country`) — One-to-Many with `VideoGame`
- **VideoGame** (`Id`, `Title`, `Platform`, `ReleaseYear`, `IsComplete`, `StudioId`) — One-to-Many with `PlayMilestone`
- **PlayMilestone** (`Id`, `MilestoneTitle`, `AchievedDate`, `HoursLogged`, `VideoGameId`)

## Tech Stack
- .NET / ASP.NET Core MVC
- Entity Framework Core & SQL Server
- Bootstrap 5 & Razor Views (including Partial Views and Sections)

## Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/JakeXS/QuestLog
   ```
2. The application uses SQL Server LocalDB (`(localdb)\mssqllocaldb`) by default in `QuestLog/appsettings.json`. If you use a different SQL Server instance, update the `Server` value in `DefaultConnection` accordingly.
3. Open **Package Manager Console** in Visual Studio and apply the database migrations:
   ```powershell
   Update-Database
   ```
4. Press `F5` (or run `dotnet run`) to launch the application.

