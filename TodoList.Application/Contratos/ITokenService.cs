using System.Threading.Tasks;
using TodoList.Application.Dtos;

namespace TodoList.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}