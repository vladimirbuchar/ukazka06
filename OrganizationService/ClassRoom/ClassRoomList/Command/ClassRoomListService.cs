using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomList.Convertor;
using OrganizationService.ClassRoom.ClassRoomList.Dto;
using OrganizationService.ClassRoom.ClassRoomList.Filter;
using Repository.Branch;
using Repository.ClassRoom;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.ClassRoom.ClassRoomList.Command
{
    public class ClassRoomListService
        : BaseListCommand<ClassRoomDbo, IClassRoomRepository, ClassRoomListDto, IClassRoomListConvertor, ClassRoomFilter>,
            IClassRoomListService
    {
        private readonly IBranchRepository _branchRepository;

        public ClassRoomListService(IClassRoomRepository repository, IClassRoomListConvertor convertor, IBranchRepository branchRepository)
            : base(repository, convertor)
        {
            _branchRepository = branchRepository;
        }

        protected override Expression<Func<ClassRoomDbo, bool>> PrepareSqlFilter(ClassRoomFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(ClassRoomDbo), "classRoom");
            Expression expression = Expression.Constant(true);
            expression = FilterInt(filter.MaxCapacity, parameter, expression, nameof(ClassRoomDbo.MaxCapacity));
            expression = FilterInt(filter.Floor, parameter, expression, nameof(ClassRoomDbo.Floor));
            expression = FilterString(filter.Name, parameter, expression, nameof(ClassRoomDbo.Name));

            return Expression.Lambda<Func<ClassRoomDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<ClassRoomDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            return base.PrepareSort(columnName, culture);
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _branchRepository.GetOrganizationId(objectId);
        }
    }
}
