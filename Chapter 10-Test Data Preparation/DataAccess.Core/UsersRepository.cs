using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core
{
    public class UsersRepository : DbRepository<UsersDBContext>
    {
        protected override UsersDBContext CreateDbContextObject()
        {
            return new UsersDBContext(new DbContextOptions<UsersDBContext>());
        }
    }
}