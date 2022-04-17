using MediatR;
using UserApi.Commands;
using UserApi.Models;
using UserApi.UserData;

namespace UserApi.Handlers
{

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserData _userData;
        public DeleteUserHandler(IUserData userData)
        {
            _userData = userData;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userData.GetUserAsync(request.Id);
            if (user is null) return null;
            
            await _userData.DeleteUserAsync(user);
            return user;
        }
    }
}