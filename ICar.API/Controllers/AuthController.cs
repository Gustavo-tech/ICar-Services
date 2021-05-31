using ICar.API.Auth.Contracts;
using ICar.API.ViewModels;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.Repositories.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoginRepository<CompanyLogin> _companyLoginRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository<UserLogin> _userLoginRepository;

        public AuthController(
            IAuthService authService,
            ICompanyRepository companyQueries,
            ILoginRepository<CompanyLogin> companyLoginRepo,
            IUserRepository userQueries,
            ILoginRepository<UserLogin> userLoginRepo
            )
        {
            _authService = authService;
            _companyRepository = companyQueries;
            _companyLoginRepository = companyLoginRepo;
            _userRepository = userQueries;
            _userLoginRepository = userLoginRepo;
        }

        //[HttpPost("authenticate/company")]
        //public async Task<IActionResult> AuthenticateCompany([FromBody] LoginViewModel login)
        //{
        //    Company company = await _companyRepository.GetCompanyByEmailAsync(login.Email);

        //    if (company != null)
        //    {
        //        if (company.Password == login.Password)
        //        {
        //            //await _companyLoginRepository.AddLogin(new CompanyLogin(company, DateTime.Now));
        //            dynamic responseObject = new
        //            {
        //                Company = company.Name,
        //                Cnpj = company.Cnpj,
        //                Email = company.Email,
        //                Role = company.Role,
        //                Cities = company.Cities,
        //                Token = _authService.GenerateToken(company),
        //            };

        //            return Ok(responseObject);
        //        }
        //        else
        //        {
        //            return Unauthorized("Identification is wrong");
        //        }
        //    }
        //    else
        //    {
        //        return NotFound("This company does't exist");
        //    }
        //}

        [HttpPost("authenticate/user")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginViewModel login)
        {
            User user = await _userRepository.GetUserByEmailAsync(login.Email);

            if (user != null)
            {
                if (user.Password == login.Password)
                {
                    await _userLoginRepository.AddLogin(new UserLogin(user));
                    dynamic responseObject = new
                    {
                        User = user.Name,
                        Cpf = user.Cpf,
                        Email = user.Email,
                        Role = user.Role,
                        Token = _authService.GenerateToken(user),
                    };

                    return Ok(responseObject);
                }
                else
                {
                    return Unauthorized("Identification is wrong");
                }
            }
            else
            {
                return NotFound("This user does't exist");
            }
        }
    }
}
