using PawPoint.API.Input;
using PawPoint.Domain;
using PawPoint.Infraestructure.Models;

namespace PawPoint.API.Mapper;
using AutoMapper;


public class InputToModel:Profile
{
    public InputToModel()
    {
        CreateMap<UserCreateInput,User>();
        CreateMap<UserUpdateInput,User>();
        CreateMap<UserSignup,User>();
        CreateMap<LoginInput,User>();
        CreateMap<PetCreateInput,Pet>();
        CreateMap<VeterinaryCreateInput,Veterinary>();
        CreateMap<ReviewCreateInput,Review>();
        CreateMap<MeetingCreateInput,Meeting>();
        CreateMap<ProductCreateInput,Product>();
        CreateMap<ServiceCreateInput,Service>();
        
    }
    
}