using System.ComponentModel.DataAnnotations;

namespace Application.Subscription.Request;

public class PlanRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxUsers { get; set; }
    [Required]
    public int IsDefalut { get; set; }
}