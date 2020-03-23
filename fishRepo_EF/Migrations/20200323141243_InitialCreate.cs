using Microsoft.EntityFrameworkCore.Migrations;

namespace fishRepo_EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishName",
                columns: table => new
                {
                    FishNameID = table.Column<string>(nullable: false),
                    Family = table.Column<string>(nullable: true),
                    SpecificName = table.Column<string>(nullable: true),
                    CommonName = table.Column<int>(nullable: false),
                    FishID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishName", x => x.FishNameID);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    SurveyID = table.Column<string>(nullable: false),
                    SurveyDate = table.Column<string>(nullable: true),
                    SurveyIndex = table.Column<string>(nullable: true),
                    Management = table.Column<int>(nullable: false),
                    BatchCode = table.Column<string>(nullable: true),
                    FishID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    CharacteristicID = table.Column<string>(nullable: false),
                    FishLength = table.Column<string>(nullable: true),
                    Trophic = table.Column<string>(nullable: true),
                    FishID = table.Column<string>(nullable: true),
                    StructureType = table.Column<int>(nullable: false),
                    FishCount = table.Column<string>(nullable: true),
                    FishNameID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.CharacteristicID);
                    table.ForeignKey(
                        name: "FK_Characteristics_FishName_FishNameID",
                        column: x => x.FishNameID,
                        principalTable: "FishName",
                        principalColumn: "FishNameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyAreas = table.Column<string>(nullable: true),
                    Longtitude = table.Column<string>(nullable: true),
                    FishLocaID = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    FishID = table.Column<string>(nullable: true),
                    CharacteristicID = table.Column<string>(nullable: true),
                    SurveyID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationsID);
                    table.ForeignKey(
                        name: "FK_Locations_Characteristics_CharacteristicID",
                        column: x => x.CharacteristicID,
                        principalTable: "Characteristics",
                        principalColumn: "CharacteristicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishID = table.Column<string>(nullable: true),
                    Regions = table.Column<string>(nullable: true),
                    LocationsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_Regions_Locations_LocationsID",
                        column: x => x.LocationsID,
                        principalTable: "Locations",
                        principalColumn: "LocationsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubRegions",
                columns: table => new
                {
                    SubRegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishID = table.Column<string>(nullable: true),
                    SubRegions = table.Column<string>(nullable: true),
                    RegionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRegions", x => x.SubRegionID);
                    table.ForeignKey(
                        name: "FK_SubRegions_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_FishNameID",
                table: "Characteristics",
                column: "FishNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CharacteristicID",
                table: "Locations",
                column: "CharacteristicID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SurveyID",
                table: "Locations",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LocationsID",
                table: "Regions",
                column: "LocationsID");

            migrationBuilder.CreateIndex(
                name: "IX_SubRegions_RegionID",
                table: "SubRegions",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubRegions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "FishName");
        }
    }
}
