using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public int Discount { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<ClientsCar> ClientsCars { get; set; } = new List<ClientsCar>();

    public virtual ICollection<ClientsOrder> ClientsOrders { get; set; } = new List<ClientsOrder>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
