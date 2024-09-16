using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using UserService.User.Shared.Dto;

namespace Services.User.Helper
{
    public static partial class UserHelper
    {
        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex NumberRegex();

        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UpperCharRegex();

        [GeneratedRegex(@".{8}")]
        private static partial Regex MinCharRegex();

        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowerCharRegex();

        [GeneratedRegex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]")]
        private static partial Regex SymbolRegex();

        public static string GenerateJWTToken(IConfiguration configuration, UserTokenDto user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWTKey"));

            SymmetricSecurityKey signingKey = new(key);
            SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256Signature);

            JwtHeader header = new(signingCredentials) { ["kid"] = configuration.GetValue<string>("JWTKid") };

            Claim[] claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole),
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(Constants.USER_ORGANIZATION_ROLE, JsonConvert.SerializeObject(user.OrganizationRole))
            ];

            JwtPayload payload =
                new(
                    issuer: configuration.GetValue<string>("JWTIssuer"),
                    audience: configuration.GetValue<string>("JWTAudience"),
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(1)
                );

            JwtSecurityToken token = new(header, payload);
            return tokenHandler.WriteToken(token);
        }

        public static void IsValidPassword(string? password1, string? password2, Result result)
        {
            password1 = password1?.Trim();
            password2 = password2?.Trim();
            Regex hasNumber = NumberRegex();
            Regex hasUpperChar = UpperCharRegex();
            Regex hasMinChars = MinCharRegex();
            Regex hasLowerChar = LowerCharRegex();
            Regex hasSymbols = SymbolRegex();
            if (password2.IsNullOrEmptyWithTrim() || password1.IsNullOrEmptyWithTrim())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, MessageItem.STRING_IS_EMPTY));
            }
            if (password1 != password2)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_ARE_DIFFERENT));
            }
            if (!hasLowerChar.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_NOT_LOWER_CHAR));
            }
            if (!hasUpperChar.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_NOT_UPPER_CHAR));
            }
            if (!hasMinChars.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_NOT_MIN_LENGTH));
            }
            if (!hasNumber.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_NOT_NUMBER));
            }
            if (!hasSymbols.IsMatch(password1))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER_PASSWORD, Constants.PASSWORD_NOT_SYMBOLS));
            }
        }
    }
}
