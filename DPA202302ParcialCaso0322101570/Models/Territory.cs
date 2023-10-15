using System;
using System.Collections.Generic;

namespace DPA202302ParcialCaso0322101570.Models;

public partial class Territory
{
    public static string Codigo { get; internal set; }
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Area { get; set; } = null!;

    public int Population { get; set; }
}
