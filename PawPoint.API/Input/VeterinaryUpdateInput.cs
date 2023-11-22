namespace PawPoint.API.Input;

public class VeterinaryUpdateInput
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Speciality { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<MeetingCreateInput>? Meetings { get; set; } = new List<MeetingCreateInput>();
    public ICollection<ServiceCreateInput>? Services { get; set; } = new List<ServiceCreateInput>();
    public ICollection<ReviewCreateInput>? Reviews { get; set; } = new List<ReviewCreateInput>();
    public ICollection<ProductCreateInput>? Products { get; set; } = new List<ProductCreateInput>();
    
}