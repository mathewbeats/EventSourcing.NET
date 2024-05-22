Event Sourcing for Student Management
Description
This project implements an Event Sourcing pattern to manage student data. Event Sourcing is a powerful architectural pattern that ensures every state change of a student is stored as a sequence of events. This approach provides a robust audit trail, allows easy reconstruction of past states, and supports a flexible, decoupled design.

Features
Event-Driven Architecture: Capture and store every change as an event, ensuring an immutable and traceable history of changes.
Student Management: Create, update, enroll, and unenroll students with events.
Immutable Events: Once created, events are immutable, providing a reliable source of truth.
Rebuild State: Reconstruct the current state of a student by replaying their events.
In-Memory Storage: Use of in-memory dictionaries for fast access and manipulation of events and current state.
Project Structure
Events: Define various events that represent changes to student data.

Event: Abstract base class for all events.
StudentCreated: Represents the creation of a student.
StudentEnrolled: Represents a student enrolling in a course.
StudentUnEnrolled: Represents a student unenrolling from a course.
StudentUpdated: Represents updates to a student's details.
Domain Model: Represents the current state of a student.

StudentClass: The main class that holds student details and applies events to update its state.
Event Store: Manages the storage and retrieval of events.

StudentDatabase: Handles the storage of events in a sorted manner and provides methods to reconstruct the current state of students.
