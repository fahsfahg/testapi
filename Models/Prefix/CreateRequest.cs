namespace TestApi.Models.Prefix;

using System.ComponentModel.DataAnnotations;
using TestApi.Models;

public class CreateRequest {
    [Required]
    public string Prefix { get; set; } = null!;

    [Required]
    public string? Description { get; set; }

    [Required]
    public string Format { get; set; } = null!;

    [Required]
    public int FormatType { get; set; }

    [Required]
    public int? DateFormat { get; set; }

    [Required]
    public int Delimiter { get; set; }

    [Required]
    public bool Isdefault { get; set; }

    [Required]
    public bool Isactive { get; set; }

    [Required]
    public string DigitRunning { get; set; } = null!;
}