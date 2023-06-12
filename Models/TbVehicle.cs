using System;
using System.Collections.Generic;

namespace TestApi.Models;

public partial class TbVehicle
{
    public string Code { get; set; } = null!;

    public string VehicleName { get; set; } = null!;

    public int SpeedLimit { get; set; }

    public int? AvgUsage { get; set; }

    public double? VolunmC { get; set; }

    public double? WeightC { get; set; }

    public double? MaxHeight { get; set; }

    public int? FuelCost { get; set; }

    public int? FixedCost { get; set; }

    public int? TimeCost { get; set; }

    public int? Frequency { get; set; }

    public bool Isactive { get; set; }
}
