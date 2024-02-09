using DbTest1.Entities;
using DbTest1.Contexts;

namespace DbTest1.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
