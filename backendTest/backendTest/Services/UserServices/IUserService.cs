using backendTest.BOs;
using backendTest.Helpers;

namespace backendTest.Services.UserServices
{
    public interface IUserService
    {
        public ServiceResult<List<UserBo>> get_all_user(string username);

        public ServiceResult<bool> insertUserData(UserBo userDetails);

        public ServiceResult<bool> deleteUserData(string user_name);

        public ServiceResult<bool> updateUserData(UserBo userDetails);
    }
}
