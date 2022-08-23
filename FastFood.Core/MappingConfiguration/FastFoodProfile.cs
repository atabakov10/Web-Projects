using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using FastFood.Models;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Web.MappingConfiguration
{
    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));
            //Categories
            this.CreateMap<CreateCategoryDTO, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDTO>()
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.CategoryName));
            this.CreateMap<Category, ListCategoryDTO>();
            this.CreateMap<ListCategoryDTO, CategoryAllViewModel>();
            this.CreateMap<Category, CategoryDetailsDto>()
                .ForMember(x => x.Items, y => y.MapFrom(d => d.Items.Select(o => o.Name)));
            this.CreateMap<CategoryDetailsDto, CategoryDetailsViewModel>()
                .ForMember(x => x.Items, y => y
                    .MapFrom(z => z.Items));
            //Item
            this.CreateMap<ListCategoryDTO, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, mo => mo
                    .MapFrom(s => s.Id))
                .ForMember(n => n.CategoryName, y => y
                    .MapFrom(s => s.Name));
            this.CreateMap<CreateItemInputModel, CreateItemDto>();
            this.CreateMap<CreateItemDto, Item>();
            this.CreateMap<Item, ListItemDto>()
                .ForMember(x => x.Category, y => y
                    .MapFrom(s => s.Category.Name));
            this.CreateMap<ListItemDto, ItemsAllViewModels>();
        }
    }
}
