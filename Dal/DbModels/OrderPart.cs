using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrderPart
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int PartId { get; set; }

    public int Count { get; set; }

    public virtual Order Order { get; set; }

    public virtual Part Part { get; set; }
}
