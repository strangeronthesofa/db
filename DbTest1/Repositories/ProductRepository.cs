using DbTest1.Entities;
using DbTest1.Contexts;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;

namespace DbTest1.Repositories;

internal class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ProductEntity Get(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products
            .Include(i => i.Category)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products
            .Include(i => i.Category)
            .ToList();
    }
}
