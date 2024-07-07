using System.Collections.Generic;
using Core.Base.Dto;
using Core.Constants;
using Core.Extension;

namespace Services.CourseStudy.Dto
{
    public class CourseMenuItemDto : ListDto
    {
        public CourseMenuItemDto()
        {
            Items = [];
        }

        public string Name { get; set; }
        private string _type { get; set; }
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                if (Items.Count > 0)
                {
                    _type = CourseLessonType.SUB_ITEM;
                }
                if (_type.IsNullOrEmptyWithTrim())
                {
                    _type = CourseLessonType.COURSE_ITEM;
                }
            }
        }
        public HashSet<CourseMenuSubItemDto> Items { get; set; }
    }
}
