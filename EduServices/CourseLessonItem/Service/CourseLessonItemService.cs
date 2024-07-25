using Core.Base.Filter;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItemRepository;
using Repository.CourseLessonRepository;
using Services.CourseLessonItem.Convertor;
using Services.CourseLessonItem.Dto;
using Services.CourseLessonItem.Validator;
using System;
using System.Threading.Tasks;

namespace Services.CourseLessonItem.Service
{
    public class CourseLessonItemService(
        ICourseLessonItemRepository courseLessonItemRepository,
        ICourseLessonItemValidator validator,
        ICourseLessonItemConvertor courseLessonItemConvertor,
        IFileUploadRepository<CourseLessonItemFileRepositoryDbo> repository,
        ICodeBookRepository<CultureDbo> culture,
        ICourseLessonRepository courseLessonRepository
    )
        : BaseService<
            ICourseLessonItemRepository,
            CourseLessonItemDbo,
            ICourseLessonItemConvertor,
            ICourseLessonItemValidator,
            CourseLessonItemCreateDto,
            CourseLessonItemListDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto,
            CourseLessonItemFileRepositoryDbo,
            FilterRequest
        >(courseLessonItemRepository, courseLessonItemConvertor, validator, repository, culture),
            ICourseLessonItemService
    {
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;
        public async Task<Result> UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLesson, Guid userId)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonItemDbo courseLessonItemDbo = await _repository.GetEntity(id);
                if (courseLessonItemDbo != null)
                {
                    courseLessonItemDbo.Position = position;
                    _ = await _repository.UpdateEntity(courseLessonItemDbo, userId);
                }
                position++;
            }
            return new Result();
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseLessonRepository.GetOrganizationId(objectId);
        }
        public override Task<Guid> GetOrganizationIdBFileId(Guid objectId)
        {
            return _repository.GetOrganizationByFileId(objectId);
        }
    }
}
