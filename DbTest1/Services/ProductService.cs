using DbTest1.Entities;
using DbTest1.Repositories;

namespace DbTest1.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;

    private readonly CategoryService _categoryService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }

    public ProductEntity CreateProduct(string title, decimal price, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);

        var productEntity = new ProductEntity
        {
            Title = title,
            Price = price,
            CategoryId = categoryEntity.Id,
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }

    public ProductEntity GetProductByProductId(int id)
    {
        var ProductEntity = _productRepository.Get(x => x.Id == id);
        return ProductEntity;
    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        return _productRepository.GetAll();
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
        return updatedProductEntity;
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
