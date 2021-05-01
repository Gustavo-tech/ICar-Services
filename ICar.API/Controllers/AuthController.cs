using ICar.API.Auth.Contracts;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ICar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICompanyQueries _cpQueries;
        private readonly IUserQueries _userQueries;

        public AuthController
            (IAuthService authService,
            ICompanyQueries companyQueries,
            IUserQueries userQueries)
        {
            _authService = authService;
            _cpQueries = companyQueries;
            _userQueries = userQueries;
        }

        [HttpPost("authenticate/company")]
        public IActionResult AuthenticateCompany([FromBody] Login login)
        {
            Company company = _cpQueries.GetCompanyByEmail(login.Email);

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
        public IActionResult AuthenticateUser([FromBody] Login login)
        {
            UserInSystem user = _userQueries.GetUserByEmail(login.Email);

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
