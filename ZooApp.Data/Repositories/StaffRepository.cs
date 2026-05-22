using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class StaffRepository : BaseUserRepository, IStaffRepository
    {
        protected override int RoleId => 2;
        

        public StaffRepository(IDbConnectionHelper connection) : base(connection) { }

    }
}