using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Integration.PdfSharpIntegration;
using Microsoft.Extensions.Configuration;
using Model.CodeBook;
using Model.Edu.Answer;
using Model.Edu.Certificate;
using Model.Edu.Course;
using Model.Edu.CourseLesson;
using Model.Edu.CourseLessonItem;
using Model.Edu.CourseTerm;
using Model.Edu.CourseTest;
using Model.Edu.Organization;
using Model.Edu.OrganizationAddress;
using Model.Edu.Question;
using Model.Edu.SendMessage;
using Model.Edu.StudentTestSummary;
using Model.Edu.StudentTestSummaryAnswer;
using Model.Edu.StudentTestSummaryQuestion;
using Model.Edu.User;
using Model.Edu.UserCertificate;
using Model.Link;
using Repository.CertificateRepository;
using Repository.CourseLectorRepository;
using Repository.CourseLessonItemRepository;
using Repository.CourseLessonRepository;
using Repository.CourseRepository;
using Repository.CourseStudentRepository;
using Repository.CourseTableRepository;
using Repository.CourseTermRepository;
using Repository.CouseStudentMaterialRepository;
using Repository.MessageRepository;
using Repository.OrganizationRepository;
using Repository.QuestionRepository;
using Repository.StudentTestSummaryAnswerRepository;
using Repository.StudentTestSummaryQuestionRepository;
using Repository.StudentTestSummaryRepository;
using Repository.TestRepository;
using Repository.UserCertificateRepository;
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.CourseStudy.Convertor;
using Services.CourseStudy.Dto;
using Services.OrganizationRole.Dto;
using Services.SystemService.FileUpload;
using Services.SystemService.SendMailService;

namespace Services.CourseStudy.Service
{
    public class CourseStudyService(
        ITestRepository testRepository,
        IUserRepository userRepository,
        ICourseLessonItemRepository courseLessonItemRepository,
        ICourseRepository courseRepository,
        ICourseStudyConvertor courseConvertor,
        ICourseLessonRepository courseLessonRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        ICouseStudentMaterialRepository couseStudentMaterialRepository,
        ICourseStudentRepository courseStudentRepository,
        IUserCertificateRepository userCertificateRepository,
        ICertificateRepository certificateRepository,
        IConfiguration configuration,
        IStudentTestSummaryRepository studentTestSummaryRepository,
        IStudentTestSummaryQuestionRepository studentTestSummaryQuestionRepository,
        IStudentTestSummaryAnswerRepository studentTestSummaryAnswerRepository,
        IQuestionRepository questionRepository,
        ICourseLectorRepository courseLectorRepository,
        IMessageRepository sendMessageRepository,
        IOrganizationRepository organizationRepository,
        ICourseTermRepository courseTermRepository,
        ICodeBookRepository<CountryDbo> codebookRepository,
        ISendMailService sendMailService,
        IPdfSharpIntegration pdfSharpIntegration,
        ICourseTableRepository courseTableRepository,
        IFileUploadService fileUploadService
    ) : BaseService<ICourseStudyConvertor>(courseConvertor), ICourseStudyService
    {
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IQuestionRepository _questionRepository = questionRepository;
        private readonly IStudentTestSummaryQuestionRepository _studentTestSummaryQuestionRepository = studentTestSummaryQuestionRepository;
        private readonly IStudentTestSummaryRepository _studentTestSummaryRepository = studentTestSummaryRepository;
        private readonly IStudentTestSummaryAnswerRepository _studentTestSummaryAnswerRepository = studentTestSummaryAnswerRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;
        private readonly ICourseLessonItemRepository _courseLessonItemRepository = courseLessonItemRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ICertificateRepository _certificateRepository = certificateRepository;
        private readonly IPdfSharpIntegration _pdfSharpIntegration = pdfSharpIntegration;
        private readonly IMessageRepository _sendMessageRepository = sendMessageRepository;
        private readonly string _fileRepositoryPath = string.Format("{0}{1}/", configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, ConfigValue.CERTIFICATE_PATH);
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;
        private readonly ICourseTableRepository _courseTableRepository = courseTableRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITestRepository _testRepository = testRepository;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly ICouseStudentMaterialRepository _couseStudentMaterialRepository = couseStudentMaterialRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly HashSet<CountryDbo> _countries = codebookRepository.GetEntities(false);
        private readonly IUserCertificateRepository _userCertificateRepository = userCertificateRepository;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly ICourseRepository _courseRespository = courseRepository;

        public Result SaveActiveSlide(Guid slideId, Guid userId, Guid courseId)
        {
            int count = _couseStudentMaterialRepository.GetEntities(false, x => x.UserId == userId && x.CourseId == courseId).Count;
            if (count == 0)
            {
                _ = _couseStudentMaterialRepository.CreateEntity(
                    new CouseStudentMaterialDbo()
                    {
                        UserId = userId,
                        CourseLessonItemId = slideId,
                        CourseId = courseId
                    },
                    userId
                );
            }
            else
            {
                CouseStudentMaterialDbo enity = _couseStudentMaterialRepository.GetEntity(false, x => x.UserId == userId && x.CourseId == courseId);
                enity.CourseLessonItemId = slideId;
                _ = _couseStudentMaterialRepository.UpdateEntity(enity, userId);
            }
            return new Result();
        }

        public Result ResetCourse(Guid studentTermId)
        {
            CourseStudentDbo entity = _courseStudentRepository.GetEntity(studentTermId);
            entity.CourseFinish = false;
            _ = _courseStudentRepository.UpdateEntity(entity, Guid.Empty);
            return new Result();
        }

        public HashSet<CourseMenuItemDto> GetCourseMenu(Guid courseId, Guid userId, string culture)
        {
            HashSet<CourseMenuItemDto> courseMenuItems = [];
            Guid materialId = _courseRespository.GetEntity(courseId).CourseMaterialId ?? Guid.Empty;
            HashSet<CourseLessonDbo> getAllLessonInCourses = _courseLessonRepository.GetEntities(false, x => x.CourseMaterialId == materialId, x => x.Position);
            courseMenuItems = getAllLessonInCourses
                .Select(x => new CourseMenuItemDto()
                {
                    Id = x.Id,
                    Name = x.CourseLessonTranslations.FindTranslation(culture).Name,
                    Items = _courseLessonItemRepository
                        .GetEntities(false, x => x.CourseLessonId == x.Id, x => x.Position)
                        .Select(y => new CourseMenuSubItemDto()
                        {
                            Id = y.Id,
                            Name = y.CourseLessonItemTranslations.FindTranslation(culture).Name,
                            Type = CourseLessonType.COURSE_ITEM
                        })
                        .ToHashSet(),
                    Type = x.Type ?? CourseLessonType.COURSE_ITEM
                })
                .Where(x => x.Type == CourseLessonType.COURSE_TEST || x.Type == CourseLessonType.COURSE_ITEM_POWER_POINT || (x.Type == CourseLessonType.SUB_ITEM && x.Items.Count > 0))
                .ToHashSet();
            _ = courseMenuItems.Add(
                new CourseMenuItemDto()
                {
                    Id = Guid.Empty,
                    Items = [],
                    Name = CourseLessonType.LAST_SLIDE,
                    Type = CourseLessonType.LAST_SLIDE,
                }
            );
            return courseMenuItems;
        }

        public UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId)
        {
            UserInOrganizationDbo getAllUserInOrganizations = _userInOrganizationRepository
                .GetEntities(false, x => x.OrganizationId == _courseRespository.GetOrganizationId(courseId))
                .FirstOrDefault(x =>
                    x.UserId == userId
                    && (
                        x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                    )
                );
            return getAllUserInOrganizations == null
                ? new UserOrganizationRoleDetailDto()
                {
                    IsCourseAdministrator = false,
                    IsCourseEditor = false,
                    IsOrganizationAdministrator = false,
                    IsOrganizationOwner = false,
                    IsLector = _courseLectorRepository.GetEntities(false, x => x.UserInOrganization.UserId == userId).FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                }
                : new UserOrganizationRoleDetailDto()
                {
                    IsCourseAdministrator = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                    IsCourseEditor = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                    IsOrganizationAdministrator = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                    IsOrganizationOwner = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                    IsLector = _courseLectorRepository.GetEntities(false, x => x.UserInOrganization.UserId == userId).FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                };
        }

        private GetUserCourseItemDto GetUserCourseItem(Guid courseId, Guid userId)
        {
            CouseStudentMaterialDbo item = _couseStudentMaterialRepository.GetEntity(false, x => x.CourseId == courseId && x.UserId == userId);
            if (item == null || item.CourseLessonItemId == Guid.Empty)
            {
                CourseLessonDbo getAllLessonInCourse = _courseLessonRepository
                    .GetEntities(false, x => x.CourseMaterialId == (_courseRespository.GetEntity(courseId).CourseMaterialId ?? Guid.Empty))
                    .FirstOrDefault();
                return getAllLessonInCourse.Type == CourseLessonType.COURSE_TEST
                    ? new GetUserCourseItemDto() { CourseLessonItem = getAllLessonInCourse.Id, ItemType = CourseLessonType.COURSE_TEST }
                    : new GetUserCourseItemDto()
                    {
                        CourseLessonItem = _courseLessonItemRepository.GetEntities(false, x => x.CourseLessonId == getAllLessonInCourse.Id).FirstOrDefault().Id,
                        ItemType = CourseLessonType.COURSE_ITEM
                    };
            }
            return new GetUserCourseItemDto() { CourseLessonItem = item.CourseLessonItemId, ItemType = item.CourseLessonItem.CourseLesson.Type };
        }

        public CourseLessonStudyDto CourseMaterialBrowse(Guid courseId, Guid userId, string culture)
        {
            UserOrganizationRoleDetailDto getUserOrganizationRoleDto = CanCourseBrowse(courseId, userId);
            if (getUserOrganizationRoleDto.IsLector || getUserOrganizationRoleDto.IsStudent)
            {
                GetUserCourseItemDto getUserCourseItem = GetUserCourseItem(courseId, userId);
                return GoToSlide(getUserCourseItem.CourseLessonItem, userId, courseId, culture);
            }
            return null;
        }

        public CourseLessonStudyDto GoToSlide(Guid slideId, Guid userId, Guid courseId, string culture)
        {
            CourseLessonItemDbo getCourseLessonItemDetail = _courseLessonItemRepository.GetEntity(slideId);
            //.GetDetail(slideId).Data;
            if (getCourseLessonItemDetail != null)
            {
                _ = SaveActiveSlide(slideId, userId, courseId);
                return new CourseLessonStudyDto()
                {
                    Name = getCourseLessonItemDetail?.CourseLessonItemTranslations.FindTranslation(culture).Name,
                    Type = CourseLessonType.COURSE_ITEM,
                    //Description = getCourseLessonItemDetail?.CourseLessonItemTranslations.FindTranslation(culture)
                    Html = getCourseLessonItemDetail?.CourseLessonItemTranslations.FindTranslation(culture).Html,
                    TemplateIdentificator = getCourseLessonItemDetail?.CourseLessonItemTemplate.SystemIdentificator,
                    //ImagePath = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, getCourseLessonItemDetail?.Id, getCourseLessonItemDetail?.),
                    PowerPointFile = "",
                    SlideId = slideId,
                    Youtube = getCourseLessonItemDetail.Youtube
                };
            }
            CourseLessonPowerPointFileDto getCourseLessonPowerPointFile = GetCourseLessonPowerPointFile(slideId, culture);
            if (getCourseLessonPowerPointFile != null && !getCourseLessonPowerPointFile.PowerPointFile.IsNullOrEmptyWithTrim())
            {
                _ = SaveActiveSlide(slideId, userId, courseId);
                return new CourseLessonStudyDto()
                {
                    Name = getCourseLessonPowerPointFile?.Name,
                    Type = CourseLessonType.COURSE_ITEM_POWER_POINT,
                    Description = getCourseLessonPowerPointFile?.Description,
                    Html = "",
                    TemplateIdentificator = "",
                    ImagePath = "",
                    PowerPointFile = string.Format("{0}{1}", _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, getCourseLessonPowerPointFile.PowerPointFile),
                    SlideId = slideId,
                };
            }

            CourseTestDbo getCourseTestDetail = _testRepository.GetEntity(false, x => x.CourseLessonId == slideId);
            if (getCourseTestDetail != null)
            {
                _ = SaveActiveSlide(slideId, userId, courseId);
                return new CourseLessonStudyDto()
                {
                    Name = getCourseTestDetail?.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    Type = CourseLessonType.COURSE_TEST,
                    TimeLimit = getCourseTestDetail.TimeLimit,
                    Questions = GenerateTest(slideId, userId, courseId, culture)
                        .Select(x => new CourseLessonQuestionStudyDto()
                        {
                            AnswerMode = x.AnswerMode.SystemIdentificator,
                            QuestionMode = x.QuestionMode.SystemIdentificator,
                            Id = x.Id,
                            Question = x.TestQuestionTranslation.FindTranslation(culture).Question,
                            FilePath = string.Format(
                                "{0}{1}/{2}",
                                _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                                x.QuestionFileRepositories.FindTranslation(culture).QuestionId,
                                x.QuestionFileRepositories.FindTranslation(culture).FileName
                            ),
                            Answers = x
                                .TestQuestionAnswer.Select(y => new CourseLessonAnswerDto()
                                {
                                    Answer = y.TestQuestionAnswerTranslations.FindTranslation(culture).Answer,
                                    Id = y.Id,
                                    FilePath = string.Format(
                                        "{0}{1}/{2}",
                                        _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                                        y.AnswerFileRepository.FindTranslation(culture).AnswerId,
                                        y.AnswerFileRepository.FindTranslation(culture).FileName
                                    )
                                })
                                .ToHashSet()
                        })
                        .ToHashSet(),
                    SlideId = slideId,
                    CanRunTest = CanRunTest(slideId, userId)
                };
            }
            return null;
        }

        private CourseLessonPowerPointFileDto GetCourseLessonPowerPointFile(Guid courseLessonItemId, string culture)
        {
            CourseLessonItemDbo entity = _courseLessonItemRepository.GetEntity(courseLessonItemId);
            return new CourseLessonPowerPointFileDto()
            {
                Id = entity.Id,
                Name = entity.CourseLessonItemTranslations.FindTranslation(culture).Name,
                PowerPointFile = entity.CourseLessonItemFileRepositories.FindTranslation(culture).FileName
            };
        }

        private bool CanRunTest(Guid slideId, Guid userId)
        {
            CourseTestDbo getCourseTestDetail = _testRepository.GetEntity(false, x => x.CourseLessonId == slideId);

            HashSet<StudentTestSummaryDbo> tests = _studentTestSummaryRepository.GetEntities(false, x => x.UserId == userId).Where(x => x.CourseTestId == getCourseTestDetail.Id).ToHashSet();
            if (getCourseTestDetail.MaxRepetition == 0)
            {
                return true;
            }
            else if (getCourseTestDetail.MaxRepetition == -1 && tests.FirstOrDefault(x => x.IsSucess) == null)
            {
                return true;
            }
            else if (getCourseTestDetail.MaxRepetition >= tests.Count)
            {
                return true;
            }
            return false;
        }

        private List<QuestionDbo> GenerateTest(Guid courseLessonId, Guid userId, Guid courseId, string culture)
        {
            if (CanRunTest(courseLessonId, userId))
            {
                CourseTestDbo getCourseTestDetail = _testRepository.GetEntity(false, x => x.CourseLessonId == courseLessonId);
                CourseDbo courseDetail = _courseRespository.GetEntity(courseId);
                List<QuestionDbo> getQuestionsInBanks = [];
                foreach (Guid item in getCourseTestDetail.CourseTestBankOfQuestions.Select(x => x.Id))
                {
                    getQuestionsInBanks = [.. getQuestionsInBanks, .. _questionRepository.GetEntities(false, x => x.BankOfQuestionId == item).ToList(),];
                }
                if (getCourseTestDetail.IsRandomGenerateQuestion)
                {
                    getQuestionsInBanks = [.. getQuestionsInBanks.ToList().Shuffle()];
                }
                if (getCourseTestDetail.QuestionCountInTest > 0)
                {
                    getQuestionsInBanks = [.. getQuestionsInBanks.ToList().Limit(getCourseTestDetail.QuestionCountInTest)];
                }
                foreach (QuestionDbo item in getQuestionsInBanks)
                {
                    bool isAutomatic =
                        item.AnswerMode.SystemIdentificator
                            is AnswerMode.SELECT_MANY
                                or AnswerMode.SELECT_ONE
                                or AnswerMode.YES_NO_TRUE_NO
                                or AnswerMode.YES_NO_TRUE_YES
                                or AnswerMode.SELECT_ONE_IMAGE
                                or AnswerMode.SELECT_MANY_IMAGE
                                or AnswerMode.SELECT_ONE_VIDEO
                                or AnswerMode.SELECT_MANY_VIDEO
                                or AnswerMode.SELECT_ONE_AUDIO
                                or AnswerMode.SELECT_MANY_AUDIO;
                    item.IsAutomatic = isAutomatic;
                    Guid questionId = _studentTestSummaryQuestionRepository
                        .CreateEntity(
                            new StudentTestSummaryQuestionDbo()
                            {
                                Question = item.TestQuestionTranslation.FindTranslation(culture).Question,
                                AnswerModeId = item.AnswerModeId,
                                IsAutomaticEvaluate = isAutomatic,
                                Position = item.Position,
                                TestQuestionId = item.Id,
                                QuestionModeId = item.QuestionModeId,
                                FilePath = string.Format(
                                    "{0}{1}/{2}",
                                    _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                                    item?.QuestionFileRepositories.FindTranslation(culture).QuestionId,
                                    item?.QuestionFileRepositories.FindTranslation(culture).FileName
                                )
                            },
                            userId
                        )
                        .Id;

                    if (getCourseTestDetail.IsRandomGenerateQuestion)
                    {
                        item.TestQuestionAnswer = [.. item.TestQuestionAnswer.ToList().Shuffle()];
                    }

                    item.Id = questionId;
                    foreach (AnswerDbo answer in item.TestQuestionAnswer)
                    {
                        answer.Id = _studentTestSummaryAnswerRepository
                            .CreateEntity(
                                new StudentTestSummaryAnswerDbo()
                                {
                                    StudentTestSummaryQuestionId = questionId,
                                    Answer = answer.TestQuestionAnswerTranslations.FindTranslation(culture).Answer,
                                    IsTrueAnswer = answer.IsTrueAnswer,
                                    Position = answer.Position,
                                    TestQuestionAnswerId = answer.Id,
                                    FilePath = string.Format(
                                        "{0}{1}/{2}",
                                        _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                                        answer?.AnswerFileRepository.FindTranslation(culture).AnswerId,
                                        answer?.AnswerFileRepository.FindTranslation(culture).FileName
                                    )
                                },
                                userId
                            )
                            .Id;
                    }
                }
                return !courseDetail.CourseWithLector ? getQuestionsInBanks.Where(x => x.IsAutomatic).ToList() : getQuestionsInBanks;
            }
            return [];
        }

        public HashSet<StudentTestListDto> GetStudentTest(Guid userId, string culture)
        {
            return _convertor.ConvertToWebModel([.. _studentTestSummaryRepository.GetEntities(false, x => x.UserId == userId, null, x => x.Finish)], culture);
        }

        public Guid StartTest(Guid courseLessonId, Guid userId, Guid courseId)
        {
            CourseTestDbo courseTestDbo = _testRepository.GetEntity(false, x => x.CourseLessonId == courseLessonId);

            return _studentTestSummaryRepository
                .CreateEntity(
                    new StudentTestSummaryDbo()
                    {
                        StartTime = DateTime.Now,
                        CourseTestId = courseTestDbo.Id,
                        UserId = userId,
                        CourseId = courseId
                    },
                    userId
                )
                .Id;
        }

        public EvaluateTestDto EvaluateTest(Guid userTestSummaryId, List<EvaluateQuestionDto> evaluateTestDtos, Guid courseLessonId)
        {
            if (userTestSummaryId == Guid.Empty)
            {
                return new EvaluateTestDto();
            }
            EvaluateTestDto evaluateTest = new() { Id = userTestSummaryId };
            foreach (EvaluateQuestionDto item in evaluateTestDtos)
            {
                Guid fileName = Guid.Empty;
                if (!item.TextManualAnswer.IsNullOrEmptyWithTrim())
                {
                    fileName = _fileUploadService.SaveFilePngFile(item.TextManualAnswer, "test");
                }
                EvaluateQuestion(userTestSummaryId, item.QuestionId, item.AnswerId, item.TextAnswer, fileName);
            }
            StudentTestSummaryDbo evaluateTestResult = EvaluateTest(userTestSummaryId);
            evaluateTest.IsAutomatic = evaluateTestResult.IsAutomaticEvaluate;
            evaluateTest.IsSucess = evaluateTestResult.IsSucess;
            evaluateTest.Score = evaluateTestResult.Score;

            return evaluateTest;
        }

        private void EvaluateQuestion(Guid userTestSummaryId, Guid questionId, List<Guid> answerId, string textAnswer, Guid fileName)
        {
            if (answerId != null && answerId.Count > 0)
            {
                foreach (Guid answer in answerId)
                {
                    EvaluateAnswer(answer, "", questionId, fileName);
                }
            }
            else
            {
                EvaluateAnswer(Guid.Empty, textAnswer, questionId, fileName);
            }
            StudentTestSummaryQuestionDbo question = _studentTestSummaryQuestionRepository.GetEntity(false, x => x.Id == questionId);
            string answerMode = question.AnswerMode.SystemIdentificator;
            int score = 1;
            bool userCorrectAnswer = true;
            if (answerMode is AnswerMode.TEXT or AnswerMode.TEXT_MANUAL)
            {
                score = 0;
            }

            HashSet<StudentTestSummaryAnswerDbo> answers = _studentTestSummaryAnswerRepository.GetEntities(false, x => x.StudentTestSummaryQuestionId == questionId);
            foreach (StudentTestSummaryAnswerDbo answer in answers)
            {
                if (answer.UserAnswer != answer.IsTrueAnswer)
                {
                    userCorrectAnswer = false;
                    score = 0;
                }
            }
            question.Score = score;
            question.IsTrue = userCorrectAnswer;
            question.StudentTestSummaryId = userTestSummaryId;
            _ = _studentTestSummaryQuestionRepository.UpdateEntity(question, Guid.Empty);
        }

        private void EvaluateAnswer(Guid answerId, string textAnswer, Guid questionId, Guid fileName)
        {
            if (answerId == Guid.Empty)
            {
                _ = _studentTestSummaryAnswerRepository.CreateEntity(
                    new StudentTestSummaryAnswerDbo()
                    {
                        StudentTestSummaryQuestionId = questionId,
                        UserTestAnswer = textAnswer,
                        UserTestImageAnswer = fileName
                    },
                    Guid.Empty
                );
            }
            else
            {
                StudentTestSummaryAnswerDbo entity = _studentTestSummaryAnswerRepository.GetEntity(answerId);
                entity.UserAnswer = true;
                entity.UserTestAnswer = textAnswer;
                entity.UserTestImageAnswer = fileName;
                _ = _studentTestSummaryAnswerRepository.UpdateEntity(entity, Guid.Empty);
            }
        }

        private StudentTestSummaryDbo EvaluateTest(Guid userTestSummaryId)
        {
            HashSet<StudentTestSummaryQuestionDbo> question = _studentTestSummaryQuestionRepository.GetEntities(false, x => x.StudentTestSummaryId == userTestSummaryId);
            double sumScore = question.Sum(x => x.Score);
            bool isAutomatic = question.FirstOrDefault(x => x.IsAutomaticEvaluate == false) == null;
            StudentTestSummaryDbo studentTestSummaryDbo = _studentTestSummaryRepository.GetEntity(userTestSummaryId);
            studentTestSummaryDbo.Finish = DateTime.Now;
            studentTestSummaryDbo.Score = sumScore;
            if (isAutomatic)
            {
                studentTestSummaryDbo.IsAutomaticEvaluate = true;
                int desiredSuccess = studentTestSummaryDbo.CourseTest.DesiredSuccess;
                if (desiredSuccess == 0 || sumScore >= desiredSuccess)
                {
                    studentTestSummaryDbo.IsSucess = true;
                }
            }

            return _studentTestSummaryRepository.UpdateEntity(studentTestSummaryDbo, Guid.Empty);
        }

        public HashSet<ShowTestResultQuestionDto> ShowTestResult(Guid userTestSummaryId)
        {
            return [];
            /*return _testService.ShowStudentAnswer(userTestSummaryId).GetUserTestQuestions.Select(x => new ShowTestResultQuestionDto()
            {
                Id = x.Id,
                IsTrue = x.IsTrue,
                TestQuestionId = x.TestQuestionId,
                UserAnswers = x.Answers.Select(y => new ShowTestResultAnswerDto()
                {
                    Id = y.Id,
                    IsTrueAnswer = y.IsTrue,
                    TestQuestionAnswerId = y.TestQuestionAnswerId,
                    Text = y.Text
                }).ToHashSet()
            }).ToHashSet();*/
        }

        public UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId)
        {
            return new UserOrganizationRoleDetailDto()
            {
                IsCourseAdministrator = false,
                IsCourseEditor = false,
                IsLector = _courseLectorRepository.GetEntities(false, x => x.UserInOrganization.UserId == userId).FirstOrDefault(x => x.Id == courseId) != null,
                IsOrganizationAdministrator = false,
                IsOrganizationOwner = false,
                IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
            };
        }

        public HashSet<SlideIdListDto> GetAllSlideId(Guid courseId, Guid userId, string culture)
        {
            HashSet<SlideIdListDto> courseMenuItems = [];
            HashSet<CourseMenuItemDto> getAllLessonInCourses = GetCourseMenu(courseId, userId, culture);
            foreach (CourseMenuItemDto item in getAllLessonInCourses)
            {
                HashSet<CourseMenuSubItemDto> subItems = item.Items;
                if (subItems.Count > 0)
                {
                    foreach (CourseMenuSubItemDto subItem in subItems)
                    {
                        _ = courseMenuItems.Add(
                            new SlideIdListDto()
                            {
                                Id = subItem.Id,
                                ParentId = item.Id,
                                Name = subItem.Name
                            }
                        );
                    }
                }
                else
                {
                    _ = courseMenuItems.Add(new SlideIdListDto() { Id = item.Id, Name = item.Name });
                }
            }
            return courseMenuItems;
        }

        private string PrepareText(string text, Guid userId, Guid organizationId, Guid courseId, Guid courseTermId)
        {
            text = text.Replace("{actualDate}", DateTime.Now.ToString());
            if (userId != Guid.Empty)
            {
                UserDbo getUserDetail = _userRepository.GetEntity(userId);
                text = text.Replace("{fullName}", string.Format("{0} {1} {2}", getUserDetail.Person.FirstName, getUserDetail.Person.SecondName, getUserDetail.Person.LastName));
            }
            if (organizationId != Guid.Empty)
            {
                OrganizationDbo getOrganizationDetail = _organizationRepository.GetEntity(organizationId);
                OrganizationAddressDbo getOrganizationAddress = getOrganizationDetail.Addresses.FirstOrDefault(x => x.SystemIdentificator == AddressType.REGISTERED_OFFICE_ADDRESS);
                text = text.Replace("{organizationAddressCountry}", _countries.FirstOrDefault(x => x.Id == getOrganizationAddress.CountryId).Name);
                text = text.Replace("{organizationAddressRegion}", getOrganizationAddress.Region);
                text = text.Replace("{organizationAddressCity}", getOrganizationAddress.City);
                text = text.Replace("{organizationAddressStreet}", getOrganizationAddress.Street);
                text = text.Replace("{organizationAddressHouseNumber}", getOrganizationAddress.HouseNumber);
                text = text.Replace("{organizationAddressHouseZip}", getOrganizationAddress.ZipCode);
            }
            if (courseId != Guid.Empty)
            {
                CourseDbo getCourseDetail = _courseRespository.GetEntity(courseId);
                text = text.Replace("{courseName}", getCourseDetail.CourseTranslations.FindTranslation("").Name);
            }
            if (courseTermId != Guid.Empty)
            {
                CourseTermDbo getCourseTermDetail = _courseTermRepository.GetEntity(courseTermId);
                text = text.Replace("{courseTerm}", string.Format("{0} {1}", getCourseTermDetail.ActiveFrom, getCourseTermDetail.ActiveTo));
            }

            return text;
        }

        public FinishCourseDto FinishCourse(Guid userId, Guid courseStudentId, Guid courseId, Guid organizationId, string culture)
        {
            CourseDbo getCourseDetail = _courseRespository.GetEntity(courseId);
            Guid fileName = Guid.Empty;
            bool pdfCreated = false;
            if (getCourseDetail.AutomaticGenerateCertificate)
            {
                CertificateDbo getCertificateDetail = _certificateRepository.GetEntity(getCourseDetail.CertificateId ?? Guid.Empty);
                string html = PrepareText(
                    getCertificateDetail.CertificateTranslations.FindTranslation(culture).Html,
                    userId,
                    organizationId,
                    courseId,
                    _courseStudentRepository.GetEntity(courseStudentId).CourseTermId
                );
                fileName = _pdfSharpIntegration.HtmlToPdfFile(html);
                DateTime certificateValidTo = DateTime.MaxValue;
                if (getCertificateDetail.CertificateValidTo > 0)
                {
                    certificateValidTo = certificateValidTo.AddMonths(getCertificateDetail.CertificateValidTo);
                }
                _ = _userCertificateRepository.CreateEntity(
                    new UserCertificateDbo()
                    {
                        Name = getCertificateDetail.CertificateTranslations.FindTranslation(culture).Name,
                        FileName = fileName.ToString(),
                        UserId = userId,
                        ValidTo = certificateValidTo
                    },
                    userId
                );

                pdfCreated = true;
                if (getCourseDetail.SendEmail)
                {
                    MessageDbo getSendMessageDetail = _sendMessageRepository.GetEntity(getCourseDetail.SendMessageId ?? Guid.Empty);
                    UserDbo getUserDetail = _userRepository.GetEntity(userId);
                    List<string> attachment = [string.Format("{0}{1}.pdf", _fileRepositoryPath, fileName)];
                    _sendMailService.AddEmailToQueue(
                        getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Subject,
                        PrepareText(
                            getSendMessageDetail.SendMessageTranslations.FindTranslation(culture).Html,
                            userId,
                            organizationId,
                            courseId,
                            _courseStudentRepository.GetEntity(courseStudentId).CourseTermId
                        ),
                        attachment,
                        new EmailAddress() { Email = getUserDetail.UserEmail },
                        organizationId,
                        getSendMessageDetail.Reply
                    );
                }
            }
            CourseStudentDbo entity = _courseStudentRepository.GetEntity(courseStudentId);
            entity.CourseFinish = true;
            _ = _courseStudentRepository.UpdateEntity(entity, userId);
            return new FinishCourseDto() { CertificatePdf = string.Format("{0}certificate/{1}.pdf", _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, fileName), PdfCreated = pdfCreated };
        }

        public Result UpdateActualTable(ActualTableUpdateDto updateActualTableDto)
        {
            _courseTableRepository.UpdateActualTable(updateActualTableDto.CourseTermId, updateActualTableDto.Img);
            return new Result();
        }

        public Result<string> GetActualTable(Guid courseTermid)
        {
            return new Result<string>() { Data = _courseTableRepository.GetActualTable(courseTermid) };
        }

        public HashSet<StudentTestResultListDto> GetAllStudentTestResult(Guid courseId, string culture)
        {
            return _convertor.ConvertToWebModel2([.. _studentTestSummaryRepository.GetEntities(false, x => x.CourseId == courseId, null, x => x.Finish)], culture);
        }

        public ShowTestResultDto ShowStudentAnswer(Guid studentTestResultId)
        {
            StudentTestSummaryDbo showTestResult = _studentTestSummaryRepository.GetEntity(false, x => x.Id == studentTestResultId);

            //_repository.ShowTestResult(studentTestResultId);
            //HashSet<GetStudentQuestion> getStudentQuestions = _repository.GetStudentQuestion(studentTestResultId);
            /*showTestResult.GetUserTestQuestions = getStudentQuestions
                .Select(x => new GetUserTestQuestion()
                {
                    AnswerMode = x.AnswerMode,
                    Id = x.Id,
                    IsAutomaticEvaluate = x.IsAutomaticEvaluate,
                    IsTrue = x.IsTrue,
                    Question = x.Question,
                    Score = x.Score,
                    FilePath = x.FilePath,
                    QuestionModeId = x.QuestionModeId,
                    TestQuestionId = x.TestQuestionId,
                    QuestionMode = x.QuestionMode,
                    Answers = _repository
                        .GetStudentAnswer(x.Id)
                        .Select(y => new GetUserTestQuestionAnswer()
                        {
                            Id = y.Id,
                            Answer = y.Answer,
                            IsTrue = y.IsTrueAnswer,
                            UserAnswer = y.UserAnswer,
                            Text = y.UserTestAnswer,
                            UserAnswerIsCorrect = y.UserAnswerIsCorrect,
                            FilePath = y.FilePath,
                            TestQuestionAnswerId = y.TestQuestionAnswerId,
                            UserTestImageAnswer = y.UserTestImageAnswer
                        })
                        .ToHashSet()
                })
                .ToHashSet();*/

            return _convertor.ConvertToWebModel(showTestResult);
        }

        public Result SetLectorControl(SetLectorControlDto setLectorControlDto)
        {
            _ = SetLectorControl(setLectorControlDto.QuestionId, setLectorControlDto.IsTrue, setLectorControlDto.Score, setLectorControlDto.StudentTestResultId);
            return new Result();
        }

        public Result SetLectorControl(Guid questionId, bool isTrue, int score, Guid studentTestResultId)
        {
            StudentTestSummaryQuestionDbo question = _studentTestSummaryQuestionRepository.GetEntity(false, x => x.Id == questionId);
            question.IsTrue = isTrue;
            question.Score = score;
            question.IsAutomaticEvaluate = true;
            _ = _studentTestSummaryQuestionRepository.UpdateEntity(question, Guid.Empty);

            StudentTestSummaryAnswerDbo answer = _studentTestSummaryAnswerRepository.GetEntity(false, x => x.StudentTestSummaryQuestionId == questionId);
            answer.UserAnswerIsCorrect = isTrue;
            _ = _studentTestSummaryAnswerRepository.UpdateEntity(answer, Guid.Empty);

            HashSet<StudentTestSummaryQuestionDbo> questions = _studentTestSummaryQuestionRepository.GetEntities(false, x => x.StudentTestSummaryId == studentTestResultId);
            int sumScore = questions.Sum(x => x.Score);
            StudentTestSummaryDbo entity = _studentTestSummaryRepository.GetEntity(studentTestResultId);
            int minimum = entity.CourseTest.DesiredSuccess;
            bool testComleted = sumScore >= minimum;

            entity.Score = score;
            entity.IsSucess = testComleted;
            entity.IsAutomaticEvaluate = _studentTestSummaryQuestionRepository.GetEntity(false, x => x.StudentTestSummaryId == studentTestResultId && x.IsAutomaticEvaluate == true) != null;
            _ = _studentTestSummaryRepository.UpdateEntity(entity, Guid.Empty);
            return new Result();
        }
    }
}
