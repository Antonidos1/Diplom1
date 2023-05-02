using System;
using System.Collections.Generic;

namespace Diplom1;

public partial class Organization
{
    public int OrgId { get; set; }

    public int? OrgCode { get; set; }

    public string? OrgName { get; set; }

    public string? City { get; set; }

    public int? TrainingStatus { get; set; }

    public int? DistantCode { get; set; }
}
