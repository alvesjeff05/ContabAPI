using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContabAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tipo_cliente = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefone_cliente = table.Column<int>(type: "int", nullable: true),
                    endereco_cliente = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__677F38F50A8F7A9E", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_funcionario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cargo_funcionario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefone_funcionario = table.Column<int>(type: "int", nullable: true),
                    departamento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Funciona__6FBD69C40E10D141", x => x.id_funcionario);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    id_servico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_servico = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    taxa_servico = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicos__D06FB5A2DCB7B0C9", x => x.id_servico);
                });

            migrationBuilder.CreateTable(
                name: "DeclaracoesFinanceiras",
                columns: table => new
                {
                    id_declaracao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    tipo_declaracao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    data_preparacao = table.Column<int>(type: "int", nullable: true),
                    conteudo_declaracao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Declarac__1132B2610363BCFB", x => x.id_declaracao);
                    table.ForeignKey(
                        name: "FK__Declaraco__id_cl__3D5E1FD2",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente");
                });

            migrationBuilder.CreateTable(
                name: "TransacoesFinanceiras",
                columns: table => new
                {
                    id_transacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    tipo_transacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    data_preparacao = table.Column<int>(type: "int", nullable: true),
                    valor_transicao = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transaco__0FBBF7735B10FBDC", x => x.id_transacao);
                    table.ForeignKey(
                        name: "FK__Transacoe__id_cl__3A81B327",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeclaracoesFinanceiras_id_cliente",
                table: "DeclaracoesFinanceiras",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesFinanceiras_id_cliente",
                table: "TransacoesFinanceiras",
                column: "id_cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclaracoesFinanceiras");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "TransacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
