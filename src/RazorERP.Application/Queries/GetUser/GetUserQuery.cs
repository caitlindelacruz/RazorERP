using MediatR;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public int Id { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
        {
            private readonly IUserRepository _userRepository;

            public GetUserQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<GetUserResponse?> Handle(GetUserQuery query, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(query.Id);
                if (user == null) return null;

                return new GetUserResponse()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Role = user.Role,
                    Id = user.Id
                };
            }
        }
    }
}

