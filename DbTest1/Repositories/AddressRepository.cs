using DbTest1.Entities;
using DbTest1.Contexts;

namespace DbTest1.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}