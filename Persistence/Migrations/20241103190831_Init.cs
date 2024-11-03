using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Todos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02f298e2-b656-4fcf-935c-8ce80df18aac", 0, "91e693ab-d566-4dc7-97dc-ba2f7b4d1e07", "User", "kakyoin@jojo.com", false, "Kakyoin", "Noriaki", false, null, null, null, "AQAAAAIAAYagAAAAEGh/5VvtOV+Adk9bzUBq+kUN5qPITrM6QPOoH0XEudxulWPAjI9zHKjD3Uyz5YS0gA==", null, false, "c80314f6-def2-43bb-abda-6531cdd48dbe", false, "kakyoin" },
                    { "03e2653b-1614-44c4-9846-2c9513d6cebc", 0, "52ad4a45-3dba-4b03-8853-7c127d0b6566", "User", "josuke@jojo.com", false, "Josuke", "Higashikata", false, null, null, null, "AQAAAAIAAYagAAAAEE/eJMwfk3oamsjokWlk/3cVwJl1dqsrdsf7t+hVJ3XhHcM+UEugh786nt50LvlZ1Q==", null, false, "2c2d8190-c455-4e7b-a773-2b78ec194539", false, "josuke" },
                    { "1d2650fd-92ec-48e2-9bb2-1598c879f848", 0, "615d54df-df9c-4776-b1ab-91417a7b5b4c", "User", "rohan@jojo.com", false, "Rohan", "Kishibe", false, null, null, null, "AQAAAAIAAYagAAAAENkgLJQlxlCESTQBFx8+n3x8LjpTsmEnG212X5bdKlXjQSxjgtUcEwH3jESJ5fa2Fg==", null, false, "d09bc2db-7702-4746-b73b-7d7ccb287e7d", false, "rohan" },
                    { "340518f6-0e7e-4c2a-9523-d0f08ef47b60", 0, "3a451d10-2c28-441d-99ac-31560a5f0376", "User", "bruno@jojo.com", false, "Bruno", "Bucciarati", false, null, null, null, "AQAAAAIAAYagAAAAEPxOR127xwmGLAuwj4pzIlCB2+aBYHH7RNPHLMto6e+3KZH6CnJfpgZzpzbPtILerA==", null, false, "bc6155a2-5388-40bf-893d-02fba5bcaf5d", false, "bruno" },
                    { "3d55c615-1a1e-41ba-b5fd-4b6057d1c526", 0, "060b897f-93bc-4271-930c-c50f0012a946", "User", "joseph@jojo.com", false, "Joseph", "Joestar", false, null, null, null, "AQAAAAIAAYagAAAAEKCPZ8q0INV9NmZNXvN57rjYvFVi+/IvQXiabJYitmiEfvHVN0FvPTrMUyyYslRC9w==", null, false, "53e03030-779e-4be2-a0ea-f08a5e963aef", false, "joseph" },
                    { "73ba6117-3056-4979-b3cb-adcc1d584c13", 0, "d2bcd7c5-34e0-477f-acb6-9c56328c95bb", "User", "jotaro@jojo.com", false, "Jotaro", "Kujo", false, null, null, null, "AQAAAAIAAYagAAAAEL9yR7g/2Nw9ICS4zLRYY20rX/bo7gjDG53/bP8dI+AQpRZe6Jee5YxedVJWnylS9w==", null, false, "3fc6e88e-a594-4cea-acb3-aead35156c01", false, "jotaro" },
                    { "8ef268f9-c05e-4f12-93f2-71f89bc598cd", 0, "f1b6f85e-f9de-4c40-b6c2-2fb9e8a8ca31", "User", "jonathan@jojo.com", false, "Jonathan", "Joestar", false, null, null, null, "AQAAAAIAAYagAAAAEH5KBqOpde+xtIsxO8QHadGOs0KNASb84HQdbJzsIZBRrsRQsp5M7FjLPjUOODmd8A==", null, false, "641bc86b-6384-4d8c-b4a7-cc381503f07f", false, "jonathan" },
                    { "b85c1194-e595-4c35-aece-e3545680c80e", 0, "77c1ee1e-3cf2-4e2d-ae0d-bb02e7e2f1b9", "User", "dio@jojo.com", false, "Dio", "Brando", false, null, null, null, "AQAAAAIAAYagAAAAEL4a9Hetk98myFogpjX6SHYnvoATTqHTecfvXr6UEvQH7WZkQglGtjbYvz8NTK12cg==", null, false, "9a23e6d9-68be-4363-a866-34f26a5c868e", false, "dio" },
                    { "c2c4fd3a-f4d5-4f9b-9f56-6e92cb6debd7", 0, "3e9f4b00-d135-4305-b54d-c21dd7fc8c5a", "User", "polnareff@jojo.com", false, "Jean Pierre", "Polnareff", false, null, null, null, "AQAAAAIAAYagAAAAEHTygIshcbIgtl07lGsWeszgHE5Ahh6AY0NBmoKHqu44KkO/cD25wKE+7XLLhh+Zog==", null, false, "274663a7-3c95-4ea5-8ead-8f1d37ec366f", false, "polnareff" },
                    { "e37fb095-73e2-480d-9cc7-186030d0fba8", 0, "505cba24-c6fe-4c34-8054-9194b055e61b", "User", "giorno@jojo.com", false, "Giorno", "Giovanna", false, null, null, null, "AQAAAAIAAYagAAAAEIgoujgtuENvbnFU7Dmrf4+gtOOSOuzu3TwXtxOWZFAjDp/ipVEN/RkPC5xPXVy7+g==", null, false, "db7f66df-69d8-43ae-93c7-2bbc8534d9c2", false, "giorno" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stand Battles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fashion Choices", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Memorable Quotes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unforgettable Villains", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meme Wars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Description", "EndDate", "StartDate", "Title", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Every time I walk into a room, I must strike a pose.", new DateTime(2024, 11, 10, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2616), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2592), "Learn how to pose dramatically", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d55c615-1a1e-41ba-b5fd-4b6057d1c526" },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Must come up with a clever scheme.", new DateTime(2024, 11, 8, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2671), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2670), "Plan the ultimate revenge against Jotaro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b85c1194-e595-4c35-aece-e3545680c80e" },
                    { 3, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use his face in the next viral meme.", new DateTime(2024, 11, 6, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2677), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2676), "Create a meme with Rohan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1d2650fd-92ec-48e2-9bb2-1598c879f848" },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Did someone eat it or did a Stand steal it?", new DateTime(2024, 11, 4, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2684), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2681), "Investigate the mystery of the missing pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03e2653b-1614-44c4-9846-2c9513d6cebc" },
                    { 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make sure it includes a strong villain.", new DateTime(2024, 11, 13, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2688), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2688), "Write a new chapter for my manga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1d2650fd-92ec-48e2-9bb2-1598c879f848" },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It’s about time my Stand helped with chores!", new DateTime(2024, 11, 5, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2733), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2732), "Train my Stand to do the dishes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d55c615-1a1e-41ba-b5fd-4b6057d1c526" },
                    { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I need to prove my style is superior!", new DateTime(2024, 11, 6, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2736), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2736), "Have a fashion showdown with Jotaro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73ba6117-3056-4979-b3cb-adcc1d584c13" },
                    { 8, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "No one messes with a Joestar’s food!", new DateTime(2024, 11, 4, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2741), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2740), "Find out who stole my spaghetti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d55c615-1a1e-41ba-b5fd-4b6057d1c526" },
                    { 9, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Need material for the next meme.", new DateTime(2024, 11, 8, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2744), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2743), "Record Dio's best quotes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b85c1194-e595-4c35-aece-e3545680c80e" },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We need to strengthen our bond.", new DateTime(2024, 11, 7, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2747), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2747), "Discuss friendship with Kakyoin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02f298e2-b656-4fcf-935c-8ce80df18aac" },
                    { 11, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use all my JoJo experiences for laughs.", new DateTime(2024, 11, 10, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2751), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2750), "Start a Stand-up comedy routine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73ba6117-3056-4979-b3cb-adcc1d584c13" },
                    { 12, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Let’s see who has the best hair!", new DateTime(2024, 11, 6, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2753), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2752), "Challenge Josuke to a hair-styling contest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "03e2653b-1614-44c4-9846-2c9513d6cebc" },
                    { 13, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make it as bizarre as possible!", new DateTime(2024, 11, 17, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2755), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2755), "Create a JoJo-themed escape room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1d2650fd-92ec-48e2-9bb2-1598c879f848" },
                    { 14, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Must include lots of drama and betrayal.", new DateTime(2024, 11, 13, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2758), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2757), "Write an epic ballad about my adventures", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "340518f6-0e7e-4c2a-9523-d0f08ef47b60" },
                    { 15, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The winner gets a pizza!", new DateTime(2024, 11, 18, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2799), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2761), "Host a Stand Battle tournament", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b85c1194-e595-4c35-aece-e3545680c80e" },
                    { 16, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It should be something cool and over-the-top!", new DateTime(2024, 11, 11, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2815), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2814), "Develop a new Stand ability", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e37fb095-73e2-480d-9cc7-186030d0fba8" },
                    { 17, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make it catchy and powerful!", new DateTime(2024, 11, 9, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2823), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2823), "Compose a theme song for my Stand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73ba6117-3056-4979-b3cb-adcc1d584c13" },
                    { 18, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time to prove my strength!", new DateTime(2024, 11, 7, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2827), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2826), "Have a showdown with a rival Stand user", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8ef268f9-c05e-4f12-93f2-71f89bc598cd" },
                    { 19, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It needs to be legendary!", new DateTime(2024, 11, 15, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2831), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2831), "Create a cosplay for the next convention", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "340518f6-0e7e-4c2a-9523-d0f08ef47b60" },
                    { 20, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I need to find some cool artifacts!", new DateTime(2024, 11, 23, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2924), new DateTime(2024, 11, 3, 22, 8, 31, 327, DateTimeKind.Local).AddTicks(2923), "Plan a trip to the Joestar family mansion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d55c615-1a1e-41ba-b5fd-4b6057d1c526" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CategoryId",
                table: "Todos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
