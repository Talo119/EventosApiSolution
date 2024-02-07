using System;
using System.Collections.Generic;

namespace Events.Domain.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Eventdate { get; set; }

    public string? User { get; set; }
}
