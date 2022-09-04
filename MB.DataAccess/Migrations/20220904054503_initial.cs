using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915"), new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6647), "User", "User", true, null },
                    { new Guid("f06310dd-0a27-4897-832d-2ebc7feb606e"), new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6649), "Admin", "Admin", true, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("eaac6de8-dfbb-485e-a94f-c126a38e0c0d"), new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6513), "TV", true, null },
                    { new Guid("febe926b-36cd-4c3c-8e96-046d0b6da71d"), new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6526), "Phone", true, null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AppRoleId", "CreateDate", "Email", "Name", "PasswordHash", "Status", "Surname", "UpdateDate" },
                values: new object[] { new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915"), new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6665), "ruslan.galandarli@gmail.com", "Ruslan", "+vm1hl0OyKZBtorJGZVZVc1awVcXBCFd+yJPRXwkYjQ=", true, "Galandarli", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Count", "CreateDate", "Name", "Status", "UpdateDate" },
                values: new object[] { new Guid("a13a1fda-419f-4ece-a25c-0e084a52d080"), new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), new Guid("eaac6de8-dfbb-485e-a94f-c126a38e0c0d"), 23, new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6685), "Sm222", true, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Count", "CreateDate", "Name", "Status", "UpdateDate" },
                values: new object[] { new Guid("eba2135b-202b-4eeb-9af1-3364d55c5949"), new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), new Guid("febe926b-36cd-4c3c-8e96-046d0b6da71d"), 23, new DateTime(2022, 9, 4, 9, 45, 3, 431, DateTimeKind.Local).AddTicks(6681), "Iphone", true, null });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserId",
                table: "Products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AppRoles");
        }
    }
}
