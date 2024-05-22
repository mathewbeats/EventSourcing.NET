using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Events;

public class StudentUpdated : Event
{

    public required Guid StudentId { get; init; }

    public required string FullName { get; set; }

    public required string Email { get; set; }


    public override Guid StreamId => StudentId;
}
