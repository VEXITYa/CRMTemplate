using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class User
{
    public int Id { get; set; }

    public bool IsBlocked { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int RoleId { get; set; }
}
