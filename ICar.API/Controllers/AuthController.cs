using ICar.API.Auth.Contracts;
using ICar.API.ViewModels;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces;
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
        private readonly IUserRepository _userRepository;

        public AuthController
            (IAuthService authService,
            ICompanyRepository companyQueries,
            IUserRepository userQueries)
        {
            _authService = authService;
            _companyRepository = companyQueries;
            _userRepository = userQueries;
        }

        [HttpPost("authenticate/company")]
        public async Task<IActionResult> AuthenticateCompany([FromBody] LoginViewModel login)
        {
            Company company = await _companyRepository.GetCompanyByEmailAsync(login.Email);

            if (company != null)
            {
                if (company.Password == login.Password)
                {
                    dynamic responseObject = new
                    {
                        Company = company.Name,
                        Cnpj = company.Cnpj,
                        Email = company.Email,
                        Role = company.Role,
                        Cities = company.Cities,
                        Token = _authService.GenerateToken(company),
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
                return NotFound("This company does't exist");
            }
        }

        [HttpPost("authenticate/user")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginViewModel login)
        {
            User user = await _userRepository.GetUserByEmailAsync(login.Email);

            if (user != null)
            {
                if (user.Password == login.Password)
                {
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
