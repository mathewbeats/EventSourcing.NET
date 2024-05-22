using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Events;

public abstract class Event
{

    public abstract Guid StreamId { get;}

    public DateTime CreatedAtUtc { get; set; }


}
