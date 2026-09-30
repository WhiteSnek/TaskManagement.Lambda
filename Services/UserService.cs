using TaskManagement.Lambda.Repositories.Interface;
using TaskManagement.Lambda.Services.Interface;

namespace TaskManagement.Lambda.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GetFirebaseTokenFromUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByUserIdAsync(userId);
            if(user == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            var token = user.FirebaseToken;
            if (token == null)
            {
                throw new KeyNotFoundException("Token is null!");
            }
            return token;
        }
    }
}
