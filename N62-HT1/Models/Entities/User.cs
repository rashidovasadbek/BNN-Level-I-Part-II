﻿namespace N62_HT1.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string EmailAddress {  get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}