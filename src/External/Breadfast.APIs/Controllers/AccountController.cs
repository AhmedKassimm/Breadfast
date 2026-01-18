using Breadfast.APIs.Errors;
using Breadfast.Application.Dtos.UserDtos;
using Breadfast.Domain.Entities.User;
using Breadfast.Domain.Interfaces.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Breadfast.APIs.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<ApplcationUser> _userManager;
        private readonly SignInManager<ApplcationUser> _signInManager;
        private readonly IAuthService _service;

        public AccountController(UserManager<ApplcationUser>userManager,
            SignInManager<ApplcationUser>signInManager,IAuthService service)
        {
             _userManager = userManager;
             _signInManager = signInManager;
            _service = service;
        }



        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized(new ApiResponce(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new ApiResponce(401));
            else
            #region Token
            {

                //  List<Claim> claims = new List<Claim>();
                //  claims.Add(new Claim(ClaimTypes.Email, model.Email));
                //  claims.Add(new Claim(ClaimTypes.UserData, user.DisplayName));
                //  
                //  
                //  string secertKey = "HellO fROM HamdDDDA Ya Kassim How Are YOU HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
                //  
                //  var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secertKey));
                //  
                //  var Token = new JwtSecurityToken(claims: claims,
                //      expires: DateTime.Now.AddDays(30),
                //      signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                //  
                //  var stringToken = new JwtSecurityTokenHandler().WriteToken(Token);

                #endregion

                return Ok(new UserDto(
                       user.UserName!
                      , user.Email!,
                       token: await _service.CreateTokenAsync(user,_userManager)
                    ));
            }
         }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            var user = new ApplcationUser()
            {

                DisplayName = model.DisplayName,    
                UserName = model.Email.Split("@")[0],
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,    

            };

           var createdUser =  await _userManager.CreateAsync(user,model.Password);

            if (!createdUser.Succeeded)
                return BadRequest(new ApiResponce(400));
            else 
                return Ok(new UserDto(
                    user.DisplayName,
                    user.Email,
                    await _service.CreateTokenAsync(user,_userManager)));
            


        }


       
    }
}
