using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model.Edu.User;
using Repository.User;
using Services.User.Helper;
using UserService.User.ChangePassword.Dto;

namespace UserService.User.ChangePassword.Validator
{
    public class ChangePasswordValidator : BaseUpdateValidator<UserDbo, IUserRepository, ChangePasswordDto>, IChangePasswordValidator
    {
        public ChangePasswordValidator(IUserRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(ChangePasswordDto update)
        {
            Result validate = new();
            await IsValidOldPassword(update.Id, update.OldUserPassword, validate);
            UserHelper.IsValidPassword(update.NewUserPassword, update.NewUserPassword2, validate);
            return validate;
        }

        private async Task IsValidOldPassword(Guid userId, string oldPassword, Result result)
        {
            UserDbo user = await _repository.GetEntity(userId);
            if (user.UserPassword != oldPassword.GetHashString())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, Constants.OLD_PASSWORD_IS_BAD));
            }
        }
    }
}
