# TaskTracker (C# ASP.NET Core MVC + Git branches)

## Run each environment
    dotnet run --launch-profile Development   # http://localhost:5001  (green)
    dotnet run --launch-profile Test          # http://localhost:5002  (blue)
    dotnet run --launch-profile Staging       # http://localhost:5003  (orange)
    dotnet run --launch-profile Release       # http://localhost:5004  (purple)
    dotnet run --launch-profile Production    # http://localhost:5005  (red)

## Branch -> Environment
| Branch    | Environment | Purpose                          |
|-----------|-------------|----------------------------------|
| feature/* | Development | one small task per branch        |
| dev       | Development | all features get merged here     |
| test      | Test        | testers check dev's work         |
| staging   | Staging     | final rehearsal before release   |
| release   | Release     | version ready to ship            |
| main      | Production  | live, stable code only (no banner)|

## Promotion flow
feature/* -> dev -> test -> staging -> release -> main

## Feature ideas to practice branching
- feature/task-priority   (add Priority to TaskItem)
- feature/due-dates       (add DueDate)
- feature/edit-task       (Edit action + view)

## Git basics
    git status | git add . | git commit -m "msg"
    git checkout -b feature/name
    git checkout dev && git merge feature/name
    git remote add origin <github-url>
    git push -u origin --all

## Using Visual Studio 2022 Community
1. Installer must have the "ASP.NET and web development" workload (+ .NET 8 SDK).
2. File > Open > Project/Solution > pick TaskTracker.csproj
3. Top toolbar dropdown next to the green play button: choose a profile
   (Development / Test / Staging / Release / Production) then press F5.
4. Git: Git menu > Create Git Repository (or run setup-git.sh in the terminal),
   then use the branch name at the bottom-right status bar to switch/create branches.

## What each file does (where you edit)
| File | Role | Edit it when... |
|------|------|-----------------|
| Models/TaskItem.cs | MODEL (data) | adding a field like Priority or DueDate |
| Controllers/TasksController.cs | CONTROLLER (logic) | adding/changing actions |
| Views/Tasks/Index.cshtml | VIEW (page) | changing what the user sees |
| Views/Shared/_Layout.cshtml | page frame + banner | changing look of every page |
| appsettings.<Env>.json | per-environment settings | changing banner label/color |
| Properties/launchSettings.json | run profiles (port + environment name) | adding a profile |
| Program.cs | app startup | rarely |
Search the code for ">>> EDIT HERE" to find the spots for each feature branch.


## Why Production has no banner
The colored banner at the top ("Environment: Development | DEV - ...") is a
helper for US, so we can tell environments apart while building and testing.
Real users on the live app should never see internal labels like that, so
`Views/Shared/_Layout.cshtml` checks `Env.IsProduction()` and skips the
banner only when running in the Production environment (the `main` branch).
