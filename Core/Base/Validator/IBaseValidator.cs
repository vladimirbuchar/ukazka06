using Core.DataTypes;

namespace Core.Base.Validator
{
    public interface IBaseValidator
    {
        void IsValidString(string text, Result result, string category, string item);
        void IsValidString(string text, ResultInsert result, string category, string item, bool required);
        void IsValidEmail(string email, Result result, string category, string item);
        void IsValidUri(string uri, Result result, string category, string item);
        void IsValidPhoneNumber(string phoneNumber, Result result, string category, string item);
        void IsValidPostiveNumber(int number, Result result, string category, string item);
        void IsValidPostiveNumber(double number, Result result, string category, string item);
    }
}
