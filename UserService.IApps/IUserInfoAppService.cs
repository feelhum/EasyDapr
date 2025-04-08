using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Apps
{
    public interface IUserInfoAppService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserOutputDto> GetUserInfoAsync(int userId);
    }
}
