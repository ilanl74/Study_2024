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
    [StringLength(50)]

    public string? Model { get; set; }

    public string? Brand { get; set; }
}
public record struct Rdata(int Id, bool IsA, DateTime Creation, string Message);

public record AData(int Id, string Stam);