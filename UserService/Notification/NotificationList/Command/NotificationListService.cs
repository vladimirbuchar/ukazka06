using Core.Base.Command.List;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Model.Edu.Notification;
using Repository.Notification;
using System.Linq.Expressions;
using System.Web.Helpers;
using UserService.Notification.NotificationList.Convertor;
using UserService.Notification.NotificationList.Dto;

namespace UserService.Notification.NotificationList.Command
{
    public class NotificationListService
        : BaseListCommand<NotificationDbo, INotificationRepository, NotificationListDto, INotificationListConvertor, RequestFilter>,
            INotificationListService
    {


        public NotificationListService(
            INotificationRepository repository,
            INotificationListConvertor convertor

        )
            : base(repository, convertor)
        {

        }

        public override async Task<ResultTable<NotificationListDto>> Execute(
            Expression<Func<NotificationDbo, bool>>? predicate = null,
            bool deleted = false,
            List<string>? culture = null,
            RequestFilter? filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging? paging = null
        )
        {
            List<NotificationDbo> notifications = [];
            notifications =
            [
                .. await _repository.GetEntities(false, predicate, null, [new Core.Base.Sort.BaseSort<NotificationDbo>() { Sort = x => x.AddDate }])
            ];

            foreach (NotificationDbo item in notifications)
            {
                item.Data.Add("{organizationName}", item.Organization?.Name);
            }
            List<NotificationListDto> data = await _convertor.ConvertToWebModel(notifications, culture);
            return new ResultTable<NotificationListDto>() { Data = data, TotalCount = await _repository.GetTotalCount(false, predicate) };
        }
    }
}
