using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HC_MIS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hc_ackStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ack_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hc_ackStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hc_development",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    open_balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allocated_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hf_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_entry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hc_development", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hc_dgoffice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hf_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cheque_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courier_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courier_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diary_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_entry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hc_dgoffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hc_hfAcknowledge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    received_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hf_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cheque_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cheque_statusId = table.Column<int>(type: "int", nullable: false),
                    received_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_entry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hc_hfAcknowledge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hc_hfbankdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hf_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branch_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_entry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hc_hfbankdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phs_Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phs_User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phs_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phs_RoleClaims_phs_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "phs_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phs_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phs_UserClaims_phs_User_UserId",
                        column: x => x.UserId,
                        principalTable: "phs_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phs_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_phs_UserLogins_phs_User_UserId",
                        column: x => x.UserId,
                        principalTable: "phs_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phs_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_phs_UserRoles_phs_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "phs_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phs_UserRoles_phs_User_UserId",
                        column: x => x.UserId,
                        principalTable: "phs_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phs_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phs_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_phs_UserTokens_phs_User_UserId",
                        column: x => x.UserId,
                        principalTable: "phs_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "phs_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_phs_RoleClaims_RoleId",
                table: "phs_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "phs_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "phs_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_phs_UserClaims_UserId",
                table: "phs_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_phs_UserLogins_UserId",
                table: "phs_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_phs_UserRoles_RoleId",
                table: "phs_UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hc_ackStatus");

            migrationBuilder.DropTable(
                name: "hc_development");

            migrationBuilder.DropTable(
                name: "hc_dgoffice");

            migrationBuilder.DropTable(
                name: "hc_hfAcknowledge");

            migrationBuilder.DropTable(
                name: "hc_hfbankdetails");

            migrationBuilder.DropTable(
                name: "phs_RoleClaims");

            migrationBuilder.DropTable(
                name: "phs_UserClaims");

            migrationBuilder.DropTable(
                name: "phs_UserLogins");

            migrationBuilder.DropTable(
                name: "phs_UserRoles");

            migrationBuilder.DropTable(
                name: "phs_UserTokens");

            migrationBuilder.DropTable(
                name: "phs_Role");

            migrationBuilder.DropTable(
                name: "phs_User");
        }
    }
}
