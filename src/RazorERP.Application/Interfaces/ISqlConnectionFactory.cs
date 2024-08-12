using Microsoft.Data.SqlClient;

namespace RazorERP.Application.Interfaces
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
