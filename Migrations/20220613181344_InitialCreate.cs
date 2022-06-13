using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beach_sys.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armario",
                columns: table => new
                {
                    ArmarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armario", x => x.ArmarioId);
                });

            migrationBuilder.CreateTable(
                name: "Compartimento",
                columns: table => new
                {
                    CompartimentoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Tamanho = table.Column<string>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    ArmarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartimento", x => x.CompartimentoId);
                    table.ForeignKey(
                        name: "FK_Compartimento_Armario_ArmarioId",
                        column: x => x.ArmarioId,
                        principalTable: "Armario",
                        principalColumn: "ArmarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    CompartimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Compartimento_CompartimentoId",
                        column: x => x.CompartimentoId,
                        principalTable: "Compartimento",
                        principalColumn: "CompartimentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compartimento_ArmarioId",
                table: "Compartimento",
                column: "ArmarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CompartimentoId",
                table: "Usuario",
                column: "CompartimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Compartimento");

            migrationBuilder.DropTable(
                name: "Armario");
        }
    }
}
