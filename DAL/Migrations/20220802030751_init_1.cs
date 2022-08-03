using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnterpriseDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "clientIdentities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientIdentities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clientIdentities_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    DateBorn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientIdenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clientEntities_clientIdentities_ClientIdenID",
                        column: x => x.ClientIdenID,
                        principalTable: "clientIdentities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    clientEntitiesID = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnterpriseTypeID = table.Column<int>(type: "int", nullable: false),
                    enterpriseEntityID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_clientEntities_clientEntitiesID",
                        column: x => x.clientEntitiesID,
                        principalTable: "clientEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_EnterpriseEntities_enterpriseEntityID",
                        column: x => x.enterpriseEntityID,
                        principalTable: "EnterpriseEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CompanyEntityID = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentEntities_CompanyEntities_CompanyEntityID",
                        column: x => x.CompanyEntityID,
                        principalTable: "CompanyEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeEntities_DepartmentEntities_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "DepartmentEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEntities_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductionEntities_DepartmentEntities_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "DepartmentEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientEntities_ClientIdenID",
                table: "clientEntities",
                column: "ClientIdenID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientIdentities_RoleId",
                table: "clientIdentities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_clientEntitiesID",
                table: "CompanyEntities",
                column: "clientEntitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_enterpriseEntityID",
                table: "CompanyEntities",
                column: "enterpriseEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEntities_CompanyEntityID",
                table: "DepartmentEntities",
                column: "CompanyEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEntities_DepartmentID",
                table: "EmployeeEntities",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEntities_RoleID",
                table: "EmployeeEntities",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionEntities_DepartmentID",
                table: "ProductionEntities",
                column: "DepartmentID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEntities");

            migrationBuilder.DropTable(
                name: "ProductionEntities");

            migrationBuilder.DropTable(
                name: "DepartmentEntities");

            migrationBuilder.DropTable(
                name: "CompanyEntities");

            migrationBuilder.DropTable(
                name: "clientEntities");

            migrationBuilder.DropTable(
                name: "EnterpriseEntities");

            migrationBuilder.DropTable(
                name: "clientIdentities");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
