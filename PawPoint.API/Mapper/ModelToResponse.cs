using AutoMapper;
using PawPoint.API.Response;
using PawPoint.Infraestructure.Models;

namespace PawPoint.API.Mapper;

public class ModelToResponse:Profile
{
    public ModelToResponse()
    {
        CreateMap<User,UserResponse>();
        CreateMap<Pet,PetResponse>();
        CreateMap<Veterinary,VeterinaryResponse>();
        CreateMap<Review,ReviewResponse>();
        CreateMap<Meeting,MeetingResponse>();
        CreateMap<Product,ProductResponse>();
        CreateMap<Service,ServiceResponse>();
        
    }
    
}