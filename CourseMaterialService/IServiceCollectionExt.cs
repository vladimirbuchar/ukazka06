using CourseMaterialService.CourseLesson.CourseLessonCreate.Command;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Validator;
using CourseMaterialService.CourseLesson.CourseLessonDelete.Command;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Command;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Conveertor;
using CourseMaterialService.CourseLesson.CourseLessonFileUpload.Command;
using CourseMaterialService.CourseLesson.CourseLessonList.Command;
using CourseMaterialService.CourseLesson.CourseLessonList.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonRestore.Command;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Command;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Validator;
using CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Validator;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDelete.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemFileDelete.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemFileUpload.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemRestore.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Command;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Validator;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Validator;
using CourseMaterialService.CourseMaterial.CourseMaterialDelete.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialFileDelete.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialFileUpload.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialRestore.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Command;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Validate;
using CourseMaterialService.CourseMaterial.GetFiles.Command;
using CourseMaterialService.CourseMaterial.GetFiles.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Command;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Validator;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationDelete.Command;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Command;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Command;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMaterialService
{
    public static class RegisterCourseMaterialService
    {
        public static void RegistrationCourseTestEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTestEvaluationCreateConvertor, CourseTestEvaluationCreateConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationCreateService, CourseTestEvaluationCreateService>();
            _ = service.AddScoped<ICourseTestEvaluationCreateValidator, CourseTestEvaluationCreateValidator>();
            _ = service.AddScoped<ICourseTestEvaluationDeleteService, CourseTestEvaluationDeleteService>();
            _ = service.AddScoped<ICourseTestEvaluationListConvertor, CourseTestEvaluationListConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationListService, CourseTestEvaluationListService>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateConvertor, CourseTestEvaluationUpdateConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateService, CourseTestEvaluationUpdateService>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateValidator, CourseTestEvaluationUpdateValidator>();

        }


        public static void RegistrationCourseLesson(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonCreateConvertor, CourseLessonCreateConvertor>();
            _ = service.AddScoped<ICourseLessonCreateService, CourseLessonCreateService>();
            _ = service.AddScoped<ICourseLessonCreateValidator, CourseLessonCreateValidator>();
            _ = service.AddScoped<ICourseLessonDeleteService, CourseLessonDeleteService>();
            _ = service.AddScoped<ICourseLessonDetailConvertor, CourseLessonDetailConvertor>();
            _ = service.AddScoped<ICourseLessonDetailService, CourseLessonDetailService>();
            _ = service.AddScoped<ICourseLessonListConvertor, CourseLessonListConvertor>();
            _ = service.AddScoped<ICourseLessonListService, CourseLessonListService>();
            _ = service.AddScoped<ICourseLessonRestoreService, CourseLessonRestoreService>();
            _ = service.AddScoped<ICourseLessonUpdateConvertor, CourseLessonUpdateConvertor>();
            _ = service.AddScoped<ICourseLessonUpdateService, CourseLessonUpdateService>();
            _ = service.AddScoped<ICourseLessonUpdateValidator, CourseLessonUpdateValidator>();
            _ = service.AddScoped<ICourseLessonUpdatePositionService, CourseLessonUpdatePositionService>();
            _ = service.AddScoped<ICourseLessonFileUploadService, CourseLessonFileUploadService>();
        }

        public static void RegistrationCourseLessonItem(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonItemCreateConvertor, CourseLessonItemCreateConvertor>();
            _ = service.AddScoped<ICourseLessonItemCreateService, CourseLessonItemCreateService>();
            _ = service.AddScoped<ICourseLessonItemCreateValidator, CourseLessonItemCreateValidator>();
            _ = service.AddScoped<ICourseLessonItemDeleteService, CourseLessonItemDeleteService>();
            _ = service.AddScoped<ICourseLessonItemDetailConvertor, CourseLessonItemDetailConvertor>();
            _ = service.AddScoped<ICourseLessonItemDetailService, CourseLessonItemDetailService>();
            _ = service.AddScoped<ICourseLessonItemListConvertor, CourseLessonItemListConvertor>();
            _ = service.AddScoped<ICourseLessonItemListService, CourseLessonItemListService>();
            _ = service.AddScoped<ICourseLessonItemRestoreService, CourseLessonItemRestore>();
            _ = service.AddScoped<ICourseLessonItemUpdateConvertor, CourseLessonItemUpdateConvertor>();
            _ = service.AddScoped<ICourseLessonItemUpdateService, CourseLessonItemUpdateService>();
            _ = service.AddScoped<ICourseLessonItemUpdateValidator, CourseLessonItemUpdateValidator>();
            _ = service.AddScoped<ICourseLessonItemUpdatePositionService, CourseLessonItemUpdatePositionService>();
            _ = service.AddScoped<ICourseLessonItemFileUploadService, CourseLessonItemFileUploadService>();
            _ = service.AddScoped<ICourseLessonItemFileDeleteService, CourseLessonItemFileDeleteService>();
        }


        public static void RegisterCourseMaterial(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseMaterialCreateConvertor, CourseMaterialCreateConvertor>();
            _ = service.AddScoped<ICourseMaterialCreateService, CourseMaterialCreateService>();
            _ = service.AddScoped<ICourseMaterialCreateValidator, CourseMaterialCreateValidator>();
            _ = service.AddScoped<ICourseMaterialDeleteService, CourseMaterialDeleteService>();
            _ = service.AddScoped<ICourseMaterialDetailConvertor, CourseMaterialDetailConvertor>();
            _ = service.AddScoped<ICourseMaterialDetailService, CourseMaterialDetailService>();
            _ = service.AddScoped<ICourseMaterialListConvertor, CourseMaterialListConvertor>();
            _ = service.AddScoped<ICourseMaterialListService, CourseMaterialListService>();
            _ = service.AddScoped<ICourseMaterialRestoreService, CourseMaterialRestoreService>();
            _ = service.AddScoped<ICourseMaterialUpdateConvertor, CourseMaterialUpdateConvertor>();
            _ = service.AddScoped<ICourseMaterialUpdateService, CourseMaterialUpdateService>();
            _ = service.AddScoped<ICourseMaterialUpdateValidator, CourseMaterialUpdateValidator>();
            _ = service.AddScoped<IGetFilesConvertor, GetFilesConvertor>();
            _ = service.AddScoped<IGetFilesService, GetFilesService>();
            _ = service.AddScoped<ICourseMaterialFileUploadService, CourseMaterialFileUploadService>();
            _ = service.AddScoped<ICourseMaterialFileDeleteService, CourseMaterialFileDeleteService>();
        }


    }
}
