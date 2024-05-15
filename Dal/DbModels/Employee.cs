using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }

    public string JobTitle { get; set; }

    public DateTime Experience { get; set; }

    public virtual ICollection<Competence> Competences { get; set; } = new List<Competence>();

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
