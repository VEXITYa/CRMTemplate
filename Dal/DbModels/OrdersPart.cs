using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrdersPart
{
    public int OrdersId { get; set; }

    public int PartsId { get; set; }

    public virtual Order Orders { get; set; }

    public virtual Part Parts { get; set; }
}
