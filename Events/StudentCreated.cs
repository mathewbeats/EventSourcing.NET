using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Events;

public class StudentCreated: Event
{
    public required Guid StudentId {get;set;}

    public required string FullName {get; set;}

    public required string Email {get; set;}

    public required DateTime DateOfBirth {get; init;}

    public override Guid StreamId => StudentId;
}
