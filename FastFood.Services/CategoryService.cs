using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;
        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task Add(CreateCategoryDTO categoryDto)
        {
            Category category = this.mapper.Map<Category>(categoryDto);
           await dbContext.Categories.AddAsync(category);
           await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListCategoryDTO>> GetAll()
        {
            ICollection<ListCategoryDTO> result = await this.dbContext
                .Categories
                .ProjectTo<ListCategoryDTO>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
            
            return result;
        }

        public async Task<bool> ExistById(int id)
        {
            return await this
                .dbContext
                .Categories
                .AnyAsync(c=> c.Id == id);

        }

        public async Task<CategoryDetailsDto> GetDetailsById(int id)
        {
            return await this.dbContext.Categories
                .ProjectTo<CategoryDetailsDto>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}