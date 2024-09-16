using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Notification;
using Repository.Notification;
using UserService.Notification.NotificationCreate.Convertor;
using UserService.Notification.NotificationCreate.Dto;
using UserService.Notification.NotificationCreate.Validator;

namespace UserService.Notification.NotificationCreate.Command
{
    public class NotificationCreateService
        : BaseCreateCommand<
            NotificationDbo,
            INotificationRepository,
            NotificationCreateDto,
            INotificationCreateConvertor,
            INotificationCreateValidator
        >,
            INotificationCreateService
    {
        private readonly ICodeBookRepository<NotificationTypeDbo> _notificationTypes;

        public NotificationCreateService(
            ICodeBookRepository<NotificationTypeDbo> notificationTypes,
            INotificationRepository repository,
            INotificationCreateConvertor convertor,
            INotificationCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _notificationTypes = notificationTypes;
        }

        public override async Task<ResultInsert> Execute(NotificationCreateDto addObject, Guid userId, string culture)
        {
            addObject.NotificationTypeId = (
                await _notificationTypes.GetEntity(false, x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION)
            ).Id;
            return await base.Execute(addObject, userId, culture);
        }
    }
}
