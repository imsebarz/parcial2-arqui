using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CreacionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidoEstado",
                columns: table => new
                {
                    PedidoEstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoEstado", x => x.PedidoEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoEstadoId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Entrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_PedidoEstado_PedidoEstadoId",
                        column: x => x.PedidoEstadoId,
                        principalTable: "PedidoEstado",
                        principalColumn: "PedidoEstadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PedidoEstado",
                columns: new[] { "PedidoEstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ingresado" },
                    { 2, "En procesamiento" },
                    { 3, "Despachado" },
                    { 4, "Entregado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PedidoEstadoId",
                table: "Pedido",
                column: "PedidoEstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PedidoEstado");
        }
    }
}
