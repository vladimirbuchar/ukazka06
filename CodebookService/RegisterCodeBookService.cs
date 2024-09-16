using CodebookService.AddressTypeDropDown.Command;
using CodebookService.AddressTypeDropDown.Convertor;
using CodebookService.AnswerModeDropDown.Command;
using CodebookService.AnswerModeDropDown.Convertor;
using CodebookService.CountryDropDown.Command;
using CodebookService.CountryDropDown.Convertor;
using CodebookService.CourseLessonItemTemplateDropDown.Command;
using CodebookService.CourseLessonItemTemplateDropDown.Convertor;
using CodebookService.CourseStatusDropDown.Command;
using CodebookService.CourseStatusDropDown.Convertor;
using CodebookService.CourseTypeDropDown.Command;
using CodebookService.CourseTypeDropDown.Convertor;
using CodebookService.CultureDetail.Command;
using CodebookService.CultureDetail.Convertor;
using CodebookService.CultureDropDown.Command;
using CodebookService.CultureDropDown.Convertor;
using CodebookService.EmailTypeDropDown.Command;
using CodebookService.EmailTypeDropDown.Convertor;
using CodebookService.LicenceList.Command;
using CodebookService.LicenceList.Convertor;
using CodebookService.LicenseDropDown.Command;
using CodebookService.LicenseDropDown.Convertor;
using CodebookService.NoteTypeDropDown.Command;
using CodebookService.NoteTypeDropDown.Convertor;
using CodebookService.QuestionModeDropDown.Command;
using CodebookService.QuestionModeDropDown.Convertor;
using CodebookService.SendMessageTypeDropDown.Command;
using CodebookService.SendMessageTypeDropDown.Convertor;
using CodebookService.TimeTableDropDown.Command;
using CodebookService.TimeTableDropDown.Convertor;
using Microsoft.Extensions.DependencyInjection;

namespace CodebookService
{
    public static class RegisterCodeBookService
    {
        public static void RegistrationCodeBook(IServiceCollection service)
        {
            _ = service.AddScoped<ICultureDetailCommand, CultureDetailCommand>();
            _ = service.AddScoped<ICultureDetailConvertor, CultureDetailConvertor>();
            _ = service.AddScoped<ILicenseDropDownService, LicenseDropDownService>();
            _ = service.AddScoped<ICourseTypeDropDownService, CourseTypeDropDownService>();
            _ = service.AddScoped<ICourseStatusDropDownService, CourseStatusDropDownService>();
            _ = service.AddScoped<ITimeTableDropDownService, TimeTableDropDownService>();
            _ = service.AddScoped<ICountryDropDownService, CountryDropDownService>();
            _ = service.AddScoped<IAnswerModeDropDownService, AnswerModeDropDownService>();
            _ = service.AddScoped<IAddressTypeDropDownService, AddressTypeDropDownService>();
            _ = service.AddScoped<ICourseLessonItemTemplateDropDownService, CourseLessonItemTemplateDropDownService>();
            _ = service.AddScoped<ICultureDropDownService, CultureDropDownService>();
            _ = service.AddScoped<ISendMessageTypeDropDownService, SendMessageTypeDropDownService>();
            _ = service.AddScoped<IQuestionModeDropDownService, QuestionModeDropDownService>();
            _ = service.AddScoped<INoteTypeDropDownService, NoteTypeDropDownService>();
            _ = service.AddScoped<IEmailTypeDropDownService, EmailTypeDropDownService>();
            _ = service.AddScoped<ICountryDropDownConvertor, CountryDropDownConvertor>();
            _ = service.AddScoped<IAddressTypeDropDownConvertor, AddressTypeDropDownConvertor>();
            _ = service.AddScoped<IAnswerModeDropDownConvertor, AnswerModeDropDownConvertor>();
            _ = service.AddScoped<ICourseLessonItemTemplateDropDownConvertor, CourseLessonItemTemplateDropDownConvertor>();
            _ = service.AddScoped<ICourseStatusDropDownConvertor, CourseStatusDropDownConvertor>();
            _ = service.AddScoped<ICourseTypeDropDownConvertor, CourseTypeDropDownConvertor>();
            _ = service.AddScoped<ICultureDropDownConvertor, CultureDropDownConvertor>();
            _ = service.AddScoped<IEmailTypeDropDownConvertor, EmailTypeDropDownConvertor>();
            _ = service.AddScoped<ILicenseDropDownConvertor, LicenseDropDownConvertor>();
            _ = service.AddScoped<INoteTypeDropDownConvertor, NoteTypeDropDownConvertor>();
            _ = service.AddScoped<IQuestionModeDropDownConvertor, QuestionModeDropDownConvertor>();
            _ = service.AddScoped<ISendMessageTypeDropDownConvertor, SendMessageTypeDropDownConvertor>();
            _ = service.AddScoped<ITimeTableDropDownConvertor, TimeTableDropDownConvertor>();
            _ = service.AddScoped<ILicenceListService, LicenceListService>();
            _ = service.AddScoped<ILicenceListConvertor, LicenceListConvertor>();
        }
    }
}
