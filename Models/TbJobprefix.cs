using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbJobprefix
{
    public int Id { get; set; }

    public string Prefix { get; set; } = null!;

    public string? Description { get; set; }

    public string Format { get; set; } = null!;

    public int FormatType { get; set; }

    public int? DateFormat { get; set; }

    public int Delimiter { get; set; }

    public bool Isdefault { get; set; }

    public bool Isactive { get; set; }

    public string DigitRunning { get; set; } = null!;
}
