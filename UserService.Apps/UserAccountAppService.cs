using UserService.IApps;

namespace UserService.Apps
{
    public class UserAccountAppService : IUserAccountAppService
    {
        public async Task<bool> LoginAsync(string userNmae, string password)
        {
           return await Task.FromResult(true);
        }
    }
}
