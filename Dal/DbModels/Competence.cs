using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Competence
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Service Service { get; set; }
}
