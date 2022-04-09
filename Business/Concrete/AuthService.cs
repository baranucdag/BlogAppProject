using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Results;
using Core.Security.Hashing;
using Core.Security.JWT;
using Entities.Dto;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService userService;
        private ITokenHelper tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }

        public IDataResult<User> RegisterUser(UserRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult IsUserExists(string email)
        {
            if (email != null)
            {
                if (userService.GetByMail(email) != null)
                {
                    return new ErrorResult(Messages.UserAlreadyExists);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.EmailNullError);

        }

        public IDataResult<AccessTokenItem> CreateAccessToken(User user)
        {
            var claims = userService.GetClaims(user);
            var accessToken = tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessTokenItem>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
