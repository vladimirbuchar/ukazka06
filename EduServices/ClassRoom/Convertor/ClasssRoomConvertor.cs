using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ClassRoom.Convertor
{
    public class ClasssRoomConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IClassRoomConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<ClassRoomDbo> ConvertToBussinessEntity(ClassRoomCreateDto addClassRoomDto, string culture)
        {
            ClassRoomDbo classRoom =
                new()
                {
                    Floor = addClassRoomDto.Floor,
                    MaxCapacity = addClassRoomDto.MaxCapacity,
                    BranchId = addClassRoomDto.BranchId,
                    IsOnline = addClassRoomDto.IsOnline
                };
            classRoom.ClassRoomTranslations = classRoom.ClassRoomTranslations.PrepareTranslation(addClassRoomDto.Name, culture, _cultureList);
            return Task.FromResult(classRoom);
        }

        public Task<ClassRoomDbo> ConvertToBussinessEntity(ClassRoomUpdateDto updateClassRoomDto, ClassRoomDbo entity, string culture)
        {
            List<ClassRoomTranslationDbo> translations =
            [
                .. entity.ClassRoomTranslations.PrepareTranslation(updateClassRoomDto.Name, culture, _cultureList)
            ];
            entity.ClassRoomTranslations = translations;
            entity.Floor = updateClassRoomDto.Floor;
            entity.MaxCapacity = updateClassRoomDto.MaxCapacity;
            return Task.FromResult(entity);
        }

        public Task<List<ClassRoomListDto>> ConvertToWebModel(List<ClassRoomDbo> getAllClassRoomInBranches, string culture)
        {
            return Task.FromResult(getAllClassRoomInBranches
                .Select(item => new ClassRoomListDto()
                {
                    Floor = item.Floor,
                    Id = item.Id,
                    MaxCapacity = item.MaxCapacity,
                    Name = item.ClassRoomTranslations?.FindTranslation(culture)?.Name
                })
                .ToList());
        }

        public Task<ClassRoomDetailDto> ConvertToWebModel(ClassRoomDbo getClassRoomDetail, string culture)
        {
            return Task.FromResult(new ClassRoomDetailDto()
            {
                Floor = getClassRoomDetail.Floor,
                Id = getClassRoomDetail.Id,
                MaxCapacity = getClassRoomDetail.MaxCapacity,
                Name = getClassRoomDetail.ClassRoomTranslations?.FindTranslation(culture)?.Name
            });
        }
    }
}
