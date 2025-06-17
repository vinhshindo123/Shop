using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTOs;
using Shop.Application.Interfaces;
using Shop.Domain.Interfaces;
using Shop.Infrastructure;

namespace Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IReporitory<Category> _repository;
        public CategoryService(IReporitory<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category()
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description
            };
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }
        public async void DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetReporitoryAsync(id);
            if (category != null)
            {
                _repository.DeleteAsync(category);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var categories = await _repository.GetAllReporitoryAsync();
            return categories.Select(c => new CategoryDto()
            {
                CategoryName = c.CategoryName,
                Description = c.Description
            });
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetReporitoryAsync(id);
            return new CategoryDto()
            {
                CategoryName = category?.CategoryName,
                Description = category?.Description
            };
        }

        public async void UpdateCategory(Category category)
        {
            _repository.UpdateAsync(category);
            await _repository.SaveChangesAsync();
        }

        public Task AddCategory(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
