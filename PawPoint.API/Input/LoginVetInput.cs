﻿using System.ComponentModel.DataAnnotations;

namespace PawPoint.API.Input;

public class LoginVetInput
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}