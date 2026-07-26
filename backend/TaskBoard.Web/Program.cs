using TaskBoard.Web.Models;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Web.Data;
using TaskBoard.Web.Interfaces;
using TaskBoard.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login";
    });

builder.Services.AddAuthorization();
builder.Services.AddDbContext<TaskBoardDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            message = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyiniz."
        });
    });
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskBoardDbContext>();

    if (!context.TaskItems.Any())
    {
        context.TaskItems.AddRange(
            new TaskItem
            {
                Title = "HTML Sayfasını Tamamla",
                Priority = "Yüksek",
                Status = "Open",
                CreatedAt = DateTime.Now
            },
            new TaskItem
            {
                Title = "CSS Düzenlemelerini Yap",
                Priority = "Normal",
                Status = "Open",
                CreatedAt = DateTime.Now
            },
            new TaskItem
            {
                Title = "JavaScript Kontrollerini Yaz",
                Priority = "Düşük",
                Status = "Open",
                CreatedAt = DateTime.Now
            }
        );

        context.SaveChanges();
    }
}
app.Run();
