using MediatR;
using UserApi.Models;
using UserApi.Queries;
using UserApi.UserData;

namespace UserApi.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserData _userData;
        public GetAllUsersHandler(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userData.GetUsersAsync();
        }
    }
}
