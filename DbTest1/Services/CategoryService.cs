using DbTest1.Entities;
using DbTest1.Repositories;

namespace DbTest1.Services
{
    internal class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryEntity CreateCategory(string categoryName)
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });
            }

            return categoryEntity;
        }

        public CategoryEntity GetCategoryByCategoryName(string categoryName)
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            return categoryEntity;
        }

        public CategoryEntity GetCategoryByCategoryId(int id)
        {
            var categoryEntity = _categoryRepository.Get(x => x.Id == id);
            return categoryEntity;
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
        {
            var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedCategoryEntity;
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(x => x.Id == id);
        }
    }
}
