using System;
using System.Collections.Generic;

namespace VolunteerCenter.Models;

public partial class VolunteerRegistration
{
    public int Id { get; set; }

    public int IdEvent { get; set; }

    public int IdUser { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public int IdRegistrationStatus { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual RegistrationStatus IdRegistrationStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
