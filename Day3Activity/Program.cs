using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using T2.Models;
using System.Text.Json;
using T2.Services;

var builder = WebApplication.CreateBuilder(args);

// Load config section from appsettings.json
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("AppOptions"));

// Register services
builder.Services.AddSingleton<ILibraryService, LibraryService>();

// Add controllers and Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var _libraryService = scope.ServiceProvider.GetRequiredService<ILibraryService>();

    string bpath = "books.json";
    string data = File.ReadAllText(bpath);
    List<Book>? books = JsonSerializer.Deserialize<List<Book>>(data);

    string upath = "users.json";
    string udata = File.ReadAllText(upath);
    List<User>? users = JsonSerializer.Deserialize<List<User>>(udata);

    if (books != null)
    {
        foreach (Book book in books)
        {
            _libraryService.AddBook(book);
        }
    }

    if (users != null)
    {
        foreach (User user in users)
        {
            _libraryService.AddUser(user);
        }
    }

    _libraryService.BorrowBook(1000, 1);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
