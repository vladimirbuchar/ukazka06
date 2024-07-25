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
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Result<CourseTestDetailDto>> AddCourseTest(CourseTestCreateDto addCourseTestDto, string culture)
        {
            Result result = await _courseLessonValidator.IsValid(
                new CourseLessonCreateDto()
                {
                    MaterialId = addCourseTestDto.CourseLesson.MaterialId,
                    Name = addCourseTestDto.CourseLesson.Name,
                    Type = addCourseTestDto.CourseLesson.Type
                }
            );
            if (result.IsOk)
            {
                CourseLessonDbo courseLesson = await _courseLessonRepository.CreateEntity(
                    await _courseLessonConvertor.ConvertToBussinessEntity(
                        new CourseLessonCreateDto()
                        {
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
                Guid testId = (await _repository.CreateEntity(test, Guid.Empty)).Id;
                courseLesson.CourseTestId = testId;
                _ = await _courseLessonRepository.UpdateEntity(courseLesson, Guid.Empty);

                foreach (Guid bankOfQuestionId in addCourseTestDto.BankOfQuestion)
                {
                    _ = await _courseTestBankOfQuestionRepository.CreateEntity(
                        new CourseTestBankOfQuestionDbo() { CourseTestId = testId, BankOfQuestionId = bankOfQuestionId },
                        Guid.Empty
                    );
                }

                return new Result<CourseTestDetailDto>() { Data = await GetCourseTestDetail(courseLesson.Id, culture) };
            }
            return (Result<CourseTestDetailDto>)result;
        }

        public async Task<CourseTestDetailDto> GetCourseTestDetail(Guid courseLessonId, string culture = "")
        {
            CourseTestDbo getCourseTestDetail = await _repository.GetEntity(false, x => x.CourseLessonId == courseLessonId);
            return getCourseTestDetail == null ? null : _convertor.ConvertToWebModel(getCourseTestDetail, culture);
        }

        public async Task<Result<CourseTestDetailDto>> UpdateCourseTest(CourseTestUpdateDto updateCourseTestDto, string culture)
        {
            Result result = await _courseLessonValidator.IsValid(
                new CourseLessonUpdateDto()
                {
                    Name = updateCourseTestDto.CourseLessonUpdate.Name,
                    Id = updateCourseTestDto.CourseLessonUpdate.Id
                }
            );
            if (result.IsOk)
            {
                CourseLessonDbo courseLesson = await _courseLessonRepository.GetEntity(updateCourseTestDto.Id);
                _ = await _courseLessonRepository.UpdateEntity(
                    await _courseLessonConvertor.ConvertToBussinessEntity(
                        new CourseLessonUpdateDto()
                        {
                            Id = updateCourseTestDto.CourseLessonUpdate.Id,
                            Name = updateCourseTestDto.CourseLessonUpdate.Name
                        },
                        courseLesson,
                        culture
                    ),
                    Guid.Empty
                );
                CourseTestDbo test = await _repository.GetEntity(false, x => x.CourseLessonId == updateCourseTestDto.Id);
                foreach (CourseTestBankOfQuestionDbo item in test.CourseTestBankOfQuestions)
                {
                    if (!updateCourseTestDto.BankOfQuestion.Contains(item.BankOfQuestionId))
                    {
                        await _courseTestBankOfQuestionRepository.DeleteEntity(item.Id, Guid.Empty);
                    }
                }
                foreach (Guid bankOfQuestionId in updateCourseTestDto.BankOfQuestion)
                {
                    if (!test.CourseTestBankOfQuestions.Select(x => x.BankOfQuestionId).Contains(bankOfQuestionId))
                    {
                        _ = await _courseTestBankOfQuestionRepository.CreateEntity(
                            new CourseTestBankOfQuestionDbo() { CourseTestId = test.Id, BankOfQuestionId = bankOfQuestionId },
                            Guid.Empty
                        );
                    }
                }
                test = _convertor.ConvertToBussinessEntity(updateCourseTestDto, test);
                CourseTestDbo getCourseTestDetail = await _repository.UpdateEntity(test, Guid.Empty);
            }
            return new Result<CourseTestDetailDto>() { Data = await GetCourseTestDetail(updateCourseTestDto.Id, culture) };
        }
    }
}
