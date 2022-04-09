using Core.Entities.Concrete;
using Core.Results;
using Core.Security.JWT;
using Entities.Dto;

namespace Business.Abstact
{
    public interface IAuthService
    {
        IDataResult<User> RegisterUser(UserRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserLoginDto userForLoginDto);
        IResult IsUserExists(string email);
        IDataResult<AccessTokenItem> CreateAccessToken(User user);
    }
}
