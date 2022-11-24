using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenValidator.Models;
using TokenValidator.Repository;

namespace TokenValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenValidatorRepository _tokenValidatorRepository;

        public TokenController(ITokenValidatorRepository tokenValidatorRepository)
        {
            _tokenValidatorRepository = tokenValidatorRepository;
        }

        [HttpGet]
        [Route(template: "token")]
        public async Task<IActionResult> ValidateToken([FromQuery] TokenInput input)
        {
            var result = await _tokenValidatorRepository.ValidateToken(input);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
