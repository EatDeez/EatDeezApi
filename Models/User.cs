namespace EatDeezApi.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }
}
