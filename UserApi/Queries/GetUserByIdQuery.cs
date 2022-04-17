using MediatR;
using UserApi.Models;

namespace UserApi.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }

        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }
    }
}
