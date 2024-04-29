namespace App;

public static class Routes
{
    public static void Endpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/movies",  async (IMovieServices services) => { await services.CreateMoviesAsync(); });
        app.MapPost("/api/v1/peoples", async (IPeopleServices services) => { await services.CreatePeopleAsync(); });
        app.MapPost("/api/v1/planets", async (IPlanetServices services) => { await services.CreatePlanetsAsync(); });
        app.MapPost("/api/v1/startships", async (IStarshipServices services) => { await services.CreateStarshipAsync(); });
        app.MapPost("/api/v1/vehicles", async (IVehicleServices services) => { await services.CreateVehicleAsync(); });
    }
}