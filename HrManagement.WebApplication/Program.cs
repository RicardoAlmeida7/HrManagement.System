using Autofac;
using Autofac.Extensions.DependencyInjection;
using HrManagement.Data.Context;
using HrManagement.Domain.Services.Email;
using HrManagement.EmailService;
using HrManagement.EmailService.Templates;
using HrManagement.Ioc;
using HrManagement.Security;
using HrManagement.Security.Cryptography;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Login/login", "");
    options.Conventions.AllowAnonymousToAreaPage("/login", "/login/recoverpassword");
});

var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HrManagementContext>(options =>
    options.EnableSensitiveDataLogging().UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection))
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
}
).AddEntityFrameworkStores<HrManagementContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new SecurityContainerModule());
    builder.RegisterModule(new ApplicationContainerModule());
    builder.RegisterModule(new RepositoriesContainerBuilder());
    builder.RegisterModule(new AppServicesContainerBuilder());
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Login/";
    options.AccessDeniedPath = "/AccessDenied";
    options.SlidingExpiration = true;

    options.Validate();
});

//email service settings
builder.Services.AddSingleton<IEmailService>(provider =>
{
    string sender = builder.Configuration.GetSection("EmailService:Sender").Value;
    string password = builder.Configuration.GetSection("EmailService:Password").Value;
    string host = builder.Configuration.GetSection("EmailService:Host").Value;
    int port = int.Parse(builder.Configuration.GetSection("EmailService:Port").Value);
    return new EmailService(sender, password, host, port);
});

var app = builder.Build();

// Create Roles
var rolesService = app.Services.GetRequiredService<IManagementRoles>();
await rolesService.RegisterRolesAsync();

var userService = app.Services.GetRequiredService<IManagementUsers>();

// Create a admin user with appsettings parameters
CreateAdminUser(app, userService);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    await next();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

static async Task CreateAdminUser(WebApplication app, IManagementUsers userService)
{
    var userManager = app.Services.GetService<IManagementUsers>();
    var adminName = app.Configuration.GetSection("UserAdmin:User").Value;
    var fullName = app.Configuration.GetSection("UserAdmin:FullName").Value;
    var password = app.Configuration.GetSection("UserAdmin:Password").Value;
    var email = app.Configuration.GetSection("UserAdmin:Email").Value;
    var tempPassword = Encrypt.GenerateRandomString(8);
    var tempPasswordHash = Encrypt.GenerateSHA256Hash(tempPassword);
    var emailService = app.Services.GetRequiredService<IEmailService>();
    var created = await userService.CreateAdminAsync(adminName, fullName, email, password, tempPasswordHash);
    if (created)
    {
        emailService.SendEmail(email, Subject.ACCESS_CREDENTIALS, AccessCredentialsTemplate.Build(adminName, tempPassword));
    }
}
