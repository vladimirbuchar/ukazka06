using Microsoft.EntityFrameworkCore;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Answer;
using Model.Tables.Edu.AttendanceStudent;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.Certificate;
using Model.Tables.Edu.Chat;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseLesson;
using Model.Tables.Edu.CourseLessonItem;
using Model.Tables.Edu.CourseMaterial;
using Model.Tables.Edu.CourseTable;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Edu.CourseTermDate;
using Model.Tables.Edu.CourseTest;
using Model.Tables.Edu.CourseTestEvaluation;
using Model.Tables.Edu.LicenseChange;
using Model.Tables.Edu.LinkLifeTime;
using Model.Tables.Edu.Note;
using Model.Tables.Edu.Notification;
using Model.Tables.Edu.Organization;
using Model.Tables.Edu.OrganizationAddress;
using Model.Tables.Edu.OrganizationRole;
using Model.Tables.Edu.OrganizationRolePermition;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Edu.OrganizationStudyHour;
using Model.Tables.Edu.Person;
using Model.Tables.Edu.PersonAddress;
using Model.Tables.Edu.SendMessage;
using Model.Tables.Edu.StudentEvaluation;
using Model.Tables.Edu.StudentGroup;
using Model.Tables.Edu.StudentTestSummary;
using Model.Tables.Edu.StudentTestSummaryAnswer;
using Model.Tables.Edu.StudentTestSummaryQuestion;
using Model.Tables.Edu.TestQuestion;
using Model.Tables.Edu.TestUserAnswer;
using Model.Tables.Edu.User;
using Model.Tables.Edu.UserCertificate;
using Model.Tables.Edu.UserRole;
using Model.Tables.Link;
using Model.Tables.System;

namespace Model
{
    public class EduDbContext : DbContext
    {
        public EduDbContext(DbContextOptions<EduDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.EnableSensitiveDataLogging();
            //_ = optionsBuilder.UseLazyLoadingProxies();
        }

        public EduDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetTableDefault<StudentAttendanceDbo>(modelBuilder);
            SetTableDefault<CourseDbo>(modelBuilder);
            SetTableDefault<CourseLessonItemDbo>(modelBuilder);
            SetTableDefault<CourseLectorDbo>(modelBuilder);
            SetTableDefault<CourseStudentDbo>(modelBuilder);
            SetTableDefault<CourseTermDbo>(modelBuilder);
            SetTableDefault<UserDbo>(modelBuilder);
            SetTableDefault<UserRoleDbo>(modelBuilder);
            SetTableDefault<CourseTestDbo>(modelBuilder);
            SetTableDefault<QuestionDbo>(modelBuilder);
            SetTableDefault<AnswerDbo>(modelBuilder);
            SetTableDefault<PersonDbo>(modelBuilder);
            SetTableDefault<OrganizationDbo>(modelBuilder);
            SetTableDefault<BranchDbo>(modelBuilder);
            SetTableDefault<ClassRoomDbo>(modelBuilder);
            SetTableDefault<LicenseDbo>(modelBuilder);
            SetTableDefault<CultureDbo>(modelBuilder);
            SetTableDefault<UserInOrganizationDbo>(modelBuilder);
            SetTableDefault<OrganizationRoleDbo>(modelBuilder);
            SetTableDefault<OrganizationRolePermitionDbo>(modelBuilder);
            SetTableDefault<StudentTestSummaryDbo>(modelBuilder);
            SetTableDefault<AddressTypeDbo>(modelBuilder);
            SetTableDefault<GalleryItemTypeDbo>(modelBuilder);
            SetTableDefault<ObjectHistoryDbo>(modelBuilder);
            SetTableDefault<CourseStatusDbo>(modelBuilder);
            SetTableDefault<CourseTypeDbo>(modelBuilder);
            SetTableDefault<TimeTableDbo>(modelBuilder);
            SetTableDefault<EduEmailDbo>(modelBuilder);
            SetTableDefault<CourseLessonItemTemplateDbo>(modelBuilder);
            SetTableDefault<AnswerFileRepositoryDbo>(modelBuilder);
            SetTableDefault<CourseTestBankOfQuestionDbo>(modelBuilder);
            SetTableDefault<CourseBrowseDbo>(modelBuilder);
            SetTableDefault<StudentTestSummaryAnswerDbo>(modelBuilder);
            SetTableDefault<StudentTestSummaryQuestionDbo>(modelBuilder);
            SetTableDefault<OrganizationSettingDbo>(modelBuilder);
            SetTableDefault<CouseStudentMaterialDbo>(modelBuilder);
            SetTableDefault<LinkLifeTimeDbo>(modelBuilder);
            SetTableDefault<CertificateDbo>(modelBuilder);
            SetTableDefault<OrganizationCultureDbo>(modelBuilder);
            SetTableDefault<UserCertificateDbo>(modelBuilder);
            SetTableDefault<CourseTermDateDbo>(modelBuilder);
            SetTableDefault<OrganizationStudyHourDbo>(modelBuilder);
            SetTableDefault<SendMessageTypeDbo>(modelBuilder);
            SetTableDefault<SendMessageDbo>(modelBuilder);
            SetTableDefault<StudentGroupDbo>(modelBuilder);
            SetTableDefault<StudentInGroupDbo>(modelBuilder);
            SetTableDefault<StudentInGroupCourseTermDbo>(modelBuilder);
            SetTableDefault<QuestionModeDbo>(modelBuilder);
            SetTableDefault<StudentEvaluationDbo>(modelBuilder);
            SetTableDefault<NoteDbo>(modelBuilder);
            SetTableDefault<NoteTypeDbo>(modelBuilder);
            SetTableDefault<ChatDbo>(modelBuilder);
            SetTableDefault<CourseTestEvaluationDbo>(modelBuilder);
            SetTableDefault<CountryDbo>(modelBuilder);
            SetTableDefault<NotificationTypeDbo>(modelBuilder);
            SetTableDefault<BankOfQuestionDbo>(modelBuilder);
            SetTableDefault<BankOfQuestionsTranslationDbo>(modelBuilder);
            SetTableDefault<BranchTranslationDbo>(modelBuilder);
            SetTableDefault<CertificateTranslationDbo>(modelBuilder);
            SetTableDefault<ClassRoomTranslationDbo>(modelBuilder);
            SetTableDefault<CourseTranslationDbo>(modelBuilder);
            SetTableDefault<CourseLessonDbo>(modelBuilder);
            SetTableDefault<CourseLessonTranslationDbo>(modelBuilder);
            SetTableDefault<CourseLessonItemTranslationDbo>(modelBuilder);
            SetTableDefault<CourseMaterialDbo>(modelBuilder);
            SetTableDefault<CourseMaterialTranslationDbo>(modelBuilder);
            SetTableDefault<NotificationDbo>(modelBuilder);
            SetTableDefault<OrganizationTranslationDbo>(modelBuilder);
            SetTableDefault<OrganizationAddressDbo>(modelBuilder);
            SetTableDefault<PersonAddressDbo>(modelBuilder);
            SetTableDefault<SendMessageTranslationDbo>(modelBuilder);
            SetTableDefault<StudentGroupTranslationDbo>(modelBuilder);
            SetTableDefault<QuestionTranslationDbo>(modelBuilder);
            SetTableDefault<AnswerTanslationDbo>(modelBuilder);
            SetTableDefault<TestUserAnswerDbo>(modelBuilder);
            SetTableDefault<CourseTableDbo>(modelBuilder);
            SetTableDefault<LicenseChangeDbo>(modelBuilder);
            SetTableDefault<QuestionFileRepositoryDbo>(modelBuilder);
            SetTableDefault<OrganizationFileRepositoryDbo>(modelBuilder);
            SetTableDefault<CourseMaterialFileRepositoryDbo>(modelBuilder);
            SetTableDefault<CourseLessonFileRepositoryDbo>(modelBuilder);
            SetTableDefault<CourseLessonItemFileRepositoryDbo>(modelBuilder);
            SetTableDefault<RouteDbo>(modelBuilder);
            SetTableDefault<PermissionsDbo>(modelBuilder);
            //
            _ = modelBuilder.Entity<UserDbo>().HasIndex(u => u.UserEmail).IsUnique();
            /*_ = modelBuilder.Entity<EduEmailDbo>().Property(x => x.IsHtml).HasDefaultValue(false);
            _ = modelBuilder.Entity<LicenseDbo>().Property(x => x.OneYearSale).HasDefaultValue(0);
            _ = modelBuilder.Entity<LicenseDbo>().Property(x => x.SendCourseInquiry).HasDefaultValue(false);9
            _ = modelBuilder.Entity<UserDbo>().Property(x => x.IsActive).HasDefaultValue(false);*/
            _ = modelBuilder.Entity<OrganizationSettingDbo>().Property(x => x.ElearningUrl).IsRequired();

            _ = modelBuilder.Entity<BankOfQuestionDbo>().HasMany(x => x.BankOfQuestionsTranslations).WithOne(y => y.BankOfQuestion).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<BankOfQuestionDbo>().HasMany(x => x.TestQuestions).WithOne(y => y.BankOfQuestion).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<BranchDbo>().HasMany(x => x.BranchTranslations).WithOne(y => y.Branch).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<BranchDbo>().HasMany(x => x.ClassRoom).WithOne(y => y.Branch).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CertificateDbo>().HasMany(x => x.CertificateTranslations).WithOne(y => y.Certificate).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<ClassRoomDbo>().HasMany(x => x.ClassRoomTranslations).WithOne(y => y.ClassRoom).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<ClassRoomDbo>().HasMany(x => x.CourseTermDates).WithOne(y => y.ClassRoom).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseDbo>().HasMany(x => x.CourseTranslations).WithOne(y => y.Course).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseDbo>().HasMany(x => x.CourseTerm).WithOne(y => y.Course).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseDbo>().HasMany(x => x.CourseBrowses).WithOne(y => y.Course).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseDbo>().HasMany(x => x.Notes).WithOne(y => y.Course).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseLessonDbo>().HasMany(x => x.CourseItem).WithOne(y => y.CourseLesson).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseLessonDbo>().HasMany(x => x.CourseLessonTranslations).WithOne(y => y.CourseLesson).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTestDbo>().HasOne(x => x.CourseLesson).WithOne(y => y.CourseTest).HasForeignKey<CourseLessonDbo>(x => x.CourseTestId);

            _ = modelBuilder.Entity<CourseLessonItemDbo>().HasMany(x => x.CourseLessonItemTranslations).WithOne(y => y.CourseLessonItem).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseLessonItemDbo>().HasMany(x => x.CourseBrowses).WithOne(y => y.CourseLessonItem).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseMaterialDbo>().HasMany(x => x.CourseMaterialTranslation).WithOne(y => y.CourseMaterial).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseMaterialDbo>().HasMany(x => x.CourseLessons).WithOne(y => y.CourseMaterial).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.AttendanceStudents).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.CourseTermDate).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.StudentInGroupCourseTerms).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.CourseLectors).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.CourseStudents).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseTermDbo>().HasMany(x => x.Chats).WithOne(y => y.CourseTerm).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseTermDateDbo>().HasMany(x => x.AttendanceStudents).WithOne(y => y.CourseTermDate).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<CourseTestDbo>().HasMany(x => x.CourseTestEvaluations).WithOne(y => y.CourseTest).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.OrganizationTranslations).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            ;
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.LicenseChanges).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            ;
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.Branch).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.Course).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.BankOfQuestions).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.Addresses).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.Certificates).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.OrganizationStudyHours).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.SendMessages).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.StudentGroups).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.CourseMaterials).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.UserInOrganizations).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<OrganizationDbo>().HasMany(x => x.Notifications).WithOne(y => y.Organization).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<StudentTestSummaryAnswerDbo>().HasOne(x => x.StudentTestSummaryQuestion).WithMany(y => y.StudentTestSummaryAnswers).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder
                .Entity<OrganizationDbo>()
                .HasOne(x => x.OrganizationSetting)
                .WithOne(y => y.Organization)
                .HasForeignKey<OrganizationSettingDbo>(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseMaterialDbo>().HasMany(x => x.Courses).WithOne(y => y.CourseMaterial).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.OrganizationStudyHourFrom).WithOne(y => y.ActiveFrom).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.OrganizationStudyHourTo).WithOne(y => y.ActiveTo).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<StudentInGroupDbo>().HasOne(x => x.UserInOrganization).WithMany(y => y.StudentInGroups).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<StudentInGroupDbo>().HasOne(x => x.UserInOrganization).WithMany(y => y.StudentInGroups);
            _ = modelBuilder.Entity<CourseLessonItemDbo>().HasMany(x => x.CourseBrowses).WithOne(y => y.CourseLessonItem).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<CourseLessonItemDbo>().HasMany(x => x.CouseStudentMaterials).WithOne(y => y.CourseLessonItem).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<QuestionDbo>().HasMany(x => x.StudentTestSummaryQuestions).WithOne(y => y.TestQuestion).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<QuestionDbo>().HasMany(x => x.TestUserAnswers).WithOne(y => y.TestQuestion).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<AnswerDbo>().HasMany(x => x.TestUserAnswers).WithOne(y => y.TestQuestionAnswer).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.CourseTermFrom).WithOne(y => y.TimeFrom).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.CourseTermTo).WithOne(y => y.TimeTo).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.CourseTermDateFrom).WithOne(y => y.TimeFrom).OnDelete(DeleteBehavior.NoAction);
            _ = modelBuilder.Entity<TimeTableDbo>().HasMany(x => x.CourseTermDateTo).WithOne(y => y.TimeTo).OnDelete(DeleteBehavior.NoAction);

            _ = modelBuilder.Entity<UserDbo>().HasOne(d => d.UserRole).WithMany(p => p.Users).HasForeignKey(d => d.UserRoleId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetTableDefault<T>(ModelBuilder modelBuilder)
            where T : TableModel
        {
            _ = modelBuilder.Entity<T>().HasIndex(u => u.SystemIdentificator).IsUnique();
            _ = modelBuilder.Entity<T>().Property(u => u.Id).ValueGeneratedOnAdd();
            /*_ = modelBuilder.Entity<T>().Property(u => u.IsDeleted).HasDefaultValue(false);
            _ = modelBuilder.Entity<T>().Property(u => u.IsActive).HasDefaultValue(true);*/
        }

        public DbSet<CourseDbo> Course { get; set; }
        public DbSet<CourseLessonItemDbo> CourseItem { get; set; }
        public DbSet<CourseLectorDbo> CourseLector { get; set; }
        public DbSet<CourseStudentDbo> CourseStudent { get; set; }
        public DbSet<CourseTermDbo> CourseTerm { get; set; }
        public DbSet<UserDbo> User { get; set; }
        public DbSet<UserRoleDbo> UserRole { get; set; }
        public DbSet<CourseTestDbo> CourseTest { get; set; }
        public DbSet<QuestionDbo> TestQuestion { get; set; }
        public DbSet<AnswerDbo> TestQuestionAnswer { get; set; }
        public DbSet<PersonDbo> Person { get; set; }
        public DbSet<OrganizationDbo> Organization { get; set; }
        public DbSet<BranchDbo> Branch { get; set; }
        public DbSet<ClassRoomDbo> ClassRoom { get; set; }
        public DbSet<LicenseDbo> License { get; set; }
        public DbSet<CultureDbo> Culture { get; set; }
        public DbSet<UserInOrganizationDbo> UserInOrganization { get; set; }
        public DbSet<OrganizationRoleDbo> OrganizationRole { get; set; }
        public DbSet<OrganizationRolePermitionDbo> OrganizationRolePermition { get; set; }
        public DbSet<StudentTestSummaryDbo> StudentTestSummary { get; set; }
        public DbSet<AddressTypeDbo> AddressType { get; set; }
        public DbSet<GalleryItemTypeDbo> GalleryItemType { get; set; }
        public DbSet<ObjectHistoryDbo> ObjectHistory { get; set; }
        public DbSet<CourseStatusDbo> CourseStatus { get; set; }
        public DbSet<CourseTypeDbo> CourseType { get; set; }
        public DbSet<TimeTableDbo> TimeTable { get; set; }
        public DbSet<EduEmailDbo> EduEmails { get; set; }
        public DbSet<CourseLessonItemTemplateDbo> CourseLessonItemTemplate { get; set; }
        public DbSet<AnswerFileRepositoryDbo> FileRepository { get; set; }
        public DbSet<CourseTestBankOfQuestionDbo> LinkTestBankOfQuestion { get; set; }
        public DbSet<CourseBrowseDbo> CourseBrowse { get; set; }
        public DbSet<StudentTestSummaryAnswerDbo> StudentTestSummaryAnswers { get; set; }
        public DbSet<StudentTestSummaryQuestionDbo> StudentTestSummaryQuestions { get; set; }
        public DbSet<OrganizationSettingDbo> OrganizationSetting { get; set; }
        public DbSet<CouseStudentMaterialDbo> CouseStudentMaterial { get; set; }
        public DbSet<LinkLifeTimeDbo> LinkLifeTime { get; set; }
        public DbSet<CertificateDbo> Certificate { get; set; }
        public DbSet<OrganizationCultureDbo> OrganizationCulture { get; set; }
        public DbSet<UserCertificateDbo> UserCertificate { get; set; }
        public DbSet<CourseTermDateDbo> CourseTermDate { get; set; }
        public DbSet<OrganizationStudyHourDbo> OrganizationStudyHour { get; set; }
        public DbSet<SendMessageTypeDbo> SendMessageType { get; set; }
        public DbSet<SendMessageDbo> SendMessage { get; set; }
        public DbSet<StudentGroupDbo> StudentGroup { get; set; }
        public DbSet<StudentInGroupDbo> StudentInGroups { get; set; }
        public DbSet<StudentInGroupCourseTermDbo> StudentInGroupCourseTerm { get; set; }
        public DbSet<QuestionModeDbo> QuestionMode { get; set; }
        public DbSet<StudentAttendanceDbo> AttendanceStudent { get; set; }
        public DbSet<StudentEvaluationDbo> StudentEvaluation { get; set; }
        public DbSet<NoteDbo> Notes { get; set; }
        public DbSet<NoteTypeDbo> NoteType { get; set; }
        public DbSet<ChatDbo> Chat { get; set; }
        public DbSet<CourseTestEvaluationDbo> CourseTestEvaluation { get; set; }
        public DbSet<CountryDbo> Countries { get; set; }
        public DbSet<NotificationTypeDbo> NotificationTypes { get; set; }
        public DbSet<BankOfQuestionDbo> BankOfQuestions { get; set; }
        public DbSet<BankOfQuestionsTranslationDbo> BankOfQuestionsTranslations { get; set; }
        public DbSet<BranchTranslationDbo> BranchTranslations { get; set; }
        public DbSet<CertificateTranslationDbo> CertificateTranslations { get; set; }
        public DbSet<ClassRoomTranslationDbo> ClassRoomTranslations { get; set; }
        public DbSet<CourseTranslationDbo> CourseTranslations { get; set; }
        public DbSet<CourseLessonDbo> CourseLessons { get; set; }
        public DbSet<CourseLessonTranslationDbo> CourseLessonTranslations { get; set; }
        public DbSet<CourseLessonItemTranslationDbo> CourseLessonItemTranslations { get; set; }
        public DbSet<CourseMaterialDbo> CourseMaterials { get; set; }
        public DbSet<CourseMaterialTranslationDbo> CourseMaterialTranslations { get; set; }
        public DbSet<NotificationDbo> Notifications { get; set; }
        public DbSet<OrganizationTranslationDbo> OrganizationTranslations { get; set; }
        public DbSet<OrganizationAddressDbo> OrganizationAddresses { get; set; }
        public DbSet<PersonAddressDbo> PersonAddresses { get; set; }
        public DbSet<SendMessageTranslationDbo> SendMessageTranslations { get; set; }
        public DbSet<StudentGroupTranslationDbo> StudentGroupTranslations { get; set; }
        public DbSet<QuestionTranslationDbo> TestQuestionTranslations { get; set; }
        public DbSet<AnswerTanslationDbo> TestQuestionAnswerTanslations { get; set; }
        public DbSet<TestUserAnswerDbo> TestUserAnswers { get; set; }
        public DbSet<CourseTableDbo> CourseTables { get; set; }
        public DbSet<LicenseChangeDbo> LicenseChanges { get; set; }
        public DbSet<QuestionFileRepositoryDbo> QuestionFileRepositories { get; set; }
        public DbSet<OrganizationFileRepositoryDbo> OrganizationFileRepositories { get; set; }
        public DbSet<CourseMaterialFileRepositoryDbo> CourseMaterialFileRepositories { get; set; }
        public DbSet<CourseLessonFileRepositoryDbo> CourseLessonFileRepositories { get; set; }
        public DbSet<CourseLessonItemFileRepositoryDbo> CourseLessonItemFileRepositories { get; set; }
        public DbSet<RouteDbo> Routes { get; set; }
        public DbSet<PermissionsDbo> Permissions { get; set; }
    }
}
