using Core.Base.Command;
using Core.DataTypes;
using UserService.User.SetNewPassword.Dto;

namespace UserService.User.SetNewPassword.Command
{
    public interface ISetNewPasswordService : IBaseCommand
    {
        Task<Result> Execute(SetNewPasswordDto setNewPasswordDto);
    }
}
