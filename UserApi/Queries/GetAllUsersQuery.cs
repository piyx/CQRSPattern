using MediatR;
using UserApi.Models;

namespace UserApi.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
