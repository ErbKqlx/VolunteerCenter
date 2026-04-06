using System;
using System.Collections.Generic;

namespace VolunteerCenter;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public int IdCategory { get; set; }

    public DateOnly Date { get; set; }

    public int IdPlace { get; set; }

    public int RequiredAmount { get; set; }

    public int IdUser { get; set; }

    public int IdEventStatus { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual EventStatus IdEventStatusNavigation { get; set; } = null!;

    public virtual Place IdPlaceNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
