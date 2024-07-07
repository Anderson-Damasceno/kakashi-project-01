using Microsoft.EntityFrameworkCore;
using TodoList.Components;
using TodoList.Data;
using TodoList.Interfaces;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var connectionStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TodoContext>(o => o.UseSqlite(connectionStr));

builder.Services.AddScoped<ITodoService,TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();