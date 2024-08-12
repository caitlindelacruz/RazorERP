using MediatR;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Queries.ListNonAdminUsers
{
    public class ListNonAdminUsersQuery : IRequest<ListNonAdminUsersResponse>
    {

        public class ListNonAdminUsersQueryHandler : IRequestHandler<ListNonAdminUsersQuery, ListNonAdminUsersResponse>
        {
            private readonly IUserRepository _userRepository;

            public ListNonAdminUsersQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<ListNonAdminUsersResponse?> Handle(ListNonAdminUsersQuery query, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetNonAdminUsersAsync();
                if (users == null) return null;

                var response = new ListNonAdminUsersResponse();
                foreach (var user in users)
                {
                    response.Users.Add(new Common.DTOs.UserDto
                    {
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



