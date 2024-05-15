using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrdersService
{
    public int OrdersId { get; set; }

    public int ServicesId { get; set; }

    public virtual Order Orders { get; set; }

    public virtual Service Services { get; set; }
}
