using System;
using System.Collections.Generic;

namespace VolunteerCenter;

public partial class Place
{
    public int Id { get; set; }

    public string PlaceName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
