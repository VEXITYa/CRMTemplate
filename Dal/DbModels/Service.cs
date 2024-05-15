using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int? OrderId { get; set; }

    public virtual ICollection<Competence> Competences { get; set; } = new List<Competence>();

    public virtual Order Order { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual OrdersService OrdersService { get; set; }

    public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
}
