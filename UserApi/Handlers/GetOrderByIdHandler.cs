using MediatR;
using UserApi.Models;
using UserApi.UserData;
using UserApi.Queries;

namespace UserApi.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserData _userData;
        public GetOrderByIdHandler(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userData.GetUserAsync(request.UserId);
        }
    }
}
