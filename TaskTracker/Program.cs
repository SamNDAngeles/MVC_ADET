// ===================================================================
// Program.cs = the "main()" of our web app (like main() in C).
// It runs first, sets things up, and starts the web server.
// You will RARELY edit this file.
// ===================================================================

// Create the app builder (prepares settings, logging, etc.)
var builder = WebApplication.CreateBuilder(args);

// Tell the app we are using MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// Build the app. It automatically reads appsettings.json AND the file that
// matches the current environment (appsettings.Development.json, etc.)
var app = builder.Build();

app.UseRouting();

// ROUTING: decides which Controller/Action runs for a URL.
// "/" (empty URL)       -> TasksController.Index()
// "/Tasks/Create"       -> TasksController.Create()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}/{action=Index}/{id?}");

// Start the web server (like an infinite loop waiting for requests)
app.Run();
