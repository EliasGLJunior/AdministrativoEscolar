using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdministrativoEscolar.CORE.Migrations
{
    /// <inheritdoc />
    public partial class InitialAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                });

            migrationBuilder.CreateTable(
                name: "StatusLetivos",
                columns: table => new
                {
                    IdStatusLetivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdStatusLetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxStatusLetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxTipoEnsino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLetivos", x => x.IdStatusLetivo);
                });

            migrationBuilder.CreateTable(
                name: "StatusMatriculas",
                columns: table => new
                {
                    IdStatusMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdStatusMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxStatusMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMatriculas", x => x.IdStatusMatricula);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SbnmAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuRG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxNacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatriculaIdMatricula = table.Column<int>(type: "int", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Matriculas_MatriculaIdMatricula",
                        column: x => x.MatriculaIdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula");
                });

            migrationBuilder.CreateTable(
                name: "StatusMatriculaHistoricos",
                columns: table => new
                {
                    IdStatusMatriculaHistorico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlStatusAtual = table.Column<bool>(type: "bit", nullable: false),
                    MatriculaIdMatricula = table.Column<int>(type: "int", nullable: true),
                    StatusMatriculaIdStatusMatricula = table.Column<int>(type: "int", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMatriculaHistoricos", x => x.IdStatusMatriculaHistorico);
                    table.ForeignKey(
                        name: "FK_StatusMatriculaHistoricos_Matriculas_MatriculaIdMatricula",
                        column: x => x.MatriculaIdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula");
                    table.ForeignKey(
                        name: "FK_StatusMatriculaHistoricos_StatusMatriculas_StatusMatriculaIdStatusMatricula",
                        column: x => x.StatusMatriculaIdStatusMatricula,
                        principalTable: "StatusMatriculas",
                        principalColumn: "IdStatusMatricula");
                });

            migrationBuilder.CreateTable(
                name: "AlunoStatusLetivoHistoricos",
                columns: table => new
                {
                    IdStatusLetivoHistorico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlStatusAtual = table.Column<bool>(type: "bit", nullable: false),
                    AlunoIdAluno = table.Column<int>(type: "int", nullable: true),
                    StatusLetivoIdStatusLetivo = table.Column<int>(type: "int", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoStatusLetivoHistoricos", x => x.IdStatusLetivoHistorico);
                    table.ForeignKey(
                        name: "FK_AlunoStatusLetivoHistoricos_Alunos_AlunoIdAluno",
                        column: x => x.AlunoIdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno");
                    table.ForeignKey(
                        name: "FK_AlunoStatusLetivoHistoricos_StatusLetivos_StatusLetivoIdStatusLetivo",
                        column: x => x.StatusLetivoIdStatusLetivo,
                        principalTable: "StatusLetivos",
                        principalColumn: "IdStatusLetivo");
                });

            migrationBuilder.CreateTable(
                name: "EnderecoAlunos",
                columns: table => new
                {
                    IdEnderecoAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuCepEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlEnderecoAtual = table.Column<bool>(type: "bit", nullable: false),
                    AlunoIdAluno = table.Column<int>(type: "int", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoAlunos", x => x.IdEnderecoAluno);
                    table.ForeignKey(
                        name: "FK_EnderecoAlunos_Alunos_AlunoIdAluno",
                        column: x => x.AlunoIdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno");
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelAlunos",
                columns: table => new
                {
                    IdResponsavelAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuRG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlResponsavelPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    AlunoIdAluno = table.Column<int>(type: "int", nullable: true),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelAlunos", x => x.IdResponsavelAluno);
                    table.ForeignKey(
                        name: "FK_ResponsavelAlunos_Alunos_AlunoIdAluno",
                        column: x => x.AlunoIdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno");
                });

            migrationBuilder.InsertData(
                table: "StatusLetivos",
                columns: new[] { "IdStatusLetivo", "CdStatusLetivo", "TxStatusLetivo", "TxTipoEnsino" },
                values: new object[,]
                {
                    { 1, "primeiro_creche", "1º Creche", "creche" },
                    { 2, "segundo_creche", "2º Creche", "creche" },
                    { 3, "terceiro_creche", "3º Creche", "creche" },
                    { 4, "primeiro_ensino_infantil", "1º Ensino Infantil", "ensino_infantil" },
                    { 5, "segundo_ensino_infantil", "2º Ensino Infantil", "ensino_infantil" },
                    { 6, "primeiro_fundamental", "1º Fundamental", "ensino_fundamental_um" },
                    { 7, "segundo_fundamental", "2º Fundamental", "ensino_fundamental_um" },
                    { 8, "terceiro_fundamental", "3º Fundamental", "ensino_fundamental_um" },
                    { 9, "quarto_fundamental", "4º Fundamental", "ensino_fundamental_um" },
                    { 10, "quinto_fundamental", "5º Fundamental", "ensino_fundamental_um" },
                    { 11, "sexto_fundamental", "6º Fundamental", "ensino_fundamental_dois" },
                    { 12, "setimo_fundamental", "7º Fundamental", "ensino_fundamental_dois" },
                    { 13, "oitavo_fundamental", "8º Fundamental", "ensino_fundamental_dois" },
                    { 14, "nono_fundamental", "9º Fundamental", "ensino_fundamental_dois" },
                    { 15, "primeiro_ensino_medio", "1º Ensino Médio", "ensino_medio" },
                    { 16, "segundo_ensino_medio", "2º Ensino Médio", "ensino_medio" },
                    { 17, "terceiro_ensino_medio", "3º Ensino Médio", "ensino_medio" },
                    { 18, "quarto_ensino_medio", "4º Ensino Médio", "ensino_medio" },
                    { 19, "primeiro_ensino_medio_tecnico", "1º Ensino Médio Técnico", "ensino_medio_tecnico" },
                    { 20, "segundo_ensino_medio_tecnico", "2º Ensino Médio Técnico", "ensino_medio_tecnico" },
                    { 21, "terceiro_ensino_medio_tecnico", "3º Ensino Médio Técnico", "ensino_medio_tecnico" },
                    { 22, "quarto_ensino_medio_tecnico", "4º Ensino Médio Técnico", "ensino_medio_tecnico" },
                    { 23, "primeiro_semestre_ensino_tecnico", "1º Semestre Ensino Técnico", "ensino_tecnico" },
                    { 24, "segundo_semestre_ensino_tecnico", "2º Semestre Ensino Técnico", "ensino_tecnico" },
                    { 25, "terceiro_semestre_ensino_tecnico", "3º Semestre Ensino Técnico", "ensino_tecnico" },
                    { 26, "quarto_semestre_ensino_tecnico", "4º Semestre Ensino Técnico", "ensino_tecnico" },
                    { 27, "primeiro_semestre_superior", "1º Semestre Superior", "ensino_superior" },
                    { 28, "segundo_semestre_superior", "2º Semestre Superior", "ensino_superior" },
                    { 29, "terceiro_semestre_superior", "3º Semestre Superior", "ensino_superior" },
                    { 30, "quarto_semestre_superior", "4º Semestre Superior", "ensino_superior" },
                    { 31, "quinto_semestre_superior", "5º Semestre Superior", "ensino_superior" },
                    { 32, "sexto_semestre_superior", "6º Semestre Superior", "ensino_superior" },
                    { 33, "setimo_semestre_superior", "7º Semestre Superior", "ensino_superior" },
                    { 34, "oitavo_semestre_superior", "8º Semestre Superior", "ensino_superior" },
                    { 35, "nono_semestre_superior", "9º Semestre Superior", "ensino_superior" },
                    { 36, "decimo_semestre_superior", "10º Semestre Superior", "ensino_superior" },
                    { 37, "decimo_primeiro_semestre_superior", "11º Semestre Superior", "ensino_superior" },
                    { 38, "decimo_segundo_semestre_superior", "12º Semestre Superior", "ensino_superior" }
                });

            migrationBuilder.InsertData(
                table: "StatusMatriculas",
                columns: new[] { "IdStatusMatricula", "CdStatusMatricula", "TxStatusMatricula" },
                values: new object[,]
                {
                    { 1, "matriculado", "Matriculado" },
                    { 2, "pendente", "Pendente" },
                    { 3, "trancado", "Trancado" },
                    { 4, "cancelado", "Cancelado" },
                    { 5, "desistencia", "Desistência" },
                    { 6, "transferido", "Transferido" },
                    { 7, "rejeitado", "Rejeitado" },
                    { 8, "suspenso", "Suspenso" },
                    { 9, "expulso", "Expulso" },
                    { 10, "graduado", "Graduado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_MatriculaIdMatricula",
                table: "Alunos",
                column: "MatriculaIdMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoStatusLetivoHistoricos_AlunoIdAluno",
                table: "AlunoStatusLetivoHistoricos",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoStatusLetivoHistoricos_StatusLetivoIdStatusLetivo",
                table: "AlunoStatusLetivoHistoricos",
                column: "StatusLetivoIdStatusLetivo");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoAlunos_AlunoIdAluno",
                table: "EnderecoAlunos",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAlunos_AlunoIdAluno",
                table: "ResponsavelAlunos",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_StatusMatriculaHistoricos_MatriculaIdMatricula",
                table: "StatusMatriculaHistoricos",
                column: "MatriculaIdMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_StatusMatriculaHistoricos_StatusMatriculaIdStatusMatricula",
                table: "StatusMatriculaHistoricos",
                column: "StatusMatriculaIdStatusMatricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoStatusLetivoHistoricos");

            migrationBuilder.DropTable(
                name: "EnderecoAlunos");

            migrationBuilder.DropTable(
                name: "ResponsavelAlunos");

            migrationBuilder.DropTable(
                name: "StatusMatriculaHistoricos");

            migrationBuilder.DropTable(
                name: "StatusLetivos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "StatusMatriculas");

            migrationBuilder.DropTable(
                name: "Matriculas");
        }
    }
}
