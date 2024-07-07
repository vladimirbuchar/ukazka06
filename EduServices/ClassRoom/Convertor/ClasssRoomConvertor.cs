using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Services.ClassRoom.Convertor
{
    public class ClasssRoomConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IClassRoomConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

        public ClassRoomDbo ConvertToBussinessEntity(ClassRoomCreateDto addClassRoomDto, string culture)
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
            return classRoom;
        }

        public ClassRoomDbo ConvertToBussinessEntity(ClassRoomUpdateDto updateClassRoomDto, ClassRoomDbo entity, string culture)
        {
            List<ClassRoomTranslationDbo> translations = [.. entity.ClassRoomTranslations.PrepareTranslation(updateClassRoomDto.Name, culture, _cultureList)];
            entity.ClassRoomTranslations = translations;
            entity.Floor = updateClassRoomDto.Floor;
            entity.MaxCapacity = updateClassRoomDto.MaxCapacity;
            return entity;
        }

        public HashSet<ClassRoomListDto> ConvertToWebModel(HashSet<ClassRoomDbo> getAllClassRoomInBranches, string culture)
        {
            return getAllClassRoomInBranches
                .Select(item => new ClassRoomListDto()
                {
                    Floor = item.Floor,
                    Id = item.Id,
                    MaxCapacity = item.MaxCapacity,
                    Name = item.ClassRoomTranslations?.FindTranslation(culture)?.Name,
                    IsOnline = item.IsOnline
                })
                .ToHashSet();
        }

        public ClassRoomDetailDto ConvertToWebModel(ClassRoomDbo getClassRoomDetail, string culture)
        {
            return new ClassRoomDetailDto()
            {
                Floor = getClassRoomDetail.Floor,
                Id = getClassRoomDetail.Id,
                MaxCapacity = getClassRoomDetail.MaxCapacity,
                Name = getClassRoomDetail.ClassRoomTranslations?.FindTranslation(culture)?.Name
            };
        }
    }
}
