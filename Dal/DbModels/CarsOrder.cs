using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CarsOrder
{
    public int CarsId { get; set; }

    public int OrdersId { get; set; }

    public virtual Car Cars { get; set; }

    public virtual Order Orders { get; set; }
}
