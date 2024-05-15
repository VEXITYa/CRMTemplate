using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrderService
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ServiceId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Order Order { get; set; }

    public virtual Service Service { get; set; }
}
