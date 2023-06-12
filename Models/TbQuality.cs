using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbQuality
{
    public int Id { get; set; }

    public string QaName { get; set; } = null!;

    public bool Isactive { get; set; }
}
