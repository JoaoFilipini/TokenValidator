using System.Threading.Tasks;
using TokenValidator.Models;

namespace TokenValidator.Repository
{
    public interface ITokenValidatorRepository
    {
        Task<TokenOutput> ValidateToken(TokenInput tokenIput);
    }
}
