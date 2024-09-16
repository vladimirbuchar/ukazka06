using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.User;
using Repository.User;
using Services.User.Helper;
using UserService.User.SetPassword.Dto;

namespace UserService.User.SetPassword.Validator
{
    public class SetPasswordValidator : BaseUpdateValidator<UserDbo, IUserRepository, SetPasswordDto>, ISetPasswordValidator
    {
        public SetPasswordValidator(IUserRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(SetPasswordDto update)
        {
            Result validate = new();
            UserHelper.IsValidPassword(update.NewUserPassword, update.NewUserPassword2, validate);
            UserDbo user = await _repository.GetEntity(update.Id);
            if (user != null && user.AllowCLassicLogin == true)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, Constants.CAN_NOT_SET_PASSWORD));
            }
            return await Task.FromResult(validate);
        }
    }
}
