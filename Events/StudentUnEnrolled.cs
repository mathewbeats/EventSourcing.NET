using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Events;

public class StudentUnEnrolled : Event
{
    public required Guid StudentId { get; init; }

    public required string CourseName { get; set; }

    public override Guid StreamId => StudentId;
}

