using MediatR;
using UserApi.Models;
using UserApi.Resources;

namespace UserApi.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CreateUserCommand(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
