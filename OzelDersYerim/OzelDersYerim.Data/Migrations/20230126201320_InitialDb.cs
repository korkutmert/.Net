using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelDersYerim.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ThisUserRole = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    About = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Experience = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    PricePerHour = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PricePerHour = table.Column<decimal>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsLessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsLessons", x => new { x.StudentId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_StudentsLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsLessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersLessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersLessons", x => new { x.TeacherId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_TeachersLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersLessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "558574f8-c217-4ce2-a556-a0c1002efd1b", null, "Teacher", "TEACHER" },
                    { "d41cfa85-8dbc-46f5-becc-d1c99b323dbb", null, "Admin", "ADMIN" },
                    { "e32f6815-c4ce-4af5-8fe4-1563bb5984ed", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ThisUserRole", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "36c1db42-7495-477f-921e-ba037f5188ed", 0, "fea0a4d8-899a-41a3-bd1f-0d5ebb5eb447", "teacher@gmail.com", false, false, null, "TEACHER@GMAIL.COM", "ABC", "AQAAAAIAAYagAAAAEGfv5O4Z6zht+wVk/RrhtGm5EDQeFEuyFT0KTvxnOL06wMR06cCnS6RQyYsdxY9yOA==", "05556669944", false, "30214faa-e554-476a-9349-0c4f3d3a68e9", "Teacher", false, "abc" },
                    { "admin", 0, "686c5560-141c-4cb2-a8dd-503a957bbe4f", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEDJ1HbDC6RpyKgYiShegOItJCpu7c9K5rjIU+vQEgu0T8atpEvwKIMCuXTFvdP2MZQ==", "05551112233", false, "d0cc910e-643a-4256-8827-4aaa15778dfe", "Admin", false, "admin" },
                    { "ahj8-ahjs-87yht", 0, "243bc742-4abb-4e96-a016-4f42e05f1585", "mehmet@gmail.com", false, false, null, "MEHMET@GMAIL.COM", "MEHMETHOCA", "AQAAAAIAAYagAAAAEElOLPbTgYmsgKK+MsJ3owWapuiop/6Q1IXfv/RHKN3MpBRYhHWFmVYcipQnn9uDDA==", "05553335566", false, "289e04d5-4fa6-42c1-a31b-63438a2dc0f3", "Teacher", false, "mehmetthoca" },
                    { "arzu", 0, "a8bfc2f8-9998-4aa6-a6fa-84129a391f77", "arzu@gmail.com", false, false, null, "ARZU@GMAIL.COM", "KLM", "AQAAAAIAAYagAAAAEFPLrVe51J6QVLab+Tu+KWodGAVUjUipywb+olHrBftOXyd3ZYP22UyKzQcg6iaHaQ==", "05557778855", false, "d90e1de9-ed81-4242-8f81-72845667e172", "Teacher", false, "klm" },
                    { "c3Mr3-s77Nel", 0, "166e4e65-4a76-406d-87c6-b6cc9ed05721", "cemre@gmail.com", false, false, null, "CEMRE@GMAIL.COM", "CEMRESENEL", "AQAAAAIAAYagAAAAEDkDgJUtAbIjJUd38jyiYRajwzP7c/FvnA4jb5VSI2DCnsPBbOY1klbMPywSGzU9jQ==", "05557770606", false, "09cd02f8-ed11-40bf-9879-27ef0c9b6b9e", "Student", false, "CemreSenel" },
                    { "f51a33d9-90b7-4304-8f27-296121b22ed8", 0, "ed11a9a9-f7e0-4e3e-9eaa-8ad353ced4ee", "student@gmail.com", false, false, null, "STUDENT@GMAIL.COM", "XWE", "AQAAAAIAAYagAAAAEAu/xMVrA2E0GWwL/HYTOZLqHG6JBRIhxdJag/YLSsATK0fhRT+f+o1TFGEduJTjYQ==", "05557778855", false, "6273fdbf-3d54-4703-b874-26f9f413ba14", "Student", false, "xwe" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "ImageUrl", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1081), "Matematik dersleri burada yer alır.", "matematik.png", "matematik" },
                    { 2, "Kimya", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1094), "Kimya dersleri burada yer alır.", "kimya.png", "kimya" },
                    { 3, "İngilizce", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1096), "İngilizce dersleri burada yer alır.", "ingilizce.png", "ingilizce" },
                    { 4, "Müzik", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1098), "Müzik dersleri burada yer alır.", "muzik.png", "muzik" },
                    { 5, "Türkçe", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1101), "Türkçe dersleri burada yer alır.", "turkce.png", "turkce" },
                    { 6, "Bilgisayar", new DateTime(2023, 1, 26, 23, 13, 20, 35, DateTimeKind.Local).AddTicks(1103), "Bilgisayar dersleri burada yer alır.", "bilgisayar.png", "bilgisayar" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "558574f8-c217-4ce2-a556-a0c1002efd1b", "36c1db42-7495-477f-921e-ba037f5188ed" },
                    { "d41cfa85-8dbc-46f5-becc-d1c99b323dbb", "admin" },
                    { "558574f8-c217-4ce2-a556-a0c1002efd1b", "ahj8-ahjs-87yht" },
                    { "558574f8-c217-4ce2-a556-a0c1002efd1b", "arzu" },
                    { "e32f6815-c4ce-4af5-8fe4-1563bb5984ed", "c3Mr3-s77Nel" },
                    { "e32f6815-c4ce-4af5-8fe4-1563bb5984ed", "f51a33d9-90b7-4304-8f27-296121b22ed8" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BranchId", "Description", "Name", "PricePerHour", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Sınav öncesi tekar, özel konu analıtımı ve soru çözümü kampı içeriklidir.", "TYT-Matematik hazırlık dersleri.", 150m, "tyt-matematik-hazirlik-dersleri" },
                    { 2, 2, "Üniversite sınavlarına ve okul sınavlarına özel etüd yapılır.", "Lise düzeyinde Kimya dersleri.", 100m, "lise-duzeyinde-kimya-dersleri" },
                    { 3, 3, "Dil Bilgisi,yazma ve konuşma olarak ileri seviye bir eğitim.", "A1-C2 arası konuşma pratikli İnglizce eğitimi.", 250m, "a1-c2-arasi-konusma-pratikli-inglizce-egitimi." }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Gender", "LastName", "Location", "ProfilePictureUrl", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mert Korkut", "Erkek", "Muslu", "Kadıköy", "1.png", "ogrenci-mert-korkut-muslu", "f51a33d9-90b7-4304-8f27-296121b22ed8" },
                    { 2, new DateTime(1995, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cemre ", "Erkek", "Şenel", "Beşiktaş", "2.png", "ogrenci-cemre-senel", "c3Mr3-s77Nel" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "About", "DateOfBirth", "Experience", "FirstName", "Gender", "IsHome", "LastName", "Location", "PricePerHour", "ProfilePictureUrl", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, "Samsun 19 Mayıs Universitesi Matematik Bölümü mezunuyum.", new DateTime(1978, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "15", "Ahmet", "Erkek", true, "Yılmaz", "Beşiktaş", 450m, "10.png", "ogretmen-ahmet-yilmaz", "36c1db42-7495-477f-921e-ba037f5188ed" },
                    { 2, "İngilizce Öğretmeniyim. Her türlü İngilizce sınavlarına hazırlık konusunda ders vermekteyim.", new DateTime(1985, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5", "Arzu", "Kadın", false, "Doğramacı", "Şişli", 300m, "11.png", "ogretmen-arzu-dogramaci", "arzu" },
                    { 3, "Boğaziçi Üniversitesi Mezunuyum. 28 yaşındayım. Özel bir lisede Kimya Öğretmenliği yapıyorum.", new DateTime(1990, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "6", "Mehmet", "Erkek", false, "Yıldırım", "Etiler", 300m, "12.png", "ogretmen-mehmet-yildirim", "ahj8-ahjs-87yht" }
                });

            migrationBuilder.InsertData(
                table: "StudentsLessons",
                columns: new[] { "LessonId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeacherBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "TeachersLessons",
                columns: new[] { "LessonId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_BranchId",
                table: "Lessons",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsLessons_LessonId",
                table: "StudentsLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_BranchId",
                table: "TeacherBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeachersLessons_LessonId",
                table: "TeachersLessons",
                column: "LessonId");
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
                name: "StudentsLessons");

            migrationBuilder.DropTable(
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeachersLessons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
