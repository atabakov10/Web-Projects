

using FastFood.Services.Models.Categories;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    { 
        Task Add(CreateCategoryDTO categoryDto);

        Task<ICollection<ListCategoryDTO>> GetAll();

        Task<bool> ExistById(int id);

        Task<CategoryDetailsDto> GetDetailsById(int id);
    }
}
