﻿using Core.Base.Validator;
using EduRepository.ClassRoomRepository;
using EduServices.ClassRoom.Dto;
using Model.Edu.ClassRoom;

namespace EduServices.ClassRoom.Validator
{
    public interface IClassRoomValidator : IBaseValidator<ClassRoomDbo, IClassRoomRepository, ClassRoomCreateDto, ClassRoomDetailDto, ClassRoomUpdateDto> { }
}
