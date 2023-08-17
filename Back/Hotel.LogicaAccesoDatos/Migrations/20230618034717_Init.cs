using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuraciones",
                columns: table => new
                {
                    NombreAtributo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LimiteSuperior = table.Column<int>(type: "int", nullable: false),
                    LimiteInferior = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuraciones", x => x.NombreAtributo);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeCabania",
                columns: table => new
                {
                    IdTipoCabania = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo_Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeCabania", x => x.IdTipoCabania);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cabanias",
                columns: table => new
                {
                    IdCabania = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoCabania = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantMaxPersonas = table.Column<int>(type: "int", nullable: false),
                    HabilitadaParaReservas = table.Column<bool>(type: "bit", nullable: false),
                    TieneJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabanias", x => x.IdCabania);
                    table.ForeignKey(
                        name: "FK_Cabanias_TipoDeCabania_IdTipoCabania",
                        column: x => x.IdTipoCabania,
                        principalTable: "TipoDeCabania",
                        principalColumn: "IdTipoCabania",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    IdMantenimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCabania = table.Column<int>(type: "int", nullable: false),
                    NombreDelFunc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo_Valor = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.IdMantenimiento);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabanias_IdCabania",
                        column: x => x.IdCabania,
                        principalTable: "Cabanias",
                        principalColumn: "IdCabania",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_IdCabania",
                table: "Cabanias",
                column: "IdCabania",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_IdTipoCabania",
                table: "Cabanias",
                column: "IdTipoCabania");

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_Nombre",
                table: "Cabanias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_IdCabania",
                table: "Mantenimientos",
                column: "IdCabania");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeCabania_IdTipoCabania",
                table: "TipoDeCabania",
                column: "IdTipoCabania",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuraciones");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabanias");

            migrationBuilder.DropTable(
                name: "TipoDeCabania");
        }
    }
}
