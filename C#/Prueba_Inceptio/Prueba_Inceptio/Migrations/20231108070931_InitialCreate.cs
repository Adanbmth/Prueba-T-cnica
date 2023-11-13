using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prueba_Inceptio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    proveedor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.proveedor_id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    moto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    marca = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    modelo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ahno = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.moto_id);
                });

            migrationBuilder.CreateTable(
                name: "refaccion",
                columns: table => new
                {
                    refaccion_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proveedor_id = table.Column<int>(type: "integer", nullable: false),
                    moto_id = table.Column<int>(type: "integer", nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    precio_unit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refaccion", x => x.refaccion_id);
                    table.ForeignKey(
                        name: "FK_refaccion_proveedor_proveedor_id",
                        column: x => x.proveedor_id,
                        principalTable: "proveedor",
                        principalColumn: "proveedor_id");
                    table.ForeignKey(
                        name: "FK_refaccion_vehiculo_moto_id",
                        column: x => x.moto_id,
                        principalTable: "vehiculo",
                        principalColumn: "moto_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_refaccion_moto_id",
                table: "refaccion",
                column: "moto_id");

            migrationBuilder.CreateIndex(
                name: "IX_refaccion_proveedor_id",
                table: "refaccion",
                column: "proveedor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refaccion");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "vehiculo");
        }
    }
}
