using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbExpense
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Isactive { get; set; }
}
