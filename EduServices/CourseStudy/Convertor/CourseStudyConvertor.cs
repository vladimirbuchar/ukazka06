﻿using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using EduServices.Course.Dto;
using EduServices.CourseStudy.Dto;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseLesson;
using Model.Tables.Edu.StudentTestSummary;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseStudy.Convertor
{
    public class CourseStudyConvertor(ICodeBookRepository<CourseTypeDbo> courseType, ICodeBookRepository<CultureDbo> culture, IConfiguration configuration) : ICourseStudyConvertor
    {
        private readonly string _fileRepositoryPath = string.Format("{0}{1}/", configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, ConfigValue.TEST);

        private readonly HashSet<CourseTypeDbo> _courseTypes = courseType.GetCodeBookItems();

        private readonly HashSet<CultureDbo> _cultureList = culture.GetCodeBookItems();

        public CourseDbo ConvertToBussinessEntity(CourseCreateDto addCourseDto, string culture)
        {
            CourseDbo course =
                new()
                {
                    Price = addCourseDto.Price,
                    Sale = addCourseDto.Sale,
                    CourseStatusId = addCourseDto.CourseStatusId,
                    CourseTypeId = addCourseDto.CourseTypeId,
                    OrganizationId = addCourseDto.OrganizationId,
                    IsPrivateCourse = addCourseDto.IsPrivateCourse,
                    MaximumStudent = addCourseDto.DefaultMaximumStudents,
                    MinimumStudent = addCourseDto.DefaultMinimumStudents,
                    CertificateId = addCourseDto.CertificateId,
                    AutomaticGenerateCertificate = addCourseDto.AutomaticGenerateCertificate,
                    CourseMaterialId = addCourseDto.CourseMaterialId,
                    SendEmail = addCourseDto.SendEmail,
                    SendMessageId = addCourseDto.EmailTemplateId,
                    CourseWithLector = addCourseDto.CourseWithLector
                };
            _ = course.CourseTranslations = _ = course.CourseTranslations.PrepareTranslation(addCourseDto.Name, addCourseDto.Description, culture, _cultureList);
            return course;
        }

        public CourseDbo ConvertToBussinessEntity(CourseUpdateDto updateCourseDto, CourseDbo entity, string culture)
        {
            entity.CourseTranslations = entity.CourseTranslations.PrepareTranslation(updateCourseDto.Name, updateCourseDto.Description, culture, _cultureList);
            entity.Price = updateCourseDto.Price;
            entity.Sale = updateCourseDto.Sale;
            entity.CourseStatusId = updateCourseDto.CourseStatusId;
            entity.CourseTypeId = updateCourseDto.CourseTypeId;
            entity.IsPrivateCourse = updateCourseDto.IsPrivateCourse;
            entity.MaximumStudent = updateCourseDto.DefaultMaximumStudents;
            entity.MinimumStudent = updateCourseDto.DefaultMinimumStudents;
            entity.CertificateId = updateCourseDto.CertificateId;
            entity.AutomaticGenerateCertificate = updateCourseDto.AutomaticGenerateCertificate;
            entity.CourseMaterialId = updateCourseDto.CourseMaterialId;
            entity.SendEmail = updateCourseDto.SendEmail;
            entity.SendMessageId = updateCourseDto.EmailTemplateId;
            entity.CourseWithLector = updateCourseDto.CourseWithLector;
            return entity;
        }

        public HashSet<CourseListInOrganizationDto> ConvertToWebModel(HashSet<CourseDbo> getAllCourseInOrganizations, string culture)
        {
            return getAllCourseInOrganizations.Select(item => new CourseListInOrganizationDto() { Id = item.Id, Name = item.CourseTranslations.FindTranslation(culture).Name, }).ToHashSet();
        }

        public CourseDetailDto ConvertToWebModel(CourseDbo getCourseDetail, string culture)
        {
            return new CourseDetailDto()
            {
                CourseStatusId = getCourseDetail.CourseStatusId,
                Description = getCourseDetail.CourseTranslations.FindTranslation(culture).Description,
                Name = getCourseDetail.CourseTranslations.FindTranslation(culture).Name,
                CourseTypeId = getCourseDetail.CourseTypeId,
                FileName = "",
                Id = getCourseDetail.Id,
                IsPrivateCourse = getCourseDetail.IsPrivateCourse,
                Price = getCourseDetail.Price,
                Sale = getCourseDetail.Sale,
                CourseType = _courseTypes.FirstOrDefault(x => x.Id == getCourseDetail.CourseTypeId).SystemIdentificator,
                MaximumStudent = getCourseDetail.MaximumStudent,
                MinimumStudent = getCourseDetail.MinimumStudent,
                CertificateId = getCourseDetail.CertificateId,
                AutomaticGenerateCertificate = getCourseDetail.AutomaticGenerateCertificate,
                CourseMaterialId = getCourseDetail.CourseMaterialId,
                SendEmail = getCourseDetail.SendEmail,
                SendMessageId = getCourseDetail.SendMessageId,
                CourseWithLector = getCourseDetail.CourseWithLector
            };
        }

        public HashSet<StudentTestListDto> ConvertToWebModel(HashSet<StudentTestSummaryDbo> getStudentTests, string culture)
        {
            return getStudentTests
                .Select(x => new StudentTestListDto()
                {
                    Finish = x.Finish.Value,
                    Id = x.Id,
                    Name = x.CourseTest.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    Score = x.Score,
                    TestCompleted = x.IsSucess,
                    TestId = x.CourseTestId,
                    CourseMaterialId = x.CourseTest.CourseLesson.CourseMaterialId,
                    CourseId = x.CourseId
                })
                .ToHashSet();
        }

        public HashSet<StudentTestResultListDto> ConvertToWebModel2(HashSet<StudentTestSummaryDbo> getAllStudentTestResults, string culture)
        {
            return getAllStudentTestResults
                .Select(x => new StudentTestResultListDto()
                {
                    FirstName = x.User.Person.FirstName,
                    Id = x.Id,
                    LastName = x.User.Person.LastName,
                    Name = x.CourseTest.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    SecondName = x.User.Person.SecondName,
                    UserEmail = x.User.UserEmail,
                    Finish = x.Finish,
                    Score = x.Score,
                    TestCompleted = x.IsSucess
                })
                .ToHashSet();
        }

        public ShowTestResultDto ConvertToWebModel(StudentTestSummaryDbo showTestResult)
        {
            return new ShowTestResultDto()
            {
                Finish = showTestResult.Finish,
                Id = showTestResult.Id,
                Question = showTestResult
                    .StudentTestSummaryQuestionDbos.Select(x => new ShowTestResultQuestionDto()
                    {
                        Id = x.Id,
                        IsTrue = x.IsTrue,
                        TestQuestionId = x.TestQuestionId,
                        AnswerMode = x.AnswerMode.SystemIdentificator,
                        Question = x.Question,
                        Score = x.Score,
                        IsAutomaticEvaluate = x.IsAutomaticEvaluate,
                        UserAnswers = x
                            .StudentTestSummaryAnswers.Select(y => new ShowTestResultAnswerDto()
                            {
                                Id = y.Id,
                                Answer = y.Answer,
                                IsTrueAnswer = y.IsTrueAnswer,
                                TestQuestionAnswerId = y.TestQuestionAnswerId,
                                Text = y.UserTestAnswer,
                                UserAnswer = y.UserAnswer,
                                UserAnswerIsCorrect = y.UserAnswerIsCorrect,
                                FilePath = y.FilePath,
                                UserTestImageAnswer = string.Format("{0}{1}.png", _fileRepositoryPath, y.UserTestImageAnswer)
                            })
                            .ToHashSet(),
                        FilePath = x.FilePath,
                        QuestionMode = x.QuestionMode.SystemIdentificator,
                        QuestionModeId = x.QuestionModeId
                    })
                    .ToHashSet(),
                Score = showTestResult.Score,
                StartTime = showTestResult.StartTime,
                TestCompleted = showTestResult.IsSucess,
                IsAutomaticEvaluate = showTestResult.IsAutomaticEvaluate,
            };
        }
    }
}
