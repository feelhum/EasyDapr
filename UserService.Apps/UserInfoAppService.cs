using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Apps
{
    public class UserInfoAppService : IUserInfoAppService
    {
        public async Task<UserOutputDto> GetUserInfoAsync(int userId)
        {
           return await Task.FromResult(new UserOutputDto() { Id = userId, Name = "Tom" });
        }
    }
}
