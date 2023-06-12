using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbJobtype
{
    public int Code { get; set; }

    public string Prefix { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Subtype { get; set; }

    public int? LoadingTime { get; set; }

    public int? MaxLoading { get; set; }

    public int? UnloadingTime { get; set; }

    public int? MaxUnloading { get; set; }

    public string? Owner { get; set; }

    public bool Isdefault { get; set; }

    public bool Isactive { get; set; }
}
