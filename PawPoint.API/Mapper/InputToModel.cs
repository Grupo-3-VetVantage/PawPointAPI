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
        CreateMap<SignupUserInput,User>();
        CreateMap<SignupVetInput, Veterinary>();
        CreateMap<LoginInput,User>();
        CreateMap<LoginVetInput,Veterinary>();
        CreateMap<PetCreateInput,Pet>();
        CreateMap<VeterinaryCreateInput,Veterinary>();
        CreateMap<VeterinaryUpdateInput, Veterinary>();
        CreateMap<ReviewCreateInput,Review>();
        CreateMap<MeetingCreateInput,Meeting>();
        CreateMap<ProductCreateInput,Product>();
        CreateMap<ServiceCreateInput,Service>();
        
    }
    
}