using AutoMapper;
using backend.Mappers;
using backend.Models;

namespace backend.Profiles
{
    public class ProductsProfile: Profile 
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsReadMapper>();
            CreateMap<ProductsCreateMapper, Products>();
            CreateMap<ProductsUpdateMapper, Products>();
        }    
    }  
} 