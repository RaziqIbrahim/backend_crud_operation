using backendTest.BOs;
using backendTest.Helpers;
using backendTest.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
    
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        [HttpGet]
        [Route("/api")]
        public IActionResult getstatus()
        {
            return Ok("All good");
        }

        [HttpGet]
        [Route("/api/getuserdata")]

        public IActionResult getUserData([FromQuery] string username)
        {
            try
            {
                #region service invocation
                var res = _userService.get_all_user(username);
                #endregion
                #region response handling
                if (res.Status == ServiceStatus.Success)
                {
                    return Ok(res.Content);
                }
                else if (res.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = res.Message });
                }
                else
                {
                    return StatusCode(500, new { message = res.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/insertUserData")]

        public IActionResult insertUserData(UserBo userdetails)
        {
            try
            {
                #region service invocation
                var res = _userService.insertUserData(userdetails);
                #endregion
                #region response handling
                if (res.Status == ServiceStatus.Success)
                {
                    return Ok(res.Content);
                }
                else if (res.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = res.Message });
                }
                else
                {
                    return StatusCode(500, new { message = res.Message });
                }
                #endregion

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/deleteUserData")]

        public IActionResult deleteUserData([FromQuery] string username)
        {
            try
            {
                #region service invocation
                var res = _userService.deleteUserData(username);
                #endregion
                #region response handling
                if (res.Status == ServiceStatus.Success)
                {
                    return Ok(res.Content);
                }
                else if (res.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = res.Message });
                }
                else
                {
                    return StatusCode(500, new { message = res.Message });
                }
                #endregion
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/updateUserDetails")]

        public IActionResult UpdateUserDetails(UserBo userDetails)
        {
            try
            {
                #region service invocation
                var res = _userService.updateUserData(userDetails);
                #endregion
                #region response handling
                if (res.Status == ServiceStatus.Success)
                {
                    return Ok(res.Content);
                }
                else if (res.Status == ServiceStatus.Invalid)
                {
                    return BadRequest(new { message = res.Message });
                }
                else
                {
                    return StatusCode(500, new { message = res.Message });
                }
                #endregion
            }
            catch (Exception ex) { 
            
                return BadRequest(ex.Message);
            }
           
        }
    }
}
