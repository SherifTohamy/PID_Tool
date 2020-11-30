using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    BudgetHours = table.Column<float>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ClosedBy = table.Column<string>(nullable: true),
                    timeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    shortcut = table.Column<string>(maxLength: 10, nullable: false),
                    Priority = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Actions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    SESANum = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    ConfirmPassword = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.SESANum);
                });

            migrationBuilder.CreateTable(
                name: "RoleSubjectRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleIdFK = table.Column<int>(nullable: false),
                    SubjectIdFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSubjectRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleSubjectRelations_Roles_RoleIdFK",
                        column: x => x.RoleIdFK,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSubjectRelations_Subjects_SubjectIdFK",
                        column: x => x.SubjectIdFK,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSesaFK = table.Column<string>(nullable: true),
                    ProjectIdFK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUserRelation_Projects_ProjectIdFK",
                        column: x => x.ProjectIdFK,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUserRelation_Users_UserSesaFK",
                        column: x => x.UserSesaFK,
                        principalTable: "Users",
                        principalColumn: "SESANum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSesaFK = table.Column<string>(nullable: true),
                    RoleIdFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleRelations_Roles_RoleIdFK",
                        column: x => x.RoleIdFK,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleRelations_Users_UserSesaFK",
                        column: x => x.UserSesaFK,
                        principalTable: "Users",
                        principalColumn: "SESANum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserRelation_ProjectIdFK",
                table: "ProjectUserRelation",
                column: "ProjectIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserRelation_UserSesaFK",
                table: "ProjectUserRelation",
                column: "UserSesaFK");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSubjectRelations_RoleIdFK",
                table: "RoleSubjectRelations",
                column: "RoleIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSubjectRelations_SubjectIdFK",
                table: "RoleSubjectRelations",
                column: "SubjectIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelations_RoleIdFK",
                table: "UserRoleRelations",
                column: "RoleIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelations_UserSesaFK",
                table: "UserRoleRelations",
                column: "UserSesaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUserRelation");

            migrationBuilder.DropTable(
                name: "RoleSubjectRelations");

            migrationBuilder.DropTable(
                name: "UserRoleRelations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
