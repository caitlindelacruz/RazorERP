using RazorERP.Application.Common.DTOs;

namespace RazorERP.Application.Queries.ListAllUsers
{
    public class ListAllUsersResponse
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
