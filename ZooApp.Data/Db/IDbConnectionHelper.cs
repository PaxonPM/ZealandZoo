using Microsoft.Data.SqlClient;

namespace ZooApp.Data.Db
{
    public interface IDbConnectionHelper
    {
        SqlConnection CreateConnection();
    }
}
