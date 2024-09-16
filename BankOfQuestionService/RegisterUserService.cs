using BankOfQuestionService.Answer.AnswerCreate.Command;
using BankOfQuestionService.Answer.AnswerCreate.Convertor;
using BankOfQuestionService.Answer.AnswerCreate.Validator;
using BankOfQuestionService.Answer.AnswerDelete.Command;
using BankOfQuestionService.Answer.AnswerDetail.Command;
using BankOfQuestionService.Answer.AnswerDetail.Convertor;
using BankOfQuestionService.Answer.AnswerFileUpload.Command;
using BankOfQuestionService.Answer.AnswerList.Command;
using BankOfQuestionService.Answer.AnswerList.Convertor;
using BankOfQuestionService.Answer.AnswerRestore.Command;
using BankOfQuestionService.Answer.AnswerUpdate.Command;
using BankOfQuestionService.Answer.AnswerUpdate.Convertor;
using BankOfQuestionService.Answer.AnswerUpdate.Validator;
using BankOfQuestionService.Answer.DeleteAnswerInQuestion.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Validator;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDelete.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Service;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionRestore.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Validator;
using BankOfQuestionService.Question.QuestionCreate.Command;
using BankOfQuestionService.Question.QuestionCreate.Convertor;
using BankOfQuestionService.Question.QuestionCreate.Validator;
using BankOfQuestionService.Question.QuestionDelete.Command;
using BankOfQuestionService.Question.QuestionDetail.Command;
using BankOfQuestionService.Question.QuestionDetail.Convertor;
using BankOfQuestionService.Question.QuestionFileUpload.Command;
using BankOfQuestionService.Question.QuestionList.Command;
using BankOfQuestionService.Question.QuestionList.Convertor;
using BankOfQuestionService.Question.QuestionRestore.Command;
using BankOfQuestionService.Question.QuestionUpdate.Command;
using BankOfQuestionService.Question.QuestionUpdate.Convertor;
using BankOfQuestionService.Question.QuestionUpdate.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfQuestionService
{
    public static class RegisterBankOfQuestionService
    {
        public static void RegisterService(IServiceCollection service)
        {
            RegistratioBankOfQuestion(service);
            RegistrationQuestion(service);
            RegistrationAnswer(service);
        }

        public static void RegistratioBankOfQuestion(IServiceCollection service)
        {
            _ = service.AddScoped<IBankOfQuestionCreateConvertor, BankOfQuestionCreateConvertor>();
            _ = service.AddScoped<IBankOfQuestionCreateService, BankOfQuestionCreateService>();
            _ = service.AddScoped<IBankOfQuestionCreateValidator, BankOfQuestionCreateValidator>();
            _ = service.AddScoped<IBankOfQuestionDeleteService, BankOfQuestionDeleteService>();
            _ = service.AddScoped<IBankOfQuestionDetailConvertor, BankOfQuestionDetailConvertor>();
            _ = service.AddScoped<IBankOfQuestionDetailService, BankOfQuestionDetailService>();
            _ = service.AddScoped<IBankOfQuestionListConvertor, BankOfQuestionListConvertor>();
            _ = service.AddScoped<IBankOfQuestionListService, BankOfQuestionListService>();
            _ = service.AddScoped<IBankOfQuestionRestoreService, BankOfQuestionRestoreService>();
            _ = service.AddScoped<IBankOfQuestionUpdateConvertor, BankOfQuestionUpdateConvertor>();
            _ = service.AddScoped<IBankOfQuestionUpdateService, BankOfQuestionUpdateService>();
            _ = service.AddScoped<IBankOfQuestionUpdateValidator, BankOfQuestionUpdateValidator>();
            _ = service.AddScoped<IBankOfQuestionDropDownService, BankOfQuestionDropDownService>();
            _ = service.AddScoped<IBankOfQuestionDropDownConvertor, BankOfQuestionDropDownConvertor>();
        }

        public static void RegistrationQuestion(IServiceCollection service)
        {
            _ = service.AddScoped<IQuestionCreateConvertor, QuestionCreateConvertor>();
            _ = service.AddScoped<IQuestionCreateService, QuestionCreateService>();
            _ = service.AddScoped<IQuestionCreateValidator, QuestionCreateValidator>();
            _ = service.AddScoped<IQuestionDeleteService, QuestionDeleteService>();
            _ = service.AddScoped<IQuestionDetailConvertor, QuestionDetailConvertor>();
            _ = service.AddScoped<IQuestionDetailService, QuestionDetailService>();
            _ = service.AddScoped<IQuestionFileUploadFileUploadService, QuestionFileUploadFileUploadService>();
            _ = service.AddScoped<IQuestionListConvertor, QuestionListConvertor>();
            _ = service.AddScoped<IQuestionListService, QuestionListService>();
            _ = service.AddScoped<IQuestionRestoreService, QuestionRestoreService>();
            _ = service.AddScoped<IQuestionUpdateConvertor, QuestionUpdateConvertor>();
            _ = service.AddScoped<IQuestionUpdateService, QuestionUpdateService>();
            _ = service.AddScoped<IQuestionUpdateValidator, QuestionUpdateValidator>();
        }

        public static void RegistrationAnswer(IServiceCollection service)
        {
            _ = service.AddScoped<IAnswerCreateConvertor, AnswerCreateConvertor>();
            _ = service.AddScoped<IAnswerCreateCommand, AnswerCreateCommand>();
            _ = service.AddScoped<IAnswerCreateValidator, AnswerCreateValidator>();
            _ = service.AddScoped<IAnswerDeleteCommand, AnswerDeleteCommand>();
            _ = service.AddScoped<IAnswerDetailConvertor, AnswerDetailConvertor>();
            _ = service.AddScoped<IAnswerDetailCommand, AnswerDetailCommand>();
            _ = service.AddScoped<IAnswerFileUploadCommand, AnswerFileUploadCommand>();
            _ = service.AddScoped<IAnswerListConvertor, AnswerListConvertor>();
            _ = service.AddScoped<IAnswerListCommand, AnswerListCommand>();
            _ = service.AddScoped<IAnswerRestoreCommand, AnswerRestoreCommand>();
            _ = service.AddScoped<IAnswerUpdateConvertor, AnswerUpdateConvertor>();
            _ = service.AddScoped<IAnswerUpdateService, AnswerUpdateCommand>();
            _ = service.AddScoped<IAnswerUpdateValidator, AnswerUpdateValidator>();
            _ = service.AddScoped<IDeleteAnswerInQuestionCommnad, DeleteAnswerInQuestionCommand>();
        }




















    }
}
