using System.ComponentModel.DataAnnotations;

namespace Clothing;

public class ShirtModel
{
    public int InternalId { get; set; }
    [Required] // important 
    public string? ExternalId { get; set; }
    [Required]
    public int Size { get; set; }
    [Required]
    public string? Model { get; set; }

    public string? Brnd { get; set; }
}
