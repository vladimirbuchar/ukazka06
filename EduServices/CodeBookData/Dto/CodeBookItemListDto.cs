using Core.Base.Dto;

namespace Services.CodeBookData.Dto
{
    public class CodeBookItemListDto : ListDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string SystemIdentificator { get; set; }
        public bool Disabled { get; set; } = false;
    }
}
