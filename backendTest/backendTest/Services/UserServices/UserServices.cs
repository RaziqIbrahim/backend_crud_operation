using backendTest.BOs;
using backendTest.Helpers;
using backendTest.Helpers.DataStores;

namespace backendTest.Services.UserServices
{
    public class UserServices : IUserService
    {
        public ServiceResult<List<UserBo>> get_all_user(string username)
        {
            try
            {
                List<UserBo> users = new List<UserBo>();
                users=UserSchema.get_all_users(username);
                return new ServiceResult<List<UserBo>>()
                {
                    Status = ServiceStatus.Success,
                    Message = "Got all the feedback",
                    Content = users
                };
            }catch (Exception ex)
            {
                return new ServiceResult<List<UserBo>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = null
                };
            }
        }

        public ServiceResult<bool> insertUserData(UserBo UserDeatils)
        {
            try
            {
                var res = UserSchema.insertUserData(UserDeatils);
                if (res > 0)
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Inserted user data",
                        Content = true
                    };
                }
                else
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Failed,
                        Message = "Unable to Insert",
                        Content = false
                    };
                }

            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = false
                };
            }
        }

        public ServiceResult<bool> deleteUserData(string user_name)
        {
            try
            {
                var res = UserSchema.deleteUserData(user_name);
                if (res > 0)
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Inserted user data",
                        Content = true
                    };
                }
                else
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Failed,
                        Message = "Unable to Insert",
                        Content = false
                    };
                }
            }catch(Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = false
                };
            }
           
        }

        public ServiceResult<bool> updateUserData(UserBo userDetails)
        {
            try
            {
                var res=UserSchema.updateUserData(userDetails);
                if (res > 0)
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Inserted user data",
                        Content = true
                    };
                }
                else
                {
                    return new ServiceResult<bool>()
                    {
                        Status = ServiceStatus.Failed,
                        Message = "Unable to Insert",
                        Content = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = false
                };
            }
        }
    }
}
