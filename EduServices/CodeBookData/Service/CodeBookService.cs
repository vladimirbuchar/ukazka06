using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using EduServices.CodeBookData.Convertor;
using EduServices.CodeBookData.Dto;
using Model.CodeBook;
using System.Collections.Generic;

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
                        return _convertor.ConvertToWebModel(_licenseCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_COURSE_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_courseTypeCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_COURSE_STATUS:
                    {
                        return _convertor.ConvertToWebModel(_courseStatusCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_TIME_TABLE:
                    {
                        return _convertor.ConvertToWebModel(_timeTableCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_COUNTRY:
                    {
                        return _convertor.ConvertToWebModel(_countryCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_ADDRESS_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_addressTypeCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_ANSWER_MODE:
                    {
                        return _convertor.ConvertToWebModel(_answerModeCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_COURSE_LESSON_ITEM_TEMPLATE:
                    {
                        return _convertor.ConvertToWebModel(_courseLessonItemTemplateCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_ENV_CULTURE:
                    {
                        return _convertor.ConvertToWebModel(_cultureCodebook.GetEntities(false, x => x.IsEnvironmentCulture, x => x.Priority));
                    }
                case CodebookValue.CB_CULTURE:
                    {
                        return _convertor.ConvertToWebModel(_cultureCodebook.GetEntities(false, null, x => x.Priority));
                    }
                case CodebookValue.CB_SEND_MESSAGE_TYPE:
                    {
                        HashSet<CodeBookItemListDto> sendmessagetype = _convertor.ConvertToWebModel(_sendMessageTypeCodebook.GetEntities(false, null, x => x.Priority));
                        foreach (CodeBookItemListDto item in sendmessagetype)
                        {
                            item.Disabled = item.SystemIdentificator == SendMessageType.SMS;
                        }
                        return sendmessagetype;
                    }
                case CodebookValue.CB_QUESTION_MODE:
                    {
                        return _convertor.ConvertToWebModel(_questionModeCodebook.GetEntities(false));
                    }
                case CodebookValue.CB_NOTE_TYPE:
                    {
                        return _convertor.ConvertToWebModel(_noteTypeCodebook.GetEntities(false));
                    }
            }
            return null;
        }
    }
}
