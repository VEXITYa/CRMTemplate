using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int CarId { get; set; }

    public DateTime DateOfOrder { get; set; }

    public DateTime WorkStart { get; set; }

    public DateTime? WorkEnd { get; set; }

    public int Cost { get; set; }

    public virtual Car Car { get; set; }

    public virtual CarsOrder CarsOrder { get; set; }

    public virtual Client Client { get; set; }

    public virtual ClientsOrder ClientsOrder { get; set; }

    public virtual ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual ICollection<OrdersPart> OrdersParts { get; set; } = new List<OrdersPart>();

    public virtual ICollection<OrdersService> OrdersServices { get; set; } = new List<OrdersService>();

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
