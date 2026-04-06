using System;
using System.Collections.Generic;

namespace VolunteerCenter.Models;

public partial class RegistrationStatus
{
    public int Id { get; set; }

    public string RegistrationStatusName { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
