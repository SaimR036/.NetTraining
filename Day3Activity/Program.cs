using Day3Activity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using System.Collections.Generic;
using System.Text.Json;
using T2.Models;
using T2.Services;
var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    .CreateLogger();

// Add services to the container.

// DEMO
builder.Services.AddDbContext<LibraryDBContext>(o =>
{
    o.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

// Load config section from appsettings.json
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("AppOptions"));

// Register services
builder.Services.AddScoped<ILibraryService, LibraryService>();


// Add controllers and Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDBContext>();

    //context.Books.RemoveRange(context.Books);
    //context.Users.RemoveRange(context.Users);
    //context.Borrows.RemoveRange(context.Borrows);

    //await context.SaveChangesAsync();
    var _libraryService = scope.ServiceProvider.GetRequiredService<ILibraryService>();

    //string bpath = "books.json";
    //string data = File.ReadAllText(bpath);
    //List<Book>? books = JsonSerializer.Deserialize<List<Book>>(data);

    //string upath = "users.json";
    //string udata = File.ReadAllText(upath);
    //List<User>? users = JsonSerializer.Deserialize<List<User>>(udata);

    //if (books != null)
    //{
    //    foreach (Book book in books)
    //    {
    //        _libraryService.AddBook(book);
    //    }
    //}

    //if (users != null)
    //{
    //    foreach (User user in users)
    //    {
    //        _libraryService.AddUser(user);
    //    }
    //}
    //Borrow b1 = new Borrow(1, 1000);
    //_libraryService.AddBorrow(b1);
    var borrows = await _libraryService.GetBorrows();
    var first = borrows.First();

    Console.WriteLine($"Borrow: Sid={first.sid}, Bid={first.Bid}"); List<Book> newbooks = await _libraryService.GetBooks();
    Console.WriteLine("BOOKS" +newbooks.Count.ToString());
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
