using System;
using System.Linq;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Model.Edu.CourseTest;
using Model.Link;
using Repository.CourseLessonRepository;
using Repository.CourseTestBankOfQuestionRepository;
using Repository.TestRepository;
using Services.CourseLesson.Convertor;
using Services.CourseLesson.Dto;
using Services.CourseLesson.Validator;
using Services.Test.Convertor;
using Services.Test.Dto;

namespace Services.Test.Service
{
    public class TestService(
        ICourseLessonConvertor courseLessonConvertor,
        ICourseLessonValidator courseLessonValidator,
        ICourseTestBankOfQuestionRepository courseTestBankOfQuestionRepository,
        ITestConvertor testConvertor,
        ICourseLessonRepository courseLessonRepository,
        ITestRepository testRepository
    ) : BaseService<ITestRepository, CourseTestDbo, ITestConvertor>(testRepository, testConvertor), ITestService
    {
        private readonly ICourseTestBankOfQuestionRepository _courseTestBankOfQuestionRepository = courseTestBankOfQuestionRepository;
        private readonly ICourseLessonValidator _courseLessonValidator = courseLessonValidator;
        private readonly ICourseLessonConvertor _courseLessonConvertor = courseLessonConvertor;
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;

        public Result<CourseTestDetailDto> AddCourseTest(CourseTestCreateDto addCourseTestDto, string culture)
        {
            Result result = _courseLessonValidator.IsValid(
                new CourseLessonCreateDto()
                {
                    Description = addCourseTestDto.CourseLesson.Description,
                    MaterialId = addCourseTestDto.CourseLesson.MaterialId,
                    Name = addCourseTestDto.CourseLesson.Name,
                    Type = addCourseTestDto.CourseLesson.Type
                }
            );
            if (result.IsOk)
            {
                CourseLessonDbo courseLesson = _courseLessonRepository.CreateEntity(
                    _courseLessonConvertor.ConvertToBussinessEntity(
                        new CourseLessonCreateDto()
                        {
                            Description = addCourseTestDto.CourseLesson.Description,
                            MaterialId = addCourseTestDto.CourseLesson.MaterialId,
                            Name = addCourseTestDto.CourseLesson.Name,
                            Type = addCourseTestDto.CourseLesson.Type
                        },
                        culture
                    ),
                    Guid.Empty
                );
                CourseTestDbo test = _convertor.ConvertToBussinessEntity(addCourseTestDto);
                test.CourseLessonId = courseLesson.Id;
                Guid testId = _repository.CreateEntity(test, Guid.Empty).Id;
                courseLesson.CourseTestId = testId;
                _ = _courseLessonRepository.UpdateEntity(courseLesson, Guid.Empty);

                foreach (Guid bankOfQuestionId in addCourseTestDto.BankOfQuestion)
                {
                    _ = _courseTestBankOfQuestionRepository.CreateEntity(
                        new CourseTestBankOfQuestionDbo() { CourseTestId = testId, BankOfQuestionId = bankOfQuestionId },
                        Guid.Empty
                    );
                }

                return new Result<CourseTestDetailDto>() { Data = GetCourseTestDetail(courseLesson.Id, culture) };
            }
            return (Result<CourseTestDetailDto>)result;
        }

        public CourseTestDetailDto GetCourseTestDetail(Guid courseLessonId, string culture = "")
        {
            CourseTestDbo getCourseTestDetail = _repository.GetEntity(false, x => x.CourseLessonId == courseLessonId);
            return getCourseTestDetail == null ? null : _convertor.ConvertToWebModel(getCourseTestDetail, culture);
        }

        public Result<CourseTestDetailDto> UpdateCourseTest(CourseTestUpdateDto updateCourseTestDto, string culture)
        {
            Result result = _courseLessonValidator.IsValid(
                new CourseLessonUpdateDto()
                {
                    Name = updateCourseTestDto.CourseLessonUpdate.Name,
                    Description = updateCourseTestDto.CourseLessonUpdate.Description,
                    Id = updateCourseTestDto.CourseLessonUpdate.Id
                }
            );
            if (result.IsOk)
            {
                CourseLessonDbo courseLesson = _courseLessonRepository.GetEntity(updateCourseTestDto.Id);
                _ = _courseLessonRepository.UpdateEntity(
                    _courseLessonConvertor.ConvertToBussinessEntity(
                        new CourseLessonUpdateDto()
                        {
                            Description = updateCourseTestDto.CourseLessonUpdate.Description,
                            Id = updateCourseTestDto.CourseLessonUpdate.Id,
                            Name = updateCourseTestDto.CourseLessonUpdate.Name
                        },
                        courseLesson,
                        culture
                    ),
                    Guid.Empty
                );
                CourseTestDbo test = _repository.GetEntity(false, x => x.CourseLessonId == updateCourseTestDto.Id);
                foreach (CourseTestBankOfQuestionDbo item in test.CourseTestBankOfQuestions)
                {
                    if (!updateCourseTestDto.BankOfQuestion.Contains(item.BankOfQuestionId))
                    {
                        _courseTestBankOfQuestionRepository.DeleteEntity(item.Id, Guid.Empty);
                    }
                }
                foreach (Guid bankOfQuestionId in updateCourseTestDto.BankOfQuestion)
                {
                    if (!test.CourseTestBankOfQuestions.Select(x => x.BankOfQuestionId).Contains(bankOfQuestionId))
                    {
                        _ = _courseTestBankOfQuestionRepository.CreateEntity(
                            new CourseTestBankOfQuestionDbo() { CourseTestId = test.Id, BankOfQuestionId = bankOfQuestionId },
                            Guid.Empty
                        );
                    }
                }
                test = _convertor.ConvertToBussinessEntity(updateCourseTestDto, test);
                CourseTestDbo getCourseTestDetail = _repository.UpdateEntity(test, Guid.Empty);
            }
            return new Result<CourseTestDetailDto>() { Data = GetCourseTestDetail(updateCourseTestDto.Id, culture) };
        }
    }
}
