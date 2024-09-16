using Core.Base.Dto;

namespace Services.Email.EmailDetail.Dto
{
    public class EmailDetailDto : DetailDto
    {
        public bool IsHtml { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string EmailBodyHtml { get; set; }
        public string EmailBodyPlainText { get; set; }

    }
}
