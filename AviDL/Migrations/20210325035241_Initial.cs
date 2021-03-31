using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AviDL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumb = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProducerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pilots_Users_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    PilotID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contributors_Pilots_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributors_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PilotID = table.Column<int>(type: "integer", nullable: false),
                    UploaderID = table.Column<int>(type: "integer", nullable: false),
                    FileURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Files_Pilots_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_UploaderID",
                        column: x => x.UploaderID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PilotID = table.Column<int>(type: "integer", nullable: false),
                    SceneIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scenes_Pilots_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PilotID = table.Column<int>(type: "integer", nullable: false),
                    ScriptURL = table.Column<string>(type: "text", nullable: true),
                    ScriptWriterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scripts_Pilots_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scripts_Users_ScriptWriterID",
                        column: x => x.ScriptWriterID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneFiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SceneID = table.Column<int>(type: "integer", nullable: false),
                    FileID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SceneFiles_Files_FileID",
                        column: x => x.FileID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceneFiles_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_PilotID",
                table: "Contributors",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_UserID",
                table: "Contributors",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PilotID",
                table: "Files",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UploaderID",
                table: "Files",
                column: "UploaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_ProducerID",
                table: "Pilots",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneFiles_FileID",
                table: "SceneFiles",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_SceneFiles_SceneID",
                table: "SceneFiles",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_PilotID",
                table: "Scenes",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_PilotID",
                table: "Scripts",
                column: "PilotID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_ScriptWriterID",
                table: "Scripts",
                column: "ScriptWriterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "SceneFiles");

            migrationBuilder.DropTable(
                name: "Scripts");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
