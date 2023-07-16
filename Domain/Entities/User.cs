using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Password { get; set; } = "";
    public ICollection<Commentary>? Commentaries { get; set; }
}

