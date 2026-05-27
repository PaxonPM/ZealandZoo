using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class GuestRepository : BaseUserRepository, IGuestRepository
    {
        protected override int RoleId => 3;

        public GuestRepository(IDbConnectionHelper connection) : base(connection) { }
        
    }
}