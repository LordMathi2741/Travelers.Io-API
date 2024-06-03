namespace Infrastructure.subscription.Model;

public partial class Plan
{
    public int Id { get; }
    public string Name { get; set; }
    public int MaxUsers { get; set; }
    public int IsDefalut { get; set; }
}

public partial class Plan
{
    public Plan()
    {
        Name = string.Empty;
        MaxUsers = 0;
        IsDefalut = 0;
    }
}