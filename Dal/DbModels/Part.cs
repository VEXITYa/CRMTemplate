using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Part
{
    public int Id { get; set; }

    public string VendorCode { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string CarBrand { get; set; }

    public int Count { get; set; }

    public int Price { get; set; }

    public int? OrderId { get; set; }

    public virtual Order Order { get; set; }

    public virtual ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();

    public virtual OrdersPart OrdersPart { get; set; }

    public virtual ICollection<ServicePart> ServiceParts { get; set; } = new List<ServicePart>();
}
