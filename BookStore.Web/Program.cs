using BookStore.Core.Interfaces;
using BookStore.Web.Components;
using BookStore.Web.Data;
using BookStore.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContextFactory<BookContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("BookStore");
	options.UseSqlServer(connectionString);
});

builder.Services.AddRazorComponents();

builder.Services.AddTransient<IBookService, BookService>();

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
	.AddAdditionalAssemblies(typeof(BookStore.Core.Components.Pages.Books).Assembly);

app.Run();
