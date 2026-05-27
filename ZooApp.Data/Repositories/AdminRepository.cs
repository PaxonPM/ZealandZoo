using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories;

public sealed class AdminRepository : BaseUserRepository, IAdminRepository
{
    protected override int RoleId => 1;

    /// <summary>
    /// Constructor for AdminRepository, initializes the base repository with the provided database connection helper.
    /// </summary>
    /// <param name="connection">The database connection helper used to interact with the database.</param>
    public AdminRepository(IDbConnectionHelper connection) : base(connection) { }

   
    UserModel? IAdminRepository.GetByName(string name) => base.GetByName(name);
}
