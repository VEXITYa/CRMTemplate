using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Car
{
    public int Id { get; set; }

    public string Vin { get; set; }

    public int ClientId { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int? Year { get; set; }

    public virtual ICollection<CarsOrder> CarsOrders { get; set; } = new List<CarsOrder>();

    public virtual Client Client { get; set; }

    public virtual ClientsCar ClientsCar { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
