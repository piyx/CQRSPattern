using MediatR;
using UserApi.Commands;
using UserApi.Models;
using UserApi.UserData;

namespace UserApi.Handlers
{

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserData _userData;
        public UpdateUserHandler(IUserData userData)
        {
            _userData = userData;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userData.GetUserAsync(request.Id);
            if (user is null) return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.LastName;
            
            await _userData.UpdateUserAsync(user);
            return user;
        }
    }
}
