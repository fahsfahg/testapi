using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbHandheld
{
    public string Code { get; set; } = null!;

    public string StatusName { get; set; } = null!;

    public bool Isactive { get; set; }
}
