using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdministrativoEscolar.CORE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    IdEscola = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdEscola = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NmEscola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NuTelefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TxEndereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NuEndereco = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NuCepEndereco = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TxBairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TxCidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TxEstado = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.IdEscola);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuMatricula = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
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
                name: "TipoUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdTipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxTipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "StatusMatriculaHistoricos",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    IdStatusMatricula = table.Column<int>(type: "int", nullable: false),
                    FlStatusAtual = table.Column<bool>(type: "bit", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMatriculaHistoricos", x => new { x.IdMatricula, x.IdStatusMatricula });
                    table.ForeignKey(
                        name: "FK_StatusMatriculaHistoricos_Matriculas_IdMatricula",
                        column: x => x.IdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusMatriculaHistoricos_StatusMatriculas_IdStatusMatricula",
                        column: x => x.IdStatusMatricula,
                        principalTable: "StatusMatriculas",
                        principalColumn: "IdStatusMatricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEscola = table.Column<int>(type: "int", nullable: true),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    TxEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TxSenha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "IdEscola");
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEscola = table.Column<int>(type: "int", nullable: false),
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NmAluno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SbnmAluno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NuTelefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NuRG = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NuCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TxNacionalidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "IdEscola",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Matriculas_IdMatricula",
                        column: x => x.IdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula");
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "AlunoStatusLetivoHistoricos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdStatusLetivo = table.Column<int>(type: "int", nullable: false),
                    FlStatusAtual = table.Column<bool>(type: "bit", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoStatusLetivoHistoricos", x => new { x.IdAluno, x.IdStatusLetivo });
                    table.ForeignKey(
                        name: "FK_AlunoStatusLetivoHistoricos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoStatusLetivoHistoricos_StatusLetivos_IdStatusLetivo",
                        column: x => x.IdStatusLetivo,
                        principalTable: "StatusLetivos",
                        principalColumn: "IdStatusLetivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoAlunos",
                columns: table => new
                {
                    IdEnderecoAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    TxEndereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NuEndereco = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NuCepEndereco = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TxBairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TxCidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TxEstado = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FlEnderecoAtual = table.Column<bool>(type: "bit", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoAlunos", x => x.IdEnderecoAluno);
                    table.ForeignKey(
                        name: "FK_EnderecoAlunos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelAlunos",
                columns: table => new
                {
                    IdResponsavelAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NmResponsavel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NuTelefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NuRG = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NuCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlResponsavelPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDelecao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelAlunos", x => x.IdResponsavelAluno);
                    table.ForeignKey(
                        name: "FK_ResponsavelAlunos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsavelAlunos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
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

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "IdTipoUsuario", "CdTipoUsuario", "TxTipoUsuario" },
                values: new object[,]
                {
                    { 1, "administrador_geral", "Administrador Geral" },
                    { 2, "administrador_escolar", "Administrador Escolar" },
                    { 3, "professor", "Professor" },
                    { 4, "aluno", "Aluno" },
                    { 5, "responsavel_aluno", "Responsável Aluno" },
                    { 6, "funcionario", "Funcionario" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "DtAtualizacao", "DtCriacao", "DtDelecao", "IdEscola", "IdTipoUsuario", "TxEmail", "TxSenha" },
                values: new object[] { 1, new DateTime(2023, 3, 24, 9, 51, 35, 688, DateTimeKind.Local).AddTicks(5048), new DateTime(2023, 3, 24, 9, 51, 35, 688, DateTimeKind.Local).AddTicks(5035), null, null, 1, "eliasgomesleitejunior99@gmail.com", "123AdmEscolar" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdEscola",
                table: "Alunos",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdMatricula",
                table: "Alunos",
                column: "IdMatricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdUsuario",
                table: "Alunos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunoStatusLetivoHistoricos_IdStatusLetivo",
                table: "AlunoStatusLetivoHistoricos",
                column: "IdStatusLetivo");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoAlunos_IdAluno",
                table: "EnderecoAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAlunos_IdAluno",
                table: "ResponsavelAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAlunos_IdUsuario",
                table: "ResponsavelAlunos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusMatriculaHistoricos_IdStatusMatricula",
                table: "StatusMatriculaHistoricos",
                column: "IdStatusMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEscola",
                table: "Usuarios",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
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

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
