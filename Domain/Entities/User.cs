﻿using Microsoft.AspNetCore.Identity;
#nullable disable
namespace Domain.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Commentary>? Commentaries { get; set; }
    public virtual ICollection<Basket>? Baskets { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}

