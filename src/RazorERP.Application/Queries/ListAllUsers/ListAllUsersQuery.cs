using MediatR;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Queries.ListAllUsers
{
    public class ListAllUsersQuery : IRequest<ListAllUsersResponse>
    {

        public class ListAllUsersQueryHandler : IRequestHandler<ListAllUsersQuery, ListAllUsersResponse>
        {
            private readonly IUserRepository _userRepository;

            public ListAllUsersQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<ListAllUsersResponse?> Handle(ListAllUsersQuery query, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetAllUsersAsync();
                if (users == null) return null;

                var response = new ListAllUsersResponse();
                foreach (var user in users)
                {
                    response.Users.Add(new Common.DTOs.UserDto { 
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Role = user.Role
                    });
                }

                return response;
            }
        }
    }
}


