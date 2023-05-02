using System;
using System.Collections.Generic;

namespace Diplom1;

public partial class User
{
    public int UserId { get; set; }

    public int? StatusCode { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }
}
