using Microsoft.Extensions.DependencyInjection;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Command;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Convertor;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Validator;
using UserService.LinkLifeTime.LinkLifeTimeDelete.Command;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Command;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Convertor;
using UserService.Note.NoteCreate.Command;
using UserService.Note.NoteCreate.Convertor;
using UserService.Note.NoteCreate.Validator;
using UserService.Note.NoteDelete.Command;
using UserService.Note.NoteDetail.Command;
using UserService.Note.NoteDetail.Convertor;
using UserService.Note.NoteImageCreate.Command;
using UserService.Note.NoteImageCreate.Convertor;
using UserService.Note.NoteImageCreate.Validator;
using UserService.Note.NoteImageUpdate.Command;
using UserService.Note.NoteImageUpdate.Convertor;
using UserService.Note.NoteImageUpdate.Validator;
using UserService.Note.NoteList.Command;
using UserService.Note.NoteList.Convertor;
using UserService.Note.NoteRestore.Command;
using UserService.Note.NoteUpdate.Command;
using UserService.Note.NoteUpdate.Convertor;
using UserService.Note.NoteUpdate.Validate;
using UserService.Notification.NotificationCreate.Command;
using UserService.Notification.NotificationCreate.Convertor;
using UserService.Notification.NotificationCreate.Validator;
using UserService.Notification.NotificationList.Command;
using UserService.Notification.NotificationList.Convertor;
using UserService.Notification.NotificationUpdate.Command;
using UserService.Notification.NotificationUpdate.Convertor;
using UserService.Notification.NotificationUpdate.Validator;
using UserService.Role.RoleDetail.Command;
using UserService.Role.RoleDetail.Convertor;
using UserService.User.ActivateUser.Command;
using UserService.User.ActivateUser.Convertor;
using UserService.User.ActivateUser.Validator;
using UserService.User.GeneratePassword.Command;
using UserService.User.GetUserToken.Command;
using UserService.User.GetUserTokenAdmin.Command;
using UserService.User.GetUserTokenBysocialNetwork.Command;
using UserService.User.RegisterUser.Command;
using UserService.User.RegisterUser.Convertor;
using UserService.User.RegisterUser.Validator;
using UserService.User.SetNewPassword.Command;
using UserService.User.SetNewPassword.Validator;
using UserService.User.Shared.Convertor;
using UserService.User.UserDetail.Command;
using UserService.User.UserDetail.Convertor;

namespace UserService
{
    public static class RegisterUserService
    {

        public static void RegisterService(IServiceCollection service)
        {
            RegisterLifeTime(service);
            RegisterNote(service);
            //RegisterNotification(service);
            RegisterRole(service);
        }
        private static void RegisterLifeTime(IServiceCollection service)
        {
            _ = service.AddScoped<ILinkLifeTimeServiceDetailService, LinkLifeTimeServiceDetailService>();
            _ = service.AddScoped<ILinkLifeTimeServiceDetailConvertor, LinkLifeTimeServiceDetailConvertor>();
            _ = service.AddScoped<ILinkLifeTimeDeleteService, LinkLifeTimeDeleteService>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateService, LinkLifeTimeServiceCreateService>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateConvertor, LinkLifeTimeServiceCreateConvertor>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateValidator, LinkLifeTimeServiceCreateValidator>();
        }
        private static void RegisterNote(IServiceCollection service)
        {

            _ = service.AddScoped<INoteCreateCommand, NoteCreateCommand>();
            _ = service.AddScoped<INoteCreateConvertor, NoteCreateConvertor>();
            _ = service.AddScoped<INoteCreateValidator, NoteCreateValidator>();
            _ = service.AddScoped<INoteDeleteCommand, NoteDeleteCommand>();
            _ = service.AddScoped<INoteDetailConvertor, NoteDetailConvertor>();
            _ = service.AddScoped<INoteDetailCommand, NoteDetailCommand>();
            _ = service.AddScoped<INoteImageCreateCommand, NoteImageCreateCommand>();
            _ = service.AddScoped<INoteImageCreateConvertor, NoteImageCreateConvertor>();
            _ = service.AddScoped<INoteImageCreateValidator, NoteImageCreateValidator>();
            _ = service.AddScoped<INoteImageUpdateCommand, NoteImageUpdateCommand>();
            _ = service.AddScoped<INoteImageUpdateConvertor, NoteImageUpdateConvertor>();
            _ = service.AddScoped<INoteImageUpdateValidator, NoteImageUpdateValidator>();
            _ = service.AddScoped<INoteListConvertor, NoteListConvertor>();
            _ = service.AddScoped<INoteListCommand, NoteListCommand>();
            _ = service.AddScoped<INoteRestoreCommand, NoteRestoreCommand>();
            _ = service.AddScoped<INoteUpdateCommand, NoteUpdateCommand>();
            _ = service.AddScoped<INoteUpdateConvertor, NoteUpdateConvertor>();
            _ = service.AddScoped<INoteUpdateValidator, NoteUpdateValidator>();
            _ = service.AddScoped<IUserDetailService, UserDetailService>();
            _ = service.AddScoped<IRegisterUserService, UserService.User.RegisterUser.Command.RegisterUserService>();
            _ = service.AddScoped<IUserDetailConvertor, UserDetailConvertor>();
            _ = service.AddScoped<IRegisterUserConvertor, RegisterUserConvertor>();
            _ = service.AddScoped<IRegisterUserValidator, RegisterUserValidator>();
            _ = service.AddScoped<ISetNewPasswordService, SetNewPasswordService>();
            _ = service.AddScoped<ISetNewPasswordValidator, SetNewPasswordValidator>();
            _ = service.AddScoped<IActivateUserService, ActivateUserService>();
            _ = service.AddScoped<IActivateUserConvertor, ActivateUserConvertor>();
            _ = service.AddScoped<IActivateUserValidator, ActivateUserValidator>();
            _ = service.AddScoped<IGetUserTokenBysocialNetworkService, GetUserTokenBySocialNetworkService>();
            _ = service.AddScoped<IGetUserTokenConvertor, GetUserTokenConvertor>();
            _ = service.AddScoped<IGetUserTokenService, GetUserTokenService>();
            _ = service.AddScoped<IGetUserTokenAdminService, GetUserTokenAdminService>();
            _ = service.AddScoped<IGeneratePasswordService, GeneratePasswordService>();

        }
        private static void RegisterNotification(IServiceCollection service)
        {

            _ = service.AddScoped<INotificationCreateConvertor, NotificationCreateConvertor>();
            _ = service.AddScoped<INotificationCreateService, NotificationCreateService>();
            _ = service.AddScoped<INotificationCreateValidator, NotificationCreateValidator>();
            _ = service.AddScoped<INotificationListService, NotificationListService>();
            _ = service.AddScoped<INotificationListConvertor, NotificationListConvertor>();
            _ = service.AddScoped<INotificationUpdateService, NotificationUpdateService>();
            _ = service.AddScoped<INotificationUpdateConvertor, NotificationUpdateConvertor>();
            _ = service.AddScoped<INotificationUpdateValidator, NotificationUpdateValidator>();
        }
        public static void RegisterRole(IServiceCollection service)
        {
            _ = service.AddScoped<IRoleDetailService, RoleDetailService>();
            _ = service.AddScoped<IRoleDetailConvertor, RoleDetailConvertor>();
        }

    }
}
