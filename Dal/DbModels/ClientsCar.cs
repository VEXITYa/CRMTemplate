using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class ClientsCar
{
    public int ClientsId { get; set; }

    public int CarsId { get; set; }

    public virtual Car Cars { get; set; }

    public virtual Client Clients { get; set; }
}
