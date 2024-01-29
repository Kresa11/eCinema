using eCinema;
using eCinema.Handlers;
using eCinema.Model.Dtos;
using eCinema.Model.Helpers;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.ProjectionStateMachine;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IProjectionService, ProjectionService>();
builder.Services.AddTransient<IPriceService, PriceService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IHallService, HallService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<ISeatReservationService, SeatReservationService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();

builder.Services.AddTransient<BaseProjectionState>();
builder.Services.AddTransient<InitialProjectionState>();
builder.Services.AddTransient<DraftProjectionState>();
builder.Services.AddTransient<ActiveProjectionState>(); 
builder.Services.AddTransient<HiddenProjectionState>(); 

builder.Services.AddAutoMapper(typeof(INotificationService));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddDbContext<CinemaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(nameof(eCinema))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<CinemaContext>();
    dataContext.Database.Migrate();
}

app.Run();
