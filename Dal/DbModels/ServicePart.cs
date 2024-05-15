using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class ServicePart
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public int PartId { get; set; }

    public virtual Part Part { get; set; }

    public virtual Service Service { get; set; }
}
