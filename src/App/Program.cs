var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CollectorContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IPeopleServices, PeopleServices>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPlanetServices, PlanetServices>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<IStarshipServices, StarshipServices>();
builder.Services.AddScoped<IStarshipRepository, StarshipRepository>();
builder.Services.AddScoped<IVehicleServices, VehicleServices>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(
    AppDomain.CurrentDomain.GetAssemblies()));

var app = builder.Build();
app.Endpoints();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
