using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbReason
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ReasonType { get; set; }

    public bool Isactive { get; set; }
}
