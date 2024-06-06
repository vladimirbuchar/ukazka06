using System;
using Core.Base.Dto;

namespace EduServices.CourseMaterial.Dto
{
    public class CourseMaterialFileListDto : ListDto
    {
        public Guid ObjectOwner { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string Url { get; set; }
    }
}
