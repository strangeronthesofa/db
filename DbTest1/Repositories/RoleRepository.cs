using DbTest1.Entities;
using DbTest1.Contexts;

namespace DbTest1.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}