using Core.Base.Command;
using Core.DataTypes;
using Core.Extension;
using Model.Edu.LinkLifeTime;
using Model.Edu.User;
using Repository.LinkLifeTime;
using Repository.User;
using UserService.User.SetNewPassword.Dto;
using UserService.User.SetNewPassword.Validator;

namespace UserService.User.SetNewPassword.Command
{
    public class SetNewPasswordService : BaseCommand<IUserRepository>, ISetNewPasswordService
    {
        private readonly ILinkLifeTimeRepository _linkLifeTimeRepository;
        private readonly ISetNewPasswordValidator _validator;

        public SetNewPasswordService(
            ISetNewPasswordValidator validator,
            IUserRepository userRepository,
            ILinkLifeTimeRepository linkLifeTimeRepository
        )
            : base(userRepository)
        {
            _linkLifeTimeRepository = linkLifeTimeRepository;
            _validator = validator;
        }

        public async Task<Result> Execute(SetNewPasswordDto setNewPasswordDto)
        {
            Result validate = await _validator.IsValidSetNewPassword(setNewPasswordDto);
            if (validate.IsOk)
            {
                LinkLifeTimeDbo link = await _linkLifeTimeRepository.GetEntity(setNewPasswordDto.LinkId);
                UserDbo user = link.User;
                if (user != null)
                {
                    user.UserPassword = setNewPasswordDto.Password1.GetHashString();
                    _ = await _repository.UpdateEntity(user, user.Id);
                    await _linkLifeTimeRepository.DeleteEntity(link, user.Id);
                }
            }
            return validate;
        }
    }
}
