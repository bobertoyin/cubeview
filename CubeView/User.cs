using Microsoft.AspNetCore.Identity;
public class CubeReviewer : IdentityUser
{
    public override string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    private DateTime joined;
    public DateTime Joined { get{return joined;} 
    private set{joined = DateTime.UtcNow;} }
}

public class ReviewerView
    {
    public string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public DateTime Joined { get; set; }
    }