using MediatR;
using UserApi.Models;

namespace UserApi.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}