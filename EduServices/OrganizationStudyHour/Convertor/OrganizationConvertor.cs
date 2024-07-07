using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extension;
using Model.Edu.OrganizationStudyHour;
using Services.OrganizationStudyHour.Dto;

namespace Services.OrganizationStudyHour.Convertor
{
    public class OrganizationStudyHourConvertor : IOrganizationStudyHourConvertor
    {
        public OrganizationStudyHourConvertor() { }

        public OrganizationStudyHourDbo ConvertToBussinessEntity(StudyHourCreateDto addStudyHoursDto, string culture)
        {
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!addStudyHoursDto.ActiveFromId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(addStudyHoursDto.ActiveFromId, out activeFromId);
            }
            if (!addStudyHoursDto.ActiveToId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(addStudyHoursDto.ActiveToId, out activeToId);
            }
            return new OrganizationStudyHourDbo()
            {
                ActiveFromId = activeFromId,
                ActiveToId = activeToId,
                OrganizationId = addStudyHoursDto.OrganizationId,
                Position = addStudyHoursDto.Position,
            };
        }

        public OrganizationStudyHourDbo ConvertToBussinessEntity(StudyHourUpdateDto updateStudyHoursDto, OrganizationStudyHourDbo entity, string culture)
        {
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!updateStudyHoursDto.ActiveFromId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(updateStudyHoursDto.ActiveFromId, out activeFromId);
            }
            if (!updateStudyHoursDto.ActiveToId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(updateStudyHoursDto.ActiveToId, out activeToId);
            }

            entity.ActiveFromId = activeFromId;
            entity.ActiveToId = activeToId;
            entity.Id = updateStudyHoursDto.Id;
            entity.Position = updateStudyHoursDto.Position;
            entity.ActiveFrom = null;
            entity.ActiveTo = null;
            return entity;
        }

        public HashSet<StudyHourListDto> ConvertToWebModel(HashSet<OrganizationStudyHourDbo> list, string culture)
        {
            return list.Select(x => new StudyHourListDto()
                {
                    Position = x.Position,
                    ActiveFrom = x.ActiveFrom.Value,
                    ActiveFromId = x.ActiveFromId,
                    ActiveTo = x.ActiveTo.Value,
                    ActiveToId = x.ActiveToId,
                    Id = x.Id
                })
                .ToHashSet();
        }

        public StudyHourDetailDto ConvertToWebModel(OrganizationStudyHourDbo detail, string culture)
        {
            return new StudyHourDetailDto()
            {
                Position = detail.Position,
                ActiveFrom = detail.ActiveFrom.Value,
                ActiveFromId = detail.ActiveFromId,
                ActiveTo = detail.ActiveTo.Value,
                ActiveToId = detail.ActiveToId,
                Id = detail.Id
            };
        }
    }
}
