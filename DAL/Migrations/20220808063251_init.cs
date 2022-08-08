using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTypesEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypesEntities", x => x.Id);
                });

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
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnterpriseTypeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_clientEntities_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clientEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_EnterpriseEntities_EnterpriseTypeID",
                        column: x => x.EnterpriseTypeID,
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
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartTypeId = table.Column<int>(type: "int", nullable: false),
                    ShortAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentEntities_CompanyEntities_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "CompanyEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEntities_DepartmentTypesEntities_DepartTypeId",
                        column: x => x.DepartTypeId,
                        principalTable: "DepartmentTypesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeEntities_DepartmentEntities_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "DepartmentEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_CompanyEntities_ClientID",
                table: "CompanyEntities",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_EnterpriseTypeID",
                table: "CompanyEntities",
                column: "EnterpriseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEntities_CompanyID",
                table: "DepartmentEntities",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEntities_DepartTypeId",
                table: "DepartmentEntities",
                column: "DepartTypeId");

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
                column: "DepartmentID");
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
                name: "DepartmentTypesEntities");

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
