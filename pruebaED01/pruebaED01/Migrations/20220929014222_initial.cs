using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaED01.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "persona");

            migrationBuilder.CreateTable(
                name: "persona",
                schema: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_documento = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    numero_documento = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    tipo_persona = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido_paterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido_materno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 28, 20, 42, 22, 173, DateTimeKind.Local).AddTicks(1965))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_direccion",
                schema: "persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_direccion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persona_direccion",
                schema: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    id_tipo_direccion = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_direccion_persona_id_persona",
                        column: x => x.id_persona,
                        principalSchema: "persona",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_persona_direccion_tipo_direccion_id_tipo_direccion",
                        column: x => x.id_tipo_direccion,
                        principalSchema: "persona",
                        principalTable: "tipo_direccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "persona",
                table: "tipo_direccion",
                columns: new[] { "id", "descripcion" },
                values: new object[] { 1, "Casa" });

            migrationBuilder.InsertData(
                schema: "persona",
                table: "tipo_direccion",
                columns: new[] { "id", "descripcion" },
                values: new object[] { 2, "Trabajo" });

            migrationBuilder.InsertData(
                schema: "persona",
                table: "tipo_direccion",
                columns: new[] { "id", "descripcion" },
                values: new object[] { 3, "Familiar" });

            migrationBuilder.CreateIndex(
                name: "IX_persona_numero_documento",
                schema: "persona",
                table: "persona",
                column: "numero_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_direccion_id_persona",
                schema: "persona",
                table: "persona_direccion",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_persona_direccion_id_tipo_direccion",
                schema: "persona",
                table: "persona_direccion",
                column: "id_tipo_direccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persona_direccion",
                schema: "persona");

            migrationBuilder.DropTable(
                name: "persona",
                schema: "persona");

            migrationBuilder.DropTable(
                name: "tipo_direccion",
                schema: "persona");
        }
    }
}
