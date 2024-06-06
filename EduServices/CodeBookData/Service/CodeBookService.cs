using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using EduServices.CodeBookData.Convertor;
using EduServices.CodeBookData.Dto;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CodeBookData.Service
{
    public class CodeBookService(
        ICodeBookRepository<LicenseDbo> licenseCodebook,
        ICodeBookRepository<CourseTypeDbo> courseTypeCodebook,
        ICodeBookRepository<CourseStatusDbo> courseStatusCodebook,
        ICodeBookRepository<TimeTableDbo> timeTableCodebook,
        ICodeBookRepository<CountryDbo> countryCodebook,
        ICodeBookRepository<AddressTypeDbo> addressTypeCodebook,
        ICodeBookRepository<AnswerModeDbo> answerModeCodebook,
        ICodeBookRepository<CourseLessonItemTemplateDbo> courseLessonItemTemplateCodebook,
        ICodeBookRepository<CultureDbo> cultureCodebook,
        ICodeBookRepository<SendMessageTypeDbo> sendMessageTypeCodebook,
        ICodeBookRepository<QuestionModeDbo> questionModeCodebook,
        ICodeBookRepository<NoteTypeDbo> noteTypeCodebook,
        ICodeBookConvertor codeBookConvertor
    ) : BaseService<ICodeBookConvertor>(codeBookConvertor), ICodeBookService
    {
        private readonly ICodeBookRepository<LicenseDbo> _licenseCodebook = licenseCodebook;
        private readonly ICodeBookRepository<CourseTypeDbo> _courseTypeCodebook = courseTypeCodebook;
        private readonly ICodeBookRepository<CourseStatusDbo> _courseStatusCodebook = courseStatusCodebook;
        private readonly ICodeBookRepository<TimeTableDbo> _timeTableCodebook = timeTableCodebook;
        private readonly ICodeBookRepository<CountryDbo> _countryCodebook = countryCodebook;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressTypeCodebook = addressTypeCodebook;
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModeCodebook = answerModeCodebook;
        private readonly ICodeBookRepository<CourseLessonItemTemplateDbo> _courseLessonItemTemplateCodebook = courseLessonItemTemplateCodebook;
        private readonly ICodeBookRepository<CultureDbo> _cultureCodebook = cultureCodebook;
        private readonly ICodeBookRepository<SendMessageTypeDbo> _sendMessageTypeCodebook = sendMessageTypeCodebook;
        private readonly ICodeBookRepository<QuestionModeDbo> _questionModeCodebook = questionModeCodebook;
        private readonly ICodeBookRepository<NoteTypeDbo> _noteTypeCodebook = noteTypeCodebook;

        public HashSet<CodeBookItemListDto> GetCodeBookItems(string codeBookName)
        {
            switch (codeBookName)
            {
                case CodebookValue.CB_LICENSE:
                    {
                        return _convertor.ConvertToWebModel(_licenseCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_COURSE_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_courseTypeCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_COURSE_STATUS:
                    {
                        return _convertor.ConvertToWebModel(_courseStatusCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_TIME_TABLE:
                    {
                        return _convertor.ConvertToWebModel(_timeTableCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_COUNTRY:
                    {
                        return _convertor.ConvertToWebModel(_countryCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_ADDRESS_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_addressTypeCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_ANSWER_MODE:
                    {
                        return _convertor.ConvertToWebModel(_answerModeCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_COURSE_LESSON_ITEM_TEMPLATE:
                    {
                        return _convertor.ConvertToWebModel(_courseLessonItemTemplateCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_ENV_CULTURE:
                    {
                        return _convertor.ConvertToWebModel(_cultureCodebook.GetCodeBookItems(x => x.IsEnvironmentCulture).OrderBy(x => x.Priority).ToHashSet());
                    }
                case CodebookValue.CB_CULTURE:
                    {
                        return _convertor.ConvertToWebModel(_cultureCodebook.GetCodeBookItems().OrderBy(x => x.Priority).ToHashSet());
                    }
                case CodebookValue.CB_SEND_MESSAGE_TYPE:
                    {
                        HashSet<CodeBookItemListDto> sendmessagetype = _convertor.ConvertToWebModel(_sendMessageTypeCodebook.GetCodeBookItems().OrderBy(x => x.Priority).ToHashSet());
                        foreach (CodeBookItemListDto item in sendmessagetype)
                        {
                            item.Disabled = item.SystemIdentificator == SendMessageType.SMS;
                        }
                        return sendmessagetype;
                    }
                case CodebookValue.CB_QUESTION_MODE:
                    {
                        return _convertor.ConvertToWebModel(_questionModeCodebook.GetCodeBookItems());
                    }
                case CodebookValue.CB_NOTE_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_noteTypeCodebook.GetCodeBookItems());
                    }
            }
            return null;
        }
    }
}
