﻿using System.Collections.ObjectModel;

namespace  PawPoint.Infraestructure.Models;

public class User :BaseModel
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    public bool IsVet { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
    
    
    public ICollection<Pet>? Pets { get; set; } = new List<Pet>();
    public ICollection<Meeting>? Meetings { get; set; } = new List<Meeting>();
    public ICollection<Review>? Reviews { get; set; } = new List<Review>();


}