using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cb_AddressType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_AddressType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_AnswerMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_AnswerMode", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Country", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_CourseLessonItemTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseLessonItemTemplate", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_CourseStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseStatus", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_CourseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_CourseType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_Culture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnvironmentCulture = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Culture", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailBodyHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailBodyPlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Email", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_GalleryItemType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_GalleryItemType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_License",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaximumBranch = table.Column<int>(type: "int", nullable: false),
                    MaximumCourse = table.Column<int>(type: "int", nullable: false),
                    CreatePrivateCourse = table.Column<bool>(type: "bit", nullable: false),
                    MaximumUser = table.Column<int>(type: "int", nullable: false),
                    MounthPrice = table.Column<double>(type: "float", nullable: false),
                    OneYearSale = table.Column<double>(type: "float", nullable: false),
                    SendCourseInquiry = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_License", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_NoteType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_NoteType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_NotificationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_NotificationType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_QuestionMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_QuestionMode", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_SendMessageType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_SendMessageType", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Cb_TimeTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationStudyHourFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationStudyHourToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermDateFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermDateToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_TimeTable", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRandomGenerateQuestion = table.Column<bool>(type: "bit", nullable: false),
                    QuestionCountInTest = table.Column<int>(type: "int", nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    DesiredSuccess = table.Column<int>(type: "int", nullable: false),
                    MaxRepetition = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTest", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_FileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_FileRepository", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRole", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Person", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserRole", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanSendCourseInquiry = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Organization_Cb_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Cb_License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseTestEvaluation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointFrom = table.Column<int>(type: "int", nullable: true),
                    PointTo = table.Column<int>(type: "int", nullable: true),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTestEvaluation", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_CourseTestEvaluation_Edu_CourseTest_CourseTestId", column: x => x.CourseTestId, principalTable: "Edu_CourseTest", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRolePermition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermitionIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRolePermition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRolePermition_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRoleTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRoleTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRoleTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRoleTranslation_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_PersonAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_PersonAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_PersonAddress_Cb_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "Cb_AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_PersonAddress_Cb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Cb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_PersonAddress_Edu_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Edu_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_User", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_User_Edu_Person_PersonId", column: x => x.PersonId, principalTable: "Edu_Person", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Edu_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_UserRoleTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserRoleTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_UserRoleTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_UserRoleTranslation_Edu_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Edu_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_BankOfQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_BankOfQuestion", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_BankOfQuestion_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMainBranch = table.Column<bool>(type: "bit", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WWW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Branch", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_Branch_Cb_Country_CountryId", column: x => x.CountryId, principalTable: "Cb_Country", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(name: "FK_Edu_Branch_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Certificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateValidTo = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Certificate", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_Certificate_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseMaterial", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_CourseMaterial_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationAddress_Cb_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "Cb_AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationAddress_Cb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Cb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_OrganizationAddress_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserDefaultPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseOldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElearningUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLogin = table.Column<bool>(type: "bit", nullable: false),
                    GoogleLogin = table.Column<bool>(type: "bit", nullable: false),
                    PasswordReset = table.Column<bool>(type: "bit", nullable: false),
                    Registration = table.Column<bool>(type: "bit", nullable: false),
                    LessonLength = table.Column<int>(type: "int", nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCustomSmtpServer = table.Column<bool>(type: "bit", nullable: false),
                    SmtpServerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpServerUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpServerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpServerPort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleApiToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                        column: x => x.LicenseOldId,
                        principalTable: "Cb_License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_OrganizationSetting_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationStudyHour",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ActiveFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationStudyHour", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_OrganizationStudyHour_Cb_TimeTable_ActiveFromId", column: x => x.ActiveFromId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_OrganizationStudyHour_Cb_TimeTable_ActiveToId", column: x => x.ActiveToId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_OrganizationStudyHour_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_OrganizationTranslation_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_SendMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendMessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_SendMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_SendMessage_Cb_SendMessageType_SendMessageTypeId",
                        column: x => x.SendMessageTypeId,
                        principalTable: "Cb_SendMessageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_SendMessage_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentGroup", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_StudentGroup_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_OrganizationCulture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_OrganizationCulture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_OrganizationCulture_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Link_OrganizationCulture_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_LinkLifeTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_LinkLifeTime", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_LinkLifeTime_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Notification_Cb_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "Cb_NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(name: "FK_Edu_Notification_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_Notification_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_UserCertificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserCertificate", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_UserCertificate_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "System_ObjectHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_ObjectHistory", x => x.Id);
                    table.ForeignKey(name: "FK_System_ObjectHistory_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_BankOfQuestionTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankOfQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_BankOfQuestionTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_BankOfQuestionTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_BankOfQuestionTranslation_Edu_BankOfQuestion_BankOfQuestionId",
                        column: x => x.BankOfQuestionId,
                        principalTable: "Edu_BankOfQuestion",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    AnswerModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankOfQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestion_Cb_AnswerMode_AnswerModeId",
                        column: x => x.AnswerModeId,
                        principalTable: "Cb_AnswerMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestion_Cb_QuestionMode_QuestionModeId",
                        column: x => x.QuestionModeId,
                        principalTable: "Cb_QuestionMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_TestQuestion_Edu_BankOfQuestion_BankOfQuestionId", column: x => x.BankOfQuestionId, principalTable: "Edu_BankOfQuestion", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_TestBankOfQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankOfQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_TestBankOfQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_TestBankOfQuestion_Edu_BankOfQuestion_BankOfQuestionId",
                        column: x => x.BankOfQuestionId,
                        principalTable: "Edu_BankOfQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Link_TestBankOfQuestion_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_BranchTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_BranchTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_BranchTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_BranchTranslation_Edu_Branch_BranchId", column: x => x.BranchId, principalTable: "Edu_Branch", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_ClassRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_ClassRoom", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_ClassRoom_Edu_Branch_BranchId", column: x => x.BranchId, principalTable: "Edu_Branch", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CertificateTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CertificateTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CertificateTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_CertificateTranslation_Edu_Certificate_CertificateId", column: x => x.CertificateId, principalTable: "Edu_Certificate", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerPointFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLesson", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_CourseLesson_Edu_CourseMaterial_CourseMaterialId", column: x => x.CourseMaterialId, principalTable: "Edu_CourseMaterial", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_CourseLesson_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseMaterialTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseMaterialTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterialTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterialTranslation_Edu_CourseMaterial_CourseMaterialId",
                        column: x => x.CourseMaterialId,
                        principalTable: "Edu_CourseMaterial",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrivateCourse = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    MinimumStudent = table.Column<int>(type: "int", nullable: false),
                    MaximumStudent = table.Column<int>(type: "int", nullable: false),
                    AutomaticGenerateCertificate = table.Column<bool>(type: "bit", nullable: false),
                    SendEmail = table.Column<bool>(type: "bit", nullable: false),
                    CourseWithLector = table.Column<bool>(type: "bit", nullable: false),
                    CourseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SendMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Course_Cb_CourseStatus_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "Cb_CourseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_Course_Cb_CourseType_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "Cb_CourseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_Course_Edu_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Edu_Certificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_Course_Edu_CourseMaterial_CourseMaterialId", column: x => x.CourseMaterialId, principalTable: "Edu_CourseMaterial", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_Course_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_Course_Edu_SendMessage_SendMessageId",
                        column: x => x.SendMessageId,
                        principalTable: "Edu_SendMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_SendMessageTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_SendMessageTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_SendMessageTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_SendMessageTranslation_Edu_SendMessage_SendMessageId",
                        column: x => x.SendMessageId,
                        principalTable: "Edu_SendMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentGroupTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentGroupTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroupTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroupTranslation_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_UserInOrganization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupDboId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_UserInOrganization", x => x.Id);
                    table.ForeignKey(name: "FK_Link_UserInOrganization_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_UserInOrganization_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Link_UserInOrganization_Edu_StudentGroup_StudentGroupDboId",
                        column: x => x.StudentGroupDboId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(name: "FK_Link_UserInOrganization_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsTrueAnswer = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileRepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId",
                        column: x => x.FileRepositoryId,
                        principalTable: "Edu_FileRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionAnswer_Edu_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "Edu_TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestionTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestionTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionTranslation_Edu_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "Edu_TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_ClassRoomTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_ClassRoomTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_ClassRoomTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_ClassRoomTranslation_Edu_ClassRoom_ClassRoomId", column: x => x.ClassRoomId, principalTable: "Edu_ClassRoom", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLessonItemTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLessonItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItem_Cb_CourseLessonItemTemplate_CourseLessonItemTemplateId",
                        column: x => x.CourseLessonItemTemplateId,
                        principalTable: "Cb_CourseLessonItemTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_CourseLessonItem_Edu_CourseLesson_CourseLessonId", column: x => x.CourseLessonId, principalTable: "Edu_CourseLesson", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLessonTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_CourseLessonTranslation_Edu_CourseLesson_CourseLessonId", column: x => x.CourseLessonId, principalTable: "Edu_CourseLesson", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    MinimumStudent = table.Column<int>(type: "int", nullable: false),
                    MaximumStudent = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    TimeFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationStudyHourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTerm", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_CourseTerm_Cb_TimeTable_TimeFromId", column: x => x.TimeFromId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_CourseTerm_Cb_TimeTable_TimeToId", column: x => x.TimeToId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Edu_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "Edu_ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_CourseTerm_Edu_Course_CourseId", column: x => x.CourseId, principalTable: "Edu_Course", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId",
                        column: x => x.OrganizationStudyHourId,
                        principalTable: "Edu_OrganizationStudyHour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_CourseTranslation_Edu_Course_CourseId", column: x => x.CourseId, principalTable: "Edu_Course", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Note", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_Note_Cb_NoteType_NoteTypeId", column: x => x.NoteTypeId, principalTable: "Cb_NoteType", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(name: "FK_Edu_Note_Edu_Course_CourseId", column: x => x.CourseId, principalTable: "Edu_Course", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_Note_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAutomaticEvaluate = table.Column<bool>(type: "bit", nullable: false),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummary_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummary_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_StudentTestSummary_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_StudentInGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_StudentInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroup_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroup_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_TestQuestionAnswerTanslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestQuestionAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestQuestionAnswerTanslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionAnswerTanslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_TestQuestionAnswerTanslation_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                        column: x => x.TestQuestionAnswerId,
                        principalTable: "Edu_TestQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonItemTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLessonItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseLessonItemTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItemTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItemTranslation_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_CourseBrowse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseBrowse", x => x.Id);
                    table.ForeignKey(name: "FK_Link_CourseBrowse_Edu_Course_CourseId", column: x => x.CourseId, principalTable: "Edu_Course", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_CourseBrowse_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(name: "FK_Link_CourseBrowse_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_CouseStudentMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CouseStudentMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_CouseStudentMaterial_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Link_CouseStudentMaterial_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Link_CouseStudentMaterial_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_CourseTermDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTermDate", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeFromId", column: x => x.TimeFromId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeToId", column: x => x.TimeToId, principalTable: "Cb_TimeTable", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_CourseTermDate_Edu_ClassRoom_ClassRoomId", column: x => x.ClassRoomId, principalTable: "Edu_ClassRoom", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_CourseTermDate_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_CourseTermDate_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Chat", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_Chat_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(name: "FK_Edu_Chat_Edu_User_UserId", column: x => x.UserId, principalTable: "Edu_User", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_CourseLector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseLector", x => x.Id);
                    table.ForeignKey(name: "FK_Link_CourseLector_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_CourseLector_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_CourseStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseFinish = table.Column<bool>(type: "bit", nullable: false),
                    UserInOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseStudent", x => x.Id);
                    table.ForeignKey(name: "FK_Link_CourseStudent_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_CourseStudent_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Link_StudentInGroupCourseTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_StudentInGroupCourseTerm", x => x.Id);
                    table.ForeignKey(name: "FK_Link_StudentInGroupCourseTerm_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroupCourseTerm_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummaryQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    IsAutomaticEvaluate = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionModeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentTestSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummaryQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Cb_AnswerMode_AnswerModeId",
                        column: x => x.AnswerModeId,
                        principalTable: "Cb_AnswerMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Cb_QuestionMode_QuestionModeId",
                        column: x => x.QuestionModeId,
                        principalTable: "Cb_QuestionMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Edu_StudentTestSummary_StudentTestSummaryId",
                        column: x => x.StudentTestSummaryId,
                        principalTable: "Edu_StudentTestSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Edu_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "Edu_TestQuestion",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_TestUserAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentTestSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestQuestionAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestUserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestUserAnswer_Edu_StudentTestSummary_StudentTestSummaryId",
                        column: x => x.StudentTestSummaryId,
                        principalTable: "Edu_StudentTestSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_TestUserAnswer_Edu_TestQuestion_TestQuestionId", column: x => x.TestQuestionId, principalTable: "Edu_TestQuestion", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_TestUserAnswer_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                        column: x => x.TestQuestionAnswerId,
                        principalTable: "Edu_TestQuestionAnswer",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_AttendanceStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_AttendanceStudent", x => x.Id);
                    table.ForeignKey(name: "FK_Edu_AttendanceStudent_Edu_CourseTerm_CourseTermId", column: x => x.CourseTermId, principalTable: "Edu_CourseTerm", principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edu_AttendanceStudent_Edu_CourseTermDate_CourseTermDateId",
                        column: x => x.CourseTermDateId,
                        principalTable: "Edu_CourseTermDate",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Edu_AttendanceStudent_Link_CourseStudent_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Link_CourseStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentEvaluation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                        column: x => x.CourseTermId,
                        principalTable: "Edu_CourseTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentEvaluation_Link_CourseStudent_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Link_CourseStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummaryAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrueAnswer = table.Column<bool>(type: "bit", nullable: false),
                    UserTestAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAnswer = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    UserAnswerIsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTestImageAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestQuestionAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentTestSummaryQuestionDboId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummaryAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionDboId",
                        column: x => x.StudentTestSummaryQuestionDboId,
                        principalTable: "Edu_StudentTestSummaryQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryAnswer_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                        column: x => x.TestQuestionAnswerId,
                        principalTable: "Edu_TestQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cb_AddressType_SystemIdentificator",
                table: "Cb_AddressType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Cb_Country_SystemIdentificator", table: "Cb_Country", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseLessonItemTemplate_SystemIdentificator",
                table: "Cb_CourseLessonItemTemplate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseStatus_SystemIdentificator",
                table: "Cb_CourseStatus",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseType_SystemIdentificator",
                table: "Cb_CourseType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Cb_Culture_SystemIdentificator", table: "Cb_Culture", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Cb_Email_SystemIdentificator", table: "Cb_Email", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_GalleryItemType_SystemIdentificator",
                table: "Cb_GalleryItemType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Cb_License_SystemIdentificator", table: "Cb_License", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Cb_NoteType_SystemIdentificator", table: "Cb_NoteType", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_NotificationType_SystemIdentificator",
                table: "Cb_NotificationType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cb_QuestionMode_SystemIdentificator",
                table: "Cb_QuestionMode",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cb_SendMessageType_SystemIdentificator",
                table: "Cb_SendMessageType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Cb_TimeTable_SystemIdentificator", table: "Cb_TimeTable", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_AttendanceStudent_CourseStudentId", table: "Edu_AttendanceStudent", column: "CourseStudentId");

            migrationBuilder.CreateIndex(name: "IX_Edu_AttendanceStudent_CourseTermDateId", table: "Edu_AttendanceStudent", column: "CourseTermDateId");

            migrationBuilder.CreateIndex(name: "IX_Edu_AttendanceStudent_CourseTermId", table: "Edu_AttendanceStudent", column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AttendanceStudent_SystemIdentificator",
                table: "Edu_AttendanceStudent",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_BankOfQuestion_OrganizationId", table: "Edu_BankOfQuestion", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_BankOfQuestion_SystemIdentificator",
                table: "Edu_BankOfQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_BankOfQuestionTranslation_BankOfQuestionId", table: "Edu_BankOfQuestionTranslation", column: "BankOfQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_BankOfQuestionTranslation_CultureId", table: "Edu_BankOfQuestionTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_BankOfQuestionTranslation_SystemIdentificator",
                table: "Edu_BankOfQuestionTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Branch_CountryId", table: "Edu_Branch", column: "CountryId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Branch_OrganizationId", table: "Edu_Branch", column: "OrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Branch_SystemIdentificator", table: "Edu_Branch", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_BranchTranslation_BranchId", table: "Edu_BranchTranslation", column: "BranchId");

            migrationBuilder.CreateIndex(name: "IX_Edu_BranchTranslation_CultureId", table: "Edu_BranchTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_BranchTranslation_SystemIdentificator",
                table: "Edu_BranchTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Certificate_OrganizationId", table: "Edu_Certificate", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Certificate_SystemIdentificator",
                table: "Edu_Certificate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CertificateTranslation_CertificateId", table: "Edu_CertificateTranslation", column: "CertificateId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CertificateTranslation_CultureId", table: "Edu_CertificateTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CertificateTranslation_SystemIdentificator",
                table: "Edu_CertificateTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_ClassRoom_BranchId", table: "Edu_ClassRoom", column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoom_SystemIdentificator",
                table: "Edu_ClassRoom",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_ClassRoomTranslation_ClassRoomId", table: "Edu_ClassRoomTranslation", column: "ClassRoomId");

            migrationBuilder.CreateIndex(name: "IX_Edu_ClassRoomTranslation_CultureId", table: "Edu_ClassRoomTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoomTranslation_SystemIdentificator",
                table: "Edu_ClassRoomTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_CertificateId", table: "Edu_Course", column: "CertificateId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_CourseMaterialId", table: "Edu_Course", column: "CourseMaterialId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_CourseStatusId", table: "Edu_Course", column: "CourseStatusId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_CourseTypeId", table: "Edu_Course", column: "CourseTypeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_OrganizationId", table: "Edu_Course", column: "OrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_SendMessageId", table: "Edu_Course", column: "SendMessageId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Course_SystemIdentificator", table: "Edu_Course", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLesson_CourseMaterialId", table: "Edu_CourseLesson", column: "CourseMaterialId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLesson_CourseTestId", table: "Edu_CourseLesson", column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLesson_SystemIdentificator",
                table: "Edu_CourseLesson",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItem_CourseLessonId", table: "Edu_CourseLessonItem", column: "CourseLessonId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItem_CourseLessonItemTemplateId", table: "Edu_CourseLessonItem", column: "CourseLessonItemTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItem_SystemIdentificator",
                table: "Edu_CourseLessonItem",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItemTranslation_CourseLessonItemId", table: "Edu_CourseLessonItemTranslation", column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItemTranslation_CultureId", table: "Edu_CourseLessonItemTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItemTranslation_SystemIdentificator",
                table: "Edu_CourseLessonItemTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonTranslation_CourseLessonId", table: "Edu_CourseLessonTranslation", column: "CourseLessonId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonTranslation_CultureId", table: "Edu_CourseLessonTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonTranslation_SystemIdentificator",
                table: "Edu_CourseLessonTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseMaterial_OrganizationId", table: "Edu_CourseMaterial", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseMaterial_SystemIdentificator",
                table: "Edu_CourseMaterial",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseMaterialTranslation_CourseMaterialId", table: "Edu_CourseMaterialTranslation", column: "CourseMaterialId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseMaterialTranslation_CultureId", table: "Edu_CourseMaterialTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseMaterialTranslation_SystemIdentificator",
                table: "Edu_CourseMaterialTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_ClassRoomId", table: "Edu_CourseTerm", column: "ClassRoomId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_CourseId", table: "Edu_CourseTerm", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_OrganizationStudyHourId", table: "Edu_CourseTerm", column: "OrganizationStudyHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_SystemIdentificator",
                table: "Edu_CourseTerm",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeFromId", table: "Edu_CourseTerm", column: "TimeFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeToId", table: "Edu_CourseTerm", column: "TimeToId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_ClassRoomId", table: "Edu_CourseTermDate", column: "ClassRoomId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_CourseTermId", table: "Edu_CourseTermDate", column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_SystemIdentificator",
                table: "Edu_CourseTermDate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeFromId", table: "Edu_CourseTermDate", column: "TimeFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeToId", table: "Edu_CourseTermDate", column: "TimeToId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_UserInOrganizationId", table: "Edu_CourseTermDate", column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_SystemIdentificator",
                table: "Edu_CourseTest",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTestEvaluation_CourseTestId", table: "Edu_CourseTestEvaluation", column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTestEvaluation_SystemIdentificator",
                table: "Edu_CourseTestEvaluation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTranslation_CourseId", table: "Edu_CourseTranslation", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTranslation_CultureId", table: "Edu_CourseTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTranslation_SystemIdentificator",
                table: "Edu_CourseTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_FileRepository_SystemIdentificator",
                table: "Edu_FileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Chat_CourseTermId", table: "Edu_Chat", column: "CourseTermId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Chat_SystemIdentificator", table: "Edu_Chat", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_Chat_UserId", table: "Edu_Chat", column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LinkLifeTime_SystemIdentificator",
                table: "Edu_LinkLifeTime",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_LinkLifeTime_UserId", table: "Edu_LinkLifeTime", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Note_CourseId", table: "Edu_Note", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Note_NoteTypeId", table: "Edu_Note", column: "NoteTypeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Note_SystemIdentificator", table: "Edu_Note", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_Note_UserId", table: "Edu_Note", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Notification_NotificationTypeId", table: "Edu_Notification", column: "NotificationTypeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Notification_OrganizationId", table: "Edu_Notification", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Notification_SystemIdentificator",
                table: "Edu_Notification",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Notification_UserId", table: "Edu_Notification", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Edu_Organization_LicenseId", table: "Edu_Organization", column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_SystemIdentificator",
                table: "Edu_Organization",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationAddress_AddressTypeId", table: "Edu_OrganizationAddress", column: "AddressTypeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationAddress_CountryId", table: "Edu_OrganizationAddress", column: "CountryId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationAddress_OrganizationId", table: "Edu_OrganizationAddress", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationAddress_SystemIdentificator",
                table: "Edu_OrganizationAddress",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRole_SystemIdentificator",
                table: "Edu_OrganizationRole",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationRolePermition_OrganizationRoleId", table: "Edu_OrganizationRolePermition", column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRolePermition_SystemIdentificator",
                table: "Edu_OrganizationRolePermition",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationRoleTranslation_CultureId", table: "Edu_OrganizationRoleTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationRoleTranslation_OrganizationRoleId", table: "Edu_OrganizationRoleTranslation", column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRoleTranslation_SystemIdentificator",
                table: "Edu_OrganizationRoleTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationSetting_LicenseOldId", table: "Edu_OrganizationSetting", column: "LicenseOldId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationSetting_OrganizationId", table: "Edu_OrganizationSetting", column: "OrganizationId", unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationSetting_SystemIdentificator",
                table: "Edu_OrganizationSetting",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveFromId", table: "Edu_OrganizationStudyHour", column: "ActiveFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveToId", table: "Edu_OrganizationStudyHour", column: "ActiveToId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_OrganizationId", table: "Edu_OrganizationStudyHour", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationStudyHour_SystemIdentificator",
                table: "Edu_OrganizationStudyHour",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationTranslation_CultureId", table: "Edu_OrganizationTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationTranslation_OrganizationId", table: "Edu_OrganizationTranslation", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationTranslation_SystemIdentificator",
                table: "Edu_OrganizationTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_Person_SystemIdentificator", table: "Edu_Person", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_PersonAddress_AddressTypeId", table: "Edu_PersonAddress", column: "AddressTypeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_PersonAddress_CountryId", table: "Edu_PersonAddress", column: "CountryId");

            migrationBuilder.CreateIndex(name: "IX_Edu_PersonAddress_PersonId", table: "Edu_PersonAddress", column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_PersonAddress_SystemIdentificator",
                table: "Edu_PersonAddress",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_SendMessage_OrganizationId", table: "Edu_SendMessage", column: "OrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Edu_SendMessage_SendMessageTypeId", table: "Edu_SendMessage", column: "SendMessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessage_SystemIdentificator",
                table: "Edu_SendMessage",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_SendMessageTranslation_CultureId", table: "Edu_SendMessageTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Edu_SendMessageTranslation_SendMessageId", table: "Edu_SendMessageTranslation", column: "SendMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessageTranslation_SystemIdentificator",
                table: "Edu_SendMessageTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentEvaluation_CourseStudentId", table: "Edu_StudentEvaluation", column: "CourseStudentId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentEvaluation_CourseTermId", table: "Edu_StudentEvaluation", column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentEvaluation_SystemIdentificator",
                table: "Edu_StudentEvaluation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentGroup_OrganizationId", table: "Edu_StudentGroup", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroup_SystemIdentificator",
                table: "Edu_StudentGroup",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentGroupTranslation_CultureId", table: "Edu_StudentGroupTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentGroupTranslation_StudentGroupId", table: "Edu_StudentGroupTranslation", column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroupTranslation_SystemIdentificator",
                table: "Edu_StudentGroupTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummary_CourseId", table: "Edu_StudentTestSummary", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummary_CourseTestId", table: "Edu_StudentTestSummary", column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_SystemIdentificator",
                table: "Edu_StudentTestSummary",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummary_UserId", table: "Edu_StudentTestSummary", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionDboId", table: "Edu_StudentTestSummaryAnswer", column: "StudentTestSummaryQuestionDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_SystemIdentificator",
                table: "Edu_StudentTestSummaryAnswer",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryAnswer_TestQuestionAnswerId", table: "Edu_StudentTestSummaryAnswer", column: "TestQuestionAnswerId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryQuestion_AnswerModeId", table: "Edu_StudentTestSummaryQuestion", column: "AnswerModeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryQuestion_QuestionModeId", table: "Edu_StudentTestSummaryQuestion", column: "QuestionModeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryQuestion_StudentTestSummaryId", table: "Edu_StudentTestSummaryQuestion", column: "StudentTestSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_SystemIdentificator",
                table: "Edu_StudentTestSummaryQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentTestSummaryQuestion_TestQuestionId", table: "Edu_StudentTestSummaryQuestion", column: "TestQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestion_AnswerModeId", table: "Edu_TestQuestion", column: "AnswerModeId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestion_BankOfQuestionId", table: "Edu_TestQuestion", column: "BankOfQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestion_QuestionModeId", table: "Edu_TestQuestion", column: "QuestionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_SystemIdentificator",
                table: "Edu_TestQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionAnswer_FileRepositoryId", table: "Edu_TestQuestionAnswer", column: "FileRepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestionAnswer_SystemIdentificator",
                table: "Edu_TestQuestionAnswer",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionAnswer_TestQuestionId", table: "Edu_TestQuestionAnswer", column: "TestQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionAnswerTanslation_CultureId", table: "Edu_TestQuestionAnswerTanslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestionAnswerTanslation_SystemIdentificator",
                table: "Edu_TestQuestionAnswerTanslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionAnswerTanslation_TestQuestionAnswerId", table: "Edu_TestQuestionAnswerTanslation", column: "TestQuestionAnswerId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionTranslation_CultureId", table: "Edu_TestQuestionTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestionTranslation_SystemIdentificator",
                table: "Edu_TestQuestionTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionTranslation_TestQuestionId", table: "Edu_TestQuestionTranslation", column: "TestQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestUserAnswer_StudentTestSummaryId", table: "Edu_TestUserAnswer", column: "StudentTestSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestUserAnswer_SystemIdentificator",
                table: "Edu_TestUserAnswer",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestUserAnswer_TestQuestionAnswerId", table: "Edu_TestUserAnswer", column: "TestQuestionAnswerId");

            migrationBuilder.CreateIndex(name: "IX_Edu_TestUserAnswer_TestQuestionId", table: "Edu_TestUserAnswer", column: "TestQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Edu_User_PersonId", table: "Edu_User", column: "PersonId");

            migrationBuilder.CreateIndex(name: "IX_Edu_User_SystemIdentificator", table: "Edu_User", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_User_UserEmail", table: "Edu_User", column: "UserEmail", unique: true, filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_User_UserRoleId", table: "Edu_User", column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_SystemIdentificator",
                table: "Edu_UserCertificate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_UserCertificate_UserId", table: "Edu_UserCertificate", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Edu_UserRole_SystemIdentificator", table: "Edu_UserRole", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Edu_UserRoleTranslation_CultureId", table: "Edu_UserRoleTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRoleTranslation_SystemIdentificator",
                table: "Edu_UserRoleTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_UserRoleTranslation_UserRoleId", table: "Edu_UserRoleTranslation", column: "UserRoleId");

            migrationBuilder.CreateIndex(name: "IX_Link_CourseBrowse_CourseId", table: "Link_CourseBrowse", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Link_CourseBrowse_CourseLessonItemId", table: "Link_CourseBrowse", column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseBrowse_SystemIdentificator",
                table: "Link_CourseBrowse",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_CourseBrowse_UserId", table: "Link_CourseBrowse", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Link_CourseLector_CourseTermId", table: "Link_CourseLector", column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseLector_SystemIdentificator",
                table: "Link_CourseLector",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_CourseLector_UserInOrganizationId", table: "Link_CourseLector", column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Link_CourseStudent_CourseTermId", table: "Link_CourseStudent", column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseStudent_SystemIdentificator",
                table: "Link_CourseStudent",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_CourseStudent_UserInOrganizationId", table: "Link_CourseStudent", column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Link_CouseStudentMaterial_CourseId", table: "Link_CouseStudentMaterial", column: "CourseId");

            migrationBuilder.CreateIndex(name: "IX_Link_CouseStudentMaterial_CourseLessonItemId", table: "Link_CouseStudentMaterial", column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_SystemIdentificator",
                table: "Link_CouseStudentMaterial",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_CouseStudentMaterial_UserId", table: "Link_CouseStudentMaterial", column: "UserId");

            migrationBuilder.CreateIndex(name: "IX_Link_OrganizationCulture_CultureId", table: "Link_OrganizationCulture", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Link_OrganizationCulture_OrganizationId", table: "Link_OrganizationCulture", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrganizationCulture_SystemIdentificator",
                table: "Link_OrganizationCulture",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_StudentInGroup_StudentGroupId", table: "Link_StudentInGroup", column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroup_SystemIdentificator",
                table: "Link_StudentInGroup",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_StudentInGroup_UserInOrganizationId", table: "Link_StudentInGroup", column: "UserInOrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Link_StudentInGroupCourseTerm_CourseTermId", table: "Link_StudentInGroupCourseTerm", column: "CourseTermId");

            migrationBuilder.CreateIndex(name: "IX_Link_StudentInGroupCourseTerm_StudentGroupId", table: "Link_StudentInGroupCourseTerm", column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroupCourseTerm_SystemIdentificator",
                table: "Link_StudentInGroupCourseTerm",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_TestBankOfQuestion_BankOfQuestionId", table: "Link_TestBankOfQuestion", column: "BankOfQuestionId");

            migrationBuilder.CreateIndex(name: "IX_Link_TestBankOfQuestion_CourseTestId", table: "Link_TestBankOfQuestion", column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_TestBankOfQuestion_SystemIdentificator",
                table: "Link_TestBankOfQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_UserInOrganization_OrganizationId", table: "Link_UserInOrganization", column: "OrganizationId");

            migrationBuilder.CreateIndex(name: "IX_Link_UserInOrganization_OrganizationRoleId", table: "Link_UserInOrganization", column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(name: "IX_Link_UserInOrganization_StudentGroupDboId", table: "Link_UserInOrganization", column: "StudentGroupDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserInOrganization_SystemIdentificator",
                table: "Link_UserInOrganization",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Link_UserInOrganization_UserId", table: "Link_UserInOrganization", column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_System_ObjectHistory_SystemIdentificator",
                table: "System_ObjectHistory",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_System_ObjectHistory_UserId", table: "System_ObjectHistory", column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Cb_Email");

            migrationBuilder.DropTable(name: "Cb_GalleryItemType");

            migrationBuilder.DropTable(name: "Edu_AttendanceStudent");

            migrationBuilder.DropTable(name: "Edu_BankOfQuestionTranslation");

            migrationBuilder.DropTable(name: "Edu_BranchTranslation");

            migrationBuilder.DropTable(name: "Edu_CertificateTranslation");

            migrationBuilder.DropTable(name: "Edu_ClassRoomTranslation");

            migrationBuilder.DropTable(name: "Edu_CourseLessonItemTranslation");

            migrationBuilder.DropTable(name: "Edu_CourseLessonTranslation");

            migrationBuilder.DropTable(name: "Edu_CourseMaterialTranslation");

            migrationBuilder.DropTable(name: "Edu_CourseTestEvaluation");

            migrationBuilder.DropTable(name: "Edu_CourseTranslation");

            migrationBuilder.DropTable(name: "Edu_Chat");

            migrationBuilder.DropTable(name: "Edu_LinkLifeTime");

            migrationBuilder.DropTable(name: "Edu_Note");

            migrationBuilder.DropTable(name: "Edu_Notification");

            migrationBuilder.DropTable(name: "Edu_OrganizationAddress");

            migrationBuilder.DropTable(name: "Edu_OrganizationRolePermition");

            migrationBuilder.DropTable(name: "Edu_OrganizationRoleTranslation");

            migrationBuilder.DropTable(name: "Edu_OrganizationSetting");

            migrationBuilder.DropTable(name: "Edu_OrganizationTranslation");

            migrationBuilder.DropTable(name: "Edu_PersonAddress");

            migrationBuilder.DropTable(name: "Edu_SendMessageTranslation");

            migrationBuilder.DropTable(name: "Edu_StudentEvaluation");

            migrationBuilder.DropTable(name: "Edu_StudentGroupTranslation");

            migrationBuilder.DropTable(name: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropTable(name: "Edu_TestQuestionAnswerTanslation");

            migrationBuilder.DropTable(name: "Edu_TestQuestionTranslation");

            migrationBuilder.DropTable(name: "Edu_TestUserAnswer");

            migrationBuilder.DropTable(name: "Edu_UserCertificate");

            migrationBuilder.DropTable(name: "Edu_UserRoleTranslation");

            migrationBuilder.DropTable(name: "Link_CourseBrowse");

            migrationBuilder.DropTable(name: "Link_CourseLector");

            migrationBuilder.DropTable(name: "Link_CouseStudentMaterial");

            migrationBuilder.DropTable(name: "Link_OrganizationCulture");

            migrationBuilder.DropTable(name: "Link_StudentInGroup");

            migrationBuilder.DropTable(name: "Link_StudentInGroupCourseTerm");

            migrationBuilder.DropTable(name: "Link_TestBankOfQuestion");

            migrationBuilder.DropTable(name: "System_ObjectHistory");

            migrationBuilder.DropTable(name: "Edu_CourseTermDate");

            migrationBuilder.DropTable(name: "Cb_NoteType");

            migrationBuilder.DropTable(name: "Cb_NotificationType");

            migrationBuilder.DropTable(name: "Cb_AddressType");

            migrationBuilder.DropTable(name: "Link_CourseStudent");

            migrationBuilder.DropTable(name: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropTable(name: "Edu_TestQuestionAnswer");

            migrationBuilder.DropTable(name: "Edu_CourseLessonItem");

            migrationBuilder.DropTable(name: "Cb_Culture");

            migrationBuilder.DropTable(name: "Edu_CourseTerm");

            migrationBuilder.DropTable(name: "Link_UserInOrganization");

            migrationBuilder.DropTable(name: "Edu_StudentTestSummary");

            migrationBuilder.DropTable(name: "Edu_FileRepository");

            migrationBuilder.DropTable(name: "Edu_TestQuestion");

            migrationBuilder.DropTable(name: "Cb_CourseLessonItemTemplate");

            migrationBuilder.DropTable(name: "Edu_CourseLesson");

            migrationBuilder.DropTable(name: "Edu_ClassRoom");

            migrationBuilder.DropTable(name: "Edu_OrganizationStudyHour");

            migrationBuilder.DropTable(name: "Edu_OrganizationRole");

            migrationBuilder.DropTable(name: "Edu_StudentGroup");

            migrationBuilder.DropTable(name: "Edu_Course");

            migrationBuilder.DropTable(name: "Edu_User");

            migrationBuilder.DropTable(name: "Cb_AnswerMode");

            migrationBuilder.DropTable(name: "Cb_QuestionMode");

            migrationBuilder.DropTable(name: "Edu_BankOfQuestion");

            migrationBuilder.DropTable(name: "Edu_CourseTest");

            migrationBuilder.DropTable(name: "Edu_Branch");

            migrationBuilder.DropTable(name: "Cb_TimeTable");

            migrationBuilder.DropTable(name: "Cb_CourseStatus");

            migrationBuilder.DropTable(name: "Cb_CourseType");

            migrationBuilder.DropTable(name: "Edu_Certificate");

            migrationBuilder.DropTable(name: "Edu_CourseMaterial");

            migrationBuilder.DropTable(name: "Edu_SendMessage");

            migrationBuilder.DropTable(name: "Edu_Person");

            migrationBuilder.DropTable(name: "Edu_UserRole");

            migrationBuilder.DropTable(name: "Cb_Country");

            migrationBuilder.DropTable(name: "Cb_SendMessageType");

            migrationBuilder.DropTable(name: "Edu_Organization");

            migrationBuilder.DropTable(name: "Cb_License");
        }
    }
}
