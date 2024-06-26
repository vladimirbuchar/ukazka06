﻿using Core.Base.Validator;
using EduRepository.OrganizationCultureRepository;
using EduServices.OrganizationCulture.Dto;
using Model.Tables.Link;

namespace EduServices.OrganizationCulture.Validator
{
    public interface IOrganizationCultureValidator
        : IBaseValidator<OrganizationCultureDbo, IOrganizationCultureRepository, OrganizationCultureCreateDto, OrganizationCultureDetailDto, OrganizationCultureUpdateDto> { }
}
