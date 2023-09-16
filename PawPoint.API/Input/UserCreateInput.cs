﻿using System.ComponentModel.DataAnnotations;

namespace PawPoint.API.Input;

public class UserCreateInput
{
    public string Roles { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    
}