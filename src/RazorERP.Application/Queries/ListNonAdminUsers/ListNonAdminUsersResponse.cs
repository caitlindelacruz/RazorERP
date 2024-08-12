using RazorERP.Application.Common.DTOs;

namespace RazorERP.Application.Queries.ListNonAdminUsers
{
    public class ListNonAdminUsersResponse
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
