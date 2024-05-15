using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class ClientsOrder
{
    public int ClientsId { get; set; }

    public int OrdersId { get; set; }

    public virtual Client Clients { get; set; }

    public virtual Order Orders { get; set; }
}
