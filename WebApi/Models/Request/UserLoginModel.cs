﻿namespace WebApi.Models.Request;

public class UserLoginModel
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
