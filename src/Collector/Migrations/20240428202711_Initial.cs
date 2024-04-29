using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collector.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "integer(10)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Episode = table.Column<int>(type: "integer(10)", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    CharacterCode = table.Column<int>(type: "integer(10)", nullable: false),
                    PlanetCode = table.Column<int>(type: "integer(10)", nullable: false),
                    VehicleCode = table.Column<int>(type: "integer(10)", nullable: false),
                    StarshipCode = table.Column<int>(type: "integer(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "integer(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RotationPeriod = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Diameter = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Gravity = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Terrain = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SurfaceWater = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Population = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CharacterCode = table.Column<int>(type: "integer(10)", nullable: false),
                    MovieCode = table.Column<int>(type: "integer(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "integer(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CostInCredits = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MaxSpeed = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    HyperdriveRating = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Mglt = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MovieCode = table.Column<int>(type: "integer(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "integer(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CostInCredits = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MaxSpeed = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MovieCode = table.Column<int>(type: "integer(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviePlanet",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlanet", x => new { x.MoviesId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_MoviePlanet_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePlanet_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(type: "integer(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BirthYear = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PlanetCode = table.Column<int>(type: "integer(10)", nullable: false),
                    MovieCode = table.Column<int>(type: "integer(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_Planets_PlanetCode",
                        column: x => x.PlanetCode,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStarship",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StarshipsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStarship", x => new { x.MoviesId, x.StarshipsId });
                    table.ForeignKey(
                        name: "FK_MovieStarship_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStarship_Starships_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieVehicle",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiclesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVehicle", x => new { x.MoviesId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_MovieVehicle_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePeople",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePeople", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviePeople_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePeople_Peoples_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_MoviesId",
                table: "MoviePeople",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlanet_PlanetsId",
                table: "MoviePlanet",
                column: "PlanetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Code",
                table: "Movies",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarship_StarshipsId",
                table: "MovieStarship",
                column: "StarshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieVehicle_VehiclesId",
                table: "MovieVehicle",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Code",
                table: "Peoples",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_PlanetCode",
                table: "Peoples",
                column: "PlanetCode");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_Code",
                table: "Planets",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_Code",
                table: "Starships",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Code",
                table: "Vehicles",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePeople");

            migrationBuilder.DropTable(
                name: "MoviePlanet");

            migrationBuilder.DropTable(
                name: "MovieStarship");

            migrationBuilder.DropTable(
                name: "MovieVehicle");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
