using MediatR;
using UserApi.Models;

namespace UserApi.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UpdateUserCommand(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
