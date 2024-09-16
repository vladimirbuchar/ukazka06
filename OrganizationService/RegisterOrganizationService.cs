using Microsoft.Extensions.DependencyInjection;
using OrganizationService.Branch.BranchCreate.Command;
using OrganizationService.Branch.BranchCreate.Convertor;
using OrganizationService.Branch.BranchCreate.Validator;
using OrganizationService.Branch.BranchDelete.Command;
using OrganizationService.Branch.BranchDetail.Command;
using OrganizationService.Branch.BranchDetail.Convertor;
using OrganizationService.Branch.BranchList.Command;
using OrganizationService.Branch.BranchList.Convertor;
using OrganizationService.Branch.BranchRestore.Command;
using OrganizationService.Branch.BranchUpdate.Command;
using OrganizationService.Branch.BranchUpdate.Convertor;
using OrganizationService.Branch.BranchUpdate.Validator;
using OrganizationService.Branch.ChangeMainBranch.Command;
using OrganizationService.Certificate.CertificateDropDown.Command;
using OrganizationService.Certificate.CertificateDropDown.Convertor;
using OrganizationService.ClassRoom.ClassRoomCreate.Command;
using OrganizationService.ClassRoom.ClassRoomCreate.Convertor;
using OrganizationService.ClassRoom.ClassRoomCreate.Validator;
using OrganizationService.ClassRoom.ClassRoomDelete.Command;
using OrganizationService.ClassRoom.ClassRoomDetail.Command;
using OrganizationService.ClassRoom.ClassRoomDetail.Convertor;
using OrganizationService.ClassRoom.ClassRoomDropDown.Convertor;
using OrganizationService.ClassRoom.ClassRoomDropDown.Service;
using OrganizationService.ClassRoom.ClassRoomList.Command;
using OrganizationService.ClassRoom.ClassRoomList.Convertor;
using OrganizationService.ClassRoom.ClassRoomRestore.Command;
using OrganizationService.ClassRoom.ClassRoomTimeTable.Command;
using OrganizationService.ClassRoom.ClassRoomUpdate.Command;
using OrganizationService.ClassRoom.ClassRoomUpdate.Convertor;
using OrganizationService.ClassRoom.ClassRoomUpdate.Validator;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Command;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Validator;
using OrganizationService.MessageTemplate.MessageTemplateDelete.Command;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Command;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.MessageTemplateDropDownConvertor;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.Service;
using OrganizationService.MessageTemplate.MessageTemplateList.Command;
using OrganizationService.MessageTemplate.MessageTemplateList.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateRestore.Command;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Command;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Validator;
using OrganizationService.Organization.OrganizationCreate.Command;
using OrganizationService.Organization.OrganizationCreate.Convertor;
using OrganizationService.Organization.OrganizationCreate.Validator;
using OrganizationService.Organization.OrganizationDelete.Command;
using OrganizationService.Organization.OrganizationDetail.Command;
using OrganizationService.Organization.OrganizationDetail.Convertor;
using OrganizationService.Organization.OrganizationFileUpload.Command;
using OrganizationService.Organization.OrganizationList.Command;
using OrganizationService.Organization.OrganizationList.Convertor;
using OrganizationService.Organization.OrganizationUpdate.Command;
using OrganizationService.Organization.OrganizationUpdate.Convertor;
using OrganizationService.Organization.OrganizationUpdate.Validator;
using OrganizationService.Organization.OrganizationWebDetail.Command;
using OrganizationService.Organization.OrganizationWebDetail.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Command;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Validator;
using OrganizationService.OrganizationCulture.OrganizationCultureDelete.Command;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Command;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureRestore.Command;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Command;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Validator;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Command;
using OrganizationService.OrganizationRole.OrganizationRoleDetail.Convertor;
using OrganizationService.OrganizationRole.OrganizationRoleList.Command;
using OrganizationService.OrganizationRole.OrganizationRoleList.Convertor;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Command;
using OrganizationService.OrganizationSetting.GetOrganizationSetting.Convertor;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Command;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Convertor;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Command;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Convertor;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Validator;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Validator;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDelete.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Service;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourList.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourRestore.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Command;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Validator;
using OrganizationService.SendMail.SendMailCreate.Command;
using OrganizationService.SendMail.SendMailCreate.Convertor;
using OrganizationService.SendMail.SendMailCreate.Validator;
using OrganizationService.SendMail.SendMailDetail.Command;
using OrganizationService.SendMail.SendMailDetail.Convertor;
using OrganizationService.SendMail.SendMailList.Command;
using OrganizationService.SendMail.SendMailList.Convertor;
using OrganizationService.SendMail.SendMailUpdate.Command;
using OrganizationService.SendMail.SendMailUpdate.Convertor;
using OrganizationService.SendMail.SendMailUpdate.Validator;
using OrganizationService.StudentGroup.StudentGroupCreate.Command;
using OrganizationService.StudentGroup.StudentGroupCreate.Convertor;
using OrganizationService.StudentGroup.StudentGroupCreate.Validator;
using OrganizationService.StudentGroup.StudentGroupDelete.Command;
using OrganizationService.StudentGroup.StudentGroupDetail.Command;
using OrganizationService.StudentGroup.StudentGroupDetail.Convertor;
using OrganizationService.StudentGroup.StudentGroupDropDown.Convertor;
using OrganizationService.StudentGroup.StudentGroupDropDown.Service;
using OrganizationService.StudentGroup.StudentGroupList.Command;
using OrganizationService.StudentGroup.StudentGroupList.Convertor;
using OrganizationService.StudentGroup.StudentGroupRestore.Command;
using OrganizationService.StudentGroup.StudentGroupUpdate.Command;
using OrganizationService.StudentGroup.StudentGroupUpdate.Convertor;
using OrganizationService.StudentGroup.StudentGroupUpdate.Validator;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Command;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Validator;
using OrganizationService.StudentInGroup.StudentInGroupDelete.Command;
using OrganizationService.StudentInGroup.StudentInGroupList.Command;
using OrganizationService.StudentInGroup.StudentInGroupList.Convertor;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Command;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Validator;
using OrganizationService.UserInOrganization.UserInOrganizationDelete.Command;
using OrganizationService.UserInOrganization.UserInOrganizationDetail.Command;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Convertor;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Service;
using OrganizationService.UserInOrganization.UserInOrganizationList.Command;
using OrganizationService.UserInOrganization.UserInOrganizationList.Convertor;
using OrganizationService.UserInOrganization.UserInOrganizationRestore.Command;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Command;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Vadlidator;

namespace OrganizationService
{
    public static class RegisterOrganizationService
    {

        public static void RegisterService(IServiceCollection service)
        {
            RegistrationStudentInGroup(service);
            RegistrationOrganizationStudyHour(service);
            RegistrationOrganizationSetting(service);
            RegisterBranch(service);
            RegistrationClassRoom(service);
            RegisterSendMessage(service);
            RegisterStudentGroup(service);
            RegistrationPermissions(service);
            RegistrationOrganizationCulture(service);
        }
        public static void RegistrationStudentInGroup(IServiceCollection service)
        {
            _ = service.AddScoped<IStudentInGroupCreateService, StudentInGroupCreateService>();
            _ = service.AddScoped<IStudentInGroupCreateValidator, StudentInGroupCreateValidator>();
            _ = service.AddScoped<IStudentInGroupDeleteService, StudentInGroupDeleteService>();
            _ = service.AddScoped<IStudentInGroupListConvertor, StudentInGroupListConvertor>();
            _ = service.AddScoped<IStudentInGroupListService, StudentInGroupListService>();

        }


        public static void RegistrationOrganizationCulture(IServiceCollection service)
        {

            _ = service.AddScoped<IOrganizationCultureCreateService, OrganizationCultureCreateService>();
            _ = service.AddScoped<IOrganizationCultureCreateConvertor, OrganizationCultureCreateConvertor>();
            _ = service.AddScoped<IOrganizationCultureCreateValidator, OrganizationCultureCreateValidator>();
            _ = service.AddScoped<IOrganizationCultureListService, OrganizationCultureListService>();
            _ = service.AddScoped<IOrganizationCultureListConvertor, OrganizationCultureListConvertor>();
            _ = service.AddScoped<IOrganizationCultureUpdateService, OrganizationCultureUpdateService>();
            _ = service.AddScoped<IOrganizationCultureUpdateConvertor, OrganizationCultureUpdateConvertor>();
            _ = service.AddScoped<IOrganizationCultureUpdateValidator, OrganizationCultureUpdateValidator>();
            _ = service.AddScoped<IOrganizationCultureDeleteService, OrganizationCultureDeleteService>();
            _ = service.AddScoped<IOrganizationCultureRestoreService, OrganizationCultureRestoreService>();
        }





        public static void RegistrationOrganizationStudyHour(IServiceCollection service)
        {

            _ = service.AddScoped<IOrganizationStudyHourCreateService, OrganizationStudyHourCreateService>();
            _ = service.AddScoped<IOrganizationStudyHourCreateConvertor, OrganizationStudyHourCreateConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourCreateValidator, OrganizationStudyHourCreateValidator>();
            _ = service.AddScoped<IOrganizationStudyHourDeleteService, OrganizationStudyHourDeleteService>();
            _ = service.AddScoped<IOrganizationStudyHourListService, OrganizationStudyHourListService>();
            _ = service.AddScoped<IOrganizationStudyHourListConvertor, OrganizationStudyHourListConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourRestoreService, OrganizationStudyHourRestoreService>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateService, OrganizationStudyHourUpdateService>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateConvertor, OrganizationStudyHourUpdateConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateValidator, OrganizationStudyHourUpdateValidator>();
            _ = service.AddScoped<IOrganizationRoleListConvertor, OrganizationRoleListConvertor>();
            _ = service.AddScoped<IOrganizationRoleListService, OrganizationRoleListService>();
            _ = service.AddScoped<IUserInOrganizationCreateService, UserInOrganizationCreateService>();
            _ = service.AddScoped<IUserInOrganizationCreateValidator, UserInOrganizationCreateValidator>();
            _ = service.AddScoped<IUserInOrganizationDeleteService, UserInOrganizationDeleteService>();
            _ = service.AddScoped<IUserInOrganizationDetailService, UserInOrganizationDetailService>();
            _ = service.AddScoped<IUserInOrganizationListConvertor, UserInOrganizationListConvertor>();
            _ = service.AddScoped<IUserInOrganizationListService, UserInOrganizationListService>();
            _ = service.AddScoped<IUserInOrganizationRestoreService, UserInOrganizationRestoreService>();
            _ = service.AddScoped<IUserInOrganizationUpdateService, UserInOrganizationUpdateService>();
            _ = service.AddScoped<IUserInOrganizationUpdateValidator, UserInOrganizationUpdateValidator>();
        }





        public static void RegistrationOrganizationSetting(IServiceCollection service)
        {

            _ = service.AddScoped<IGetOrganizationSettingService, GetOrganizationSettingService>();
            _ = service.AddScoped<IGetOrganizationSettingConvertor, GetOrganizationSettingConvertor>();
            _ = service.AddScoped<IOrganizationSettingUpdateService, OrganizationSettingUpdateService>();
            _ = service.AddScoped<IOrganizationSettingUpdateConvertor, OrganizationSettingUpdateConvertor>();
            _ = service.AddScoped<IOrganizationSettingUpdateValidator, OrganizationSettingUpdateValidator>();
            _ = service.AddScoped<IOrganizationStudyHourDetailService, OrganizationStudyHourDetailService>();
            _ = service.AddScoped<IOrganizationStudyHourDetailConvertor, OrganizationStudyHourDetailConvertor>();
        }

        public static void RegisterBranch(this IServiceCollection service)
        {

            _ = service.AddScoped<IBranchCreateService, BranchCreateService>();
            _ = service.AddScoped<IBranchCreateValidator, BranchCreateValidator>();
            _ = service.AddScoped<IBranchCreateConvertor, BranchCreateConvertor>();
            _ = service.AddScoped<IBranchDeleteService, BranchDeleteService>();
            _ = service.AddScoped<IBranchDetailService, BranchDetailService>();
            _ = service.AddScoped<IBranchListService, BranchListService>();
            _ = service.AddScoped<IBranchListConvertor, BranchListConvertor>();
            _ = service.AddScoped<IBranchRestoreService, BranchRestoreService>();
            _ = service.AddScoped<IBranchUpdateService, BranchUpdateService>();
            _ = service.AddScoped<IBranchUpdateValidator, BranchUpdateValidator>();
            _ = service.AddScoped<IBranchUpdateConvertor, BranchUpdateConvertor>();
            _ = service.AddScoped<IChangeMainBranchService, ChangeMainBranchService>();
            _ = service.AddScoped<IBranchDetailConvertor, BranchDetailConvertor>();
        }



        public static void RegistrationClassRoom(this IServiceCollection service)
        {

            _ = service.AddScoped<IClassRoomCreateService, ClassRoomCreateService>();
            _ = service.AddScoped<IClassRoomCreateValidator, ClassRoomCreateValidator>();
            _ = service.AddScoped<IClassRoomCreateConvertor, ClassRoomCreateConvertor>();
            _ = service.AddScoped<IClassRoomUpdateService, ClassRoomUpdateService>();
            _ = service.AddScoped<IClassRoomUpdateValidator, ClassRoomUpdateValidator>();
            _ = service.AddScoped<IClassRoomUpdateConvertor, ClassRoomUpdateConvertor>();
            _ = service.AddScoped<IClassRoomDeleteService, ClassRoomDeleteService>();
            _ = service.AddScoped<IClassRoomDetailService, ClassRoomDetailService>();
            _ = service.AddScoped<IClassRoomDetailConvertor, ClassRoomDetailConvertor>();
            _ = service.AddScoped<IClassRoomListService, ClassRoomListService>();
            _ = service.AddScoped<IClassRoomListConvertor, ClassRoomListConvertor>();
            _ = service.AddScoped<IClassRoomRestoreService, ClassRoomRestoreService>();
            _ = service.AddScoped<IClassRoomTimeTableService, ClassRoomTimeTableService>();
        }


        public static void RegisterSendMessage(this IServiceCollection service)
        {

            _ = service.AddScoped<IMessageTemplateCreateConvertor, MessageTemplateCreateConvertor>();
            _ = service.AddScoped<IMessageTemplateCreateService, MessageTemplateCreateService>();
            _ = service.AddScoped<IMessageTemplateCreateValidator, MessageTemplateCreateValidator>();
            _ = service.AddScoped<IMessageTemplateDeleteService, MessageTemplateDeleteService>();
            _ = service.AddScoped<IMessageTemplateDetailConvertor, MessageTemplateDetailConvertor>();
            _ = service.AddScoped<IMessageTemplateDetailService, MessageTemplateDetailService>();
            _ = service.AddScoped<IMessageTemplateListConvertor, MessageTemplateListConvertor>();
            _ = service.AddScoped<IMessageTemplateListService, MessageTemplateListService>();
            _ = service.AddScoped<IMessageTemplateRestoreService, MessageTemplateRestoreService>();
            _ = service.AddScoped<IMessageTemplateUpdateConvertor, MessageTemplateUpdateConvertor>();
            _ = service.AddScoped<IMessageTemplateUpdateService, MessageTemplateUpdateService>();
            _ = service.AddScoped<IMessageTemplateUpdateValidator, MessageTemplateUpdateValidator>();
            _ = service.AddScoped<IMessageTemplateDropDownService, MessageTemplateDropDownService>();
            _ = service.AddScoped<IMessageTemplateDropDownConvertor, MessageTemplateDropDownConvertor>();
            _ = service.AddScoped<IClassRoomDropDownConvertor, ClassRoomDropDownConvertor>();
            _ = service.AddScoped<IClassRoomDropDownService, ClassRoomDropDownService>();
            _ = service.AddScoped<IOrganizationStudyHourDropDownService, OrganizationStudyHourDropDownService>();
            _ = service.AddScoped<IOrganizationStudyHourDropDownConvertor, OrganizationStudyHourDropDownConvertor>();
            _ = service.AddScoped<IStudentGroupDropDownService, StudentGroupDropDownService>();
            _ = service.AddScoped<IStudentGroupDropDownConvertor, StudentGroupDropDownConvertor>();
            _ = service.AddScoped<IUserInOrganizationDropDownService, UserInOrganizationDropDownService>();
            _ = service.AddScoped<IUserInOrganizationDropDownConvertor, UserInOrganizationDropDownConvertor>();


        }

        public static void RegisterStudentGroup(this IServiceCollection service)
        {

            _ = service.AddScoped<IStudentGroupCreateConvertor, StudentGroupCreateConvertor>();
            _ = service.AddScoped<IStudentGroupCreateService, StudentGroupCreateService>();
            _ = service.AddScoped<IStudentGroupCreateValidator, StudentGroupCreateValidator>();
            _ = service.AddScoped<IStudentGroupDeleteService, StudentGroupDeleteService>();
            _ = service.AddScoped<IStudentGroupDetailConvertor, StudentGroupDetailConvertor>();
            _ = service.AddScoped<IStudentGroupDetailService, StudentGroupDetailService>();
            _ = service.AddScoped<IStudentGroupListConvertor, StudentGroupListConvertor>();
            _ = service.AddScoped<IStudentGroupListService, StudentGroupListService>();
            _ = service.AddScoped<IStudentGroupRestoreService, StudentGroupRestoreService>();
            _ = service.AddScoped<IStudentGroupUpdateConvertor, StudentGroupUpdateConvertor>();
            _ = service.AddScoped<IStudentGroupUpdateService, StudentGroupUpdateService>();
            _ = service.AddScoped<IStudentGroupUpdateValidator, StudentGroupUpdateValidator>();
            _ = service.AddScoped<IOrganizationRoleDetailService, OrganizationRoleDetailService>();
            _ = service.AddScoped<IOrganizationRoleDetailConvertor, OrganizationRoleDetailConvertor>();
        }




        public static void RegistrationPermissions(this IServiceCollection service)
        {

            _ = service.AddScoped<IOrganizationList, OrganizationList>();
            _ = service.AddScoped<IOrganizationListConvertor, OrganizationListConvertor>();
            _ = service.AddScoped<IOrganizationWebDetail, OrganizationWebDetail>();
            _ = service.AddScoped<IOrganizationWebDetailConvertor, OrganizationWebDetailConvertor>();
            _ = service.AddScoped<IGetOrganizationSettingByUrlService, GetOrganizationSettingByUrlService>();
            _ = service.AddScoped<IGetOrganizationSettingByUrlConvertor, GetOrganizationSettingByUrlConvertor>();
            _ = service.AddScoped<IOrganizationCreateService, OrganizationCreateService>();
            _ = service.AddScoped<IOrganizationCreateConvertor, OrganizationCreateConvertor>();
            _ = service.AddScoped<IOrganizationCreateValidator, OrganizationCreateValidator>();
            _ = service.AddScoped<IOrganizationDetailService, OrganizationDetailService>();
            _ = service.AddScoped<IOrganizationDetailConvertor, OrganizationDetailConvertor>();
            _ = service.AddScoped<IOrganizationUpdateService, OrganizationUpdateService>();
            _ = service.AddScoped<IOrganizationUpdateConvertor, OrganizationUpdateConvertor>();
            _ = service.AddScoped<IOrganizationUpdateValidator, OrganizationUpdateValidator>();
            _ = service.AddScoped<IOrganizaionDeleteService, OrganizaionDeleteService>();
            _ = service.AddScoped<IOrganizationFileUploadService, OrganizationFileUploadService>();

            _ = service.AddScoped<ISendMailCreateService, SendMailCreateService>();
            _ = service.AddScoped<ISendMailCreateConvertor, SendMailCreateConvertor>();
            _ = service.AddScoped<ISendMailCreateValidator, SendMailCreateValidator>();
            _ = service.AddScoped<ISendMailDetailConvertor, SendMailDetailConvertor>();
            _ = service.AddScoped<ISendMailDetailService, SendMailDetailService>();
            _ = service.AddScoped<ISendMailListConvertor, SendMailListConvertor>();
            _ = service.AddScoped<ISendMailListService, SendMailListService>();
            _ = service.AddScoped<ISendMailUpdateConvertor, SendMailUpdateConvertor>();
            _ = service.AddScoped<ISendMailUpdateService, SendMailUpdateService>();
            _ = service.AddScoped<ISendMailUpdateValidator, SendMailUpdateValidator>();
            _ = service.AddScoped<ICertificateDropDownCommand, CertificateDropDownCommand>();
            _ = service.AddScoped<ICertificateDropDownConvertor, CertificateDropDownConvertor>();


        }


    }
}
