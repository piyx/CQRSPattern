using MediatR;
using UserApi.Commands;
using UserApi.Models;
using UserApi.UserData;

namespace UserApi.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserData _userData;
        public CreateUserHandler(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            user.Id = await _userData.AddUserAsync(user);
            return user;
        }
    }
}
